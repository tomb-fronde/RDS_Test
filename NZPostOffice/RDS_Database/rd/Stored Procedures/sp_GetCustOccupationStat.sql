
--
-- Definition for stored procedure sp_GetCustOccupationStat : 
--

--
-- Definition for stored procedure sp_GetCustOccupationStat : 
--

create procedure [rd].[sp_GetCustOccupationStat](@inregion int)
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  select region=region.rgn_name,
    occupation=occupation.occupation_description,
    occupationcount=(select count(customer.cust_id) from
      contract,
      customer,
      outlet,
      customer_occupation where
      (customer.contract_no = contract.contract_no) and
      (contract.con_base_office = outlet.outlet_id) and
      (outlet.region_id = region.region_id) and
      (customer_occupation.cust_id = customer.cust_id) and
      (customer_occupation.occupation_id = occupation.occupation_id)) from
    occupation,
    region where
    (region.region_id = @inregion or @inregion = 0) order by
    region.rgn_name asc,
    occupation.occupation_description asc
end