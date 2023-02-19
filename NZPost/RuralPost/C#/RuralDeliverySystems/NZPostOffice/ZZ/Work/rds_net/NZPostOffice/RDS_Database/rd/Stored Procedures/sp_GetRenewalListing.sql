
--
-- Definition for stored procedure sp_GetRenewalListing : 
--

create procedure [rd].[sp_GetRenewalListing](@in_Contract int)
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  select contract_seq_number from
    contract_renewals where
    contract_no = @in_Contract order by contract_seq_number desc
end