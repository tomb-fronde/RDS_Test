/****** Object:  StoredProcedure [rd].[rds_npad_modify_address]    Script Date: 08/05/2008 10:17:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [rd].[rds_npad_modify_address](
	@in_dpid           int,
	@in_adr_no         int           = NULL,
	@in_adr_alpha      char(20)      = NULL,
	@in_adr_unit       char(10)      = NULL,
	@in_unique_road_id int           = NULL,
	@in_sl_id          int           = NULL,
	@in_tc_id          int           = NULL,
	@in_rd_no          char(40)      = NULL,
	@in_post_code      char(4),
	@in_adr_property   char(100)     = NULL,
	@in_username       char(20),
	@in_xcoordinate    numeric(10,2) = NULL,
	@in_ycoordinate    numeric(10,2) = NULL
	)
/******************************************************************
 * Description
 *    This routine modifies an address record in the RDS system.
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
 * 13 Feb 2006  TJB  Added X and Y coordinate parameters as per CR13
 * 14 Feb 2006  TJB  Removed checks for DPID being a master, and 
 *                   non-numerics in in_adr_no.
 *                   Add insert of geocode if the address doesn't have one.
 * 30 Mar 2006  TJB  Fixed bug with updating property name.
 *  5 Apr 2006  TJB  Ensure RD numbers for Oamaru are 3 chars
 *                   with the last char an alpha.
 *                   Added Contract # lookup in case the change 
 *                   is to a new RD route/post code.
 * 11 May 2006  TJB  SR4687: If a road/suburb association doesn't 
 *                   exist, create it (don''t flag it as an error).
 * 31 Jan 2008  TJB  Changed char()s to varchar()s in SQL Server version
 *****************************************************************/
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
begin transaction
  declare @status int,               -- Return status (0 = success)
          @description varchar(100), -- Return description (mainly error message)
          @found tinyint,            -- Flag indicating a database record 
                                     -- exists (1) or not (NULL)
          @msg varchar(80),          -- Test message
          @adrID int,                -- New address ID
          @custID int,               -- New customer ID
          @masterID int,             -- Master customer ID
          @masterAddress int         -- Master customer''s address ID

              -- Most of these are used to ensure either a proper value or NULL
              -- is used to create the address or customer record (the passed
              -- value may be '' or 0 instead of NULL).
              -- In other cases, the passed value can be used when it is required
              -- and has passed validation (eg adr_no, tc_id, rd_no, post_code)
  declare @adr_no varchar(20),       -- RDS street number: normalised input value
          @adr_unit varchar(10),     -- RDS address unit
          @adr_alpha varchar(20),    -- RDS address alpha
          @slID int,                 -- RDS address suburb
          @tcID int,                 -- RDS address mailtown
          @rdNo varchar(20),         -- RDS RD Number
          @roadID int,               -- RDS road_id
          @postCode char(4),         -- RDS post code
          @postcodeID int,           -- Post Code ID
          @master_dpid int,          -- RDS dpid of master customer
          @contract_no int,          -- Contract number
          @temp_int int,             -- Temporary number
          @now datetime
          
              -- Trimmed input strings
              -- The post_code must be 4 characters anyway so shouldn't be trimmed
              -- The in_username is only used in the logged message and needn't be trimmed until used
  declare @tmp_in_adr_alpha    varchar(20),
          @tmp_in_adr_unit     varchar(10),
          @tmp_in_rd_no        varchar(40),
          @tmp_in_adr_property varchar(100)

  -- Need the date and time for the logged actions
  select @now=getdate()
  select @status=0
  
  -- Trim the input strings
  select @tmp_in_adr_alpha     = ltrim(rtrim(@in_adr_alpha))
  select @tmp_in_adr_unit      = ltrim(rtrim(@in_adr_unit))
  select @tmp_in_rd_no         = ltrim(rtrim(@in_rd_no))
  select @tmp_in_adr_property  = ltrim(rtrim(@in_adr_property))

  /************************************************************
   * Validate the input parameters
   ***********************************************************/
  -- Check to see that the dpid is valid ...
  if @in_dpid is null or @in_dpid <= 0
    begin
      select @status=101
      select @description='Dpid does not exist or invalid'
    end
    
  -- ... and does already exist
  if @status = 0
    begin
      select @found=null
      select @found = count(*) from address 
       where dp_id = @in_dpid
      if @found is null or @found < 1
        begin
          select @status=101
          select @description='Dpid does not exist or invalid'
        end
      else
      if @found is not null and @found > 1
        begin
          select @status=120
          select @description='Dpid exists more than once!'
        end
    end
    
  /* This isn't relevant: if the DPID was found in the address table, it is either
   *                      associated with a master customer, or an unoccupied address. 
   *                      If NPAD sends the DPID of a non-master (recipient) the DPID
   *                      won't be in the address table and will have been invalidated 
   *                      above.
   *
   *       -- ... and is a master
   *   if @status = 0 
   *   and not exists (select 1 from customer_address_moves, rds_customer
   *                    where customer_address_moves.dp_id = @in_dpid
   *                      and customer_address_moves.move_out_date is null
   *                      and rds_customer.cust_id = customer_address_moves.cust_id
   *                      and rds_customer.master_cust_id is null)
   *   then
   *       set @status = 102;
   *       set @description = 'Dpid is not a master';
   *   end if;
   */
 
 -- Check to see that the road ID is valid ...
  if @status = 0 and
    (@in_unique_road_id is null or @in_unique_road_id <= 0)
    begin
      select @status=103
      select @description='Unique_road_id does not exist or invalid'
    end
 
 -- ... and does exist
  -- We get the road_id for the road to use below
  if @status = 0
    begin
      select @roadID=null
      select @roadID = road_id from road 
       where unique_road_id = @in_unique_road_id
      if @roadID is null
        begin
          select @status=103
          select @description='Unique_road_id does not exist or invalid'
        end
    end
    
  -- Check to see if a street number is specified
  if @status = 0
    if @in_adr_no is not null and @in_adr_no > 0
      select @adr_no=convert(varchar(20),@in_adr_no)
    else
      select @adr_no=null
      
  /* This isn't relevant now: in_adr_no is numeric so cannot contain non-numerics
   *
   *       -- If there is a street number, it must not contain non-numeric characters
   *       if @adr_no is not null and isnumeric(@adr_no) = 0 then
   *           set @status = 110;
   *           set @description = 'Invalid street number'';
   *       end if;
   */

  -- Check to see if the unit number is valid (if specified)
  -- ==> any value is allowed
  -- Set @adr_unit to the @in_adr_unit value or NULL
  -- eliminating the possibl passed value of ''.
  if @status = 0
    begin
      if @tmp_in_adr_unit is not null and len(@tmp_in_adr_unit) > 0
        select @adr_unit=@tmp_in_adr_unit
      else
        select @adr_unit=null
        
      -- Check to see if the number alpha is valid (if specified)
      -- ==> any value is allowed
      -- Set @adr_alpha to the @in_adr_alpha value or NULL
      -- eliminating the possibl passed value of ''.
      if @tmp_in_adr_alpha is not null and len(@tmp_in_adr_alpha) > 0
        select @adr_alpha=@tmp_in_adr_alpha
      else
        select @adr_alpha=null
        
      -- Check to see if the suburb is valid (if specified)
      if @in_sl_id is not null and @in_sl_id > 0
        begin
          if not exists(select 1 from suburbLocality 
                         where sl_id = @in_sl_id)
            begin
              select @status=104
              select @description='LocalityID does not exist or invalid'
            end
          select @slID=@in_sl_id
        end
      else -- We use @slID in place of @in_sl_id to
           -- ensure its value is either a real value or NULL
           -- This eliminates the possibility of it being 0.
        select @slID=null
    end
    
  -- Check to see if the mailtown is valid (must be specified)
  if @status = 0
    if @in_tc_id is null
      begin
        select @status=105
        select @description='MailtownID does not exist or invalid'
      end
    else
    if not exists(select 1 from townCity 
                   where tc_id = @in_tc_id) 
       or @in_tc_id <= 0
      begin
        select @status=105
        select @description='MailtownID does not exist or invalid'
      end
    else
      select @tcID=@in_tc_id   -- We use @tcID in place of @in_tc_id
      
  if @status = 0
    -- Check to see if an RD number was specified
    if @tmp_in_rd_no is not null and len(@tmp_in_rd_no) > 0
      select @rdno=@tmp_in_rd_no
    else
      begin
        select @rdno=null
        select @status=108
        select @description='RD number missing or invalid'
      end
      
  -- Check that the RD number is valid for Oamaru
  -- (3 chars with the last char an alpha)
  if @status = 0 and @in_tc_id = (select tc_id from towncity 
                                   where tc_name = 'Oamaru')
    begin
      if len(@rdno) > 3
        begin
          select @status=108
          select @description='RD number missing or invalid'
        end
      else
        if len(@rdno) < 3
          select @rdno=space(3-len(@rdno))+@rdno  -- Pad on the left to 3 characters
          
      if @status = 0 and(isnumeric(right(@rdno,1)) = 1 or right(@rdno,1) = ' ')
        begin
          select @status=120
          select @description='RD number invalid for Oamaru'
        end
    end
    
  -- Check to see if a post code was specified
  if @status = 0
    if @in_post_code is not null and len(@in_post_code) <> 4
      begin
        select @postCode=null
        select @status=109
        select @description='Post code missing or invalid'
      end
    else
      begin
        select @postCode=@in_post_code
        -- ... and that it exists (assume is the right one)
        select @postCodeID = rd.f_getPostCodeID(@in_post_code, @in_tc_id, @roadID)
        if @postCodeID = -1
          begin
            select @status=109
            select @description='Post code missing or invalid'
          end
      end
      
  --    -- Check to see if the road exists in the suburb (if specified)
  --    if @status = 0 and @slID is not null then
  --        if not exists (select 1 from road_suburb
  --                        where sl_id = @slID
  --                          and road_id = @roadID)
  --        then
  --            set @status = 106;
  --            set @description = 'Street does not exist in Locality';
  --        end if;
  --    end if;
  
  -- Check to see if the road exists in the mailtown
  if @status = 0 and @tcID is not null
    if not exists(select 1 from town_road 
                   where tc_id = @tcId 
                     and road_id = @roadID)
      begin
        select @status=107
        select @description='Street does not exist in Mailtown'
      end
      
  -- Check to see if the suburb exists in the mailtown (if specified)
  if @status = 0 and @slID is not null
    if not exists(select 1 from town_suburb 
                   where sl_id = @slID 
                     and tc_id = @tcID)
      begin
        select @status=119
        select @description='Locality does not exist in Mailtown'
      end
      
  -- Get the contract number for the new address
  if @status = 0
    begin
          -- See if we can determine the contract number
          -- Look for other addresses in the same RD/post code
      select @temp_int = count(distinct @contract_no) 
        from address a join post_code 
                         on a.post_code_id = post_code.post_code_id
		       join road 
		         on a.road_id = road.road_id 
       where post_code = @in_post_code 
         and a.adr_rd_no = @RDno 
         and @contract_no is not null 
         and unique_road_id = @in_unique_road_id
         
      if @@error <> 0
        begin
          select @description='SQL Error '+convert(varchar(6),@@error)
                              +' counting contract#s in post_code'
          select @status=-1
        end
        
      if @temp_int = 1 and @status = 0
        begin
              -- NOTE: Rewrote this to make it intelligible.  Replace first and last lines
              --       with commented-out code to get original.  TJB 31-Jan-2008
--          select @contract_no = f.t from (select distinct a.contract_no as t 
          select distinct @contract_no = a.contract_no
            from rd.address a join rd.post_code pc 
                                on a.post_code_id = pc.post_code_id
                              join rd.road r
                                on a.road_id = r.road_id 
           where post_code = @in_post_code 
             and adr_rd_no = @RDno 
             and contract_no is not null 
             and unique_road_id = @in_unique_road_id
--             and unique_road_id = @in_unique_road_id) f
          if @@error <> 0
            begin
              select @description='SQL Error '+convert(varchar(6),@@error)
                                  +' getting contract# for address'
              select @status=-1
            end
        end
      else
        select @contract_no=null
    end
    
  /************************************************************
   * Do the modifications
   ***********************************************************/
  if @status = 0
    begin
          -- Get the adr_id of the address
      select @adrID = adr_id from rd.address 
       where dp_id = @in_dpid
       
          -- Update the address record
      update rd.address 
         set adr_no = @adr_no,
             contract_no = @contract_no,
             adr_unit = @adr_unit,
             adr_alpha = @adr_alpha,
             adr_property_identification = @tmp_in_adr_property,
             road_id = @roadID,
             sl_id = @slID,
             tc_id = @tcID,
             adr_rd_no = @rdNO,
             post_code_id = @postcodeID,
             adr_last_amended_date = @now,
             adr_last_amended_user = ltrim(rtrim(@in_username))
       where dp_id = @in_dpid
       
      if @@error <> 0
        begin
          select @description='SQL Error '+convert(varchar(6),@@error)
                              +' updating address record'
          select @status=-1
        end
      else
        select @msg='Updated address'
        
      -- If there is a street number for the address, clear the DPIDs 
      -- associated with any customers at the address.
      if @status = 0 and @adr_no is not null
        begin
          update customer_address_moves 
             set dp_id = null 
           where adr_id = @adrID
           
          if @@error <> 0 and @@rowcount <> 0 /* was @@error <>100 */
            begin
              -- Return error if the error isn't 'not found'' (100)
              select @description='SQL Error '+convert(varchar(6),@@error)
                                  +' removing DPIDs from customers'
              select @status=-1
            end
          else
            select @msg=@msg+' and removed customer DPIDs'
        end
        
      -- If the road doesn''t already exist in the suburb, creeate it.
      if @status = 0
        if @slID is not null
          if not exists(select 1 from road_suburb 
                         where sl_id = @slID 
                           and road_id = @roadID)
            begin
              insert into road_suburb ( sl_id, road_id ) 
              values ( @slID, @roadID )
              if @@error <> 0
                begin
                  select @status=-1
                  select @description='SQL Error '+convert(varchar(6),@@error)
                                      +' creating road_suburb record'
                end
            end
            
      -- Update the geocode values
      if @status = 0
        begin
             -- If there''s an entry for the geocode, update it. 
              -- Otherwise create a new entry for it.
          if exists(select 1 from address_geocode where adr_id = @adrID)
            update address_geocode 
               set geocode_x = @in_xcoordinate,
                   geocode_y = @in_ycoordinate 
             where adr_id = @adrID
          else
            insert into address_geocode 
              ( adr_id, geocode_x, geocode_y ) 
            values
              ( @adrID, @in_xcoordinate, @in_ycoordinate )
              
          if @@error <> 0
            begin
              -- Return error
              select @description='SQL Error '+convert(varchar(6),@@error)
                                  +' updating address geocode'
              select @status=-1
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
    
  -- Log the message
  select @msg=isnull(convert(varchar(20),@in_adr_no),'NULL')+','
              +isnull(@tmp_in_adr_alpha,'NULL')+','
              +isnull(@tmp_in_adr_unit,'NULL')+','
              +isnull(convert(varchar(8),@in_unique_road_id),'NULL')+','
              +isnull(convert(varchar(8),@in_sl_id),'NULL')+','
              +isnull(convert(varchar(8),@in_tc_id),'NULL')+','
              +isnull(@tmp_in_rd_no,'NULL')+','
              +isnull(@in_post_code,'NULL')
              
  insert into NPAD_msg_log
    (msg_date, msg_username, msg_type, msg_dpid, msg_status, msg_description) 
  values
    (@now, ltrim(rtrim(@in_username)), 'modify address', @in_dpid, @status, @msg)
    
  -- Return status
  select status=@status, sescription=@description 
  return @status
end
GO
