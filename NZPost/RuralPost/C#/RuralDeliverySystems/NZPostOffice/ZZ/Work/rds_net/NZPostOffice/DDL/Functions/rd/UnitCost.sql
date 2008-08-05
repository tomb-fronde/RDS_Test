/****** Object:  UserDefinedFunction [rd].[UnitCost]    Script Date: 08/05/2008 11:25:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for user-defined function UnitCost : 
--

create function [rd].[UnitCost](@inRegion int,@inOutlet int,@inRenGroup int,@inContractType int)
returns decimal(10,2)
AS
BEGIN

  declare @dTotal decimal(10,2)
  select @dTotal = sum(isnull(contract_allowance.ca_annual_amount,0)) 
    from contract_renewals join
    contract as con on
    contract_renewals.contract_no = con.contract_no and
    contract_renewals.contract_seq_number = con.con_active_sequence join
    contract_allowance on
    contract_renewals.contract_no = contract_allowance.contract_no,
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
  return @dTotal
end
GO
