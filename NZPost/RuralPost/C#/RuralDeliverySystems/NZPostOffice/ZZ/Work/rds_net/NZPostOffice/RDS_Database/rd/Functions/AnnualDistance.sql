
--
-- Definition for user-defined function AnnualDistance : 
--

-- SQL Manager 2005 for SQL Server (2.5.0.1)
-- ---------------------------------------
-- Host      : 10.32.1.130
-- Database  : RDSPROD
-- Version   : Microsoft SQL Server  9.00.1399.06


--
-- Definition for user-defined function AnnualDistance : 
--

create function [rd].[AnnualDistance](@inRegion int,@inOutlet int,@inRenGroup int,@inContractType int)
returns int
AS
BEGIN

  declare @dReturn decimal(12,2)
  declare @dTotal decimal(12,2)
  select  @dTotal=sum(contract_renewals.con_distance_at_renewal)
    from contract,
    contract_renewals,
    outlet,
    types_for_contract where
    (contract_renewals.contract_no = contract.contract_no) and
    (contract_renewals.contract_seq_number = contract.con_active_sequence) and
    (contract.con_base_office = outlet.outlet_id) and
    (types_for_contract.contract_no = contract.contract_no) and
    ((contract.con_date_terminated is null)) and
    (outlet.region_id = @inRegion or @inRegion = 0) and
    (outlet.outlet_id = @inOutlet or @inOutlet = 0) and
    ((contract.con_base_cont_type = @inContractType and @inContractType > 0) or
    (@inContractType = 0 or @inContractType is null)) and
    (contract.rg_code = @inRenGroup or @inRenGroup = 0)
  select @dReturn=isnull(@dTotal,0)
  select @dTotal=sum(frequency_distances.fd_distance*rate_days.rtd_days_per_annum)  
    from contract,
    frequency_distances,
    route_frequency,
    rate_days,
    contract_renewals,
    outlet,
    types_for_contract where
    (contract.contract_no = frequency_distances.contract_no) and
    (route_frequency.contract_no = frequency_distances.contract_no) and
    (route_frequency.sf_key = frequency_distances.sf_key) and
    (route_frequency.rf_delivery_days = frequency_distances.rf_delivery_days) and
    (route_frequency.sf_key = rate_days.sf_key) and
    (contract_renewals.contract_no = contract.contract_no) and
    (contract_renewals.contract_seq_number = contract.con_active_sequence) and
    (rate_days.rr_rates_effective_date = contract_renewals.con_rates_effective_date) and
    (contract.con_base_office = outlet.outlet_id) and
    (types_for_contract.contract_no = contract.contract_no) and
    ((contract.con_date_terminated is null) and
    (frequency_distances.fd_effective_date >= contract_renewals.con_start_date)) and
    (outlet.region_id = @inRegion or @inRegion = 0) and
    (outlet.outlet_id = @inOutlet or @inOutlet = 0) and
    ((contract.con_base_cont_type = @inContractType and @inContractType > 0) or
    (@inContractType = 0 or @inContractType is null)) and
    (contract.rg_code = @inRenGroup or @inRenGroup = 0)
  select @dReturn=@dReturn+isnull(@dTotal,0)
  return @dReturn
end