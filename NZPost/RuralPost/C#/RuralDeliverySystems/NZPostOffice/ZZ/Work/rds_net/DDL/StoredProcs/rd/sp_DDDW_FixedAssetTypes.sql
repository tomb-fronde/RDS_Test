/****** Object:  StoredProcedure [rd].[sp_DDDW_FixedAssetTypes]    Script Date: 08/05/2008 10:18:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for stored procedure sp_DDDW_FixedAssetTypes : 
--

create procedure [rd].[sp_DDDW_FixedAssetTypes]
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  select fat_id,
    fat_description from
    fixed_asset_type
end
GO
