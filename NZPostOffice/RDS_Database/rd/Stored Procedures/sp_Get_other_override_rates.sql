
CREATE procedure [rd].[sp_Get_other_override_rates](
	  @inContractNo int
	, @inSequenceNo int
	, @inVehicleNo  int)
-- TJB  Frequencies & Vehicles  15-Jan-2021
-- Added vehicle_number parameter
AS
BEGIN
  
  set NOCOUNT on
  set CONCAT_NULL_YIELDS_NULL off
  
  select mor.contract_no
       , mor.contract_seq_number
       , mor.mor_name
       , mor.mor_value
       , mor.mor_km_flag
       , mor.mor_annual_flag 
       , mor.vehicle_number
    from misc_override_rate mor
   where mor.contract_no         = @inContractNo 
     and mor.contract_seq_number = @inSequenceNo
     and (mor.vehicle_number = @inVehicleNo
           or mor.vehicle_number is null
           or @inVehicleNo is null)
     
end