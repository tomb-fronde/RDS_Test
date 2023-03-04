
--
-- Definition for stored procedure sp_GetRoadTownMap : 
--

--
-- Definition for stored procedure sp_GetRoadTownMap : 
--

create procedure [rd].[sp_GetRoadTownMap] AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  select road.road_id,
    road.rt_id,
    town_road.tc_id from
    road,
    town_road where
    (town_road.road_id = road.road_id)
end