/****** Object:  StoredProcedure [odps].[OD_RPS_NegativePay]    Script Date: 08/05/2008 10:14:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for stored procedure OD_RPS_NegativePay : 
--

create procedure [odps].[OD_RPS_NegativePay](@sdate datetime,@edate datetime)
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  select payment.contract_no,
    contractor.c_surname_company,
    contractor.c_first_names,
    contractor.c_initials,
    Gross_Pay=odps.OD_RPF_PCNegitivePayGetSum(payment.invoice_id,'GP')+odps.OD_RPF_PCNegitivePayGetSum(payment.invoice_id,'OGP'),
    GST=odps.OD_RPF_PCGetSum(payment.invoice_id,'GST')*-1,
    Tax=abs(odps.OD_RPF_PCGetSum(payment.invoice_id,'TAX')),
    Post_Tax_Adjustments=odps.OD_RPF_PCGetSum(payment.invoice_id,'PTD')*-1,
    Net_Pay=(odps.OD_RPF_PCNegitivePayGetSum(payment.invoice_id,'GP')+odps.OD_RPF_PCNegitivePayGetSum(payment.invoice_id,'OGP') ) + (odps.OD_RPF_PCGetSum(payment.invoice_id,'GST')*-1) - abs(odps.OD_RPF_PCGetSum(payment.invoice_id,'TAX')) - (odps.OD_RPF_PCGetSum(payment.invoice_id,'PTD')*-1) from
    rd.contractor,
    payment where
    contractor.contractor_supplier_no = payment.contractor_supplier_no and
    odps.OD_RPF_PCNegitivePayGetSum(payment.invoice_id,'GP')+odps.OD_RPF_PCNegitivePayGetSum(payment.invoice_id,'OGP')
	+odps.OD_RPF_PCGetSum(payment.invoice_id,'GST')*-1
	-abs(odps.OD_RPF_PCGetSum(payment.invoice_id,'TAX'))
	-odps.OD_RPF_PCGetSum(payment.invoice_id,'PTD')*-1 < 0 and
    payment.invoice_date between @sdate and @edate
end
GO
