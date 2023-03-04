
--
-- Definition for stored procedure sp_DDDW_Routefreq_new : 
--

create procedure [rd].[sp_DDDW_Routefreq_new](@cno int,@sfk int)
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  select route_frequency.contract_no,
    route_frequency.sf_key,
    route_frequency.rf_delivery_days from
    route_frequency where
    (route_frequency.rf_active = 'Y') and
    ((route_frequency.contract_no = @cno and @cno is not null and @cno > -1) or
    (1 = 1 and @cno = -1)) and
    ((route_frequency.sf_key = @sfk and @sfk is not null and @sfk > -1) or
    (@sfk = -1))
end