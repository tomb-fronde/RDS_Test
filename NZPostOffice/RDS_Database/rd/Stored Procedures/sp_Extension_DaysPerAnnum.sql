create procedure [rd].[sp_Extension_DaysPerAnnum](@inContract int,@inKey int)
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  select rate_days.rtd_days_per_annum from
    contract join
    contract_renewals as cr on
    contract.contract_no = cr.contract_no and
    contract.con_active_sequence = cr.contract_seq_number
	 join
    rate_days on
    cr.con_rg_code_at_renewal = rate_days.rg_code and
    cr.con_rates_effective_date = rate_days.rr_rates_effective_date and
    rate_days.sf_key = @inKey where
    contract.contract_no = @inContract
end