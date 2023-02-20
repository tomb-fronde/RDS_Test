/****** Object:  StoredProcedure [rd].[sp_GetContractor]    Script Date: 08/05/2008 10:19:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

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
GO
