

--
-- Definition for stored procedure sp_GetRenewalGroupRatev2 : 
--

create procedure [rd].[sp_GetRenewalGroupRatev2](
@inRGCode int,
@in_EffectDate datetime)
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  select rg_code,
    rr_rates_effective_date,
    rr_nominal_vehical_value,
    rr_wage_hourly_rate,
    rr_repairs_maintenance_rate,
    rr_tyre_tubes_rate,
    rr_vehical_allowance_rate,
    rr_vehical_insurance_premium,
    rr_public_liability_rate,
    rr_carrier_risk_rate,
    rr_acc_rate,
    rr_licence_rate,
    rr_vehical_rate_of_return_pct,
    rr_salvage_ratio,
    rr_item_proc_rate_per_hr,
    rr_frozen_indicator,
    rr_contract_start,
    rr_contract_end,
    rr_ruc,rr_accounting,rr_telephone,rr_sundries from
    renewal_rate where
    rg_code = @inRgCode and rr_rates_effective_date = @in_EffectDate
end