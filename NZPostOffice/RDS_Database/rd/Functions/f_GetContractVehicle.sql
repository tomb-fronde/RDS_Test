
-- select [rd].[f_GetContractVehicle](5000, 24)

CREATE FUNCTION [RD].[f_GetContractVehicle] (
            @inContractNo int
          , @inSequenceNo int)
-- TJB Frequencies & Vehicles  16-Feb-2021  NEW
-- Gets the most-frequently referenced vehicle associated  
-- with the indicated contract.
RETURNS int  -- vehicle_number
AS
BEGIN
  declare @VehicleNumber  int
        , @Count          int
        
  select top 1 @count = count(*)
             , @VehicleNumber = rf.vehicle_number
    from rd.route_frequency rf
       , rd.contract_vehical cv
   where cv.contract_no = @inContractNo
     and cv.contract_seq_number = @inSequenceNo
     and rf.contract_no = cv.contract_no
     and rf.vehicle_number = cv.vehicle_number
     and rf.rf_active = 'Y'
   group by rf.vehicle_number, cv.cv_vehical_status
   order by 1 desc, rf.vehicle_number
  
  return @VehicleNumber
END