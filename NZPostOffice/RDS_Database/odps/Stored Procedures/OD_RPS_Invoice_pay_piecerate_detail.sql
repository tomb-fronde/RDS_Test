
CREATE procedure [odps].[OD_RPS_Invoice_pay_piecerate_detail](@invoiceid int)
AS
  -- Select piecerate detail for export

  -- TJB  RPCR_058b Dec-2013
  -- Added code to determine contractor start/end dates
  -- and apply to detail selection.  Fixes bug where a
  -- contract changes hands during a pay period.
  --
  -- TJB  RPCR_054  July-2013: NEW
  -- Add prs_key to selection
  -- Derived from OD_RPS_Invoice_pay_piecerate_detail{km,cp,pp,xp}
  -- Simplify and reformat
BEGIN
  set CONCAT_NULL_YIELDS_NULL off
  
  declare @contract_no int,
          @contract_seq int,
          @contractor_no int,
          @cr_effective_date datetime,
          @contractor_start datetime,
          @contractor_end datetime

  select @contract_no = contract_no
       , @contract_seq = contract_seq_number
       , @contractor_no = contractor_supplier_no
    from odps.payment
   where invoice_id = @invoiceid

  select top 1 
         @contractor_start = contractor_renewals.cr_effective_date,
         @contractor_end   =
                (select rd.date(MIN(cr.cr_effective_date)-1) 
                   from rd.contractor_renewals as cr 
                  where cr.contract_no = @contract_no 
                    and cr.contract_seq_number = @contract_seq
                    and cr.cr_effective_date > contractor_renewals.cr_effective_date)
    from rd.contractor_renewals 
   where contractor_renewals.contract_no = @contract_no 
     and contractor_renewals.contractor_supplier_no = @contractor_no 
     and contractor_renewals.contract_seq_number = @contract_seq
  order by contractor_renewals.cr_effective_date asc

  select invoice_id,
         prd_date,
         prt_code,
         prd_quantity,
         rate,
         cost,
         atype,
         prs_key
    from t_invoice_piecerates
   where invoice_id = @invoiceid
     and ((@contractor_end is null and prd_date >= @contractor_start)
         or prd_date between @contractor_start and @contractor_end)
   order by prs_key
          , prd_date
          , prt_code
end