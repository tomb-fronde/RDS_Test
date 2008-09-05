/****** Object:  UserDefinedFunction [rd].[CustsRegion]    Script Date: 08/05/2008 11:23:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for user-defined function CustsRegion : 
--

create function [rd].[CustsRegion](@inRegion int,@inOutlet int,@inRenGroup int)
returns int
AS
BEGIN

  declare @iReturn integer,
  @iTotal integer
  select @iTotal = sum(iSnull(contract_renewals.con_no_customers_at_renewal,0))+
    sum(isnull(contract_renewals.con_no_cmb_custs_at_renewal,0)) 
    from contract_renewals join
    contract as aa on
    contract_renewals.contract_no = aa.contract_no and
    contract_renewals.contract_seq_number = aa.con_active_sequence,
    contract join
    outlet on
    contract.con_base_office = outlet.outlet_id and
    (outlet.region_id = @inRegion or @inRegion = 0) and
    (outlet.outlet_id = @inOutlet or @inOutlet = 0) where
    contract.contract_no = any(select types_for_contract.contract_no from
      types_for_contract join
      contract_type on types_for_contract.ct_key = contract_type.ct_key 
		where
      contract_type.ct_rd_ref_mandatory = 'Y') and
    contract.con_date_terminated is null and
    (contract_renewals.contract_no = contract.contract_no) and
    (contract_renewals.contract_seq_number = contract.con_active_sequence) and
    (contract.rg_code = @inRenGroup or @inRenGroup = 0)
  select @iReturn=@iReturn+iSnull(@iTotal,0)
  select @iReturn=iSnull(@iTotal,0)
  select @iTotal = sum(isnull(frequency_distances.fd_no_of_boxes,0))+
    sum(isnull(frequency_distances.fd_no_cmb_customers,0))
    from contract_renewals join
    contract as aa on
    contract_renewals.contract_no = aa.contract_no and
    contract_renewals.contract_seq_number = aa.con_active_sequence join
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
      contract_type on types_for_contract.ct_key = contract_type.ct_key where
      contract_type.ct_rd_ref_mandatory = 'Y') and
    contract.con_date_terminated is null and
    (contract_renewals.contract_no = contract.contract_no) and
    (contract_renewals.contract_seq_number = contract.con_active_sequence) and
    (contract.rg_code = @inRenGroup or @inRenGroup = 0)
  select @iReturn=@iReturn+isnull(@iTotal,0)
  if @iReturn = 0
    select @iReturn=null
  return @iReturn
end
GO
