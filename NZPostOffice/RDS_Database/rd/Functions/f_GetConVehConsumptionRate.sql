
--
-- Definition for user-defined function f_GetConVehConsumptionRate : 
--

create function [rd].[f_GetConVehConsumptionRate](@incontractNo int,@inSequenceNo int,@inVehicleNo int)
returns numeric(12,2)
-- TJB SR4633 14-Oct-2004  - New
-- Get fuel consumption rate for a specific vehicle in a contract 
-- Used to get the consumption rate for the previous vehicle in a contract 
-- when a new vehicle has been added and a frequency adjustment may 
-- need to be created.
as -- Based on f_getConsumptionRates.
begin

  declare @vn_ConsumptionRate numeric(12,2)
  select @vn_ConsumptionRate = fuel_rates.fr_fuel_consumtion_rate
    from fuel_type,
    fuel_rates,
    contract_vehical,
    vehicle,
    contract,
    contract_renewals where
    contract_vehical.contract_no = @inContractNo and
    contract_vehical.contract_seq_number = @inSequenceNo and
    contract_vehical.vehicle_number = @inVehicleNo and
    vehicle.vehicle_number = contract_vehical.vehicle_number and
    fuel_type.ft_key = vehicle.ft_key and
    fuel_rates.ft_key = fuel_type.ft_key and
    contract_renewals.contract_no = contract_vehical.contract_no and
    contract_renewals.contract_seq_number = contract_vehical.contract_seq_number and
    fuel_rates.rr_rates_effective_date = contract_renewals.con_rates_effective_date and
    contract.contract_no = contract_renewals.contract_no and
    fuel_rates.rg_code = contract.rg_code
  return @vn_ConsumptionRate
end