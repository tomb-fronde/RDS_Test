
-- select [rd].[f_VehicleName] 4290

CREATE FUNCTION [rd].[f_VehicleName] (@inVehicleNumber int)
RETURNS varchar(255)
-- TJB Frequencies and Vehicles  Dec-2020 NEW
-- Returns the name of a vehicle, where the name is
--    Registration_no + Vehicle_make + Vehicle_model
AS
BEGIN
  declare @VehicleName varchar(255)
  
  select @VehicleName = isnull(v.v_vehicle_registration_number,'')
                      + isnull(' '+v.v_vehicle_make,'') 
                      + isnull(' '+v.v_vehicle_model,'')
    from rd.vehicle v
   where v.vehicle_number = @inVehicleNumber

  RETURN @VehicleName
END