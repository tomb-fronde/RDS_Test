/****** Object:  UserDefinedFunction [rd].[AnnualVolume]    Script Date: 08/05/2008 11:23:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for user-defined function AnnualVolume : 
--

--
-- Definition for user-defined function AnnualVolume : 
--

create function [rd].[AnnualVolume](@inRegion int,@inOutlet int,@inRenGroup int,@inContractType int)
returns decimal(12,2)
AS
BEGIN

  declare @dReturn decimal(12,2),
  @dTotal decimal(12,2)
  select @dTotal=sum(contract_renewals.con_volume_at_renewal) 
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
  select @dTotal=sum(frequency_distances.fd_volume)
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
GO
