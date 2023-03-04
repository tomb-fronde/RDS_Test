
--
-- Definition for user-defined function RDGeoPercent : 
--

create function [rd].[RDGeoPercent](@inRegion int,@inOutlet int,@inRenGroup int,@inContractType int)
returns float
AS
BEGIN

  declare @i_geocoded float,
  @i_total float,
  @d_percentage float
  -- get the geocoded count
  select @i_geocoded = count(addr.adr_id) 
    from towncity as tc join address as addr on tc.tc_id = addr.tc_id join address_geocode as ag on addr.adr_id = ag.adr_id,contract as con where
    addr.contract_no = con.contract_no and
    (@inRegion = 0 or @inRegion is null or tc.region_id = @inRegion) and
    (@inOutlet = 0 or @inOutlet is null or con.con_lodgement_office = @inOutlet) and
    (@inRenGroup = 0 or @inRenGroup is null or con.rg_code = @inRenGroup) and
    (@inContractType = 0 or @inContractType is null or con.con_base_cont_type = @inContractType)
  -- get the not geocoded count
  select @i_total = count(addr.adr_id) 
    from towncity as tc join address as addr on tc.tc_id = addr.tc_id join contract as con on addr.contract_no = con.contract_no where
    addr.contract_no = con.contract_no and
    (@inRegion = 0 or @inRegion is null or tc.region_id = @inRegion) and
    (@inOutlet = 0 or @inOutlet is null or con.con_lodgement_office = @inOutlet) and
    (@inRenGroup = 0 or @inRenGroup is null or con.rg_code = @inRenGroup) and
    (@inContractType = 0 or @inContractType is null or con.con_base_cont_type = @inContractType)
  if @i_total <> 0
    begin
      select @d_percentage=(@i_geocoded/@i_total)*100
      select @d_percentage=round(@d_percentage,0)
    end
  else
    select @d_percentage=0
  return round(@d_percentage,2)
end