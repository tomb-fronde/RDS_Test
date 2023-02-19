

--
-- Definition for user-defined function noroadnumPercent : 
--

create function [rd].[noroadnumPercent](@inRegion int,@inOutlet int,@inRenGroup int,@inContractType int)
returns real
-- TJB  Sept 2005  NPAD2 address schema changes
as -- Added adr_unit number to adr_no.
begin

  declare @i_no_num real,
  @i_total real,
  @d_percentage real
  select @i_no_num = count(addr.adr_id) 
    from towncity as tc join address as addr on tc.tc_id = addr.tc_id join "contract" as con on addr.contract_no = con.contract_no where
    (@inRegion = 0 or @inRegion is null or tc.region_id = @inRegion) and
    (@inOutlet = 0 or @inOutlet is null or con.con_lodgement_office = @inOutlet) and
    (@inContractType = 0 or @inContractType is null or con.con_base_cont_type = @inContractType) and
    (@inRenGroup = 0 or @inRenGroup is null or con.rg_code = @inRenGroup) and
    (addr.adr_unit is null and addr.adr_no is null)
  select @i_total = count(addr.adr_id) 
    from towncity as tc join address as addr on tc.tc_id = addr.tc_id join "contract" as con on addr.contract_no = con.contract_no where
    (@inRegion = 0 or @inRegion is null or tc.region_id = @inRegion) and
    (@inOutlet = 0 or @inOutlet is null or con.con_lodgement_office = @inOutlet) and
    (@inContractType = 0 or @inContractType is null or con.con_base_cont_type = @inContractType) and
    (@inRenGroup = 0 or @inRenGroup is null or con.rg_code = @inRenGroup)
  if @i_total <> 0
    begin
      select @d_percentage=(@i_no_num/@i_total)*100
      select @d_percentage=round(@d_percentage,2)
    end
  else
    select @d_percentage=0
  return round(@d_percentage,2)
end