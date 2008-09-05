/****** Object:  StoredProcedure [odps].[OD_DWS_NetPay_Before_acceptance]    Script Date: 08/05/2008 10:13:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--
-- Definition for stored procedure OD_DWS_NetPay_Before_acceptance : 
--

create procedure  [odps].[OD_DWS_NetPay_Before_acceptance]
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  select distinct contractor.c_surname_company + case when len(c_first_names) > 0 then ', ' + c_first_names else ''
    end,Payment_Value=(select sum(pc_amount) from
       odps.t_payment_component INNER JOIN
       odps.Payment_Component_Type ON odps.t_payment_component.pct_id = odps.Payment_Component_Type.pct_id INNER JOIN
       odps.payment_component_group ON odps.Payment_Component_Type.pcg_id = odps.payment_component_group.pcg_id where
--      t_payment_component.pct_id = payment_component_type.pct_id and
--      payment_component_group.pcg_id = payment_component_type.pcg_id and
      payment_component_group.pcg_Short_code in('GP','OGP') and
      t_payment.invoice_id = t_payment_component.invoice_id),
    tax=(select sum(pc_amount)*-1 from
       odps.t_payment_component INNER JOIN
       odps.Payment_Component_Type ON odps.t_payment_component.pct_id = odps.Payment_Component_Type.pct_id INNER JOIN
       odps.payment_component_group ON odps.Payment_Component_Type.pcg_id = odps.payment_component_group.pcg_id where
--      t_payment_component.pct_id = payment_component_type.pct_id and
--      payment_component_group.pcg_id = payment_component_type.pcg_id and
      payment_component_group.pcg_Short_code = 'TAX' and
      t_payment.invoice_id = t_payment_component.invoice_id),
    GST=(select sum(pc_amount) from
       odps.t_payment_component INNER JOIN
       odps.Payment_Component_Type ON odps.t_payment_component.pct_id = odps.Payment_Component_Type.pct_id INNER JOIN
       odps.payment_component_group ON odps.Payment_Component_Type.pcg_id = odps.payment_component_group.pcg_id where
--      t_payment_component.pct_id = payment_component_type.pct_id and
--      payment_component_group.pcg_id = payment_component_type.pcg_id and
      payment_component_group.pcg_Short_code = 'GST' and
      t_payment.invoice_id = t_payment_component.invoice_id),
    Adjustments=(select abs(sum(pc_amount)) from
       odps.t_payment_component INNER JOIN
       odps.Payment_Component_Type ON odps.t_payment_component.pct_id = odps.Payment_Component_Type.pct_id INNER JOIN
       odps.payment_component_group ON odps.Payment_Component_Type.pcg_id = odps.payment_component_group.pcg_id where
--      t_payment_component.pct_id = payment_component_type.pct_id and
--      payment_component_group.pcg_id = payment_component_type.pcg_id and
      payment_component_group.pcg_Short_code = 'PTA' and
      t_payment.invoice_id = t_payment_component.invoice_id),
    contract_no from
     odps.t_payment INNER JOIN rd.contractor 
    ON  contractor.contractor_supplier_no = odps.t_payment.contractor_supplier_no where
    t_payment.contractor_supplier_no = contractor.contractor_supplier_no order by
    6 asc,1 asc
end
GO
