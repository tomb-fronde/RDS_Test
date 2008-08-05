/****** Object:  StoredProcedure [rd].[sp_DDDW_ContractTypes]    Script Date: 08/05/2008 10:18:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

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
GO
