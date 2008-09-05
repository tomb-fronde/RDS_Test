/****** Object:  StoredProcedure [rd].[sp_GetContractorDS]    Script Date: 08/05/2008 10:19:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for stored procedure sp_GetContractorDS : 
--

--
-- Definition for stored procedure sp_GetContractorDS : 
--

create procedure [rd].[sp_GetContractorDS](@in_Contractor int)
AS
BEGIN
  select contractor_supplier_no,
    cd_old_ds_no from
    contractor_ds where
    contractor_supplier_no = @in_Contractor order by
    cd_old_ds_no asc
end
GO
