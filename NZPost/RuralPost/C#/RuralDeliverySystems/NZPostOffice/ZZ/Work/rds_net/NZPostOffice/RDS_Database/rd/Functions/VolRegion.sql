
create function [rd].[VolRegion](@inRegion int,@inOutlet int,@inRenGroup int)
returns int
AS
BEGIN

  declare @iReturn int,
  @iTotal decimal(12,2),
  @iTotalExtn int
  select @iReturn=0
  select @iTotal = sum(isnull(contract_renewals.con_volume_at_renewal,0))
    from contract_renewals join
    contract as con on
    contract_renewals.contract_no = con.contract_no and
    contract_renewals.contract_seq_number = con.con_active_sequence,
    contract join
    outlet on
    contract.con_base_office = outlet.outlet_id and
    (outlet.region_id = @inRegion or @inRegion = 0) and
    (outlet.outlet_id = @inOutlet or @inOutlet = 0) where
    contract.contract_no = any(select types_for_contract.contract_no from
      types_for_contract join
      contract_type ON types_for_contract.ct_key = contract_type.ct_key where
      contract_type.ct_rd_ref_mandatory = 'Y') and
    contract.con_date_terminated is null and
    (contract_renewals.contract_no = contract.contract_no) and
    (contract_renewals.contract_seq_number = contract.con_active_sequence) and
    (contract.rg_code = @inRenGroup or @inRenGroup = 0)
  select @iTotalExtn = sum(isnull(frequency_distances.fd_volume,0))  
    from contract_renewals join
    contract as con on
    contract_renewals.contract_no = con.contract_no and
    contract_renewals.contract_seq_number = con.con_active_sequence join
    frequency_distances on
    contract_renewals.contract_no = frequency_distances.contract_no and
    contract_renewals.con_start_date <= frequency_distances.fd_effective_date,
    contract join
    outlet on
    contract.con_base_office = outlet.outlet_id and
    (outlet.region_id = @inRegion or @inRegion = 0) and
    (outlet.outlet_id = @inOutlet or @inOutlet = 0) where
    contract.contract_no = any(select types_for_contract.contract_no from
      types_for_contract join
      contract_type ON types_for_contract.ct_key = contract_type.ct_key where
      contract_type.ct_rd_ref_mandatory = 'Y') and
    contract.con_date_terminated is null and
    (contract_renewals.contract_no = contract.contract_no) and
    (contract_renewals.contract_seq_number = contract.con_active_sequence) and
    (contract.rg_code = @inRenGroup or @inRenGroup = 0)
  select @iReturn=isnull(@iTotal,0)+isnull(@iTotalExtn,0)
  if @iReturn = 0
    select @iReturn=null
  return @iReturn
end