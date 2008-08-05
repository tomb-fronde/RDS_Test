/****** Object:  UserDefinedFunction [rd].[RDRunsRegion]    Script Date: 08/05/2008 11:25:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for user-defined function RDRunsRegion : 
--

create function [rd].[RDRunsRegion](@inRegion int,@inOutlet int,@inRenGroup int)
returns int
AS
BEGIN

  declare @iReturn int
  select @iReturn = count(*) 
    from contract join outlet on contract.con_base_office = outlet.outlet_id and
    (outlet.region_id = @inRegion or @inRegion = 0) and
    (outlet.outlet_id = @inOutlet or @inOutlet = 0) join
    contract_renewals on contract.contract_no = contract_renewals.contract_no and
    contract.con_active_sequence = contract_renewals.contract_seq_number join region on outlet.region_id = region.region_id where
    contract.contract_no = 
    any(select types_for_contract.contract_no from
      types_for_contract join contract_type on contract_type.ct_key = types_for_contract.ct_key  where
      contract_type.ct_rd_ref_mandatory = 'Y') and
    contract.con_date_terminated is null and
    (contract_renewals.contract_no = contract.contract_no) and
    (contract_renewals.contract_seq_number = contract.con_active_sequence) and
    (contract.rg_code = @inRenGroup or @inRenGroup = 0)
  if @iReturn = 0
    select @iReturn=null
  return @iReturn
end
GO
