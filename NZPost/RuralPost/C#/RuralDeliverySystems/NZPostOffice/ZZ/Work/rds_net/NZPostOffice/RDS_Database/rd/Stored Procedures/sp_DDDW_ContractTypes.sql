
--
-- Definition for stored procedure sp_DDDW_ContractTypes : 
--

create procedure [rd].[sp_DDDW_ContractTypes]
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  select ct_key,contract_type,ct_rd_ref_mandatory from
    contract_type union
  select 0,'','N' order by
    1 asc
end