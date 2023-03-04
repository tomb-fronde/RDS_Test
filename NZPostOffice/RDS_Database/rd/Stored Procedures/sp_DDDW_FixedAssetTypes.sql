
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