
--
-- Definition for user-defined function OD_BLF_GetContractorNo : 
--

create function [odps].[OD_BLF_GetContractorNo](@incontract_no int,@inSequence_no int,@EffDate datetime)
returns int
AS
BEGIN

  declare @contractor int
  if @inSequence_no = 0
    begin
      select @contractor = min(contractor_renewals.contractor_supplier_no) 
        from rd.contractor_renewals,
        rd.contract,
        rd.contract_renewals where
        contract_renewals.contract_no = contract.contract_no and
        contract_renewals.contract_no = contractor_renewals.contract_no and
        contract_renewals.contract_seq_number = contractor_renewals.contract_seq_number and
        contract.con_active_sequence = contract_renewals.contract_seq_number and
        contract.contract_no = @inContract_No and
        contractor_renewals.cr_effective_date = (select max(cr_effective_date) from
          rd.contractor_renewals as cr where
          cr.cr_effective_date <= @effdate and
          cr.contract_no = @inContract_no)
      if @@error <> 0 /* <> was < */ or @@error = -1 or @@rowcount = 0 /* was @@error =100 */
        return(-1)
    end
  else
    begin
      select @contractor = min(contractor_renewals.contractor_supplier_no) 
        from rd.contractor_renewals where
        contractor_renewals.contract_no = @inContract_no and
        contractor_renewals.contract_seq_number = @inSequence_no and
        contractor_renewals.cr_effective_date = (select max(cr_effective_date) from
          rd.contractor_renewals as cr where
          cr.cr_effective_date <= @effdate and
          cr.contract_no = @inContract_no)
      if @@error <> 0
        return(-1)
    end
  return(@contractor)
end