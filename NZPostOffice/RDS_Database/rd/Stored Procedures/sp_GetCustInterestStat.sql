

--
-- Definition for stored procedure sp_GetCustInterestStat : 
--

--
-- Definition for stored procedure sp_GetCustInterestStat : 
--

create procedure [rd].[sp_GetCustInterestStat](@inregion int)
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  select region=region.rgn_name,
    interest=interest.interest_description,
    interestcount=(select count(customer.cust_id) from
      contract,
      customer,
      outlet,
      customer_interest where
      (customer.contract_no = contract.contract_no) and
      (contract.con_base_office = outlet.outlet_id) and
      (outlet.region_id = region.region_id) and
      (customer_interest.cust_id = customer.cust_id) and
      (customer_interest.interest_id = interest.interest_id)) from
    interest,
    region where
    (region.region_id = @inregion or @inregion is null) order by
    region.rgn_name asc,
    interest.interest_description asc
end