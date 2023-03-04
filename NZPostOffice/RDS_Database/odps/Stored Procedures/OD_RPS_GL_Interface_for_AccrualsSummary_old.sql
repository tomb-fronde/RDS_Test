


--
-- Definition for stored procedure OD_RPS_GL_Interface_for_AccrualsSummary_old : 
--

create procedure [odps].[OD_RPS_GL_Interface_for_AccrualsSummary_old](@ProcDate datetime)
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  select pbu_code=pbu_code.pbu_code,
    account_number=account_codes.ac_code,
    transaction_amount=sum(abs(pc_amount))*.3548387096774,description='RD Accruals - Contract Price',drcr='D',
    trans=0,trans2=0 from
    rd.contract,
    payment,
    payment_component,
    payment_component_group,
    payment_component_type,
    account_codes,
    pbu_code where
    (contract.contract_no = payment.contract_no) and
    (payment_component.invoice_id = payment.invoice_id) and
    (payment_component_type.pcg_id = payment_component_group.pcg_id) and
    (payment_component_type.pct_id = payment_component.pct_id) and
    (pbu_code.pbu_id = contract.pbu_id) and
    (account_codes.ac_id = payment_component_type.ac_id) and
    (payment_component_group.pcg_short_code = 'GP' or
    payment_component_group.pcg_short_code = 'OGP') and
    payment.invoice_date = @procdate
    group by pbu_code.pbu_code,
    account_codes.ac_code union
  select pbu_code=isnull((select pbu_code.pbu_code from "national",pbu_code where nat_pbu_code_gst_gl = pbu_id and "national".nat_id = (select odps.od_blf_getwhichnational(@procdate)  )),'49999'),
    account_number=isnull((select account_codes.ac_code from account_codes,"national" where nat_ac_id_accrualBalance_gl = account_codes.ac_id and "national".nat_id = (select odps.od_blf_getwhichnational(@procdate)  )),'4250'),
    transaction_amount=abs(sum(pc_amount)*.3548387096774)*-1,description='RD Accruals - GST',drcr='C',
    trans=0,trans2=0 from
    rd.contract,
    payment,
    payment_component,
    payment_component_group,
    payment_component_type where
    (contract.contract_no = payment.contract_no) and
    (payment_component.invoice_id = payment.invoice_id) and
    (payment_component_type.pcg_id = payment_component_group.pcg_id) and
    (payment_component_type.pct_id = payment_component.pct_id) and
    (payment_component_group.pcg_short_code = 'GST') and
    payment.invoice_date = @procdate
end