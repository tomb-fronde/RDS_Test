/****** Object:  StoredProcedure [rd].[ps_Renewal_Information]    Script Date: 08/05/2008 10:17:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for stored procedure ps_Renewal_Information : 
--

create procedure [rd].[ps_Renewal_Information](@inRegion int,@inYearStart datetime,@inMonthEnd datetime,@outYTDDelHours decimal(12,2) output,@outYTDSortHours decimal(12,2) output,@outYTDDistance decimal(12,2) output,@outMonthDelHours decimal(12,2) output,@outMonthSortHours decimal(12,2) output,@outMonthDistance decimal(12,2) output) 
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  declare @decRenewalDelHours decimal(12,2),
  @decExtnDelHours decimal(12,2),
  @decRenewalDistance decimal(12,2),
  @decExtnDistance decimal(12,2),
  @decRenewalSortHours decimal(12,2),
  @decExtnSortHours decimal(12,2),
  @dMonthStart datetime
  select @dMonthStart=rd.ymd(year(@inMonthEnd),month(@inMonthEnd),1)
  select @decRenewalDelHours = sum(contract_renewals.con_del_hrs_week_at_renewal),
		 @decRenewalSortHours = sum(contract_renewals.con_processing_hours_per_week),
		 @decRenewalDistance = sum(contract_renewals.con_distance_at_renewal) 
     from contract_renewals join 
    contract on
    contract_renewals.contract_no = contract.contract_no and
    contract_renewals.contract_seq_number = contract.con_active_sequence and
    (contract.con_date_terminated is null or
    contract.con_date_terminated > @inYearStart) join
    outlet on
    contract.con_base_office = outlet.outlet_id and
    (outlet.region_id = @inRegion or @inRegion = 0)

  select @decExtnDelHours = sum(frequency_distances.fd_delivery_hrs_per_week),
@decExtnSortHours = sum(frequency_distances.fd_processing_hrs_week),
@decExtnDistance = sum(isnull(frequency_distances.fd_distance,0)*rate_days.rtd_days_per_annum) 
     from frequency_distances join
    contract on
    frequency_distances.contract_no = contract.contract_no and
    (contract.con_date_terminated is null or
    contract.con_date_terminated > @inYearStart) join
    outlet on
    contract.con_base_office = outlet.outlet_id and
    (outlet.region_id = @inRegion or @inRegion = 0) join
    contract_renewals on
    contract.contract_no = contract_renewals.contract_no and
    contract.con_active_sequence = contract_renewals.contract_seq_number,
    rate_days where
    frequency_distances.sf_key = rate_days.sf_key and
    contract_renewals.con_rg_code_at_renewal = rate_days.rg_code and
    contract_renewals.con_rates_effective_date = rate_days.rr_rates_effective_date and
    fd_effective_date between @inYearStart and @inMonthEnd
  select @outYTDDelHours=isnull(@decRenewalDelHours,0)+isnull(@decExtnDelHours,0)
  select @outYTDSortHours=isnull(@decRenewalSortHours,0)+isnull(@decExtnSortHours,0)
  select @outYTDDistance=isnull(@decRenewalDistance,0)+isnull(@decExtnDistance,0)
  select @decExtnDelHours = sum(frequency_distances.fd_delivery_hrs_per_week),
	@decExtnSortHours = sum(frequency_distances.fd_processing_hrs_week),
	@decExtnDistance = sum(isnull(frequency_distances.fd_distance,0)*rate_days.rtd_days_per_annum)
     from frequency_distances join
    contract on
    frequency_distances.contract_no = contract.contract_no and
    (contract.con_date_terminated is null or
    contract.con_date_terminated > @inYearStart) join
    outlet on
    contract.con_base_office = outlet.outlet_id and
    (outlet.region_id = @inRegion or @inRegion = 0) join
    contract_renewals on
    contract.contract_no = contract_renewals.contract_no and
    contract.con_active_sequence = contract_renewals.contract_seq_number,
    rate_days where
    frequency_distances.sf_key = rate_days.sf_key and
    contract_renewals.con_rg_code_at_renewal = rate_days.rg_code and
    contract_renewals.con_rates_effective_date = rate_days.rr_rates_effective_date and
    fd_effective_date between @inYearStart and @inMonthEnd
  select @outMonthDelHours=isnull(@decExtnDelHours,0)
  select @outMonthSortHours=isnull(@decExtnSortHours,0)
  select @outMonthDistance=isnull(@decExtnDistance,0)
end
GO
