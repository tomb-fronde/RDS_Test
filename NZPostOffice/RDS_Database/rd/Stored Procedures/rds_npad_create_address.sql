
CREATE PROCEDURE [rd].[rds_npad_create_address](
	@in_dpid             int,
	@in_adr_no           int       = NULL,
	@in_adr_alpha        char(20)  = NULL,
	@in_unique_road_id   int       = NULL,
	@in_sl_id            int       = NULL,
	@in_tc_id            int       = NULL,
	@in_rd_no            char(40)  = NULL,
	@in_post_code        char(4),
	@in_adr_property     char(100) = NULL,
	@in_adr_unit         char(10)  = NULL,
	@in_cust_surname     char(45)  = NULL,
	@in_cust_initials    char(30)  = NULL,
	@in_cust_title       char(10)  = NULL,
	@in_master_cust_dpid int       = NULL,
	@in_username         char(20),
	@in_xcoordinate      numeric(10,2) = NULL,
	@in_ycoordinate      numeric(10,2) = NULL)

/******************************************************************
* Description
*    This routine creates an address record in the RDS system.
*    For unnumbered addresses, it also creates a new customer 
*    in the rds_customer table and an associated record in the
*    Customer_address_moves table.
*
*    Addresses can only be created where the road, mailtown and 
*    suburb (if specified) already exist.
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
* 24 Feb 2006  TJB  Made description of error 101 consistent
* 20 Mar 2006  TJB  Changed default new customer attributes to
*                   'rural resident' and Privacy = No.
* 24 Mar 2006  TJB  Add lookup of contract_no using post_code,
*                   RD_no, and unique_road_id.
*  5 Apr 2006  TJB  Ensure RD numbers for Oamaru are 3 chars
*                   with the last char an alpha.
* 10 Apr 2006  TJB  Add 3rd f_getNextSequence parameter
* 11 May 2006  TJB  SR4687: If a road/suburb association doesn't 
*                   exist, create it (don't flag it as an error).
* 17 May 2007  TJB  Fix bug:  set default adpost quantity = 1 for new
*                   master customers.
* 30 Jan 2008  TJB  Changed char()s to varchar()s in SQL Server version
* 24 Nov 2009  TJB  [CR001] Changed scheme to look up contract_no
*                   - use new post_code table column
* 23 Dec 2010  TJB  Add adress to address_frequency table if possible
* 24 Feb 2011  TJB  Added @nRoutesAddedTo and associated message
*  5 Jul-2016  TJB  Bug fix: Get contract_no where there are more than
*                   one contract per post_code (see RPCR_105)
************************************************************************/
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
begin transaction
  declare 
     @status int                -- Return status (0 = success)
    ,@description varchar(60)   -- Return description (mainly error message)
    ,@numbered tinyint          -- Flag indicating the address is numbered (1) 
                                --       or not (0)
    ,@found tinyint             -- Flag indicating a database record exists (1)
                                --       or not (NULL)
    ,@msg varchar(80)           -- Test message
    ,@adrID int                 -- New address ID
    ,@custID int                -- New customer ID
    ,@postCodeID int            -- Post code ID
    ,@masterCustID int          -- Master customer's ID
    ,@masterAdrID int           -- Master customer's adr_id
    ,@contract_no int           -- Contract number
    ,@temp_int int              -- Temporary number
    ,@temp_char varchar(20)     -- Temporary string
    ,@routeErrMsg varchar(255)  -- addAddressToRoute error message
    ,@nRoutesAddedTo int        -- Number of routes the address is added to
    
           -- Most of these are used to ensure either a proper value or NULL
           -- is used to create the address or customer record (the passed
           -- value may be '' or 0 instead of NULL).
           -- In other cases, the passed value can be used when it is required
           -- and has passed validation (eg adr_no, tc_id, rd_no, post_code)
  declare 
     @adrNo varchar(20)         -- in_adr_no as a string to match database column type (normalised)
    ,@adrUnit varchar(10)       -- Normalized address adr_unit
    ,@adrAlpha varchar(20)      -- Normalized address adr_alpha
    ,@adrProperty varchar(20)   -- Normalized address adr_property_identification
    ,@slID int                  -- Normalized address sl_id
    ,@roadID int                -- RDS road_id (determined via unique_road_id)
    ,@custInitials varchar(30)  -- Normalized rds_customer cust_initials
    ,@custTitle varchar(10)     -- Normalized rds_customer cust_title
    ,@masterDpid int            -- Normalized dpid of master customer
    ,@RDno varchar(40)          -- Normalised RD number
    ,@now datetime

           -- Trimmed input strings
  declare @tmp_in_cust_surname varchar(45)
  declare @tmp_in_cust_initials varchar(30)
  declare @tmp_in_rdno varchar(40)
  declare @tmp_in_adr_alpha varchar(20)
  declare @tmp_in_adr_property varchar(100)
  declare @tmp_in_adr_unit varchar(10)
  declare @tmp_in_cust_title varchar(10)
  
           -- Need the date and time for the logged actions
  select @now = getdate()
  select @status = 0
  select @routeErrMsg = ''
  select @nRoutesAddedTo = 0
  
  select @tmp_in_cust_title    = rtrim(@in_cust_title)
  select @tmp_in_cust_initials = ltrim(rtrim(@in_cust_initials))
  select @tmp_in_cust_surname  = ltrim(rtrim(@in_cust_surname))
  select @tmp_in_adr_unit      = ltrim(rtrim(@in_adr_unit))
  select @tmp_in_adr_alpha     = ltrim(rtrim(@in_adr_alpha))
  select @tmp_in_adr_property  = ltrim(rtrim(@in_adr_property))
  select @tmp_in_rdno          = ltrim(rtrim(@in_rd_no))

  /************************************************************
   * Check input parameters
   ***********************************************************/
  -- Check to see that the dpid is valid ...
  if @in_dpid is null or @in_dpid <= 0
  begin
      select @status=115
      select @description='Invalid Dpid'
  end
  else
  -- ... and doesn't already exist 
  if exists(select 1 from address
             where dp_id = @in_dpid)
  begin
      select @status=101
      select @description='Address already exists (same dpid)'
  end
  else
  -- Check to see that the road ID is valid ...
  if @in_unique_road_id is null or @in_unique_road_id <= 0
  begin
      select @status=103
      select @description='Unique_road_id does not exist or invalid'
  end
  -- ... and does exist
  -- We get the road_id for the road to use below
  if @status = 0
  begin
      select @roadID=NULL
      select @roadID = road_id from road
       where unique_road_id = @in_unique_road_id
      if @roadID is null
      begin
          select @status=103
          select @description='Unique_road_id does not exist or invalid'
      end
  end
    
  -- Check to see if this address is numbered or not.
  -- A numbered address MUST have a street number and MAY have 
  --     a unit number and/or alpha suffix.
  if @status = 0
      if @in_adr_no is not null and @in_adr_no > 0
      begin
          select @numbered=1
          select @adrNo=convert(varchar(20),@in_adr_no)
      end
      else
      begin
          select @numbered=0
          select @adrNo=null
      end
      
  -- Check to see if the unit number is valid (if specified)
  -- any value is allowed
  -- Set @adrUnit to the @in_adr_unit value or NULL
  -- eliminating the possibly passed value of ''.
  if @status = 0
      begin
      if @tmp_in_adr_unit is null or @tmp_in_adr_unit = ''
          select @adrUnit=null
      else
          select @adrUnit=@tmp_in_adr_unit
        
      -- Check to see if the number alpha is valid (if specified)
      --> any value is allowed
      -- Set @adrAlpha to the @in_adr_alpha value or NULL
      -- eliminating the possibly passed value of ''.
      if @tmp_in_adr_alpha is null or @tmp_in_adr_alpha = ''
          select @adrAlpha=null
      else
          select @adrAlpha=@tmp_in_adr_alpha
        
      -- Check to see if the property name is valid (if specified)
      --> any value is allowed
      -- Set @adrProperty to the @in_adr_property value or NULL
      -- eliminating the possibly passed value of ''.
      if @tmp_in_adr_property is null or @tmp_in_adr_property = ''
          select @adrProperty=null
      else
          select @adrProperty=@tmp_in_adr_property
        
      -- Normalise the suburbID
      if @in_sl_id is null
          select @slID=null
      else
          select @slID=@in_sl_id
        
      -- Check to see if the suburb exists (if specified)
      if @slID is not null
          if not exists(select 1 from suburbLocality
                         where sl_id = @slID) 
             or @slID <= 0
          begin
              select @status=104
              select @description='LocalityID does not exist or invalid'
          end
      end
    
  -- Check to see that a mailtown was specified
  if @status = 0
      if @in_tc_id is null
      begin
          select @status=114
          select @description='Mailtown not specified'
      end
      
  -- Check to see that the mailtown is valid
  if @status = 0
      if @in_tc_id is not null
          if not exists(select 1 from townCity 
                         where tc_id = @in_tc_id) 
             or @in_tc_id <= 0
          begin
              select @status=105
              select @description='MailtownID does not exist or invalid'
          end
        
  -- Check to see if the suburb exists in the mailtown
  if @status = 0
      if @slID is not null
          if not exists(select 1 from town_suburb 
                         where tc_id = @in_tc_id 
                           and sl_id = @slID)
          begin
              select @status=119
              select @description='Locality does not exist in Mailtown'
          end
        
  --    -- Check to see if the road exists in the suburb (if specified)
  --    if @status = 0 then
  --        if @slID is not null then
  --            if not exists (select 1 from road_suburb
  --                            where sl_id = @slID
  --                              and road_id = @roadID)
  --            then
  --                set @status = 106;
  --                set @description = 'Street does not exist in Locality';
  --            end if;
  --        end if;
  --    end if;
  -- Check to see if the road exists in the mailtown
  
  if @status = 0
      if @in_tc_id is not null
          if not exists(select 1 from town_road 
                         where tc_id = @in_tc_id 
                           and road_id = @roadID)
          begin
              select @status=107
              select @description='Street does not exist in Mailtown'
          end

  -- Check to see that an RD number was specified
  --> NOTE: Alphanumeric values are acceptable
  if @status = 0
      if @in_rd_no is not null and LEN(@tmp_in_rdno) > 0
          select @rdno=@tmp_in_rdno
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
      if LEN(@RDno) > 3
      begin
          select @status=108
          select @description='RD number missing or invalid'
      end
      else
      if len(@RDno) < 3
        select @RDno=space(3-len(@RDno))+@RDno   -- Pad on the left to 3 characters
      if @status = 0 and(isnumeric(right(@RDno,1)) = 1 or right(@RDno,1) = ' ')
      begin
          select @status=120
          select @description='RD number invalid for Oamaru'
      end
  end
    
  -- Check to see that a post code was specified
  --> Note: isnumeric() returns 0 if the post_code is NULL
  if @status = 0
      if isnumeric(@in_post_code) = 0 or len(@in_post_code) <> 4
      begin
          select @status=109
          select @description='Post Code missing or invalid'
      end

  -- ... and that it exists (assume its the right one)
  if @status = 0
  begin
      select @postCodeID=rd.f_getPostCodeID(@in_post_code,@in_tc_id,@roadID)
      if @postCodeID = -1
      begin
          select @status=109
          select @description='Post Code missing or invalid'
      end
  end
    
  -- Check whether a customer has been named when it shouldn't be
  -- An address can have either a street number or customer named, 
  -- but not both.
  if @status = 0
      if @numbered = 1
          if @tmp_in_cust_surname is not null and len(@tmp_in_cust_surname) > 0
          begin
              select @status=116
              select @description='Both street number and customer given for address'
          end
        
  -- Check whether a customer has not been named when it should be
  if @status = 0
      if @numbered = 0
          if @tmp_in_cust_surname is null or len(@tmp_in_cust_surname) = 0
          begin
              select @status=117
              select @description='No street number or customer given for address'
          end
        
  -- Normalise the master_cust_dpid.  We'll use it soon.
  if @in_master_cust_dpid is null or @in_master_cust_dpid = 0
      select @masterDpid=null
  else
      select @masterDpid=@in_master_cust_dpid
    
  -- At this point the @in_cust_surname either has something in it when it should
  -- or doesn't have anything when it shouldn't (NULL and '' being equivalent).
  -- If this is an unnumbered address, we want to ensure the cust_initials and cust_title
  -- are either <something> or NULL (not '').  What that <something> is doesn't matter.
  -- We also want to ensure the master_dpid is either NULL or > 0, and if > 0, is valid.
  -- They're only used to create a customer record for an unnumbered address, so what they 
  -- are if they're not going to be used doesn't matter.
  if @status = 0 and @numbered = 0
  begin
      -- Normalise the cust_title
      if @tmp_in_cust_title is null or @tmp_in_cust_title = ''
          select @custTitle=null
      else
          select @custTitle=@tmp_in_cust_title

      -- Normalise the cust_initials
      if @tmp_in_cust_initials is null or @tmp_in_cust_initials = ''
          select @custInitials=null
      else
          select @custInitials=@tmp_in_cust_initials

      -- If a master_cust_dpid was given, check that it is valid
      -- The referenced customer must be a master
      -- and that customer's address must match the new address
      if @masterDpid is not null
      begin
          select @found=null
          -- Check that there's only one master dpid
          -- in the customer_address_moves table.
          select @found = count(*) from customer_address_moves 
           where dp_id = @masterDpid 
             and move_out_date is null
          if @found is null
          begin
              select @status=118
              select @description='Invalid master customer dpid'
          end
          else
          if @found > 1
          begin
              select @status=120
              select @description='Other: Master dpid appears too often in customer_address_moves'
          end

          -- Get the master dpid's customer ID and address
          -- for further validations
          if @status = 0
          begin
              select @masterCustID = cust_id,@masterAdrID = adr_id 
                from customer_address_moves
               where dp_id = @masterDpid 
                 and move_out_date is null
                 
              -- Check that the master dpid refers to a master customer
              select @found = 1 from rds_customer 
               where cust_id = @masterCustID 
                 and master_cust_id is null
                 
              if @found is null or @found <> 1
              begin
                  select @status=120
                  select @description='Master dpid is not a master customer'
              end
          end
      end
  end
    
  -- Now check that the address isn't being duplicated (when its a numbered address)
  -- and exists when it should (when creating a recipient)
  if @status = 0 and @numbered = 1
  begin
      -- New numbered address: there shouldn't be a duplicate
      -- Look up the dp_id for the address
      select @temp_int=null
      select @temp_int = dp_id 
        from address join post_code 
                       on address.post_code_id = post_code.post_code_id 
       where adr_no = @adrNo 
         and isnull(adr_unit,'') = isnull(@adrUnit,'') 
         and isnull(adr_alpha,'') = isnull(@adrAlpha,'') 
         and road_id = @roadID 
         and tc_id = @in_tc_id 
         and adr_rd_no = @RDno 
         and post_code.post_code = @in_post_code
         
      -- If a duplicate address was found check whether has the same or a different dp_id
      if @temp_int is not null
          if @temp_int = @in_dpid
          begin
              select @status=101
              select @description='Address already exists (same dpid)'
          end
          else
          begin
              select @status=102
              select @description='Address already exists (different dpid)'
          end
  end
    
  if @status = 0 and @numbered = 0 and @masterDpid is not null
  begin
      -- new recipient: the address must exist 
      -- and must be the same as the master's.
      -- Look up the dp_id of the master's address
      -- and also that the addresses match
      select @temp_int = dp_id 
        from address join post_code 
                       on address.post_code_id = post_code.post_code_id 
       where adr_id = @masterAdrID 
         and adr_no is null 
         and road_id = @roadID 
         and tc_id = @in_tc_id 
         and adr_rd_no = @RDno 
         and post_code.post_code = @in_post_code
         
      -- If the address didn't match, or has a different dp_id than the master's
      if @temp_int is null or @temp_int <> @masterDpid
      begin
          select @status=113
          select @description='Master customer dpid does not exist or invalid'
      end
  end
    
  -- NOTE:  the other possibility is that this might be an unnumbered address
  --        with no master customer dpid specified (but these are not allowed).  
  --        In that case, there may be duplicate (unnumbered) addresses, and 
  --        we're about to create another with this customer as its master.
  
  /************************************************************
   * Create the new address
   ***********************************************************/
  -- Get the next available address ID for the new address
  -- Note: we only actually create a new address record for
  -- numbered addresses and unnumbered addresses where we 
  -- create a new master customer.
  
  if @status = 0
  begin
      exec @adrID=rd.f_getNextSequence 'address', 1, 0 

      -- TJB  5-Jul-2016: Bug fix
      -- Original selected first contract when there are more than 1 contract for the post code
      -- RPCR_105 required the contract with the most addresses on the road.
      select @contract_no = rd.f_get_roadcontract( @roadID, @in_post_code)
      
      -- select @contract_no = contract_no 
      --   from rd.post_code
      --  where post_code = @in_post_code 

      if @@error <> 0
      begin
          select @status=-1
          select @description='SQL Error '+convert(varchar(6),@@error)+' determining contract# from post_code'
      end
        
      if @numbered = 1 and @status = 0
      begin
          -------------------------------------
          --  Create a new numbered address  --
          -------------------------------------
          insert into address 
                 (adr_id, adr_no, adr_unit, adr_alpha, adr_property_identification,
                  road_id, sl_id, tc_id, adr_rd_no, post_code_id,
                  dp_id, contract_no, adr_date_loaded, adr_last_amended_user) 
          values 
                 (@adrID, @adrNo, @adrUnit, @adrAlpha, @adrProperty,
                  @roadID, @slID, @in_tc_id, @RDno, @postCodeID,
                  @in_dpid, @contract_no, @now, @in_username)
                  
          if @@error <> 0
          begin
              select @status=-1
              select @description='SQL Error '+convert(char(6),@@error)+' creating numbered address'
          end
          else
                -- Successful: prepare addition for 'Successful' message
            select @msg='New Adr_id = '+convert(varchar(8),@adrID)
            
          -- TJB Jan-2011 Sequencing Review: Added
          -- Create procedure addAddressToRoute
          -- Call addAddressToRoute to add a new address to a frequency where possible.
          if @status = 0
          begin
              begin try
                  exec addAddressToRoute @adrID, @contract_no, @roadID

                  -- Save the number of routes the address was added to
                  select @nRoutesAddedTo=count(*) from address_frequency
                   where contract_no = @contract_no and adr_id = @adrID
              end try
              begin catch
                  select @routeErrMsg = ERROR_MESSAGE()
              end catch
          end
            
          -- Now add the geocode 
          if @status = 0
          begin
              insert into address_geocode(adr_id, geocode_x, geocode_y) 
              values (@adrID, @in_xcoordinate, @in_ycoordinate)
              
              if @@error <> 0
              begin
                  select @status=-1
                  select @description='SQL Error '+convert(varchar(6),@@error)+' adding address_geocode record'
              end
          end
      end
      else
      begin
          -------------------------------------
          -- Create a new unnumbered address --
          -------------------------------------
          -- Get the next available customer ID for the new customer
          execute @custID=rd.f_getNextSequence 'customer', 1, 0
          
          if @masterDpid is null
          begin
              ----------------------------------
              -- Create a new master customer --
              ----------------------------------
              -- Create the address record
              insert into address 
                     (adr_id, adr_no, adr_unit, adr_alpha, adr_property_identification,
                      road_id,sl_id, tc_id, adr_rd_no, post_code_id, dp_id,
                      contract_no, adr_date_loaded, adr_last_amended_user) 
              values 
                     (@adrID, null, null, null, @adrProperty,
                      @roadID, @slID, @in_tc_id, @RDno, @postCodeID, @in_dpid,
                      @contract_no, @now, @in_username)
              if @@error <> 0
              begin
                  select @status=-1
                  select @description='SQL Error '+convert(varchar(6),@@error)+' creating unnumbered address'
              end
                
              -- Add the address to the address_frequency table 
              if @status = 0
              begin
                  begin try
                      exec addAddressToRoute @adrID, @contract_no, @roadID

                      -- Save the number of routes the address was added to
                      select @nRoutesAddedTo = count(*) from address_frequency
                       where contract_no = @contract_no and adr_id = @adrID
                  end try
                  begin catch
                      select @routeErrMsg = ERROR_MESSAGE()
                  end catch
              end
            
              -- Now add the geocode 
              if @status = 0
              begin
                  insert into address_geocode (adr_id, geocode_x, geocode_y) 
                  values (@adrID, @in_xcoordinate, @in_ycoordinate)
                  
                  if @@error <> 0
                  begin
                      select @status=-1
                      select @description='SQL Error '+convert(varchar(6),@@error)+' adding address_geocode record'
                  end
              end
                
              -- Create the master customer record
              if @status = 0
              begin
                  insert into rds_customer 
                         (cust_id, cust_title, cust_initials, cust_surname_company,
                          master_cust_id, cust_dir_listing_ind,
                          cust_business, cust_rural_resident, cust_rural_farmer,
                          cust_date_commenced, cust_last_amended_date, cust_last_amended_user) 
                  values 
                         (@custID, @custTitle, @custInitials, @tmp_in_cust_surname,
                          null, 'Y', 'N', 'Y', 'N',
                          rd.today(), @now, @in_username)
                          
                  if @@error <> 0
                  begin
                      select @status=-1
                      select @description='SQL Error '+convert(varchar(6),@@error)+' creating master customer'
                  end
              end
                
              -- Create the customer_address_moves record linking the
              -- customer to the address.
              if @status = 0
              begin
                  insert into customer_address_moves (adr_id, cust_id, dp_id, move_in_date,move_out_date) 
                  values (@adrID, @custID, @in_dpid, @now,null)
                  if @@error <> 0
                  begin
                      select @status=-1
                      select @description='SQL Error '+convert(varchar(6),@@error)
                                          +' creating customer_address_moves record for master'
                  end
              end
              select @msg='New Adr_id = '+convert(varchar(8),@adrID)
                          +', new master = '+convert(varchar(8),@custID)
          end
          else
          begin
              ------------------------------
              --  Create a new recipient  --
              ------------------------------
              -- Create the recipient customer record
              insert into rds_customer 
                     (cust_id, cust_title, cust_initials, cust_surname_company,
                      master_cust_id, cust_dir_listing_ind,
                      cust_date_commenced, cust_last_amended_date, cust_last_amended_user) 
              values 
                     (@custID, @custTitle, @custInitials, @tmp_in_cust_surname,
                      @masterCustID, 'Y', rd.today(), @now, @in_username)
                      
              if @@error <> 0
              begin
                  select @status=-1
                  select @description='SQL Error '+convert(varchar(6),@@error)+' creating recipient'
              end
                
              -- Create the customer_address_moves record linking the
              -- recipient to the master's address but with its own dp_id.
              if @status = 0
              begin
                  insert into customer_address_moves 
                         (adr_id, cust_id,dp_id, move_in_date, move_out_date) 
                  values 
                         (@masterAdrID, @custID, @in_dpid ,@now,null)
                         
                  if @@error <> 0
                    begin
                      select @status=-1
                      select @description='SQL Error '+convert(varchar(6),@@error)
                                          +' creating customer_address_moves record for recipient'
                  end
              end
              select @msg='New recipient = '+convert(varchar(8),@custID)
                          +', at masters adr_id = '+convert(varchar(8),@masterAdrID)
          end
      end
  end
    
  -- If the road doesn't already exist in the suburb, create it.
  if @status = 0
  begin
      if @slID is not null
          if not exists(select 1 from road_suburb 
                         where sl_id = @slID 
                           and road_id = @roadID)
          begin
              insert into road_suburb ( sl_id, road_id) 
              values ( @slID, @roadID )
              if @@error <> 0
              begin
                  select @status=-1
                  select @description='SQL Error '+convert(varchar(6),@@error)+' creating road_suburb record'
              end
          end
  end
  
  /************************************************************
   * Done.  Return status
   ***********************************************************/
  if @status = 0
  begin
      commit transaction -- Commit the changes    
      select @description = 'Success'+' - '+@msg
      if @routeErrMsg != '' 
          select @description = @description + '; ' + @routeErrMsg
      else     -- TJB 24 Feb 2011  Added "@nRoutesAddedTo routes" to message
          select @description = @description + '; ' + convert(varchar(7),@nRoutesAddedTo) + ' routes'
  end
  else
      rollback transaction

  -- Log the message
  select @msg=isnull(convert(varchar(20),@in_adr_no),'NULL')+','
              +isnull(@tmp_in_adr_alpha,'NULL')+','
              +isnull(convert(varchar(8),@in_unique_road_id),'NULL')+','
              +isnull(convert(varchar(8),@in_sl_id),'NULL')+','
              +isnull(convert(varchar(8),@in_tc_id),'NULL')+','
              +isnull(@tmp_in_rdno,'NULL')+','
              +isnull(@in_post_code,'NULL')+','
              +isnull(@tmp_in_adr_unit,'NULL')+','
              +isnull(@tmp_in_cust_surname,'NULL')+','
              +isnull(@tmp_in_cust_initials,'NULL')+','
              +isnull(@tmp_in_cust_title,'NULL')+','
              +isnull(convert(varchar(8),@in_master_cust_dpid),'NULL')
  
  insert into rd.NPAD_msg_log 
      (msg_date, msg_username, msg_type, msg_dpid, msg_status, msg_description) 
  values
      (@now, @in_username, 'create address', @in_dpid, @status, @msg)
      
  -- Return status
  select status=@status, description=@description 
  return @status
end