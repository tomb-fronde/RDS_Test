
-- EXEC rd.freq_change_select 'YYYYYYN', 8, NULL, 'Chr'
-- EXEC rd.freq_change_select 'YYYYYYN', 8, @rg_description = 'Non'
-- EXEC rd.freq_change_select 'YNYNYNN', 3
CREATE PROCEDURE rd.freq_change_select(
      @delivery_days char(7)
    , @sf_key int = null
    , @region_id int = null
    , @rgn_name varchar(40) = null
    , @rg_code int = null
    , @rg_description varchar(30) = null
	)
AS
---------------------------------------------------------------
-- TJB  Nov 2013: NEW                                        --
-- This procedure selects the contracts whose frequency      --
-- meets the selection criteria, placing the results in the  --
-- t_freq_change_contract table.  The results are returned   --
-- for display to the operator.                              -- 
-- The information in the table are used by the procedure    --
-- freq_change_bulk to change the contracts' frequency.      --
---------------------------------------------------------------
BEGIN
   delete from  rd.t_freq_change_contracts

   ------------------------------------------------------------------------------
   -- Check that the sf_key and/or delivery days have been specified
   ------------------------------------------------------------------------------
   if (@sf_key is null or @sf_key = 0)
      and (@delivery_days is null or @delivery_days = '')
   begin
       select 'You must enter either an sf_key or delivery_days (preferably both)'
              as 'ERROR'
       return
   end

   ------------------------------------------------------------------------------
   -- Do the select putting the results in the work table
   ------------------------------------------------------------------------------
   insert into rd.t_freq_change_contracts
        ( contract_no, sf_key, rf_delivery_days
        , region_id, rgn_name
        , rg_code, rg_description)
   select rf.contract_no, rf.sf_key, rf.rf_delivery_days
        , r.region_id, r.rgn_name
        , rg.rg_code, rg.rg_description
     from rd.route_frequency rf
        , rd.region r, rd.outlet o, [rd].[contract] c
        , rd.renewal_group rg
    where (rf.sf_key = @sf_key 
               or @sf_key is null or @sf_key = 0)
      and (rf.rf_delivery_days = @delivery_days 
               or @delivery_days is null or @delivery_days = '')
      and rf.rf_active = 'Y'
      and c.contract_no = rf.contract_no
      and o.outlet_id = c.con_base_office
      and r.region_id = o.region_id
      and ((r.region_id = @region_id)
          or ((@region_id is null or @region_id = 0)
               and r.rgn_name like @rgn_name+'%')
          or ((@region_id is null or @region_id = 0)
               and (@rgn_name is null or @rgn_name = '')))
      and rg.rg_code = c.rg_code
      and ((rg.rg_code = @rg_code)
          or ((@rg_code is null or @rg_code = 0)
               and rg.rg_description like @rg_description+'%')
          or ((@rg_code is null or @rg_code = 0)
               and (@rg_description is null or @rg_description = '')))
    order by contract_no

   ------------------------------------------------------------------------------
   -- If there were some results from the select, display them
   -- If not, display a warning message
   ------------------------------------------------------------------------------
    if 0 = (select count(*) from rd.t_freq_change_contracts)
        select 'No contracts selected' as WARNING
    else
        select contract_no, sf_key, rf_delivery_days
             , region_id, rgn_name
             , rg_code, rg_description
          from rd.t_freq_change_contracts
        order by contract_no

END