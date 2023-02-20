/****** Object:  StoredProcedure [rd].[sp_GetRoadSuburbMap_v2]    Script Date: 08/05/2008 10:21:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [rd].[sp_GetRoadSuburbMap_v2]
-- TJB  Sept 2005  NPAD2 address schema changes
as -- Added road_suffix and road_type returned
begin
  select r1.road_id,
    r1.road_name,
    r1.rt_id,
    road_type.rt_name,
    road_suffix.rs_id,
    road_suffix.rs_name,
    suburblocality.sl_id,
    suburblocality.sl_name from
    /*road as r1 join road_type on r1.rt_id=road_type.rt_id,
    road as r2 left outer join road_suffix on r2.rs_id=road_suffix.rs_id,
    road as r3 join road_suburb  on r3.road_id=road_suburb.road_id,
    road_suburb as rs join suburblocality on rs.sl_id=suburblocality.sl_id*/
	road as r1 join road_type on r1.rt_id=road_type.rt_id
		left outer join road_suffix on r1.rs_id=road_suffix.rs_id
		left outer join road_suburb as rs on r1.road_id=rs.road_id
		left outer join suburblocality on rs.sl_id=suburblocality.sl_id
--   where road_type.rt_id = road.rt_id
--     and road_suburb.sl_id = suburblocality.sl_id
--     and road_suburb.road_id = road.road_id
end
GO
