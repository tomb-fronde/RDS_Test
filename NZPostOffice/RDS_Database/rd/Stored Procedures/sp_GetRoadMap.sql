
--
-- Definition for stored procedure sp_GetRoadMap : 
--

create procedure [rd].[sp_GetRoadMap]
-- TJB  Sept 2005  NPAD2 address schema changes
as -- Add rs_id and rs_name to returned values
begin
set CONCAT_NULL_YIELDS_NULL off
  select road.road_id,road.rt_id, road.road_name,road_type.rt_name,
    road.rs_id, road_suffix.rs_name 
  from  road left outer join road_type on road.rt_id=road_type.rt_id left outer join road_suffix 
        on road.rs_id=road_suffix.rs_id
  --order by road.road_name asc
end