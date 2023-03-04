
--
-- Definition for stored procedure sp_DDDW_contract : 
--

create procedure [rd].[sp_DDDW_contract](@outletid int,@rgcode int,@conttype int,@regionid int)
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  select contract.contract_no,
    contract.con_title from contract left outer join renewal_group on contract.rg_code = renewal_group.rg_code
    left outer join types_for_contract on contract.contract_no = types_for_contract.contract_no,
    outlet where contract.con_base_office = outlet.outlet_id and((contract.rg_code = @rgcode and @rgcode is not null and @rgcode <> -1) or(1 = 1 and @rgcode = -1)) and((outlet.outlet_id = @outletid and @outletid is not null and @outletid <> -1) or(1 = 1 and @outletid = -1)) and((outlet.region_id = @regionid and @regionid is not null and @regionid <> -1) or(1 = 1 and @regionid = -1)) and((types_for_contract.ct_key = @conttype and @conttype is not null and @conttype <> -1) or(1 = 1 and @conttype = -1)) order by contract.con_title asc
end