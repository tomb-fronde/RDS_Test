
--
-- Definition for user-defined function CoreContract : 
--

--
-- Definition for user-defined function CoreContract : 
--

create function  [rd].[CoreContract](@inRegion int,@inOutlet int,@inRenGroup int,@inContractType int)
returns decimal(10,2)
AS
BEGIN

  declare @dReturn decimal(10,2),
  @dTotal decimal(10,2)
  select @dTotal = sum(isnull(contract_renewals.con_renewal_payment_value,0))
    from  contract INNER JOIN
    contract_renewals ON contract.contract_no = contract_renewals.contract_no INNER JOIN
    outlet ON contract.con_base_office = outlet.outlet_id INNER JOIN
    types_for_contract ON contract.contract_no = types_for_contract.contract_no where
--    (contract_renewals.contract_no = contract.contract_no) and
    (contract_renewals.contract_seq_number = contract.con_active_sequence) and
--    (contract.con_base_office = outlet.outlet_id) and
--    (types_for_contract.contract_no = contract.contract_no) and
    ((contract.con_date_terminated is null)) and
    (outlet.region_id = @inRegion or @inRegion = 0) and
    (outlet.outlet_id = @inOutlet or @inOutlet = 0) and
    ((contract.con_base_cont_type = @inContractType and @inContractType > 0) or
    (@inContractType = 0 or @inContractType is null)) and
    (contract.rg_code = @inRenGroup or @inRenGroup = 0)
  select @dReturn=isnull(@dTotal,0)
  select @dTotal = sum(isnull(frequency_adjustments.fd_amount_to_pay,0))
    from  contract INNER JOIN
    contract_renewals ON contract.contract_no = contract_renewals.contract_no INNER JOIN
    outlet ON contract.con_base_office = outlet.outlet_id INNER JOIN
    frequency_adjustments ON contract.contract_no = frequency_adjustments.contract_no where
--    (contract_renewals.contract_no = contract.contract_no) and
--    (contract_renewals.contract_no = frequency_adjustments.contract_no) and
    (contract_renewals.contract_seq_number = frequency_adjustments.contract_seq_number) and
    (contract_renewals.contract_seq_number = contract.con_active_sequence) and
--    (outlet.outlet_id = contract.con_base_office) and
    (frequency_adjustments.fd_confirmed = 'Y') and
    (contract.con_date_terminated is null) and
    (outlet.region_id = @inRegion or @inRegion = 0) and
    (outlet.outlet_id = @inOutlet or @inOutlet = 0) and
    ((contract.con_base_cont_type = @inContractType and @inContractType > 0) or
    (@inContractType = 0 or @inContractType is null)) and
    (contract.rg_code = @inRenGroup or @inRenGroup = 0)
  select @dReturn=@dReturn+isnull(@dTotal,0)
  return @dReturn
end