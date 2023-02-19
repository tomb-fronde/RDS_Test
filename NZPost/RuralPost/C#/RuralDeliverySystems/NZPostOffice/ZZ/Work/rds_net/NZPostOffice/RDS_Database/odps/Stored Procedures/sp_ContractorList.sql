

--
-- Definition for stored procedure sp_ContractorList : 
--

create procedure [odps].[sp_ContractorList]
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  select c.contractor_supplier_no,
    contractor_name=c.c_surname_company + isnull(c.c_first_names,isnull(c.c_initials,'')) from
    rd.contractor as c
end