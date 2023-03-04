
--
-- Definition for stored procedure updatephones : 
--

create procedure [rd].[updatephones]
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  update contractor set c_phone_day = rd.f_transform_telno(c_phone_day) where c_phone_day is not null
  if @@ERROR < 0
    begin
      rollback transaction
      return(-1)
    end
  commit transaction
  update contractor set c_phone_night = rd.f_transform_telno(c_phone_night) where c_phone_night is not null
  if @@ERROR < 0
    begin
      rollback transaction
      return(-2)
    end
  commit transaction
  update contract_renewals set con_relief_driver_home_phone = rd.f_transform_telno(con_relief_driver_home_phone) where con_relief_driver_home_phone is not null
  if @@ERROR < 0
    begin
      rollback transaction
      return(-3)
    end
  commit transaction
  update outlet set o_telephone = rd.f_transform_telno(o_telephone) where o_telephone is not null
  if @@ERROR < 0
    begin
      rollback transaction
      return(-4)
    end
  commit transaction
  update outlet set o_fax = rd.f_transform_telno(o_fax) where o_fax is not null
  if @@ERROR < 0
    begin
      rollback transaction
      return(-5)
    end
  commit transaction
  update region set rgn_telephone = rd.f_transform_telno(rgn_telephone) where rgn_telephone is not null
  if @@ERROR < 0
    begin
      rollback transaction
      return(-6)
    end
  commit transaction
  update region set rgn_fax = rd.f_transform_telno(rgn_fax) where rgn_fax is not null
  if @@ERROR < 0
    begin
      rollback transaction
      return(-7)
    end
  commit transaction
  update userids set u_phone = rd.f_transform_telno(u_phone) where u_phone is not null
  if @@ERROR < 0
    begin
      rollback transaction
      return(-8)
    end
  commit transaction
  update customer set cust_phone_day = rd.f_transform_telno(cust_phone_day) where cust_phone_day is not null
  if @@ERROR < 0
    begin
      rollback transaction
      return(-9)
    end
  commit transaction
  update customer set cust_phone_night = rd.f_transform_telno(cust_phone_night) where cust_phone_night is not null
  if @@ERROR < 0
    begin
      rollback transaction
      return(-10)
    end
  commit transaction
  return 0
end