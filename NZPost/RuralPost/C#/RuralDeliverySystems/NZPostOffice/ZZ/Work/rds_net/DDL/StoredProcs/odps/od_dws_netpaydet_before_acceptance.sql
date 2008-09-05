/****** Object:  StoredProcedure [odps].[od_dws_netpaydet_before_acceptance]    Script Date: 08/05/2008 10:13:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for stored procedure od_dws_netpaydet_before_acceptance : 
--

create procedure [odps].[od_dws_netpaydet_before_acceptance]
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  select(case when payment_component_type.pct_description like 'Withh%' then t_payment_component.pc_amount*-1 else t_payment_component.pc_amount end),
    t_payment.contract_no,
    account_codes.ac_code,
    t_payment_component.comments,
    name=c_surname_company + case when isnull(c_first_names,'') = '' then '' else ', ' + 

c_first_names end  + ' 
                                                                                                                           ' 
from
    odps.payment_component_type,
    odps.t_payment,
    odps.t_payment_component,
    rd.contractor,
    odps.account_codes where
    (t_payment_component.invoice_id = t_payment.invoice_id) and
    (t_payment_component.pct_id = payment_component_type.pct_id) and
    (t_payment.contractor_supplier_no = contractor.contractor_supplier_no) and
    (account_codes.ac_id = payment_component_type.ac_id) order by
    t_payment.contract_no asc,c_surname_company asc
end
GO
