
--
-- Definition for user-defined function f_GetLatestConVehicle : 
--

create function [rd].[f_GetLatestConVehicle](@in_contractNo int)
returns int
AS
BEGIN

  declare @vn_vehicle_number int
  select @vn_vehicle_number=max(cv.vehicle_number) 
    from contract_vehical as cv where
    cv.contract_no = @in_contractNo and
    cv.contract_seq_number = (select max(contract_seq_number) from
      contract_vehical as cv1 where
      cv1.contract_no = @in_contractNo)
  return @vn_vehicle_number
end