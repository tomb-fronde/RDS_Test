/****** Object:  StoredProcedure [odps].[OD_RPS_TNegativePay]    Script Date: 08/05/2008 10:14:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for stored procedure OD_RPS_TNegativePay : 
--

create procedure [odps].[OD_RPS_TNegativePay]
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  select t_payment.contract_no,
    contractor.c_surname_company,
    contractor.c_first_names,
    contractor.c_initials,
    Gross_Pay=odps.OD_RPF_PCTNegativePayGetSum(t_payment.invoice_id,'GP')
				+odps.OD_RPF_PCTNegativePayGetSum(t_payment.invoice_id,'OGP'),
    GST=odps.OD_RPF_PCTGetSum(t_payment.invoice_id,'GST')*-1,
    Tax=abs(odps.OD_RPF_PCTGetSum(t_payment.invoice_id,'TAX')),
    Post_Tax_Adjustments=odps.OD_RPF_PCTGetSum(t_payment.invoice_id,'PTD')*-1,
    Net_Pay=odps.OD_RPF_PCTNegativePayGetSum(odps.t_payment.invoice_id,'GP')
			+odps.OD_RPF_PCTNegativePayGetSum(odps.t_payment.invoice_id,'OGP')
			+odps.OD_RPF_PCTGetSum(odps.t_payment.invoice_id,'GST')*-1
			-abs(odps.OD_RPF_PCTGetSum(odps.t_payment.invoice_id,'TAX'))
			-odps.OD_RPF_PCTGetSum(odps.t_payment.invoice_id,'PTD')*-1
from
    rd.contractor,
    t_payment where
    contractor.contractor_supplier_no = t_payment.contractor_supplier_no and
    odps.OD_RPF_PCTNegativePayGetSum(t_payment.invoice_id,'GP')+odps.OD_RPF_PCTNegativePayGetSum(t_payment.invoice_id,'OGP')
	+odps.OD_RPF_PCTGetSum(t_payment.invoice_id,'GST')*-1
	-abs(odps.OD_RPF_PCTGetSum(t_payment.invoice_id,'TAX'))
	-odps.OD_RPF_PCTGetSum(t_payment.invoice_id,'PTD')*-1 < 0
end
GO
