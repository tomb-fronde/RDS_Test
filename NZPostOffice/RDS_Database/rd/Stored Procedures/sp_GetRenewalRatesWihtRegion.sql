
--
-- Definition for stored procedure sp_GetRenewalRatesWihtRegion : 
--

create procedure [rd].[sp_GetRenewalRatesWihtRegion](
@inregion int)
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  if @inregion > 0
    select distinct renewal_rate.rg_code,
      renewal_rate.rr_rates_effective_date,
      renewal_rate.rr_frozen_indicator from
      contract,
      outlet,
      renewal_rate where
      (outlet.outlet_id = contract.con_lodgement_office) and
      (contract.rg_code = renewal_rate.rg_code) and
      (outlet.region_id = @inregion) order by
      renewal_rate.rr_rates_effective_date asc
  else
    select distinct renewal_rate.rg_code,
      renewal_rate.rr_rates_effective_date,
      renewal_rate.rr_frozen_indicator from
      renewal_rate order by
      renewal_rate.rr_rates_effective_date asc
end