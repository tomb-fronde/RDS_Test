/****** Object:  UserDefinedFunction [rd].[f_GetFuelRates]    Script Date: 08/05/2008 11:23:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for user-defined function f_GetFuelRates : 
--

create function [rd].[f_GetFuelRates](@in_contractNo int,@inSequenceNo int,@inEffDate datetime)
returns numeric(12,2)
AS
BEGIN

  declare @vn_fuelrate numeric(12,2)
  select  @vn_fuelrate=fuel_rates.fr_fuel_rate
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
  return @vn_fuelrate
end
GO
