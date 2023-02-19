

--
-- Definition for stored procedure sp_DDDW_rb_contract : 
--

create procedure [rd].[sp_DDDW_rb_contract](@regionid int,@outletid int,@rgcode int,@conttype int,@sfkey int)
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
 select contract.contract_no,contract.con_title 
from contract left outer join renewal_group on contract.rg_code = renewal_group.rg_code
left outer join types_for_contract on contract.contract_no = types_for_contract.contract_no
left outer join route_frequency on contract.contract_no = route_frequency.contract_no,outlet 
where contract.con_base_office = outlet.outlet_id 
and((contract.rg_code = @rgcode and @rgcode is not null and @rgcode <> -1) 
or(1 = 1 and @rgcode = -1)) and((outlet.outlet_id = @outletid 
and @outletid is not null and @outletid <> -1) or(1 = 1 and @outletid = -1)) 
and((outlet.region_id = @regionid and @regionid is not null and @regionid <> -1) 
or(1 = 1 and @regionid = -1)) and((types_for_contract.ct_key = @conttype 
and @conttype is not null and @conttype <> -1) or(1 = 1 and @conttype = -1)) 
and((route_frequency.sf_key = @sfkey and @sfkey is not null and @sfkey <> -1)
 or(@sfkey = -1)) union select-1,'<All>'  order by 2 asc end