
CREATE procedure [rd].[sp_schedule_B](
	@inContract int,
	@inSequence int,
    @inEffDate datetime = null)
AS
BEGIN
  -- TJB  RPCR_057  Jan-2014
  -- Added @inEffDate - show schedule as of this date
  --  
  -- TJB  Release 7.1.10.3  Sep-2013
  -- Added prs_key to returned values
  --
  -- TJB  Release 7.1.10  Aug-2013
  -- Added @con_renewal_end and changed effective_date condition to
  -- look for range of values - since piece rates are now no longer 
  -- renewal dates.
  set CONCAT_NULL_YIELDS_NULL off

  -- TJB  RPCR_057  Jan-2014
  -- If no effective date is included in the call, use the current date
  if @inEffDate is null
     set @inEffDate = getdate()

  -- TJB  RPCR_057  Jan-2014
  -- Determine the appropriate sequence number for the report's effective date
  select @inSequence = contract_seq_number
    from contract_renewals cr1
   where contract_no = @inContract
     and con_rates_effective_date 
             = (select max(con_rates_effective_date)
                  from contract_renewals cr2
                 where cr2.contract_no = cr1.contract_no
                   and con_rates_effective_date <= @inEffDate)
   and @inEffDate >= con_start_date
   and @inEffDate <= con_expiry_date

  -- TJB  RPCR_057  Jan-2014
  -- The piecerates now depend on the effective date; this is no longer used
--  declare @con_renewal_end datetime
--          
--  select @con_renewal_end = dateadd(day,-1,contract_renewals.con_rates_effective_date)
--    from contract_renewals
--   where contract_renewals.contract_no = @inContract
--     and contract_renewals.contract_seq_number = (@inSequence + 1)
--     
--  if @con_renewal_end is null
--  begin
--    select @con_renewal_end = DATEADD(day,1,getdate())
--    select @con_renewal_end = DATEADD(dd, DATEDIFF(dd, 0, @con_renewal_end), 0)
--  end
     
  select contract_no=contract_renewals.contract_no,
         contract_seq_number=contract_renewals.contract_seq_number,
         con_renewal_payment_value=contract_renewals.con_renewal_payment_value,
         con_title=contract.con_title,
         gst_number=contractor.c_gst_number,
         piece_rate_pr_rate=piece_rate.pr_rate,
         piece_rate_type_prt_description=piece_rate_type.prt_description,
         piece_rate_supplier_prs_description=piece_rate_supplier.prs_description,
         piece_rate_type_prt_code=piece_rate_type.prt_code, 
         piece_rate.pr_effective_date,
         piece_rate_supplier.prs_key
    from contract_renewals,
         contract,
         contractor_renewals,
         contractor,
         piece_rate,
         piece_rate_type,
         piece_rate_supplier 
   where contract_renewals.contract_no = contract.contract_no 
     and contract_renewals.contract_no = contractor_renewals.contract_no 
     and contract_renewals.contract_seq_number = contractor_renewals.contract_seq_number 
     and contract_renewals.con_date_last_assigned = contractor_renewals.cr_effective_date 
     and contractor.contractor_supplier_no = contractor_renewals.contractor_supplier_no 
     and contract_renewals.con_rg_code_at_renewal = piece_rate.rg_code 
     and piece_rate_type.prt_key = piece_rate.prt_key 
     and piece_rate_supplier.prs_key = piece_rate_type.prs_key 
     and contract_renewals.contract_no = @inContract 
     and contract_renewals.contract_seq_number = @inSequence 
     and piece_rate.pr_active_status = 'Y' 
     and piece_rate_type.prt_print_on_schedule = 'Y' 
     -- and contract_renewals.con_rates_effective_date =  piece_rate.pr_effective_date
     and piece_rate.pr_effective_date 
               = (select max(pr2.pr_effective_date) from piece_rate pr2
                   where pr2.prt_key = piece_rate.prt_key
                     and pr2.rg_code = piece_rate.rg_code
                     and pr2.pr_effective_date <= @inEffDate)  -- @con_renewal_end)
   order by piece_rate_type.prs_key
end