/****** Object:  UserDefinedFunction [rd].[f_validate_road]    Script Date: 08/05/2008 11:24:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create function [rd].[f_validate_road](@in_roadname char(50),@in_rtid int,@in_rsid int,@in_slname char(50),@in_tcid int)
returns int 
-- TJB  NPAD2  May 2006   - New -
-- Validate the address
-- Return
--   >0     road_id of existing road
--   -1     road doesn''t already exist
--   -2     road doesn''t exist in the mailtown
--   -3     road doesn''t exist in the suburb
as --   -4     suburb doesn''t exist in the mailtown
begin

  declare @roadid int,
  @slid int,
  @temp int
  -- First, determine the suburb ID, if a suburb name is specified.
  -- There are possibly multiple suburbs with the same name, but only
  -- one suburb with a given name in a mailtown.  Its an error if 
  -- the specified suburb doesn''t exist in the specified mailtown.
  if @in_slname is null or @in_slname = ''
    select @slid=0
  else
    select @slid = s.sl_id from
      town_suburb as ts join suburblocality as s on ts.sl_id = s.sl_id where
      ts.tc_id = @in_tcid and
      s.sl_name = @in_slname order by
      s.sl_id asc
  if @slid is null
    return-4 -- Suburb doesn''t exist in the town
  -- Check to see if the road exists in the mailtown and suburb
  if @slid = 0
    select @roadid = road.road_id from
      road join town_road as tr on road.road_id = tr.road_id where
      road_name = @in_roadname and
      tr.tc_id = @in_tcid and
      isnull(@in_rtid,0) = isnull(rt_id,0) and
      isnull(@in_rsid,0) = isnull(rs_id,0)
  else
    select @roadid = road.road_id from
      road join town_road as tr on road.road_id = tr.road_id
	 join road_suburb as rs on road.road_id = rs.road_id where
      road.road_name = @in_roadname and
      road.road_name = @in_roadname and
      tr.tc_id = @in_tcid and
      rs.sl_id = @slid and
      isnull(@in_rtid,0) = isnull(road.rt_id,0) and
      isnull(@in_rsid,0) = isnull(road.rs_id,0)
  if @roadid is not null and @roadid > 0
    return @roadid -- The road exists in the town and suburb
  -- Check to see if a road of the specified name/type/suffix exists
  select @roadid = road_id from
    road where
    road_name = @in_roadname and
    isnull(@in_rtid,0) = isnull(rt_id,0) and
    isnull(@in_rsid,0) = isnull(rs_id,0) order by
    road_id asc
  if @roadid is null or @roadid <= 0
    return-1 -- These''s no road by that name
  -- At this point, if a suburb wasn''t specified, we know that
  -- the road exists, but doesn''t exist in the mailtown (otherwise 
  -- the initial lookup of the road_id would have succeeded).
  if @slid = 0
    return-2 -- Road doesn''t exist in the town
  -- If a suburb was specified, it could be either the road/town or 
  -- road/suburb that doesn't exist.  We'll check for the road/suburb.
  if not exists(select 1 from road join road_suburb on road.road_id = road_suburb.road_id where
      road_name = @in_roadname and
      isnull(@in_rtid,0) = isnull(rt_id,0) and
      isnull(@in_rsid,0) = isnull(rs_id,0) and
      road_suburb.sl_id = @slid)
    return-3 -- Road doesn''t exist in the suburb
  else
    return-2 -- Road doesn''t exist in the town
return 0
end
GO
