
--
-- Definition for stored procedure sp_GetContractAllowance : 
--

--
-- Definition for stored procedure sp_GetContractAllowance : 
--

create procedure [rd].[sp_GetContractAllowance](@in_Contract int)
AS
BEGIN
  select ca.alt_key,
    ca.contract_no,
    ca.ca_effective_date,
    ca.ca_annual_amount,
    ca.ca_notes,
    ca.ca_paid_to_date,
    ca.pct_id from
    contract_allowance as ca join allowance_type as at on ca.alt_key=at.alt_key where
    ca.contract_no = @in_Contract and
    ca.ca_annual_amount is not null and
    ca.ca_annual_amount <> 0 order by
    at.alt_description asc
end