/****** Object:  StoredProcedure [rd].[sp_GetRenewalInfo]    Script Date: 08/05/2008 10:20:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for stored procedure sp_GetRenewalInfo : 
--

create procedure [rd].[sp_GetRenewalInfo](
@in_ContractNo int,
@in_ContractSeq int)
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  select contract_renewals.contract_no,
    contract_renewals.contract_seq_number,
    contract.con_title,
    contract_renewals.con_start_date,
    contract_renewals.con_rates_effective_date,
    contract_renewals.con_rg_code_at_renewal,
    contract_renewals.con_expiry_date,
    contract_renewals.con_start_pay_date,
    contract_renewals.con_last_paid_date,
    contract_renewals.con_processing_hours_per_week,
    round(contract_renewals.con_renewal_benchmark_price,0),
    round(contract_renewals.con_renewal_payment_value,2),
    contract_renewals.con_relief_driver_name,
    contract_renewals.con_relief_driver_address,
    contract_renewals.con_relief_driver_home_phone,
    contract_renewals.con_date_last_assigned,
    contract_renewals.con_acceptance_flag,
    contract_renewals.con_volume_at_renewal,
    contract_renewals.con_del_hrs_week_at_renewal,
    contract_renewals.con_distance_at_renewal,
    contract_renewals.con_no_customers_at_renewal,
    contract_renewals.con_no_rural_private_bags_at_renewal,
    contract_renewals.con_no_other_bags_at_renewal,
    contract_renewals.con_no_private_bags_at_renewal,
    contract_renewals.con_no_post_offices_at_renewal,
    contract_renewals.con_no_cmbs_at_renewal,
    contract_renewals.con_no_cmb_custs_at_renewal from
    contract_renewals join contract on contract_renewals.contract_no=contract.contract_no where
    (contract_renewals.contract_no = @in_ContractNo) and
    (contract_renewals.contract_seq_number = @in_ContractSeq)
end
GO
