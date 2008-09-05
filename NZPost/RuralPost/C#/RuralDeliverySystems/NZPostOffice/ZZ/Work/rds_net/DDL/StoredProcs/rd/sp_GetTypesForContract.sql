/****** Object:  StoredProcedure [rd].[sp_GetTypesForContract]    Script Date: 08/05/2008 10:21:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for stored procedure sp_GetTypesForContract : 
--

create procedure [rd].[sp_GetTypesForContract](@in_Contract int)
AS
BEGIN
  select tfc.ct_key,
    tfc.contract_no from
    types_for_contract as tfc join contract_type as ct on tfc.ct_key=ct.ct_key where
    tfc.contract_no = @in_Contract order by
    ct.contract_type asc
end
GO
