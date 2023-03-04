
CREATE procedure [rd].[sp_GetNonVehicleRenewalRates](
@inRGCode int,
@in_EffectDate datetime)
as
-- TJB  RPCR_041  Nov 2012
-- Added column nvr_relief_weeks
--
-- TJB  SR4661  May2005
-- Added delivery and processing wage rates
--
begin
set CONCAT_NULL_YIELDS_NULL off
  select rg_code,
    nvr_rates_effective_date,
    nvr_wage_hourly_rate,
    nvr_vehicle_insurance_base_premium,
    nvr_public_liability_rate,
    nvr_carrier_risk_rate,
    nvr_acc_rate,
    nvr_item_proc_rate_per_hr,
    nvr_frozen_indicator,
    nvr_contract_start,
    nvr_contract_end,
    nvr_accounting,
    nvr_telephone,
    nvr_sundries,
    nvr_acc_rate_amount,
    nvr_uniform,
    nvr_delivery_wage_rate,
    nvr_processing_wage_rate,
    nvr_relief_weeks 
  from
    non_vehicle_rate 
  where
    (rg_code = @inRGCode or @inRGCode is null) and
    nvr_rates_effective_date = @in_EffectDate
end