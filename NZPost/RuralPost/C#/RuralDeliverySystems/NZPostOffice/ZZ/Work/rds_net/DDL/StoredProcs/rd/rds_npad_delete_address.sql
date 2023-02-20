/****** Object:  StoredProcedure [rd].[rds_npad_delete_address]    Script Date: 08/05/2008 10:17:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for stored procedure rds_npad_delete_address : 
--

create procedure [rd].[rds_npad_delete_address](
    @in_dpid int,
    @in_username char(20)
    )
/******************************************************************
 * Description
 *    This routine deletes an address record.  The address must not
 *    be occupied (which disqualifies unnumbered addresses).
 *    
 * Parameters
 *    dpid        - DPID of the  to be deletedaddress
 *
 * Returns
 *    status      - A status code
 *                   0 = Success
 *                  >0 = Failure for various reasons (see code)
 *                  -1 = SQL errors
 *    description - Short description of the status
 *
 * System
 *    NPAD2 - NZ Post
 *
 * Author
 *    Tom Britton, Synergy International
 *
 * Created 
 *    November 2005
 *
 * Modification history
 * 13 Feb 2006  TJB  Added deletion of geocode entry for the address (CR13)
 * xx Mar 2006  TJB  Added check for address being a termination point
 * 20 Mar 2006  TJB  Fixed "dpid_id" bug
 * 31 Jan 2008  TJB  Changed char()s to varchar()s in SQL Server version
 *  1 Feb 2008  TJB  Fixed bug in address occupied test: join on adr_id not dp_id
 *****************************************************************/
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
begin transaction
  declare @status int,               -- Return status (0 = success)
          @description varchar(100), -- Return description (mainly error message)
          @msg varchar(80),          -- Test message
          @found int,                -- Flag indicating a database record 
                                     -- exists (1) or not (NULL)
                                     -- Sometimes used as a count.
          @adrID int,                -- Old address ID
          @now datetime
  
  -- Need the date and time for the logged actions
  select @now=getdate()
  select @status=0
  
  /************************************************************
   * Check input parameters
   ***********************************************************/
  
  -- Check to see that the dpid is valid ...
  if @in_dpid is null or @in_dpid <= 0
    begin
      select @status=101
      select @description='DPID does not exist'
    end
  
  -- ... and must already exist 
  if @status = 0
    begin
      select @found=null
      select @found = count(*) from address 
       where dp_id = @in_dpid
       
      if @@error <> 0
        begin
          select @status=-1
          select @description='SQL Error '+convert(char(6),@@error)
                              +' checking the address already exists'
        end
      if @status = 0 and (@found is null or @found <> 1)
        begin
          select @status=103
          select @description='DPID does not exist or is duplicated'
        end
    end
  
  -- Check that the address is not occupied
  if @status = 0 
     and exists (select 1 from address join customer_address_moves 
                                         on address.adr_id = customer_address_moves.adr_id 
                  where address.dp_id = @in_dpid 
                    and move_out_date is null)
    begin
      select @status=102
      select @description='Address occupied'
    end
  
  -- Check that the address is not a termination point
  if @status = 0 
     and exists (select 1 from route_description rd
                             , address 
                  where address.dp_id = @in_dpid 
                    and rd.adr_id = address.adr_id)
    begin
      select @status=121
      select @description='Address is route termination point'
    end
  
  /***************************************************************
   * Delete the address record
   ***************************************************************/
  if @status = 0
    begin
      delete from address 
       where dp_id = @in_dpid
       
      if @@error <> 0
        begin
          select @status=-1
          select @description='SQL Error '+convert(varchar(6),@@error)
                              +' deleting address record'
        end
      else
        select @msg='Address deleted'
        
      if @@error <> 0 and @@rowcount <> 0 /* was @@error <>100 */
        begin
          -- Return error if the error isn't 'not found'' (100)
          delete from address_geocode 
           where adr_id = @adrID
          if @@error <> 0
            begin
              select @status=-1
              select @description='SQL Error '+convert(varchar(6),@@error)
                                  +' deleting address_geocode record'
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
  select @msg=isnull(convert(varchar(8),@in_dpid),'NULL')
  
  insert into NPAD_msg_log
    (msg_date, msg_username, msg_type, msg_dpid, msg_status, msg_description) 
  values
    (@now, convert(varchar(20),@in_username), 'delete address', @in_dpid, @status, @msg)
    
  -- Return status
  select status=@status, description=@description 
  return @status
end
GO
