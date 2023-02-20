/****** Object:  StoredProcedure [rd].[rds_npad_create_road]    Script Date: 08/05/2008 10:17:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




create procedure [rd].[rds_npad_create_road](
	@in_unique_road_id int = NULL,
	@in_road_name char(50),
	@in_rt_id int,
	@in_rs_id int = NULL,
	@in_tc_id int,
	@in_sl_id int = NULL,
	@in_username char(20)
	)
/******************************************************************
 * Description
 *    This routine creates a new road.
 *
 * System
 *    NPAD2 - NZ Post
 *
 * Author
 *    Tom Britton, Synergy International
 *
 * Created on
 *    November 2005
 *
 * Modification history
 * 13 Feb 2006  TJB  Moved 'rollback' to end if inserts
 * 17 Mar 2006  TJB  Changed to allow multiple calls with different mailtowns
 * 10 Apr 2006  TJB  Add 3rd f_getNextSequence parameter
 * 31 Jan 2008  TJB  Changed char()s to varchar()s in SQL Server version
 *****************************************************************/
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
begin transaction
  declare @status      int,
          @description varchar(100),
          @msg         varchar(80),
          @new_road_id int,
          @now         datetime,
          @new_road    int            -- Flag: 0 = new road; 1 = new road/mailtown
          
      -- Trimmed input strings
  declare @tmp_in_road_name varchar(50)

      -- Need the date and time for the logged actions
  select @now=getdate()
  
      -- Trim the input strings
  select @tmp_in_road_name = ltrim(rtrim(@in_road_name))

      -- Initialize some variables
  select @status=0
  select @new_road=0
  
  /************************************************************
   * Check input parameters
   ***********************************************************/
  -- Check to see that the unique_road_id is valid ...
  if @in_unique_road_id is null or @in_unique_road_id <= 0
    begin
      select @status=108
      select @description='Unique_road_id invalid'
    end
  else
  -- Check the validity of the road name (it must not be NULL)
  if @tmp_in_road_name is null or LEN(@tmp_in_road_name) <= 0
    begin
      select @status=107
      select @description='Street name invalid'
    end
  else
  -- Check the validity of the road type (it may be NULL)
  if @in_rt_id is not null and @in_rt_id <= 0
    begin
      select @status=103
      select @description='Street typeID does not exist or invalid'
    end
  else
  if @in_rt_id is not null and
  not exists(select 1 from road_type 
              where rt_id = @in_rt_id)
    begin
      select @status=103
      select @description='Street typeID does not exist or invalid'
    end
  else
  -- Check the validity of the road suffix (it may be NULL)
  if @in_rs_id is not null and @in_rs_id <= 0
    begin
      select @status=104
      select @description='Street suffixID does not exist or invalid'
    end
  else
  if @in_rs_id is not null and
  not exists(select 1 from road_suffix 
              where rs_id = @in_rs_id)
    begin
      select @status=104
      select @description='Street suffixID does not exist or invalid'
    end
  else
  -- Check the validity of the suburb/locality (it may be NULL)
  if @in_sl_id is not null and @in_sl_id <= 0
    begin
      select @status=105
      select @description='LocalityID does not exist or invalid'
    end
  else
  if @in_sl_id is not null and
  not exists(select 1 from SuburbLocality 
              where sl_id = @in_sl_id)
    begin
      select @status=105
      select @description='LocalityID does not exist or invalid'
    end
  else
  -- Check the validity of the mailtown (it may not be NULL)
  if @in_tc_id is null or @in_tc_id <= 0
    begin
      select @status=106
      select @description='MailtownID does not exist or invalid'
    end
  else
  if @in_tc_id is not null and
  not exists(select 1 from TownCity 
              where tc_id = @in_tc_id)
    begin
      select @status=106
      select @description='MailtownID does not exist or is invalid'
    end
  else
  -- Check to see if the suburb exists in the mailtown (if one is specified)
  if @in_sl_id is not null and
  not exists(select 1 from town_suburb 
              where tc_id = @in_tc_id and
    sl_id = @in_sl_id)
    begin
      select @status=109
      select @description='Locality does not exist in Mailtown'
    end
  else
  -- Check to see if the road already exists
  -- It exists if the road name, type and suffix exists as a road
  -- and that road is in the suburb (if one is specified)
  -- and is already in the mailtown (which must be specified)
  if exists(select 1 from road left outer join road_type 
                                       on road.rt_id = road_type.rt_id 
                               left outer join road_suffix 
                                       on road.rs_id = road_suffix.rs_id,
                          road_suburb left outer join suburbLocality 
                                       on road_suburb.sl_id = suburbLocality.sl_id,
                          town_road left outer join townCity 
                                       on town_road.tc_id = townCity.tc_id 
             where road.road_name = @tmp_in_road_name 
               and road_suburb.road_id = road.road_id 
               and town_road.road_id = road.road_id 
               and ((@in_rt_id is null and road.rt_id is null) 
                    or (@in_rt_id is not null and road.rt_id = @in_rt_id)) 
               and ((@in_rs_id is null and road.rs_id is null) 
                    or (@in_rs_id is not null and road.rs_id = @in_rs_id)) 
               and (@in_sl_id is null or road_suburb.sl_id = @in_sl_id) 
               and town_road.tc_id = @in_tc_id)
    begin
      select @status=102
      select @description='Street exists'
    end
  
  -- Check to see if the road already exists in the mailtown
  if @status = 0
    if exists(select 1 from road 
               where unique_road_id = @in_unique_road_id)
      begin
        select @new_road=1            -- Actually flags that the road isn''t new
        if exists(select 1 from town_road, road 
                   where tc_id = @in_tc_id 
                     and road.road_id = town_road.road_id 
                     and road.unique_road_id = @in_unique_road_id)
          begin
            select @status=101
            select @description='Unique_road_id exists'
          end
      end
  
  /************************************************************
   * If the road is new, create the new road
   ***********************************************************/
  -- Get a road_id for the new road entry
  select @new_road_id=0
  if @status = 0 and @new_road = 0
    begin
      execute @new_road_id=rd.f_getNextSequence 'road',1,0 
      if @new_road_id <= 0
        begin
          select @status=-1
          select @description='SQL Error: invalid road ID'
        end
      
      -- Insert the new road entry
      if @status = 0
        begin
          insert into road
            (road_id, rt_id, rs_id, road_name, unique_road_id,
             last_amended_date, last_amended_user) 
           values
             (@new_road_id, @in_rt_id, @in_rs_id, @tmp_in_road_name, @in_unique_road_id,
              @now, @in_username)
          if @@error <> 0
            begin
              select @status=-1
              select @description='SQL Error '+convert(varchar(6),@@error)
                                  +' creating road table entry'
            end
        end
        
--      select @msg='Added road as road_id = '+cast(@new_road_id as char(8))
      select @msg='Added road as road_id = '+convert(varchar(8),@new_road_id)
      -- If a suburb was specified, add an entry in the road_suburb table
      if @status = 0 and @in_sl_id is not null
        begin
          insert into road_suburb(sl_id,road_id) values(
            @in_sl_id,@new_road_id)
          if @@error <> 0
            begin
              select @status=-1
              select @description='SQL Error '+convert(varchar(6),@@error)
                                  +' adding road_suburb table entry'
            end
        end
      -- Set the new_road flag to say the road now exists
      -- so that a town_road entry can be created.
      select @new_road=1
    end
  -- Add an entry in the town_road table
  if @status = 0 and @new_road = 1
    begin
      if @new_road_id = 0
        begin
          select @new_road_id = road_id from
            road where
            unique_road_id = @in_unique_road_id
          if @@error <> 0
            begin
              select @status=-1
              select @description='SQL Error '+convert(varchar(6),@@error)
                                  +' getting road ID for town_road insert'
            end
        end
      if @status = 0
        begin
          insert into town_road(tc_id,road_id) values(
            @in_tc_id,@new_road_id)
          if @@error <> 0
            begin
              select @status=-1
              select @description='SQL Error '+convert(varchar(6),@@error)
                                  +' adding town_road table entry'
            end
        end
    end
  
  /************************************************************
   * Done.  Return status
   ***********************************************************/
  if @status = 0
    begin
      commit transaction -- Commit the changes
      select @description='Success'+' - '+@msg
    end
  else
    rollback transaction
    
  -- log message
  select @msg=isnull(convert(varchar(8),@in_unique_road_id),'NULL')+','
              +isnull(@tmp_in_road_name,'NULL')+','
              +isnull(convert(varchar(8),@in_rt_id),'NULL')+','
              +isnull(convert(varchar(8),@in_rs_id),'NULL')+','
              +isnull(convert(varchar(8),@in_tc_id),'NULL')+','
              +isnull(convert(varchar(8),@in_sl_id),'NULL')
              
  insert into NPAD_msg_log
    (msg_date, msg_username, msg_type, msg_dpid, msg_status, msg_description) 
  values (@now, ltrim(rtrim(@in_username)), 'create road', null, @status, @msg)
  
  -- Return status
  select status=@status, description=@description 
end
GO
