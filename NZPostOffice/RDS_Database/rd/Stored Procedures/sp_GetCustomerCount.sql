
--
-- Definition for stored procedure sp_GetCustomerCount : 
--

--
-- Definition for stored procedure sp_GetCustomerCount : 
--

create procedure [rd].[sp_GetCustomerCount](@inRegion int,@inOutlet int,@inContractType int,@inRenewalGroup int)
-- TJB  SR4659  July 2005
as -- Added lookup and return of CMB kiwimail count.
begin
set CONCAT_NULL_YIELDS_NULL off
  select region.rgn_name,
    outlet.o_name,
    contract.con_title,
    contract.contract_no,
    resident=rd.f_GetCustomerKiwimailCount(contract.contract_no,'R'),
    business=rd.f_GetCustomerKiwimailCount(contract.contract_no,'B'),
    farmer=rd.f_GetCustomerKiwimailCount(contract.contract_no,'F'),
    unclassified=rd.f_GetCustomerKiwimailCount(contract.contract_no,'X'),
    cmb=rd.f_GetCustomerKiwimailCount(contract.contract_no,'C') from
    contract,
    outlet,
    region where
    region.region_id = outlet.region_id and
    contract.con_base_office = outlet.outlet_id and
    ((region.region_id = @inRegion and @inRegion > 0) or(@inRegion is null)) and
    ((outlet.outlet_id = @inOutlet and @inOutlet > 0) or(@inOutlet is null)) and
    (rg_code = @inRenewalGroup or @inRenewalGroup = -1) and
    contract.contract_no > 0 and
    con_date_terminated is null and
    ((contract.con_base_cont_type = @inContractType and @inContractType > 0) or
    (@inContractType = 0 or @inContractType is null)) order by
    region.rgn_name asc,
    outlet.o_name asc,
    contract.contract_no asc
end