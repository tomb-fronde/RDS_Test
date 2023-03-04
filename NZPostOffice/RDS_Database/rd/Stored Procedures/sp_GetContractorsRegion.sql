
--
-- Definition for stored procedure sp_GetContractorsRegion : 
--

--
-- Definition for stored procedure sp_GetContractorsRegion : 
--

create procedure [rd].[sp_GetContractorsRegion](@in_Contractor int,@in_Region int)
AS
BEGIN
  select out_count=count(*) from
    outlet as o,
    contract as c,
    contractor_renewals as cr where
    cr.contract_no = c.contract_no and
    c.con_base_office = o.outlet_id and
    cr.contractor_supplier_no = @in_Contractor and
    o.region_id = @in_Region
end