
--
-- Definition for stored procedure sp_GetTypesForContractor : 
--

create procedure [rd].[sp_GetTypesForContractor](@in_Contractor int)
AS
BEGIN
  select contractor_supplier_no,
    types_for_contractor.ct_key from
    types_for_contractor join contract_type on types_for_contractor.ct_key=contract_type.ct_key where
    contractor_supplier_no = @in_contractor order by
    contract_type asc
end