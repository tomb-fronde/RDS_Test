/****** Object:  UserDefinedFunction [rd].[f_GetConVehFuelRate]    Script Date: 08/05/2008 11:23:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for user-defined function f_GetConVehFuelRate : 
--

create function [rd].[f_GetConVehFuelRate](@inContractNo int,@inSequenceNo int,@inVehicleNo int)
returns numeric(12,2)
-- TJB SR4633 14-Oct-2004 
-- Get fuel rate for a specific vehicle in a contract 
-- Used to get the fuel rate for the previous vehicle in a contract 
-- when a new vehicle has been added and a frequency adjustment may 
-- need to be created.
as -- Based on f_getFuelRate.
begin

  declare @vn_fuelrate numeric(12,2)
  select @vn_fuelrate = fuel_rates.fr_fuel_rate
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
    contract_renewals.contract_no = contract_vehical.contract_no and
    contract_renewals.contract_seq_number = contract_vehical.contract_seq_number and
    contract.contract_no = contract_renewals.contract_no and
    fuel_rates.rr_rates_effective_date = contract_renewals.con_rates_effective_date and
    fuel_rates.ft_key = fuel_type.ft_key and
    fuel_rates.rg_code = contract.rg_code
  return @vn_fuelrate
end
GO
