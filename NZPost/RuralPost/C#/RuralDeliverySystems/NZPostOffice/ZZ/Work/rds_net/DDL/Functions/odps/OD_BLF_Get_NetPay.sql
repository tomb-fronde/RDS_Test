/****** Object:  UserDefinedFunction [odps].[OD_BLF_Get_NetPay]    Script Date: 08/05/2008 11:22:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for user-defined function OD_BLF_Get_NetPay : 
--

create function [odps].[OD_BLF_Get_NetPay](@in_invoice_ID int,@in_contract_no int,@in_contractor_no int)
returns decimal(12,2)
AS
BEGIN

  declare @net_pay decimal(12,2)
  if @in_invoice_ID > 0
    begin
      select @net_pay = sum(case when payment_component_group.pcg_short_code = 'GST' then abs(pc_amount) else pc_amount end)
        from payment_component,payment_component_type,payment_component_group where
        (payment_component.invoice_id = @in_invoice_ID) and
        (payment_component.pct_id = payment_component_type.pct_id) and
        (payment_component_type.pcg_id = payment_component_group.pcg_id)
      if @@error <> 0 /* <> was < */
        begin
          --rollback transaction
          return(-200100)
        end
      return(@net_pay)
    end
  if @in_contract_no > 0
    begin
      select @net_pay = sum(case when payment_component_group.pcg_short_code = 'GST' then abs(pc_amount) else pc_amount end)
        from payment,payment_component,payment_component_type,payment_component_group where
        (payment.contract_no = @in_contract_no) and
        (payment_component.invoice_id = payment.invoice_ID) and
        (payment_component.pct_id = payment_component_type.pct_id) and
        (payment_component_type.pcg_id = payment_component_group.pcg_id)
      if @@error <> 0 /* <> was < */
        begin
          --rollback transaction
          return(-200200)
        end
      return(@net_pay)
    end
  if @in_contractor_no > 0
    begin
      select @net_pay = sum(case when payment_component_group.pcg_short_code = 'GST' then abs(pc_amount) else pc_amount end)
        from payment,payment_component,payment_component_type,payment_component_group where
        (payment.contractor_supplier_no = @in_contractor_no) and
        (payment_component.invoice_id = payment.invoice_ID) and
        (payment_component.pct_id = payment_component_type.pct_id) and
        (payment_component_type.pcg_id = payment_component_group.pcg_id)
      if @@error <> 0 /* <> was < */
        begin
          --rollback transaction
          return(-200300)
        end
      return(@net_pay)
    end
  return(@net_pay)
end
GO
