/****** Object:  StoredProcedure [rd].[sp_GetRoadTownMap_V2]    Script Date: 08/05/2008 10:21:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for stored procedure sp_GetRoadTownMap_V2 : 
--

--
-- Definition for stored procedure sp_GetRoadTownMap_V2 : 
--

create procedure [rd].[sp_GetRoadTownMap_V2]
-- TJB  Mar 2006   NPAD2
as -- Add road_name and rs_id to returned columns
begin
set CONCAT_NULL_YIELDS_NULL off
  select road.road_id,
    road.rt_id,
    town_road.tc_id,
    road.road_name,
    road.rs_id from
    road,
    town_road where
    town_road.road_id = road.road_id
end
GO
