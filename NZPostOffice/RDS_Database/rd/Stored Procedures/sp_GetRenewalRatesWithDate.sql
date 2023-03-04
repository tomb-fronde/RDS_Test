
--
-- Definition for stored procedure sp_GetRenewalRatesWithDate : 
--

create procedure [rd].[sp_GetRenewalRatesWithDate](
@inRGCode int,
@inEffectDate datetime)
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  select renewal_rate.rg_code,renewal_rate.rr_rates_effective_date,renewal_rate.rr_nominal_vehical_value,
    renewal_rate.rr_wage_hourly_rate,
    renewal_rate.rr_repairs_maintenance_rate,
    renewal_rate.rr_tyre_tubes_rate,
    renewal_rate.rr_vehical_allowance_rate,
    renewal_rate.rr_vehical_insurance_premium,
    renewal_rate.rr_public_liability_rate,
    renewal_rate.rr_carrier_risk_rate,
    renewal_rate.rr_acc_rate,
    renewal_rate.rr_licence_rate,
    renewal_rate.rr_vehical_rate_of_return_pct,renewal_rate.rr_salvage_ratio,renewal_rate.rr_item_proc_rate_per_hr,
    renewal_rate.rr_frozen_indicator,
    renewal_rate.rr_contract_start,
    renewal_rate.rr_contract_end,
    renewal_rate.rr_ruc,renewal_rate.rr_accounting,renewal_rate.rr_telephone,renewal_rate.rr_sundries from
    renewal_rate where
    rg_code = @inRGCode and
    rr_rates_effective_date = @inEffectDate order by
    rr_rates_effective_date desc
end