
--
-- Definition for user-defined function OD_BLF_Get_NetPay_PreAccept : 
--

create function [odps].[OD_BLF_Get_NetPay_PreAccept](@in_invoice_ID int,@in_contract_no int,@in_contractor_no int)
returns decimal(12,2)
AS
BEGIN

  declare @net_pay decimal(12,2)
  if @in_invoice_ID > 0
    begin
      select @net_pay = sum(case when payment_component_group.pcg_short_code = 'GST' then abs(pc_amount) else pc_amount end)
        from t_payment_component,payment_component_type,payment_component_group where
        (t_payment_component.invoice_id = @in_invoice_ID) and
        (t_payment_component.pct_id = payment_component_type.pct_id) and
        (payment_component_type.pcg_id = payment_component_group.pcg_id)
      if @@error <> 0 /* <> was < */
        begin
          --rollback transaction
          return(-200000)
        end
      return(@net_pay)
    end
  if @in_contract_no > 0
    begin
      select @net_pay = sum(case when payment_component_group.pcg_short_code = 'GST' then abs(pc_amount) else pc_amount end)
        from t_payment,t_payment_component,payment_component_type,payment_component_group where
        (t_payment.contract_no = @in_contract_no) and
        (t_payment_component.invoice_id = t_payment.invoice_ID) and
        (t_payment_component.pct_id = payment_component_type.pct_id) and
        (payment_component_type.pcg_id = payment_component_group.pcg_id)
      if @@error <> 0 /* <> was < */
        begin
          --rollback transaction
          return(-200010)
        end
      return(@net_pay)
    end
  if @in_contractor_no > 0
    begin
      select @net_pay = sum(case when payment_component_group.pcg_short_code = 'GST' then abs(pc_amount) else pc_amount end)
        from t_payment,t_payment_component,payment_component_type,payment_component_group where
        (t_payment.contractor_supplier_no = @in_contractor_no) and
        (t_payment_component.invoice_id = t_payment.invoice_ID) and
        (t_payment_component.pct_id = payment_component_type.pct_id) and
        (payment_component_type.pcg_id = payment_component_group.pcg_id)
      if @@error <> 0 /* <> was < */
        begin
          --rollback transaction
          return(-200020)
        end
      return(@net_pay)
    end
  return(@net_pay)
end