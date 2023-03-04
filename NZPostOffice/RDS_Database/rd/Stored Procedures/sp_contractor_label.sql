
--
-- Definition for stored procedure sp_contractor_label : 
--

create procedure [rd].[sp_contractor_label](@region int,@contractor char(40))
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
 select name=ltrim(rtrim(c_first_names))+' '+
ltrim(rtrim(c_surname_company)),contractor.c_address from contractor,region,
contractor_renewals,contract_renewals,contract,
outlet where(contractor.contractor_supplier_no = 
contractor_renewals.contractor_supplier_no) and(contract_renewals.contract_no = 
contractor_renewals.contract_no) and(contract_renewals.contract_seq_number =
 contractor_renewals.contract_seq_number) and(contract.contract_no =
 contract_renewals.contract_no) and(contract.con_active_sequence = 
contract_renewals.contract_seq_number) and(outlet.outlet_id = 
contract.con_base_office) and(region.region_id = outlet.region_id) 
and((region.region_id = @region and @region <> -1) or(@region = -1)) 
and((left(contractor.c_surname_company,len(ltrim(rtrim(@contractor)))) = ltrim(rtrim(@contractor))
 and @contractor is not null) or(@contractor is null)) end