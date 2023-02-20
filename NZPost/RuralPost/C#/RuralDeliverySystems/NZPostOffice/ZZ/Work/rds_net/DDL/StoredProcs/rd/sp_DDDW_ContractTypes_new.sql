/****** Object:  StoredProcedure [rd].[sp_DDDW_ContractTypes_new]    Script Date: 08/05/2008 10:18:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--
-- Definition for stored procedure sp_DDDW_ContractTypes_new : 
--

create procedure [rd].[sp_DDDW_ContractTypes_new]
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off 
select ct_key,contract_type from contract_type union select-1,'<All>' order by 2 asc end













GO
