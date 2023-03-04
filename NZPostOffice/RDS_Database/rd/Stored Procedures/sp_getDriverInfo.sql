CREATE procedure [rd].[sp_getDriverInfo](
	@inDriverNo int)
AS
-- TJB  RPCR_060  Jan-2014: Created
-- Get drivers 'personal' info
BEGIN
  set CONCAT_NULL_YIELDS_NULL OFF
  select driver_no
       , d_title, d_first_names, d_surname
       , d_phone_day, d_phone_night, d_mobile, d_mobile2 
   from driver
   where driver_no = @inDriverNo

END