/****** Object:  UserDefinedFunction [rd].[RDRunsRegionV2]    Script Date: 08/05/2008 11:25:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for user-defined function RDRunsRegionV2 : 
--

create function [rd].[RDRunsRegionV2](@inRegion int,@inOutlet int,@inRenGroup int,@inContractType int)
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
    ((contract.con_base_cont_type = @inContractType and @inContractType > 0) or
    (@inContractType = 0 or @inContractType is null)) and
    contract.con_date_terminated is null and
    (contract_renewals.contract_no = contract.contract_no) and
    (contract_renewals.contract_seq_number = contract.con_active_sequence) and
    (contract.rg_code = @inRenGroup or @inRenGroup = 0)
  if @iReturn = 0
    select @iReturn=null
  return @iReturn
end
GO
