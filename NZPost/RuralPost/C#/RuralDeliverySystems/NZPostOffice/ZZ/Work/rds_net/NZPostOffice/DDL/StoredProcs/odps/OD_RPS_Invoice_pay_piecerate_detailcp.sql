/****** Object:  StoredProcedure [odps].[OD_RPS_Invoice_pay_piecerate_detailcp]    Script Date: 08/05/2008 10:14:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for stored procedure OD_RPS_Invoice_pay_piecerate_detailcp : 
--

create procedure [odps].[OD_RPS_Invoice_pay_piecerate_detailcp](@invoiceid int,@contractno int,@contractorno int,@payperiod_start datetime,@payperiod_end datetime)
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  declare @v_contract_no int,
  @v_cr_effective_date datetime,
  @v_contractor_start datetime,
  @v_contractor_end datetime
  --Cursor retrieves contractor start and end dates
  -- SR#4465 PBY 18-01-2003 Subselect will returns multiple rows if there are more than 1 contractors
  -- within the same renewal period.  Added a MIN function to always retrieve the oldest
  -- next contractor''s contract start date
  --
  -- TJB  SR4667  June05
  -- Fix bug where these dates weren''t selected when a contractor had two contracts
  -- with different sequence numbers, and the one being searched for wasn''t the max() one.
  -- Dropped use of cursor (see the select below the 'fetch').
  --
  --Find out if there are more than one contractors in the payperiod
  select @v_contract_no = count(contract_no)
    from odps.payment where
    contract_no = @contractno and
    payment.POTS = 'N' and
    invoice_date = @payperiod_end
  --If there are more than one contract then the contract has changed hands, go in here
  if @v_contract_no > 1
    begin
      -- open vc_contract_list;
      -- fetch next vc_contract_list into v_contractor_start,v_contractor_end;
      select @v_contractor_start= 
        (select rd.date(MIN(cr.cr_effective_date)-1) from
          rd.contractor_renewals as cr where
          cr.contract_no = contract.contract_no and
          cr.contract_seq_number = contract.con_active_sequence and
          cr.cr_effective_date > contractor_renewals.cr_effective_date)
        from rd.contract,
        rd.contractor_renewals where
        contract.contract_no = @contractno and
        contractor_renewals.contract_no = contract.contract_no and
        contractor_renewals.contractor_supplier_no = @contractorno and
        contractor_renewals.contract_seq_number = 
        (select max(cr2.contract_seq_number) from
          rd.contractor_renewals as cr2 where
          cr2.contract_no = @contractno and
          cr2.contractor_supplier_no = @contractorno) and
        (contract.con_date_terminated is null or
        contract.con_date_terminated > @payperiod_end or
        (contract.con_date_terminated - @payperiod_start) < 32 or
        contract.con_date_terminated between @payperiod_start and @payperiod_end) order by
        contractor_renewals.cr_effective_date asc
      if @@error <> 0 /* <> was < */
        begin
          rollback transaction
          return(-8)
        end
      if @v_contractor_end is null
        select @v_contractor_end=rd.date(rd.today()+30)
      select t_invoice_piecerates2.invoice_id,
        t_invoice_piecerates2.prd_date,
        t_invoice_piecerates2.prt_code,
        t_invoice_piecerates2.prd_quantity,
        t_invoice_piecerates2.rate,
        t_invoice_piecerates2.cost from
        t_invoice_piecerates2 where
        t_invoice_piecerates2.invoice_id = @invoiceid and
        t_invoice_piecerates2.prd_date between @v_contractor_start and @v_contractor_end order by
        t_invoice_piecerates2.prd_date asc,
        t_invoice_piecerates2.prt_code asc
    end
  else
    select t_invoice_piecerates2.invoice_id,
      t_invoice_piecerates2.prd_date,
      t_invoice_piecerates2.prt_code,
      t_invoice_piecerates2.prd_quantity,
      t_invoice_piecerates2.rate,
      t_invoice_piecerates2.cost from
      t_invoice_piecerates2 where
      t_invoice_piecerates2.invoice_id = @invoiceid order by
      t_invoice_piecerates2.prd_date asc,
      t_invoice_piecerates2.prt_code asc
end
GO
