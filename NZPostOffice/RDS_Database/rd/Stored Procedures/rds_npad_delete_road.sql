
--
-- Definition for stored procedure rds_npad_delete_road : 
--

create procedure [rd].[rds_npad_delete_road](
	@in_unique_road_id int = NULL,
	@in_username char(20)
	)
/******************************************************************
 * Description
 *    This routine deletes an existing road.
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
 * 31 Jan 2008  TJB  Changed char()s to varchar()s in SQL Server version
 *****************************************************************/
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  declare @status      int,
          @description varchar(100),
          @msg         varchar(80),
          @roadID      int,              -- RDS road_id of the road 
          @now         datetime
          
  -- Need the date and time for the logged actions
  select @now=getdate()
  select @status=0

  begin transaction
  
  /************************************************************
   * Check input parameters
   ***********************************************************/
  -- Check to see that the unique_road_id is valid ...
  if @in_unique_road_id is null or @in_unique_road_id <= 0
    begin
      select @status=101
      select @description='Unique_road_id does not exist or invalid'
    end

  -- ... and already exists
  -- Get the road_id for the road
  if @status = 0
    begin
      select @roadID=null
      select @roadID = road_id from road 
       where unique_road_id = @in_unique_road_id
      if @@error <> 0 and @@rowcount <> 0 /* was @@error <>100 */
        begin
          select @status=-1
          select @description='SQL Error '+convert(varchar(6),@@error)
                              +' getting RDS road_id'
        end
      else
        if @roadID is null
          begin
            select @status=101
            select @description='Unique_road_id does not exist or invalid'
          end
    end

  -- Check to see if there are any addresses on the road
  if @status = 0 and exists(select 1 from address 
                             where road_id = @roadID)
    begin
      select @status=102
      select @description='Street has at least one address'
    end
    
  /************************************************************
   * Delete the road
   ***********************************************************/
  if @status = 0
    begin
      delete from road_suburb
       where road_id = @roadID
      if @@error <> 0 and @@rowcount <> 0 /* was @@error <>100 */
        begin
          select @status=-1
          select @description='SQL Error '+convert(varchar(6),@@error)
                              +' deleting road from road_suburb table'
        end
        
      if @status = 0
        begin
          delete from town_road 
           where road_id = @roadID
           
          if @@error <> 0 and @@rowcount <> 0 /* was @@error <>100 */
            begin
              select @status=-1
              select @description='SQL Error '+convert(varchar(6),@@error)
                                  +' deleting road from town_road table'
            end
        end
        
      if @status = 0
        begin
          delete from road 
           where road_id = @roadID
           
          if @@error <> 0 and @@rowcount <> 0 /* was @@error <>100 */
            begin
              select @status=-1
              select @description='SQL Error '+convert(varchar(6),@@error)
                                  +' deleting road from road table'
            end
        end
    end
    
  /************************************************************
   * Done.  Return status
   ***********************************************************/
  if @status = 0
    begin
      commit transaction -- Commit the changes
      select @description='Success'
    end
  else
    rollback transaction
 
  -- log message
  select @msg=isnull(convert(varchar(8),@in_unique_road_id),'NULL')
  
  insert into NPAD_msg_log
    (msg_date, msg_username, msg_type, msg_dpid, msg_status, msg_description) 
  values 
    (@now, ltrim(rtrim(@in_username)), 'delete road', null, @status, @msg)

  -- Return status
  select status=@status, description=@description 
end