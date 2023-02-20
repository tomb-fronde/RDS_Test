/****** Object:  StoredProcedure [rd].[f_create_road]    Script Date: 08/05/2008 10:16:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create procedure [rd].[f_create_road](@in_roadname char(50),@in_rtid int,@in_rsid int,@in_slname char(50),@in_tcid int,@in_user char(20))
-- TJB  NPAD2  May 2006   - New -
-- Create a new road if necessary, and/or links between the road and 
-- town and suburb.
-- Returns the road_id of the existing or created road.
--
-- Returns
--   >0     Road_id 
--    0     Not OK    (failed to create the road or its linkages)
as --   -4     OK        (suburb doesn''t exist in the mailtown)
begin
set CONCAT_NULL_YIELDS_NULL off
  declare @tempid int
  declare @roadid int
  declare @slid int
  declare @now datetime
  -- First, determine the suburb ID, if a suburb name is specified.
  -- There are possibly multiple suburbs with the same name, but only
  -- one suburb with a given name in a mailtown.  Its an error if 
  -- the specified suburb doesn''t exist in the specified mailtown.
  if @@TRANCOUNT = 0
  begin
	begin tran
  end
  if @in_slname is null or @in_slname = ''
    select @slid=0
  else
    select top 1 @slid = sl.sl_id from
      town_suburb as ts join suburblocality as sl
      on ts.tc_id = sl.sl_id
      where
      ts.tc_id = @in_tcid and
      sl.sl_name = @in_slname order by
      sl.sl_id asc
  if @slid is null
    return-4 -- Suburb doesn''t exist in the town
  -- Let's see if there's already a road with the right name, and 
  -- no unique_road_id (a non-NPAD road). We''ll look for a road 
  -- associated with the mailtown, following the NPAD scheme of
  -- having separate roads for each mailtown even though the old
  -- RDS scheme didn''t.
  select @roadid = road.road_id from
    road join town_road 
    on road.road_id = town_road.road_id
    where
    road_name = rd.trim(@in_roadname) and
    tc_id = @in_tcid and
    isnull(@in_rtid,0) = isnull(rt_id,0) and
    isnull(@in_rsid,0) = isnull(rs_id,0) and
    unique_road_id is null
  if @roadid is null or @roadid <= 0
    begin
      -- If a non-NPAD road wasn''t found, look for an NPAD one.
      select top 1 @roadid = road.road_id from
      road join town_road 
      on road.road_id = town_road.road_id
      where
        road_name = rd.trim(@in_roadname) and
        tc_id = @in_tcid and
        isnull(@in_rtid,0) = isnull(rt_id,0) and
        isnull(@in_rsid,0) = isnull(rs_id,0)
      if @slid > 0
        -- If a suburb was specified, see if there is a road in the 
        -- suburb and town (there could be different roads in different 
        -- suburbs in the town and the road/town lookup above might 
        -- have found the wrong one).
        select top 1 @tempid = road.road_id from
          road join town_road
          on road.road_id = town_road.road_id
			 join road_suburb 
          on road.road_id = road_suburb.road_id
          where
          road.road_name = rd.trim(@in_roadname) and
          tc_id = @in_tcid and
          SL_id = @slid and
          isnull(@in_rtid,0) = isnull(road.rt_id,0) and
          isnull(@in_rsid,0) = isnull(road.rs_id,0)
      if @tempid is not null and @tempid > 0
        select @roadid=@tempid
    end
  -- At this point, if @roadid is null, there isn''t an existing road record 
  -- we can use and we''ll have to create a new one.
  if @roadid is null or @roadid <= 0
    begin
      select @now=getdate()
      execute @roadid=rd.f_getNextSequence 'Road',1,0
      insert into road(road_id,
        road_name,rt_id,rs_id,unique_road_id,
        last_amended_date,last_amended_user) values(
        @roadid,rd.trim(@in_roadname),@in_rtid,@in_rsid,null,
        @now,@in_user)
    end
  -- Now set up the linkages between the road and town and suburb 
  -- if necessary.
  --
  -- If there isn''t a road/town relation, add one.
  if not exists(select 1 from town_road where
      tc_id = @in_tcid and
      road_id = @roadid)
    insert into town_road(tc_id,road_id) values(
      @in_tcid,@roadid)
  -- If there isn''t a road/suburb relation, add one.
  if @slid > 0 and
    not exists(select 1 from road_suburb where
      sl_id = @slid and
      road_id = @roadid)
    insert into road_suburb(sl_id,road_id) values(
      @slid,@roadid)
  commit transaction
  return @roadid
end
GO
