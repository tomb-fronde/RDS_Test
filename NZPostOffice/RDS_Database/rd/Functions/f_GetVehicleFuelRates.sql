/*
 select [rd].[f_GetVehicleFuelRates]( 50216, 2, 4177, '1-Apr-2020')
 select [rd].[f_GetVehicleFuelRates]( 50216, 2, 2067, '1-Apr-2020')
*/
CREATE function [rd].[f_GetVehicleFuelRates](
	  @inContractNo        int
	, @inContractSeqNumber int
	, @inVehicleNumber     int
	, @inEffDate      datetime)
returns numeric(12,2)
AS
BEGIN
  --  TJB  Frequencies and Values  Dec-2020 NEW
  --  Gets the fuel rates for a specifc vehicle 
  --  Adapted from f_GetFuelRates()

  declare @vn_fuelrate numeric(12,2)

  select top 1
         @vn_fuelrate = fuel_rates.fr_fuel_rate
    from rd.contract_vehical,
         rd.contract,
         rd.vehicle,
         rd.fuel_type,
         rd.fuel_rates
   where contract_vehical.contract_no = @inContractNo 
     and contract_vehical.contract_seq_number = @inContractSeqNumber 
     and contract_vehical.vehicle_number = @inVehicleNumber
     and contract.contract_no = contract_vehical.contract_no 
     and vehicle.vehicle_number = contract_vehical.vehicle_number 
     and fuel_type.ft_key  = vehicle.ft_key
     and fuel_rates.rg_code  = contract.rg_code
     and fuel_rates.ft_key  = fuel_type.ft_key
     and fuel_rates.rr_rates_effective_date <= @inEffDate
   order by fuel_rates.rr_rates_effective_date desc
   
  return @vn_fuelrate
END