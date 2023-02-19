

--
-- Definition for user-defined function f_GetFuelRates_whatif : 
--

create function  [rd].[f_GetFuelRates_whatif](@in_contractNo int,@inSequenceNo int,@inEffDate datetime)
-- TJB 4635 - Sept 04
-- Variation on f_getFuelRates for whatif calculation
-- Drops RG_Code from selection condition (see below)
-- See also f_getConsumptionRates_whatif, getContractDelDays_whatif, f_getInsurance_whatif
returns numeric(12,2)
as -- Called from sp_getWhatifCalc2001c
begin

  declare @vn_fuelrate numeric(12,2)
  select @vn_fuelrate=fuel_rates.fr_fuel_rate 
    from fuel_type,
    fuel_rates,
    contract_vehical,
    vehicle,
    contract,
    contract_renewals where
    contract_vehical.contract_no = @in_contractNo and
    contract_vehical.contract_seq_number = @inSequenceNo and
    contract_renewals.contract_no = contract_vehical.contract_no and
    contract_renewals.contract_seq_number = contract_vehical.contract_seq_number and
    contract.contract_no = contract_renewals.contract_no and
    -- TJB 4635
    -- and contract.rg_code = fuel_rates.rg_code 
    fuel_type.ft_key = fuel_rates.ft_key and
    vehicle.ft_key = fuel_type.ft_key and
    vehicle.vehicle_number = contract_vehical.vehicle_number and
    contract_vehical.vehicle_number = rd.f_GetLatestVehicle(@in_contractNo,@inSequenceNo) and
    fuel_rates.rr_rates_effective_date = @inEffDate
  return @vn_fuelrate
end