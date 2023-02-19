
--
-- Definition for user-defined function f_GetConsumptionRates : 
--

create function [rd].[f_GetConsumptionRates](@in_contractNo int,@inSequenceNo int,@inEffDate datetime)
returns numeric(12,2)
AS
BEGIN

  declare @vn_ConsumptionRate numeric(12,2)
  select @vn_ConsumptionRate = fuel_rates.fr_fuel_consumtion_rate
    from fuel_type,
    fuel_rates,
    contract_vehical,
    vehicle,
    contract,
    contract_renewals where
    contract_renewals.contract_no = contract_vehical.contract_no and
    contract_renewals.contract_seq_number = contract_vehical.contract_seq_number and
    contract_renewals.contract_no = contract.contract_no and
    contract.rg_code = fuel_rates.rg_code and
    fuel_type.ft_key = fuel_rates.ft_key and
    vehicle.ft_key = fuel_type.ft_key and
    vehicle.vehicle_number = contract_vehical.vehicle_number and
    contract_vehical.vehicle_number = rd.f_GetLatestVehicle(@in_contractNo,@inSequenceNo) and
    contract_vehical.contract_no = @in_contractNo and
    contract_vehical.contract_seq_number = @inSequenceNo and
    fuel_rates.rr_rates_effective_date = @inEffDate
  return @vn_ConsumptionRate
end