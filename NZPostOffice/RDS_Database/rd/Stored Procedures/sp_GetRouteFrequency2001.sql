
--
-- Definition for stored procedure sp_GetRouteFrequency2001 : 
--

CREATE procedure [rd].[sp_GetRouteFrequency2001](
          @in_Contract int
        , @in_showAll int = 1)
AS
BEGIN
-- TJB  Release 7.1.9.3 fixup
-- Added default to @in_showAll parameter
--
-- TJB  RPCR_044  Jan-2013
-- Added in_showAll
--   == 1  Show all frequencies for this contract (original behaviour)
--   == 0  Show only active frequencies (rf_active == 'Y')
--
  set CONCAT_NULL_YIELDS_NULL off
  select route_frequency.contract_no,
         route_frequency.sf_key,
         route_frequency.rf_delivery_days,
         route_frequency.rf_active,
         rf_monday=substring(route_frequency.rf_delivery_days,1,1),
         rf_tuesday=substring(route_frequency.rf_delivery_days,2,1),
         rf_wednesday=substring(route_frequency.rf_delivery_days,3,1),
         rf_thursday=substring(route_frequency.rf_delivery_days,4,1),
         rf_friday=substring(route_frequency.rf_delivery_days,5,1),
         rf_saturday=substring(route_frequency.rf_delivery_days,6,1),
         rf_sunday=substring(route_frequency.rf_delivery_days,7,1),
         route_frequency.rf_distance,
         case when ((select count(*) 
                       from frequency_distances as fd,
                            contract as c,contract_renewals as cr 
                      where fd.contract_no = route_frequency.contract_no 
                        and fd.sf_key = route_frequency.sf_key 
                        and fd.rf_delivery_days = route_frequency.rf_delivery_days 
                        and fd.contract_no = c.contract_no 
                        and c.con_active_sequence = cr.contract_seq_number) > 0 ) 
              then 'Yes' 
              else 'No' 
              end  
    from route_frequency 
   where route_frequency.contract_no = @in_Contract
     and ((@in_showAll = 1)
           or (@in_showAll = 0 and route_frequency.rf_active = 'Y'))
  
end