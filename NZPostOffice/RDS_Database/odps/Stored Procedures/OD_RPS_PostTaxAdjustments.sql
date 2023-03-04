

--
-- Definition for stored procedure OD_RPS_PostTaxAdjustments : 
--

create procedure [odps].[OD_RPS_PostTaxAdjustments](@sdate datetime,@edate datetime)
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  select distinct payment.contract_no,
    contractor.c_surname_company,
    contractor.c_first_names,
    contractor.c_initials,
    (select pbu_code.pbu_code from pbu_code where pbu_code.pbu_id = contract.pbu_id),
    account_codes.ac_code,
    Amount=odps.OD_RPF_PCGetSum(payment.invoice_id,'PTA')*-1 from
    rd.contractor,
    rd.contract left outer join account_codes on contract.ac_id = account_codes.ac_id,
    payment,
    payment_component,
    payment_component_type,
    payment_component_group where
    contractor.contractor_supplier_no = payment.contractor_supplier_no and
    payment.contract_no = contract.contract_no and
    payment.invoice_date between @sdate and @edate and
    payment.invoice_id = payment_component.invoice_id and
    payment_component.pct_id = payment_component_type.pct_id and
    payment_component_TYPE.pcg_id = payment_component_group.pcg_id and
    pcg_short_code like 'PTA%'
end