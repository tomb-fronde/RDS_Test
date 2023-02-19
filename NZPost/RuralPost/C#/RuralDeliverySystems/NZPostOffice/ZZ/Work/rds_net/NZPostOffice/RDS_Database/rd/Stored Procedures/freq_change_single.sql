
CREATE PROCEDURE rd.freq_change_single( 
	  @contract_no int
	, @old_delivery_days char(7)
	, @old_sf_key int
	, @new_delivery_days char(7)
	, @new_sf_key int
	, @new_reason varchar(250) = null)
AS
----------------------------------------------------------
-- TJB  Nov 2013: NEW                                   --
-- This procedure will change a contract's frequency.   --
-- Called either from the freq_change_bulk procedure or --
-- manually to change a sincle contract's frequency.    --
----------------------------------------------------------
-- TJB  Dec-2013
-- Added delivery hrs/wk calculation for frequency_distances
-- Made parameter @new_reason optional with default value
-- Added insert into frequency_distances for old sf_key to save reason for change
BEGIN
   declare @today datetime
   select @today = rd.Date(getdate())

   ------------------------------------------------------------------------------
   -- Do some basic error checking
   ------------------------------------------------------------------------------

   -- Check to see if the frequency to be changed is valid
   if not exists (select 1 from rd.route_frequency
                   where contract_no = @contract_no
                     and sf_key = @old_sf_key
                     and rf_delivery_days = @old_delivery_days
                     and rf_active = 'Y')
   begin
       select 'Old frequency ' + @old_delivery_days
             + ' key ' + convert(varchar,@old_sf_key)
             + ' not found or is inactive for contract ' + convert(varchar,@contract_no)
             + ' - not changed.'
             as ERROR
       return
   end

   -- Check to see if the new frequency's sf_key exists: return error if not.
   if not exists (select 1 from rd.standard_frequency
                   where sf_key = @new_sf_key)
   begin
       select 'New sf_key ' + convert(varchar,@new_sf_key)
             + ' does not exist - not changed.'
              as ERROR
       return
   end

   -- Check to see if the new frequency's sf_key number of delivery days
   -- is the same as the new frequency's: return error if not.
   if not exists (select 1 from rd.standard_frequency
               where sf_key = @new_sf_key
                 and sf_days_week = rd.f_numFreqDeliveryDays(@new_delivery_days)
             )
   begin
       select 'New sf_key''s days_week does not match the frequency''s '
              as ERROR
       return
   end

   -- Check to see if the new frequency already exists for this contract
   if exists (select 1 from rd.route_frequency
               where contract_no = @contract_no
                 and sf_key = @new_sf_key
                 and rf_delivery_days = @new_delivery_days)
   begin
       select 'New frequency ' + @new_delivery_days
              + ' key ' + convert(varchar,@new_sf_key)
              + ' already exists for contract ' + convert(varchar,@contract_no)
              + ' - not changed.'
              as ERROR
       return
   end

   ------------------------------------------------------------------------------
   -- Add the new frequency for this contract
   --
   -- Create new route_frequency (initially inactive) and frequency_distance records
   -- Alter the frequency columns for associated mail_carried , route_description
   -- and address_frequency and address_frequency_sequence records.
   ------------------------------------------------------------------------------

   ------------------------------------------------------------------------------
   -- Create a route_frequency record for the new frequency, initially inactive
   -- This must be first since the others (below) use this as a foreign key
   insert into rd.route_frequency
        ( contract_no, sf_key, rf_delivery_days
        , rf_active, rf_valid_ind, rf_valid_date, rf_valid_user
        , rf_distance, rf_annotation, rf_annotation_print)
   select @contract_no, @new_sf_key, @new_delivery_days
        , 'N', 1, @today, 'admin'
        , rf_distance, rf_annotation, rf_annotation_print
     from rd.route_frequency
    where contract_no = @contract_no
      and sf_key = @old_sf_key
      and rf_delivery_days = @old_delivery_days
      
   ------------------------------------------------------------------------------
   -- Create a frequency_distances records for the old and new frequencies
   declare @diff_delivery_hrs_per_week numeric(6,3)
         , @diff_delivery_hrs_txt varchar(40)
         , @reason varchar(250)

   -- Determine the change in the delivery hours per week
       
   select @diff_delivery_hrs_per_week 
                = rd.f_getChangeDelHrsWeek( @contract_no, @old_sf_key, @new_sf_key )
                    
   -- Insert a record for the old frequency
   -- This simply includes the reason for the change: either the one supplied
   -- or a default

   -- Set up the default reason.  
   if @new_reason is null or ltrim(rtrim(@new_reason)) = ''
       set @reason ='Changed frequency '+@old_delivery_days
                           + ' to '+@new_delivery_days
   else
       set @reason = @new_reason
       
   INSERT INTO rd.frequency_distances
        ( contract_no, sf_key, rf_delivery_days, 
          fd_effective_date, fd_change_reason, fd_delivery_hrs_per_week)
   VALUES
        ( @contract_no, @old_sf_key, @old_delivery_days, 
          @today, @reason, null )

   -- Insert a record for the new frequency
   -- This includes the reason for the change and the change in delivery hours.
   -- The reason is either the one supplied or a default with the delivery hours change

   if @new_reason is null or ltrim(rtrim(@new_reason)) = ''
   begin
       -- For the default reason, the delivery hours are either the actual change
       -- or 'not determined' if a change wasn't able to be determined (see f_getChangeDelHrsWeek).
       if @diff_delivery_hrs_per_week is null or @diff_delivery_hrs_per_week = 0
           set @diff_delivery_hrs_txt = 'not determined'
       else
           set @diff_delivery_hrs_txt = convert(varchar,@diff_delivery_hrs_per_week)

       set @reason = @reason + '; delivery time change '+@diff_delivery_hrs_txt
   end

   INSERT INTO rd.frequency_distances
        ( contract_no, sf_key, rf_delivery_days, 
          fd_effective_date, fd_change_reason, fd_delivery_hrs_per_week )
   VALUES
        ( @contract_no, @new_sf_key, @new_delivery_days, 
          @today, @reason, @diff_delivery_hrs_per_week )
   
   ------------------------------------------------------------------------------
   -- If there are existing mail_carried records for the frequency being replaced, 
   -- create copies for the new frequency from the ones being replaced
   if exists (select 1 from rd.mail_carried
               where contract_no = @contract_no
                 and sf_key = @old_sf_key
                 and rf_delivery_days = @old_delivery_days)
   begin
       update rd.mail_carried
          set sf_key = @new_sf_key
            , rf_delivery_days = @new_delivery_days
        where contract_no = @contract_no
          and sf_key = @old_sf_key
          and rf_delivery_days = @old_delivery_days
   end
    
   ------------------------------------------------------------------------------
   -- If there are existing route_description records for the frequency being 
   -- replaced, create copies for the new frequency from the ones being replaced
   if exists (select 1 from rd.route_description
               where contract_no = @contract_no
                 and sf_key = @old_sf_key
                 and rf_delivery_days = @old_delivery_days)
   begin
       UPDATE rd.route_description
          SET sf_key           = @new_sf_key
            , rf_delivery_days = @new_delivery_days
        where contract_no = @contract_no
          and sf_key = @old_sf_key
          and rf_delivery_days = @old_delivery_days
   end

   ------------------------------------------------------------------------------
   -- If there are existing address_frequency_sequence records for the frequency being 
   -- replaced, create copies for the new frequency from the ones being replaced
   if exists (select 1 from rd.address_frequency_sequence
               where contract_no = @contract_no
                 and sf_key = @old_sf_key
                 and rf_delivery_days = @old_delivery_days)
   begin
       UPDATE rd.address_frequency_sequence
          SET sf_key           = @new_sf_key
            , rf_delivery_days = @new_delivery_days
        WHERE contract_no = @contract_no
          AND sf_key = @old_sf_key
          AND rf_delivery_days = @old_delivery_days
   end

   ------------------------------------------------------------------------------
   -- If there are existing address_frequency records for the frequency being 
   -- replaced, create copies for the new frequency from the ones being replaced
   -- (NOTE: the address_frequency table may be obsolete - tjb, Nov 2013)
   if exists (select 1 from rd.address_frequency
               where contract_no = @contract_no
                 and sf_key = @old_sf_key
                 and rf_delivery_days = @old_delivery_days)
   begin
       UPDATE rd.address_frequency
          SET sf_key           = @new_sf_key
            , rf_delivery_days = @new_delivery_days
        WHERE contract_no = @contract_no
          AND sf_key = @old_sf_key
          AND rf_delivery_days = @old_delivery_days
   end

   ------------------------------------------------------------------------------
   -- Now make the old record inactive and the new one active
   ------------------------------------------------------------------------------
   -- Wrap it in a transaction so it appears to happen all at once
   begin tran
   update rd.route_frequency
      set rf_active = 'N'
    where contract_no = @contract_no
      and sf_key = @old_sf_key
      and rf_delivery_days = @old_delivery_days

   update rd.route_frequency
      set rf_active = 'Y'
    where contract_no = @contract_no
      and sf_key = @new_sf_key
      and rf_delivery_days = @new_delivery_days

   commit tran
END