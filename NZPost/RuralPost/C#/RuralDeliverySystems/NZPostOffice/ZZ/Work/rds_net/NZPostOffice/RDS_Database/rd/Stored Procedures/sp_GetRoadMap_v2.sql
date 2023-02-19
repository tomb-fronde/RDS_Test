
--
-- Definition for stored procedure sp_GetRoadMap_v2 : 
--

create procedure [rd].[sp_GetRoadMap_v2]
-- TJB  Sept 2005  NPAD2 address schema changes
-- Add rs_id and rs_name to returned values
-- TJB  Mar 2006   NPAD2
as -- Add mailtown ID to returned columns
begin
set CONCAT_NULL_YIELDS_NULL off
  select road.road_id,
    road.rt_id,
    road.road_name,
    road_type.rt_name,
    road.rs_id,
    road_suffix.rs_name,
    town_road.tc_id 
  from
    road left outer join road_type on road.rt_id=road_type.rt_id 
    left outer join road_suffix on road.rs_id=road_suffix.rs_id join
    town_road  on road.road_id=town_road.road_id where
    town_road.road_id = road.road_id 
order by  road.road_name asc
end