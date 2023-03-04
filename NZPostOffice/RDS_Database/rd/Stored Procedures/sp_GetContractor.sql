
--
-- Definition for stored procedure sp_GetContractor : 
--

--
-- Definition for stored procedure sp_GetContractor : 
--

create procedure [rd].[sp_GetContractor](@in_Contractor int)
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
    c_mobile from
    contractor where
    contractor_supplier_no = @in_Contractor
end