/****** Object:  UserDefinedFunction [rd].[f_CheckRates]    Script Date: 08/05/2008 11:23:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for user-defined function f_CheckRates : 
--

--
-- Definition for user-defined function f_CheckRates : 
--

create function [rd].[f_CheckRates](@inRGCode int,@inEffDate datetime)
returns int
AS
BEGIN

  declare @ll_Count integer,
  @ll_NumVehicleTypes integer,
  @ll_NumVehicleTypesFilled integer
  --Check fuel rates
  select @ll_Count=count(*)
    from fuel_type,
    fuel_rates where
    fuel_type.ft_key = fuel_rates.ft_key and
    fuel_rates.rr_rates_effective_date = @inEffDate and
    fuel_rates.rg_code = @inRGCode and
    (fuel_rates.fr_fuel_rate is null or fuel_rates.fr_fuel_consumtion_rate is null)
  if @ll_Count > 0
    return 0
  --check rate days
  select @ll_Count = count(*)
    from standard_frequency,
    rate_days where
    standard_frequency.sf_key = rate_days.sf_key and
    rate_days.rr_rates_effective_date = @inEffDate and
    rate_days.rg_code = @inRGCode and
    rate_days.rtd_days_per_annum is null
  if @ll_Count > 0
    return 0
  --
  select @ll_Count=count(*)
    from piece_rate where
    piece_rate.pr_effective_date = @inEffDate and
    piece_rate.rg_code = @inRGCode and
    pr_active_status = 'Y' and
    pr_rate is null
  if @ll_Count > 0
    return 0
  --Count vehicle types
  select @ll_NumVehicleTypes = count(*) 
    from vehicle_type
  --Count vehicle types already entered
  select @ll_NumVehicleTypesFilled = count(vehicle_rate.vt_key) 
    from vehicle_rate where
    vehicle_rate.vr_rates_effective_date = @inEffDate and
    vehicle_rate.vr_nominal_vehicle_value is not null and
    vehicle_rate.vr_repairs_maintenance_rate is not null and
    vehicle_rate.vr_tyre_tubes_rate is not null and
    vehicle_rate.vr_vehicle_allowance_rate is not null and
    vehicle_rate.vr_licence_rate is not null and
    vehicle_rate.vr_vehicle_rate_of_return_pct is not null and
    vehicle_rate.vr_salvage_ratio is not null and
    vehicle_rate.vr_ruc is not null and
    vehicle_rate.vr_sundries_k is not null and
    vehicle_rate.vr_vehicle_value_insurance_pct is not null
  if(@ll_NumVehicleTypesFilled is null or @ll_NumVehicleTypesFilled < @ll_NumVehicleTypes)
    return 0
  return 1
end
GO
