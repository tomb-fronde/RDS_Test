
-- EXEC rd.freq_change_bulk 'YNYNYNN', 3, 'Change frequency 6 days/wk to 5 (Mon-Fri)'
CREATE PROCEDURE rd.freq_change_bulk( 
	  @new_delivery_days char(7)
	, @new_sf_key int
	, @new_reason varchar(40) = NULL)
AS
---------------------------------------------------------------
-- TJB  Nov 2013: NEW                                        --
-- This procedure steps through the t_freq_change_contract   --
-- table populated by the freq_change_select procedure       --
-- calling freq_change_single to change the contracts'       --
-- frequency.                                                --
---------------------------------------------------------------
BEGIN
   declare @contract_no int
   declare @old_sf_key int
   declare @old_delivery_days char(7)

   ------------------------------------------------------------------------------
   -- Do some basic error checking
   ------------------------------------------------------------------------------

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

   -- Check to see if the new frequency already exists for any of the contracts
   if exists (select 1 from rd.route_frequency rf, rd.t_freq_change_contracts t
               where rf.contract_no = t.contract_no
                 and rf.sf_key = @new_sf_key
                 and rf.rf_delivery_days = @new_delivery_days
                 -- and rf.rf_active = 'Y'
              )
   begin
       -- If so, tell the user, identifying the culprits.
       select t.contract_no as 'WARNING - New frequency exists for these contracts - no contracts changed!'
         from rd.route_frequency rf, rd.t_freq_change_contracts t
        where rf.contract_no = t.contract_no
          and rf.sf_key = @new_sf_key
          and rf.rf_delivery_days = @new_delivery_days
          -- and rf.rf_active = 'Y'

       return
   end

   ------------------------------------------------------------------------------
   -- OK to proceed
   ------------------------------------------------------------------------------
   -- Create a cursor and step through the work table changing the frequency 
   -- for each contract by calling the freq_change_single proc.
   declare cur_change_freq cursor for
       select t.contract_no, t.sf_key, t.rf_delivery_days
         from rd.t_freq_change_contracts t

   open cur_change_freq

   fetch next from cur_change_freq
      into @contract_no, @old_sf_key, @old_delivery_days

   while ( @@fetch_status <> -1 )
   begin
       exec rd.freq_change_single @contract_no, @old_delivery_days, @old_sf_key
                                , @new_delivery_days, @new_sf_key, @new_reason

       fetch next from cur_change_freq
          into @contract_no, @old_sf_key, @old_delivery_days
   end

   close cur_change_freq

END