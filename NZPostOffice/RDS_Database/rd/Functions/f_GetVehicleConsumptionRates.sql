
-- select [rd].[f_GetVehicleConsumptionRates]( 5109, 25, 4114, '1-Nov-2020' )

CREATE function [rd].[f_GetVehicleConsumptionRates](
	  @inContractNo        int
	, @inContractSeqNumber int
	, @inVehicleNumber     int
	, @inEffDate     datetime)
returns numeric(12,2)
AS
BEGIN
  -- TJB Frequencies and Vehicles Dec 2020 NEW
  -- Gets the consumption rate for a specifc vehicle
  -- Adapted from f_GetConsumptionRates()
  
  declare @vn_ConsumptionRate numeric(12,2)
  
  select top 1
         @vn_ConsumptionRate = fuel_rates.fr_fuel_consumtion_rate
    from rd.fuel_type
       , rd.fuel_rates
       , rd.contract_vehical
       , rd.vehicle
       , rd.contract
       , rd.contract_renewals 
   where
         contract_renewals.contract_no = contract_vehical.contract_no 
     and contract_renewals.contract_seq_number = contract_vehical.contract_seq_number 
     and contract_renewals.contract_no = contract.contract_no 
     and contract.rg_code = fuel_rates.rg_code 
     and fuel_type.ft_key = fuel_rates.ft_key 
     and vehicle.ft_key = fuel_type.ft_key 
     and vehicle.vehicle_number = contract_vehical.vehicle_number 
     and contract_vehical.vehicle_number = @inVehicleNumber 
     and contract_vehical.contract_no = @inContractNo 
     and contract_vehical.contract_seq_number = @inContractSeqNumber 
     and fuel_rates.rr_rates_effective_date <= @inEffDate
   order by fuel_rates.rr_rates_effective_date desc
     
  return @vn_ConsumptionRate
END