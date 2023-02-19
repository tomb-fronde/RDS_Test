
--
-- Definition for user-defined function OD_BLF_Get_GrossPay_PreAccept : 
--

create function [odps].[OD_BLF_Get_GrossPay_PreAccept](@in_invoice_ID int,@in_contract_no int,@in_contractor_no int)
returns decimal(12,2)
AS
BEGIN

  declare @gross_pay decimal(12,2)
  select @gross_pay = sum(pc_amount)
    from t_payment_component,payment_component_type,payment_component_group where
    (t_payment_component.invoice_id = @in_invoice_ID) and
    (t_payment_component.pct_id = payment_component_type.pct_id) and
    (payment_component_type.pcg_id = payment_component_group.pcg_id) and
    (payment_component_group.pcg_short_code in('GP','OGP'))
  if @@error <> 0 /* <> was < */
    begin
      --rollback transaction
      return(-200000)
    end
  return(@gross_pay)
end