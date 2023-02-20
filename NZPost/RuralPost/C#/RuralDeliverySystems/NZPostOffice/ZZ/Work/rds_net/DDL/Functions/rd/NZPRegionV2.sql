/****** Object:  UserDefinedFunction [rd].[NZPRegionV2]    Script Date: 08/05/2008 11:24:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for user-defined function NZPRegionV2 : 
--

create function [rd].[NZPRegionV2](@inRegion int,@inOutlet int,@inRenGroup int,@inContractType int)
returns decimal(10,2)
AS
BEGIN

  declare @dReturn decimal(10,2),
  @dTotal decimal(10,2)
  select @dTotal = rd.CoreContract(@inRegion,@inOutlet,@inRenGroup,@inContractType) 
    
  select @dReturn=isnull(@dTotal,0)
  select @dTotal = sum(isnull(frequency_adjustments.fd_amount_to_pay,0))
    from contract_renewals join
    contract as aa on
    contract_renewals.contract_no = aa.contract_no and
    contract_renewals.contract_seq_number = aa.con_active_sequence join
    frequency_adjustments on
    contract_renewals.contract_no = frequency_adjustments.contract_no and
    contract_renewals.contract_seq_number = frequency_adjustments.contract_seq_number and
    frequency_adjustments.fd_confirmed = 'Y',
    contract join
    outlet on
    contract.con_base_office = outlet.outlet_id and
    (outlet.region_id = @inRegion or @inRegion = 0) and
    (outlet.outlet_id = @inOutlet or @inOutlet = 0) where
    contract.con_date_terminated is null and
    ((contract.con_base_cont_type = @inContractType and @inContractType > 0) or
    (@inContractType = 0 or @inContractType is null)) and
    (contract_renewals.contract_no = contract.contract_no) and
    (contract_renewals.contract_seq_number = contract.con_active_sequence) and
    (contract.rg_code = @inRenGroup or @inRenGroup = 0)
  select @dReturn=@dReturn+isnull(@dTotal,0)
  select @dTotal = rd.NZPAllowance(@inRegion,@inOutlet,@inRenGroup,@inContractType) 
    
  select @dReturn=@dReturn+isnull(@dTotal,0)
  if @dReturn = 0
    select @dReturn=null
  return @dReturn
end
GO
