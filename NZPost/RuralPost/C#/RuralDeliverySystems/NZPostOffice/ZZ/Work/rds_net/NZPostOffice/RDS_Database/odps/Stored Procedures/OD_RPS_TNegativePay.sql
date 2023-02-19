
CREATE procedure [odps].[OD_RPS_TNegativePay]
AS
BEGIN
  -- TJB  RPCR_094  Mar-2015
  -- Fix: Change payment_component_group.pcg_short_code in call
  --      to OD_RPF_PCTGetSum from 'PTD' to PTA'
  set CONCAT_NULL_YIELDS_NULL off
  select t_payment.contract_no,
         contractor.c_surname_company,
         contractor.c_first_names,
         contractor.c_initials,
         Gross_Pay=odps.OD_RPF_PCTNegativePayGetSum(t_payment.invoice_id,'GP')
				+odps.OD_RPF_PCTNegativePayGetSum(t_payment.invoice_id,'OGP'),
         GST=odps.OD_RPF_PCTGetSum(t_payment.invoice_id,'GST')*-1,
         Tax=abs(odps.OD_RPF_PCTGetSum(t_payment.invoice_id,'TAX')),
         Post_Tax_Adjustments=odps.OD_RPF_PCTGetSum(t_payment.invoice_id,'PTA')*-1,
         Net_Pay=odps.OD_RPF_PCTNegativePayGetSum(odps.t_payment.invoice_id,'GP')
			+odps.OD_RPF_PCTNegativePayGetSum(odps.t_payment.invoice_id,'OGP')
			+odps.OD_RPF_PCTGetSum(odps.t_payment.invoice_id,'GST')*-1
			-abs(odps.OD_RPF_PCTGetSum(odps.t_payment.invoice_id,'TAX'))
			-odps.OD_RPF_PCTGetSum(odps.t_payment.invoice_id,'PTA')*-1,
         Contract_Pay=abs(odps.OD_RPF_PCTGetSum(t_payment.invoice_id,'CP'))
   from
         rd.contractor,
         odps.t_payment 
   where
         contractor.contractor_supplier_no = t_payment.contractor_supplier_no 
     and odps.OD_RPF_PCTNegativePayGetSum(t_payment.invoice_id,'GP')
         + odps.OD_RPF_PCTNegativePayGetSum(t_payment.invoice_id,'OGP')
         + odps.OD_RPF_PCTGetSum(t_payment.invoice_id,'GST')*-1
	 - abs(odps.OD_RPF_PCTGetSum(t_payment.invoice_id,'TAX'))
	 - odps.OD_RPF_PCTGetSum(t_payment.invoice_id,'PTA')*-1 < 0
end