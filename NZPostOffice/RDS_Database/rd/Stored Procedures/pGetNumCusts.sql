
--
-- Definition for stored procedure pGetNumCusts : 
--

create procedure [rd].[pGetNumCusts](@inRegion decimal(12,2),@numCusts decimal(7) output) AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  select @numCusts = count(*) 
    from customer as cust,
    contract as con,
    outlet as "out" where
    cust.contract_no <> 0 and
    cust.contract_no = con.contract_no and
    con.con_lodgement_office = "out".outlet_id and
    ("out".region_id = @inRegion or
    @inRegion = 0)
end