
--
-- Definition for stored procedure sp_GetRenewal : 
--

create procedure [rd].[sp_GetRenewal](
@in_ContractNo int,
@in_ContractSeq int)
AS
BEGIN
  select contract_no,
    contract_seq_number,
    con_start_date,
    con_rates_effective_date,
    con_rg_code_at_renewal,
    con_expiry_date,
    con_start_pay_date,
    con_last_paid_date,
    con_processing_hours_per_week,
    con_renewal_benchmark_price,
    con_renewal_payment_value,
    con_relief_driver_name,
    con_relief_driver_address,
    con_relief_driver_home_phone,
    con_date_last_assigned,
    con_acceptance_flag,
    con_volume_at_renewal,
    con_del_hrs_week_at_renewal,
    con_distance_at_renewal,
    con_no_customers_at_renewal,
    con_no_rural_private_bags_at_renewal,
    con_no_other_bags_at_renewal,
    con_no_private_bags_at_renewal,
    con_no_post_offices_at_renewal,
    con_no_cmbs_at_renewal,
    con_no_cmb_custs_at_renewal from
    contract_renewals where
    (contract_no = @in_ContractNo) and
    (contract_seq_number = @in_ContractSeq)
end