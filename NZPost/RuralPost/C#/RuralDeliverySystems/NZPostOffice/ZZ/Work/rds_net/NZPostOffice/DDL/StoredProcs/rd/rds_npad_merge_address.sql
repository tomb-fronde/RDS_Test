/****** Object:  StoredProcedure [rd].[rds_npad_merge_address]    Script Date: 08/05/2008 10:17:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for stored procedure rds_npad_merge_address : 
--

create procedure [rd].[rds_npad_merge_address](
@in_old_dpid int,
@in_new_dpid int,
@in_username char(20))
/******************************************************************
* Description
*    This routine merges the customers from one address into another
*    and deletes the old address.
*    This usually involves merging the customers from an unnumbered 
*    address into an existing numbered address.  An implicit assumption
*    is that the two addresses differ only in the street number.
*
* Parameters
*    new_dpid    - DPID of the originating address
*    old_dpid    - DPID of the new address
*    system_date - Not actually used since the address table isn''t updated
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
* 13Feb2006  TJB  Added deletion of geocode entry for the address (CR13)
* 14Feb2006  TJB  Fixed bug with geocode entry
*
*****************************************************************/
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  declare @status int, -- Return status (0 = success)
  @description char(100), -- Return description (mainly error
  -- message)
  @msg char(80), -- Test message
  @found integer, -- Flag indicating a database record 
  -- exists (1) or not (NULL)
  -- Sometimes used as a count.
  @old_master_cust_id int,
  @new_master_cust_id int,
  @old_adrID int, -- Old address ID
  @new_adrID int, -- New address ID
  @now datetime
  -- Need the date and time for the logged actions
  select @now=getdate()
  select @status=0
  /************************************************************
  * Check input parameters
  ***********************************************************/
  -- Check to see that the dpids are valid ...
  if @in_old_dpid is null or @in_old_dpid <= 0
    begin
      select @status=103
      select @description='Invalid old DPID'
    end
  else
  if @in_new_dpid is null or @in_new_dpid <= 0
    begin
      select @status=104
      select @description='Invalid new DPID'
    end
  -- Check that the old address already exists 
  if @status = 0
    begin
      select @found=null
      select @found = count(*) from
        address where
        dp_id = @in_old_dpid
      if @found is null or @found <> 1
        begin
          select @status=101
          select @description='Old DPID does not exist'
        end
    end
  -- Check that the new address already exists 
  if @status = 0
    begin
      select @found=null
      select @found = count(*) from
        address where
        dp_id = @in_new_dpid
      if @found is null or @found <> 1
        begin
          select @status=102
          select @description='New DPID does not exist'
        end
    end
  -- Check that the new address is a numbered address
  if @status = 0 and
    not exists(select 1 from address where
      dp_id = @in_new_dpid and
      adr_no is not null)
    begin
      select @status=105
      select @description='New DPID must be a numbered address'
    end
  -- Check that the old address is an unnumbered address
  if @status = 0 and
    exists(select 1 from address where
      dp_id = @in_old_dpid and
      adr_no is not null)
    begin
      select @status=107
      select @description='Old DPID must be an unnumbered address'
    end
  -- Check that the old DPID is for a master customer
  -- (and get the old address' master customer's cust_id)
  if @status = 0
    begin
      select @old_master_cust_id=null
      select @old_master_cust_id = rcust.cust_id from
        address as addr left outer join customer_address_moves as cam on addr.adr_id = cam.adr_id 
        left outer join rds_customer as rcust on cam.cust_id = rcust.cust_id  where
        addr.dp_id = @in_old_dpid and
        move_out_date is null and
        master_cust_id is null
      if @old_master_cust_id is null
        begin
          select @status=106
          select @description='Old address must have a master customer'
        end
    end
  /***************************************************************
  * Merge the customers from the old address into the new address
  ***************************************************************/
  if @status = 0
    begin
      -- Get the cust_id of the master customer at the new address
      -- if there is one.
      select @new_master_cust_id=null
      select @new_master_cust_id = rds_customer.cust_id from
        address left outer join customer_address_moves on address.adr_id = customer_address_moves.adr_id left outer join
        rds_customer on customer_address_moves.cust_id = rds_customer.cust_id  where
        address.dp_id = @in_new_dpid and
        move_out_date is null and
        master_cust_id is null
      -- Get the adr_id''s of the old and new addresses
      select @old_adrID = adr_id from
        address where
        dp_id = @in_old_dpid
      select @new_adrID = adr_id from
        address where
        dp_id = @in_new_dpid
      -- Link all the customers from the old address
      -- to the new address.  The new address is numbered
      -- so the customers won''t have DPIDs.
      update customer_address_moves set
        adr_id = @new_adrID,
        dp_id = null where
        adr_id = @old_adrID
      if @@error <> 0
        begin
          select @status=-1
          select @description='SQL Error '+convert(char(6),@@error)+' updating customer_address_moves'
        end
      else
        select @msg='Linked customers to new address'
      -- If the new address already has a master customer
      -- link the old master and any recipients to the 
      -- existing master at the new address as recipients
      if @status = 0 and @new_master_cust_id is not null
        begin
          update rds_customer set
            master_cust_id = @new_master_cust_id,
            cust_last_amended_date = @now,
            cust_last_amended_user = @in_username where
            (cust_id = @old_master_cust_id or
            master_cust_id = @old_master_cust_id)
          if @@error <> 0
            begin
              select @status=-1
              select @description='SQL Error '+convert(char(6),@@error)+' linking customers to new master'
            end
          else
            select @msg=@msg+' and linked customers to new master'
        end
      if @status = 0
        begin
          -- Delete the old address
          delete from address where
            dp_id = @in_old_dpid
          if @@error <> 0
            begin
              select @status=-1
              select @description='SQL Error '+convert(char(6),@@error)+' deleting old address record'
            end
          if @@error = 0
            delete from address_geocode where
              adr_id = @old_adrID
          if @@error <> 0 and @@rowcount <> 0 /* was @@error <>100 */
            begin
              -- Return the error if it isn't 'not found'' (100)
              select @status=-1
              select @description='SQL Error '+convert(char(6),@@error)+' deleting old address_geocode record'
            end
        end
    end
  /************************************************************
  * Done.  Return status
  ***********************************************************/
  if @status = 0
    begin
      commit transaction
      select @description='Success'+' - '+@msg
    end
  else
    rollback transaction
  -- log message
  select @msg= rd.trim(convert(char(8),@in_new_dpid))
  insert into NPAD_msg_log(msg_date,
    msg_username,msg_type,msg_dpid,msg_status,msg_description) values(
    @now,@in_username,'merge address',@in_old_dpid,@status,@msg)
  -- Return status
  select Status=@status,Description=@description 
  return @status
end
GO
