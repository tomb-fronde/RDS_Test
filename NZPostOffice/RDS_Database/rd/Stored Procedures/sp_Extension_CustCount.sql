
--
-- Definition for stored procedure sp_Extension_CustCount : 
--

create procedure [rd].[sp_Extension_CustCount](@inContract int,@inRegion int,@inType char(1))
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  if @intype = '1'
    select cnt=count(*) from
      contract as c,
      outlet as o where
      c.contract_no = @inContract and
      o.outlet_id = c.con_lodgement_office and
      o.region_id = @inregion
  else
    select count(*) from
      contract as c where
      c.contract_no = @inContract
end