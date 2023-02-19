
create procedure [rd].[sp_SearchForContractor3](@in_ContractorSupplierNo int,@in_ContractNo int,@in_ct_key int,@in_c_surname_company char(40),@in_c_first_names char(40),@in_c_phone_day char(11))
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  select contractor_supplier_no from
    contractor
end