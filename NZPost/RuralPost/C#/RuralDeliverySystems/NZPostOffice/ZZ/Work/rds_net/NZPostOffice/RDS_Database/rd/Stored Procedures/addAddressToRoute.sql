
CREATE PROCEDURE [rd].[addAddressToRoute](
	@inAddress_id  int, 
	@inContract_no int, 
	@inRoad_id     int)
AS
BEGIN
-- ========================================================================
-- Author:	Tom Britton
-- Create date: 23-Dec-2010
-- Description:	
--      Add a (new) address to the address_frequency table
--      Fails if the route frequency to use is ambiguous (throws exception)
--      Unambiguous if the contract has only one active frequency
--              or all addresses on the same road have the same frequencies
--
-- Modifications
-- 18-Jan-2013 TJB  Fixup
--      Added code to add the number of delivery days to the adr_delivery_days 
--      column in the address record.
--  1-Mar-2011 TJB  Release 7.1.5 Bug-fix
--      Added check to see if different numbers of addresses (on the new 
--      address' road) are on the contract's routes.  If so, the route(s)
--      this address can be added to is ambiguous and the address isn't
--      added to any route.
-- 24-Feb-2011 TJB  Release 7.1.5 Bug-fix
--      Changed so that, where a contract has several routes, the address
--      is added to all routes where all other addresses on the same road 
--      are all on the route.
-- ========================================================================
  declare @num_routes int
        , @sf_key int
        , @delivery_days char(7)
        , @numDeliveryDays int

  set @sf_key = -1
  set @delivery_days = ''

  -- Determine the number of routes in contract
  select @num_routes = count(distinct(convert(varchar,rf.sf_key)+rf.rf_delivery_days) )
    from route_frequency rf
   where contract_no = @inContract_no
     and rf_active = 'Y'

  -- If the contract has only one route
  if @num_routes = 1
  begin
    -- Determine the route details
    select top(1) 
           @sf_key = af.sf_key
         , @delivery_days = af.rf_delivery_days
      from address_frequency af, address a
     where af.contract_no = a.contract_no
       and a.contract_no = @inContract_no

    -- Add the address to the address_frequency table
    if exists (select 1 from address_frequency
                where adr_id = @inAddress_id)
    begin
       raiserror('Address already exists in route.',12,1)
    end
    else
    begin
      insert into address_frequency
          (adr_id ,sf_key ,rf_delivery_days ,contract_no)
      values
          (@inAddress_id, @sf_key, @delivery_days, @inContract_no)
    end
  end
  else
    -- The contract has more than one route.  See if there are any routes 
    -- where all addresses on the road are on the route.  In such cases, add 
    -- this (new) address to those routes.
  begin
    declare @num_addresses int
    declare @tmp_count     int

    -- Get the number of addresses on this road for this contract    
    select @num_addresses = count(*)
      from address
     where contract_no = @inContract_no
       and road_id = @inRoad_id

    -- Determine number of routes this contract has and the number of addresses 
    -- on the new address' road on each of those routes.
    -- Create a temporary table to hold the routes where there are addresses on 
    -- this road and the number of such addresses on the route.
    create table #tmp_addr_freq (
        sf_key            int      not null,
        rf_delivery_days  char(7)  not null,
        num_addresses     int          null
        )

    -- Populate the temporary table with the route identification and the number 
    -- of addresses on the road for each of those routes.
    insert into #tmp_addr_freq
        (sf_key, rf_delivery_days, num_addresses)
    select distinct af.sf_key, af.rf_delivery_days, count(*)
      from address_frequency af, address a, route_frequency rf
     where a.contract_no = af.contract_no
       and af.contract_no = @inContract_no
       and a.road_id = @inRoad_id
       and af.adr_id = a.adr_id
       and rf.contract_no = af.contract_no
       and rf.sf_key = af.sf_key
       and rf.rf_delivery_days = af.rf_delivery_days
       and rf.rf_active = 'Y'
     group by af.sf_key, af.rf_delivery_days

    -- Now, add this address to each of this contract's routes where all the addresses
    -- on this road are on all of the routes.  If any of the contract's routes have some, 
    -- but not all, of the road's addresses, then it is ambiguous which routes the address 
    -- should be added to, and so it isn't added to any.
    --
    -- NOTE: the new address has been added to the address table, so the 
    --       number of addresses there will be 1 more than are in the
    --       address_frequency table when 'all' are in a route (hence 
    --       the "(@num_addresses - 1)").
    
    -- Check to see if all the routes have the all the addresses (excluding the new address)
    select @tmp_count = count(*) 
      from #tmp_addr_freq
     where num_addresses != (@num_addresses - 1)

    -- If any routes have different numbers of this road's addresses, we have a situation
    -- where it is ambiguous as to which route(s) to add the new address to, and we don't 
    -- add it to any.
    if ( @tmp_count > 0 )
    begin
         raiserror('Ambiguous route: not added',12,1)
    end

    -- The address can be added to all the routes

    -- Check that the address isn't already on the route
    -- (since this is supposed to be a new address it shouldn't already be on the route)
    if exists (select 1 from address_frequency
                where contract_no = @inContract_no
                  and adr_id = @inAddress_id)
    begin
       raiserror('Address already exists in route.',12,1)
    end
    else
    -- Add the address to each of the routes where all other addresses 
    -- on the same road are on the route
    begin
      insert into address_frequency
          (adr_id ,sf_key ,rf_delivery_days ,contract_no)
     select @inAddress_id, sf_key, rf_delivery_days, @inContract_no
       from #tmp_addr_freq
      where num_addresses = (@num_addresses - 1)
    end

    drop table #tmp_addr_freq
  end
  
  -- Set the adr_delivery_days value in the address record
  select @numDeliveryDays = rd.f_getAdrDeliveryDays(@inAddress_id)
  update rd.address
     set adr_delivery_days = @numDeliveryDays
   where adr_id = @inAddress_id
   
END