
--
-- Definition for stored procedure sp_GetSummaryFrequencies : 
--

create procedure [rd].[sp_GetSummaryFrequencies](@inContract int,@inSequence int)
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  select standard_frequency.sf_key,
    standard_frequency.sf_description,
    route_frequency.rf_delivery_days,
    route_frequency.rf_distance,
    frequency_distances.fd_effective_date,
    frequency_distances.fd_distance,
    frequency_distances.fd_no_of_boxes,
    frequency_distances.fd_no_rural_bags,
    frequency_distances.fd_no_other_bags,
    frequency_distances.fd_no_private_bags,
    frequency_distances.fd_no_post_offices,
    frequency_distances.fd_no_cmbs,
    frequency_distances.fd_no_cmb_customers,
    frequency_distances.fd_volume,
    frequency_distances.fd_delivery_hrs_per_week,
    frequency_distances.fd_processing_hrs_week,
    rate_days.rtd_days_per_annum,'X' from
    frequency_distances join
    standard_frequency on
    frequency_distances.sf_key = standard_frequency.sf_key join
    route_frequency on
    frequency_distances.contract_no = route_frequency.contract_no and
    frequency_distances.rf_delivery_days = route_frequency.rf_delivery_days and
    frequency_distances.sf_key = route_frequency.sf_key join
    contract_renewals on
    frequency_distances.contract_no = contract_renewals.contract_no and
    frequency_distances.fd_effective_date >= contract_renewals.con_start_date and
    contract_renewals.contract_no = @inContract and
    contract_renewals.contract_seq_number = @inSequence join
    rate_days on
    frequency_distances.sf_key = rate_days.sf_key where
    rate_days.rg_code = contract_renewals.con_rg_code_at_renewal and
    rate_days.rr_rates_effective_date = contract_renewals.con_rates_effective_date union
  select null,'Renewal Information',
    null,
    null,
    null,
    contract_renewals.con_distance_at_renewal,
    contract_renewals.con_no_customers_at_renewal,
    contract_renewals.con_no_rural_private_bags_at_renewal,
    contract_renewals.con_no_other_bags_at_renewal,
    contract_renewals.con_no_private_bags_at_renewal,
    contract_renewals.con_no_post_offices_at_renewal,
    contract_renewals.con_no_cmbs_at_renewal,
    contract_renewals.con_no_cmb_custs_at_renewal,
    contract_renewals.con_volume_at_renewal,
    contract_renewals.con_del_hrs_week_at_renewal,
    contract_renewals.con_processing_hours_per_week,
    1,'R' from
    contract_renewals where
    contract_renewals.contract_no = @inContract and
    contract_renewals.contract_seq_number = @inSequence
end