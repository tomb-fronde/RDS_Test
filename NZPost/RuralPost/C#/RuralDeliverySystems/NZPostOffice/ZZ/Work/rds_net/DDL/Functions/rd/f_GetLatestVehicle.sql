/****** Object:  UserDefinedFunction [rd].[f_GetLatestVehicle]    Script Date: 08/05/2008 11:24:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for user-defined function f_GetLatestVehicle : 
--

--
-- Definition for user-defined function f_GetLatestVehicle : 
--

create function [rd].[f_GetLatestVehicle](@in_contractNo int,@inSequenceNo int)
returns int
AS
BEGIN

  declare @vn_vehicle_number int
  select @vn_vehicle_number=vehicle.vehicle_number 
    from contract_vehical,
    vehicle where
    vehicle.vehicle_number = contract_vehical.vehicle_number and
    contract_vehical.contract_no = @in_contractNo and
    contract_vehical.contract_seq_number = @inSequenceNo and
    isnull(vehicle.v_purchased_date,getdate()-10000) = 
    (select max(isnull(v.v_purchased_date,getdate()-10000)) from
      contract_vehical as cv,
      vehicle as v where
      v.vehicle_number = cv.vehicle_number and
      cv.contract_no = @in_contractNo and
      cv.contract_seq_number = @inSequenceNo)
  return @vn_vehicle_number
end
GO
