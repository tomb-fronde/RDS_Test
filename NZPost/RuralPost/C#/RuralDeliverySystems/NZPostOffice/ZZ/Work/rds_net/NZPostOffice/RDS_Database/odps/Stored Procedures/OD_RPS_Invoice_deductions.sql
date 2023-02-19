
--
-- Definition for stored procedure OD_RPS_Invoice_deductions : 
--

create procedure [odps].[OD_RPS_Invoice_deductions](@invoiceid int)
AS
BEGIN
  select post_tax_deductions_applied.pcd_date,
    post_tax_deductions.ded_description,
    post_tax_deductions_applied.pcd_amount*-1 from
    post_tax_deductions,
    post_tax_deductions_applied where
    (post_tax_deductions.ded_id = post_tax_deductions_applied.ded_id) and
    ((post_tax_deductions_applied.invoice_id = @invoiceid))
end