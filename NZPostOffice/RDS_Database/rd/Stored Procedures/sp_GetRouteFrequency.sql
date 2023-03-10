
--
-- Definition for stored procedure sp_GetRouteFrequency : 
--

create procedure [rd].[sp_GetRouteFrequency](@in_Contract int)
AS
BEGIN
  select contract_no,
    sf_key,
    rf_delivery_days,
    rf_active,
    rf_monday=substring(rf_delivery_days,1,1),
    rf_tuesday=substring(rf_delivery_days,2,1),
    rf_wednesday=substring(rf_delivery_days,3,1),
    rf_thursday=substring(rf_delivery_days,4,1),
    rf_friday=substring(rf_delivery_days,5,1),
    rf_saturday=substring(rf_delivery_days,6,1),
    rf_sunday=substring(rf_delivery_days,7,1),
    rf_distance from
    route_frequency where
    contract_no = @in_Contract
end