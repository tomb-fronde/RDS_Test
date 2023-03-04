
--
-- Definition for stored procedure sp_GetContractorFull : 
--

--
-- Definition for stored procedure sp_GetContractorFull : 
--

create procedure [rd].[sp_GetContractorFull](@in_Contractor int)
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  select contractor_supplier_no,
    c_title,
    c_surname_company,
    c_first_names,
    c_initials,
    c_address,
    c_phone_day,
    c_phone_night,
    c_mobile,
    c_bank_account_no,
    c_ird_no,
    c_gst_number,
    c_tax_rate,
    c_salutation from
    contractor where
    contractor_supplier_no = @in_Contractor
end