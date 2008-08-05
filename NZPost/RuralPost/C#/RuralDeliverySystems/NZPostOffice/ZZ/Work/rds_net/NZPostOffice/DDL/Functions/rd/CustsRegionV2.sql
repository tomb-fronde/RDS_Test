/****** Object:  UserDefinedFunction [rd].[CustsRegionV2]    Script Date: 08/05/2008 11:23:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for user-defined function CustsRegionV2 : 
--

--
-- Definition for user-defined function CustsRegionV2 : 
--

create function [rd].[CustsRegionV2](@inRegion int,@inOutlet int,@inRenGroup int,@inContractType int)
returns int
AS
BEGIN

  declare @iReturn integer,
  @iTotal integer
  select @iReturn=0
  select @iTotal=Count(rds_customer.cust_id)
    from
    address,
    contract,
    contract_renewals,
    customer_address_moves,
    outlet,
    rds_customer,
    types_for_contract where
    (contract.contract_no = address.contract_no) and
    (contract_renewals.contract_no = contract.contract_no) and
    (contract_renewals.contract_seq_number = contract.con_active_sequence) and
    (customer_address_moves.adr_id = address.adr_id) and
    (rds_customer.cust_id = customer_address_moves.cust_id) and
    (types_for_contract.contract_no = contract.contract_no) and
    (contract.con_base_office = outlet.outlet_id) and
    ((rds_customer.master_cust_id is null) and
    (customer_address_moves.move_out_date is null) and
    (contract.con_date_terminated is null) and
    (outlet.region_id = @inRegion or @inRegion = 0) and
    (outlet.outlet_id = @inOutlet or @inOutlet = 0) and
    ((contract.con_base_cont_type = @inContractType and @inContractType > 0) or(@inContractType = 0 or @inContractType is null)) and
    (contract.rg_code = @inRenGroup or @inRenGroup = 0))
  select @iReturn=isnull(@iTotal,0)
  return @iReturn
end
GO
