
--
-- Definition for stored procedure sp_GetRegions : 
--

create procedure [rd].[sp_GetRegions]
AS
BEGIN
  select region_id,
    rgn_name from
    region
end