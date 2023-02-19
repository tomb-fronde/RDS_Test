
--
-- Definition for stored procedure sp_Extension_Deliverytime : 
--

create procedure [rd].[sp_Extension_Deliverytime]
AS
BEGIN
  select del_hours_variables.dhv_travelling_speed,
    del_hours_variables.dhr_seconds_customer from
    rd.del_hours_variables
end