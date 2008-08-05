/****** Object:  UserDefinedFunction [rd].[VolRegionV2]    Script Date: 08/05/2008 11:25:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for user-defined function VolRegionV2 : 
--

create function [rd].[VolRegionV2](@inRegion int,@inOutlet int,@inRenGroup int,@inContractType int)
returns int
AS
BEGIN

  declare @iReturn int,
  @iTotal decimal(12,2),
  @iTotalExtn int
  select @iReturn=0
  select @iTotal = sum(isnull(contract_renewals.con_volume_at_renewal,0)) 
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
  select @iTotalExtn = sum(isnull(frequency_distances.fd_volume,0)) 
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
  select @iReturn=isnull(@iTotal,0)+isnull(@iTotalExtn,0)
  if @iReturn = 0
    select @iReturn=null
  return @iReturn
end
GO
