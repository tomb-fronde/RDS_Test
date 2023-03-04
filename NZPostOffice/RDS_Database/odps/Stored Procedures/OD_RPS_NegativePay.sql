
CREATE procedure [odps].[OD_RPS_NegativePay](
	 @sdate datetime
	,@edate datetime)
AS
BEGIN
  -- TJB  RPCR_094  Mar-2015
  -- Fix: Change payment_component_group.pcg_short_code in call
  --      to OD_RPF_PCTGetSum from 'PTD' to PTA'
  set CONCAT_NULL_YIELDS_NULL off
  select pmt.contract_no
       , contractor.c_surname_company
       , contractor.c_first_names
       , contractor.c_initials
       , Gross_Pay=odps.OD_RPF_PCNegitivePayGetSum(pmt.invoice_id,'GP')
                   +odps.OD_RPF_PCNegitivePayGetSum(pmt.invoice_id,'OGP')
       , GST=odps.OD_RPF_PCGetSum(pmt.invoice_id,'GST')*-1
       , Tax=abs(odps.OD_RPF_PCGetSum(pmt.invoice_id,'TAX'))
       , Post_Tax_Adjustments=odps.OD_RPF_PCGetSum(pmt.invoice_id,'PTA')*-1
       , Net_Pay=(odps.OD_RPF_PCNegitivePayGetSum(pmt.invoice_id,'GP')
         + odps.OD_RPF_PCNegitivePayGetSum(pmt.invoice_id,'OGP') ) 
         + (odps.OD_RPF_PCGetSum(pmt.invoice_id,'GST')*-1) 
         - abs(odps.OD_RPF_PCGetSum(pmt.invoice_id,'TAX')) 
         - (odps.OD_RPF_PCGetSum(pmt.invoice_id,'PTA')*-1) 
   from rd.contractor
      , odps.payment pmt
  where contractor.contractor_supplier_no = pmt.contractor_supplier_no 
    and odps.OD_RPF_PCNegitivePayGetSum(pmt.invoice_id,'GP')
        + odps.OD_RPF_PCNegitivePayGetSum(pmt.invoice_id,'OGP')
	+ odps.OD_RPF_PCGetSum(pmt.invoice_id,'GST')*-1
	- abs(odps.OD_RPF_PCGetSum(pmt.invoice_id,'TAX'))
	- odps.OD_RPF_PCGetSum(pmt.invoice_id,'PTA')*-1 < 0 
    and pmt.invoice_date between @sdate and @edate
end