
--
-- Definition for stored procedure ps_serviceplan : 
--

create procedure [rd].[ps_serviceplan](@inRegion int,@inYearStart datetime,@inMonthEnd datetime,@outYTDRenNo int output,@outYTDOutNo int output,@outYTDRenVal decimal(12,2) output,@outYTDOutVal decimal(12,2) output,@outMonRenNo int output,@outMonOutNo int output,@outMonRenVal decimal(12,2) output,@outMonOutVal decimal(12,2) output,@outYTDRenTrans int output,@outMonthRenTrans int output,@outYTDConCancelled int output,@outMonthConCancelled int output) AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  declare @dMonthStart datetime
  select @dMonthStart=rd.ymd(year(@inMonthEnd),month(@inMonthEnd),1)
  select @outYTDRenNo = sum(case when contract_renewals.con_acceptance_flag = 'Y' then 1 else 0 end),
    @outYTDOutNo = sum(case when  contract_renewals.con_acceptance_flag <> 'Y' then 1 else 0 end),
    @outMonRenNo = sum(case when  contract_renewals.con_acceptance_flag = 'Y' and contract_renewals.con_start_date >= @dMonthStart then 1 else 0 end),
    @outMonOutNo = sum(case when  contract_renewals.con_acceptance_flag <> 'Y' and contract_renewals.con_start_date >= @dMonthStart then 1 else 0 end),
    @outYTDRenVal = sum(case when  contract_renewals.con_acceptance_flag = 'Y' then contract_renewals.con_renewal_payment_value else 0 end),
    @outYTDOutVal = sum(case when  contract_renewals.con_acceptance_flag <> 'Y' then contract_renewals.con_renewal_payment_value else 0 end),
    @outMonRenVal = sum(case when  contract_renewals.con_acceptance_flag = 'Y' and contract_renewals.con_start_date >= @dMonthStart then contract_renewals.con_renewal_payment_value else 0 end),
    @outMonOutVal = sum(case when  contract_renewals.con_acceptance_flag <> 'Y' and contract_renewals.con_start_date >= @dMonthStart then contract_renewals.con_renewal_payment_value else 0 end) 
     from contract join
    outlet on
    contract.con_base_office = outlet.outlet_id and
    (outlet.region_id = @inRegion or @inRegion = 0) join
    contract_renewals on
    contract.contract_no = contract_renewals.contract_no where
    (contract.con_date_terminated is null or
    contract.con_date_terminated > @inYearStart) and
    contract_renewals.contract_seq_number = (select max(contract_seq_number) from contract_renewals where contract_no = contract.contract_no) and
    contract_renewals.con_start_date between @inYearStart and @inMonthEnd
  select @outYTDRenTrans = count(*),
    @outMonthRenTrans = sum(case when contractor_renewals.cr_effective_date between @dMonthStart and @inMonthEnd then 1 else 0 end)
     from contractor_renewals where
    contractor_renewals.cr_effective_date between @inYearStart and @inMonthEnd
  select @outYTDConCancelled = count(*),
    @outMonthConCancelled = sum(case when contract.con_date_terminated between @dMonthStart and @inMonthEnd then 1 else 0 end)
     from contract where
    contract.con_date_terminated between @inYearStart and @inMonthEnd
end