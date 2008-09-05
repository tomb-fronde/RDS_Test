/****** Object:  StoredProcedure [odps].[OD_RPS_Invoice_pay_adjustments]    Script Date: 08/05/2008 10:14:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [odps].[OD_RPS_Invoice_pay_adjustments](@invoiceid int,@in_date datetime)
-- TJB  SR4654  April 2005    Changed.  
-- If the payment_component description is "Global fuel rate changed ..."
-- return either the old worded description, or the truncated new wording 
as -- (the function v_fuelRateDescription decides).
begin
set CONCAT_NULL_YIELDS_NULL off
  select @in_date,
    prs_description,
    pvolume=(select sum(payment_component_piece_rates.pcpr_volume) from
      payment,payment_component,payment_component_piece_rates,rd.piece_rate_type where
      (payment.invoice_id = payment_component.invoice_id) and
      (payment_component_piece_rates.pc_id = payment_component.pc_id) and
      (piece_rate_type.prt_key = payment_component_piece_rates.prt_key) and
      (piece_rate_supplier.prs_key = piece_rate_type.prs_key) and
      (payment_component.invoice_id = @invoiceid) and
      (payment.POTS = 'N')),
    pvalue=(select sum(payment_component_piece_rates.pcpr_value) from
      payment,payment_component,payment_component_piece_rates,rd.piece_rate_type where
      (payment.invoice_id = payment_component.invoice_id) and
      (payment_component_piece_rates.pc_id = payment_component.pc_id) and
      (piece_rate_type.prt_key = payment_component_piece_rates.prt_key) and
      (piece_rate_supplier.prs_key = piece_rate_type.prs_key) and
      (payment_component.invoice_id = @invoiceid) and
      (payment.POTS = 'N')) from
    rd.piece_rate_supplier where
    exists((select payment_component_piece_rates.pcpr_volume from
      payment,payment_component,payment_component_piece_rates,rd.piece_rate_type where
      (payment.invoice_id = payment_component.invoice_id) and
      (payment_component_piece_rates.pc_id = payment_component.pc_id) and
      (piece_rate_type.prt_key = payment_component_piece_rates.prt_key) and
      (piece_rate_supplier.prs_key = piece_rate_type.prs_key) and
      (payment_component.invoice_id = @invoiceid) and
      (payment.POTS = 'N'))) union
  select pc.misc_date,
    -- TJB  SR4654  April 2005
    -- pc.misc_string ,
    description=case when CHARINDEX('Global fuel rate changed',pc.misc_string) = 0 then
      pc.misc_string
    else odps.v_fuelRateDescription(pc.misc_string)
    end,0,
    pvalue=(select sum(isnull(pc_amount,0)) from
      payment,
      payment_component_type,
      payment_component where
      payment.POTS = 'N' and
      (payment_component.invoice_id = payment.invoice_id) and
      (payment_component_type.pct_id = payment_component.pct_id) and
      ((payment_component_type.pct_description like 'Contract Adjustment%' or
      ((payment_component_type.pct_description like 'Frequency Adjustment%' or
      payment_component_type.pct_description like 'Contract allowance%') and
      left(payment_component.comments,6) = 'Arrear')) and
      (payment.invoice_id = @invoiceid)) and
      payment_component.pc_id = pc.pc_id) from
    payment_component as pc where
    pc.invoice_id = @invoiceid and
    ((select sum(isnull(pc_amount,0)) from
      payment,
      payment_component_type,
      payment_component where
      payment.POTS = 'N' and
      (payment_component.invoice_id = payment.invoice_id) and
      (payment_component_type.pct_id = payment_component.pct_id) and
      ((payment_component_type.pct_description like 'Contract Adjustment%' or
      ((payment_component_type.pct_description like 'Frequency Adjustment%' or
      payment_component_type.pct_description like 'Contract allowance%') and
      left(payment_component.comments,6) = 'Arrear')) and
      (payment.invoice_id = @invoiceid)) and
      payment_component.pc_id = pc.pc_id) <> 0 or (select sum(isnull(pc_amount,0)) from
      payment,
      payment_component_type,
      payment_component where
      payment.POTS = 'N' and
      (payment_component.invoice_id = payment.invoice_id) and
      (payment_component_type.pct_id = payment_component.pct_id) and
      ((payment_component_type.pct_description like 'Contract Adjustment%' or
      ((payment_component_type.pct_description like 'Frequency Adjustment%' or
      payment_component_type.pct_description like 'Contract allowance%') and
      left(payment_component.comments,6) = 'Arrear')) and
      (payment.invoice_id = @invoiceid)) and
      payment_component.pc_id = pc.pc_id) is not null)
end
GO
