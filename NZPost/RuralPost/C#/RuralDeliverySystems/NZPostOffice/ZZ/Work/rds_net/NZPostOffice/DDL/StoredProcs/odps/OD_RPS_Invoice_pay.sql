/****** Object:  StoredProcedure [odps].[OD_RPS_Invoice_pay]    Script Date: 08/05/2008 10:13:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for stored procedure OD_RPS_Invoice_pay : 
--

create procedure [odps].[OD_RPS_Invoice_pay](
@invoiceid int,
@enddate datetime,
@insupplier int,
@incontract_no int)
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  -- 1/June/06 TJB  SR4684
  -- Added handling of ParcelPost (prs_key = 4)
  --
  -- 18/May/06 TJB  SR4685
  -- Reformatted to make it legible and removed large commented-out section.
  --
  -- 18/02/02 PBY Request#4326
  -- Removed hardcoding of 'Kiwimail', 'CourierPost' and 'XP' from sql code.  
  -- Used the corresponding payment_component_type.prs_key instead.
  select m_standard=(select isnull(sum(pc_amount),0) from
      payment,
      payment_component,
      payment_component_type where
      (payment_component.invoice_id = payment.invoice_id) and
      (payment_component_type.pct_id = payment_component.pct_id) and
      ((payment_component_type.pct_description like 'Contract payment value%' or
      payment_component_type.pct_description like 'Frequency Adjustment%') and
      (payment.invoice_id = @invoiceid) and
      (left(payment_component.comments,6) <> 'Arrear'))),
    m_allowance=(select isnull(sum(pc_amount),0) from
      payment,
      payment_component,
      payment_component_type where
      (payment_component.invoice_id = payment.invoice_id) and
      (payment_component_type.pct_id = payment_component.pct_id) and
      ((payment_component_type.pct_description like 'Contract allowance%' and
      left(payment_component.comments,6) <> 'Arrear') and
      (payment.invoice_id = @invoiceid))),
    m_Taxable_adjustments=(select isnull(sum(pc_amount),0) from
      payment,
      payment_component,
      payment_component_type where
      (payment_component.invoice_id = payment.invoice_id) and
      (payment_component_type.pct_id = payment_component.pct_id) and
      ((payment_component_type.prs_key = 1 or
      payment_component_type.prs_key = 2 or
      payment_component_type.prs_key = 3 or
      payment_component_type.prs_key = 4 or
      payment_component_type.pct_description like 'Contract Adjustment%' or
      ((payment_component_type.pct_description like 'Frequency Adjustment%' or
      payment_component_type.pct_description like 'Contract allowance%') and
      left(payment_component.comments,6) = 'Arrear')) and
      (payment.invoice_id = @invoiceid))),
    m_GST_rate=(select abs(isnull(nat_od_standard_gst_rate,12.5)) from
      "national" where
      nat_id = odps.od_blf_getwhichnational(@enddate)),
    m_GST_value=(select isnull(sum(pc_amount*-1),0) from
      payment,
      payment_component,
      payment_component_type where
      (payment_component.invoice_id = payment.invoice_id) and
      (payment_component_type.pct_id = payment_component.pct_id) and
      ((payment_component_type.pct_description like 'GST%') and
      (payment.invoice_id = @invoiceid))),
    m_wtax_rate=(select witholding_tax_rate_applied from
      payment where
      (payment.invoice_id = @invoiceid)),
    m_wtax_value=(select isnull(sum(pc_amount*-1),0) from
      payment,
      payment_component,
      payment_component_type where
      (payment_component.invoice_id = payment.invoice_id) and
      (payment_component_type.pct_id = payment_component.pct_id) and
      ((payment_component_type.pct_description like 'Withholding Tax%') and
      (payment.invoice_id = @invoiceid))),
    m_adj_notax=(select isnull(sum(pc_amount*-1),0) from
      payment,
      payment_component,
      payment_component_type where
      (payment_component.invoice_id = payment.invoice_id) and
      (payment_component_type.pct_id = payment_component.pct_id) and
      ((payment_component_type.pct_description like 'Post-Tax Adjustments%') and
      (payment.invoice_id = @invoiceid))),
    y_standard=(select isnull(sum(pc_amount),0) from
      payment,
      payment_component,
      payment_component_type where
      (payment_component.invoice_id = payment.invoice_id) and
      (payment_component_type.pct_id = payment_component.pct_id) and
      ((payment_component_type.pct_description like 'Contract payment value%' or
      payment_component_type.pct_description like 'Frequency Adjustment%') and
      (left(payment_component.comments,6) <> 'Arrear') and
      (payment.contractor_supplier_no = @insupplier) and
      (payment.contract_no = @incontract_no) and
      (payment.invoice_date between odps.OD_MiscF_GetFinYear(@enddate,'S') and @enddate))),
    y_allowance=(select isnull(sum(pc_amount),0) from
      payment,
      payment_component,
      payment_component_type where
      (payment_component.invoice_id = payment.invoice_id) and
      (payment_component_type.pct_id = payment_component.pct_id) and
      ((payment_component_type.pct_description like 'Contract allowance%' and
      left(payment_component.comments,6) <> 'Arrear') and
      (payment.contractor_supplier_no = @insupplier) and
      (payment.contract_no = @incontract_no) and
      (payment.invoice_date between odps.OD_MiscF_GetFinYear(@enddate,'S') and @enddate))),
    y_Taxable_adjustments=(select isnull(sum(pc_amount),0) from
      payment,
      payment_component,
      payment_component_type where
      (payment_component.invoice_id = payment.invoice_id) and
      (payment_component_type.pct_id = payment_component.pct_id) and
      ((payment_component_type.prs_key = 1 or
      payment_component_type.prs_key = 2 or
      payment_component_type.prs_key = 3 or
      payment_component_type.prs_key = 4 or
      payment_component_type.pct_description like 'Contract Adjustment%' or
      ((payment_component_type.pct_description like 'Frequency Adjustment%' or
      payment_component_type.pct_description like 'Contract allowance%') and
      left(payment_component.comments,6) = 'Arrear')) and
      (payment.contractor_supplier_no = @insupplier) and
      (payment.contract_no = @incontract_no) and
      (payment.invoice_date between odps.OD_MiscF_GetFinYear(@enddate,'S') and @enddate))),
    y_GST_value=(select isnull(sum(pc_amount*-1),0) from
      payment,
      payment_component,
      payment_component_type where
      (payment_component.invoice_id = payment.invoice_id) and
      (payment_component_type.pct_id = payment_component.pct_id) and
      ((payment_component_type.pct_description like 'GST%') and
      (payment.contractor_supplier_no = @insupplier) and
      (payment.contract_no = @incontract_no) and
      (payment.invoice_date between odps.OD_MiscF_GetFinYear(@enddate,'S') and @enddate))),
    y_wtax_value=(select isnull(sum(pc_amount*-1),0) from
      payment,
      payment_component,
      payment_component_type where
      (payment_component.invoice_id = payment.invoice_id) and
      (payment_component_type.pct_id = payment_component.pct_id) and
      ((payment_component_type.pct_description like 'Withholding Tax%') and
      (payment.contractor_supplier_no = @insupplier) and
      (payment.contract_no = @incontract_no) and
      (payment.invoice_date between odps.OD_MiscF_GetFinYear(@enddate,'S') and @enddate))),
    y_adj_notax=(select isnull(sum(pc_amount*-1),0) from
      payment,
      payment_component,
      payment_component_type where
      (payment_component.invoice_id = payment.invoice_id) and
      (payment_component_type.pct_id = payment_component.pct_id) and
      ((payment_component_type.pct_description like 'Post-Tax Adjustments%') and
      (payment.contractor_supplier_no = @insupplier) and
      (payment.contract_no = @incontract_no) and
      (payment.invoice_date between odps.OD_MiscF_GetFinYear(@enddate,'S') and @enddate))) 
end
GO
