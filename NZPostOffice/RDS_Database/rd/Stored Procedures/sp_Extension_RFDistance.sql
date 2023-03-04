
--
-- Definition for stored procedure sp_Extension_RFDistance : 
--

create procedure [rd].[sp_Extension_RFDistance](@inContract int,@inKey int,@indays char(100))
AS
BEGIN
  select rf_distance from
    route_frequency where
    contract_no = @inContract and
    sf_key = @inkey and
    rf_delivery_days = @indays
end