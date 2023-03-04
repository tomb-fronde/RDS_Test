
--
-- Definition for stored procedure sp_Contract_Payments : 
--

CREATE procedure [rd].[sp_Contract_Payments](
	@inContract int,
	@inRenewal int)
AS
BEGIN
  --
  -- TJB  RPCR_017 July-2010
  -- Add condition on allowance: include only if approved
  --
  select contract_renewals.con_renewal_payment_value
       ,'Renewal Price'
       , 1 
    from contract_renewals 
   where contract_renewals.contract_no = @inContract 
     and contract_renewals.contract_seq_number = @inRenewal 
union
  select sum(contract_allowance.ca_annual_amount) 
       , allowance_type.alt_description
       , 2 
    from contract_allowance join allowance_type 
                   on  contract_allowance.alt_key = allowance_type.alt_key 
   where contract_allowance.contract_no = @inContract
     and contract_allowance.ca_approved = 'Y'   -- TJB RPCR_017 July-2010: added
   group by allowance_type.alt_description 
union
  select sum(contract_adjustments.ca_amount)
       ,'Contract Adjustments'
       , 3 
    from contract_renewals join contract 
                   on  contract_renewals.contract_no = contract.contract_no 
                 join contract_adjustments 
                   on  contract_renewals.contract_no = contract_adjustments.contract_no 
                   and contract_renewals.contract_seq_number = contract_adjustments.contract_seq_number 
   where contract_adjustments.ca_confirmed = 'Y' 
     and contract_renewals.contract_no = @inContract 
     and contract_renewals.contract_seq_number = @inRenewal 
union
  select sum(frequency_adjustments.fd_adjustment_amount)
       ,'Extensions'
       , 4 
    from contract_renewals join contract 
                   on  contract_renewals.contract_no = contract.contract_no 
                 join frequency_adjustments 
                   on  contract_renewals.contract_no = frequency_adjustments.contract_no 
                   and contract_renewals.contract_seq_number = frequency_adjustments.contract_seq_number 
   where frequency_adjustments.fd_confirmed = 'Y' 
     and contract_renewals.contract_no = @inContract 
     and contract_renewals.contract_seq_number = @inRenewal
     
end