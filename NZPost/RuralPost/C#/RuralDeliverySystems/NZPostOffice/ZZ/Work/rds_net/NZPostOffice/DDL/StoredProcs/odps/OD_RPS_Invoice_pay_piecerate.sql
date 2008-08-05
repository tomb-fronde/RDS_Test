/****** Object:  StoredProcedure [odps].[OD_RPS_Invoice_pay_piecerate]    Script Date: 08/05/2008 10:14:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [odps].[OD_RPS_Invoice_pay_piecerate](@invoiceid int,@in_date datetime)
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  select @in_date,
    prs_description,
    pvolume=(select sum(payment_component_piece_rates.pcpr_volume) from payment,payment_component,payment_component_piece_rates,rd.piece_rate_type where(payment.invoice_id = payment_component.invoice_id) and(payment_component_piece_rates.pc_id = payment_component.pc_id) and(piece_rate_type.prt_key = payment_component_piece_rates.prt_key) and(piece_rate_supplier.prs_key = piece_rate_type.prs_key) and(payment_component.invoice_id = @invoiceid)),
    pvalue=(select sum(payment_component_piece_rates.pcpr_value) from payment,payment_component,payment_component_piece_rates,rd.piece_rate_type where(payment.invoice_id = payment_component.invoice_id) and(payment_component_piece_rates.pc_id = payment_component.pc_id) and(piece_rate_type.prt_key = payment_component_piece_rates.prt_key) and(piece_rate_supplier.prs_key = piece_rate_type.prs_key) and(payment_component.invoice_id = @invoiceid)) from
    rd.piece_rate_supplier where
    (select sum(payment_component_piece_rates.pcpr_volume) from payment,payment_component,payment_component_piece_rates,rd.piece_rate_type where(payment.invoice_id = payment_component.invoice_id) and(payment_component_piece_rates.pc_id = payment_component.pc_id) and(piece_rate_type.prt_key = payment_component_piece_rates.prt_key) and(piece_rate_supplier.prs_key = piece_rate_type.prs_key) and(payment_component.invoice_id = @invoiceid)) > 0
end
GO
