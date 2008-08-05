/****** Object:  StoredProcedure [odps].[od_dws_ContractorList]    Script Date: 08/05/2008 10:13:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for stored procedure od_dws_ContractorList : 
--

create procedure [odps].[od_dws_ContractorList]
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  select c.contractor_supplier_no,
    contractor_name=c.c_surname_company + case when isnull(c.c_first_names,'') = '' then case when isnull(c.c_initials,'') = '' then '' else ', ' + c.c_initials end
			else ', ' + c.c_first_names end  from
    rd.contractor as c
end
GO
