
CREATE procedure [odps].[OD_RPS_Invoice_Pay_Allowance_Breakdown](
	@inInvoiceId int)
as
-- TJB  RPCR_056  June 2013:   New
-- Return the allowances for the invoice, found in t_invoice_allowances
-- (see OD_DWS_Invoice_Allowance_Detail).  Used by allowance breakdown 
-- section of the Invoice.
begin
  set CONCAT_NULL_YIELDS_NULL off
  select contract_no
       , invoice_id
       , alt_key
       , alt_description
       , amount
    from odps.t_invoice_allowances
   where invoice_id = @inInvoiceId
end