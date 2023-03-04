

CREATE procedure [odps].[OD_RPS_Invoice_pay_piecerate_detailpp](
	@invoiceid int,
	@contractno int,
	@contractorno int,
	@payperiod_start datetime,
	@payperiod_end datetime)
as
begin
  -- TJB  RPCR_012  2-July-2010
  -- Add atype (name of piece rate supplier) to fields returned.
  -- Used in Invoices in place of hard-coded names.
  --
  -- TJB RD7_0031  12-May-2009
  -- Fix bug where piecerate payments not reported correctly
  --
  -- TJB  SR4684  June/2006    -- New --
  -- Adapted from OD_RPS_Invoice_pay_piecerate_detailxp
  --
  -- TJB  SR4667  June05
  -- Fix bug where these dates weren''t selected when a contractor had two contracts
  -- with different sequence numbers, and the one being searched for wasn''t the max() one.
  -- Dropped use of cursor (see the select below the 'fetch').
  --  declare vc_contract_list dynamic scroll cursor for 
  -- 
  -- SR#4465 PBY 18-01-2003 Subselect will returns multiple rows if there are more than 1 contractors
  -- within the same renewal period.  Added a MIN function to always retrieve the oldest
  -- next contractor''s contract start date
  

  set CONCAT_NULL_YIELDS_NULL off

  declare @v_contract_no int,
          @v_cr_effective_date datetime,
          @v_contractor_start datetime,
          @v_contractor_end datetime
 
  --Find out if there are more than one contractors in the payperiod
  select @v_contract_no=count(contract_no) 
    from odps.payment 
   where contract_no = @contractno and
         payment.POTS = 'N' and
         invoice_date = @payperiod_end

  --If there are more than one contract then the contract has changed hands, go in here
  if @v_contract_no > 1
  begin
      -- open vc_contract_list;
      -- fetch next vc_contract_list into v_contractor_start,v_contractor_end;

      -- 12-May-2009  TJB  Fix bug where piecerate payments not reported correctly
      --     - originally @v_contractor_end not determined 
      --          
      -- select @v_contractor_start = 
      
      select top 1 @v_contractor_start = contractor_renewals.cr_effective_date,
             @v_contractor_end =
                 (select rd.date(MIN(cr.cr_effective_date)-1) 
                    from rd.contractor_renewals as cr 
                   where cr.contract_no = contract.contract_no and
                         cr.contract_seq_number = contract.con_active_sequence and
                         cr.cr_effective_date > contractor_renewals.cr_effective_date) 
        from rd.contract,
             rd.contractor_renewals 
       where contract.contract_no = @contractno and
             contractor_renewals.contractor_supplier_no = @contractorno and
             contractor_renewals.contract_no = contract.contract_no and
             contractor_renewals.contract_seq_number = 
                 (select max(cr2.contract_seq_number) 
                    from rd.contractor_renewals as cr2 
                   where cr2.contract_no = @contractno and
                         cr2.contractor_supplier_no = @contractorno) and
                         (contract.con_date_terminated is null 
                           or contract.con_date_terminated > @payperiod_end 
                           or datediff(day,contract.con_date_terminated,@payperiod_start) < 32 
                           or contract.con_date_terminated between @payperiod_start 
                                                               and @payperiod_end) 
      order by contractor_renewals.cr_effective_date asc
      
      if @@error <> 0 /* <> was < */
      begin
          rollback transaction
          return(-8)
      end
      
      if @v_contractor_end is null
          select @v_contractor_end=rd.date(rd.today()+30)
          
      select tip4.invoice_id,
             tip4.prd_date,
             tip4.prt_code,
             tip4.prd_quantity,
             tip4.rate,
             tip4.cost,
             tip4.atype 
        from t_invoice_piecerates4 as tip4 
       where tip4.invoice_id = @invoiceid and
             tip4.prd_date between @v_contractor_start 
                               and @v_contractor_end 
       order by tip4.prd_date asc,
                tip4.prt_code asc
                
  end
  else
     select tip4.invoice_id,
            tip4.prd_date,
            tip4.prt_code,
            tip4.prd_quantity,
            tip4.rate,
            tip4.cost, 
            tip4.atype 
       from t_invoice_piecerates4 as tip4 
      where tip4.invoice_id = @invoiceid 
      order by tip4.prd_date asc,
               tip4.prt_code asc
end