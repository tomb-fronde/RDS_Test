/****** Object:  StoredProcedure [odps].[OD_RPS_WithholdingTax]    Script Date: 08/05/2008 10:14:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure  [odps].[OD_RPS_WithholdingTax](@sdate datetime,@edate datetime,@fin_sdate datetime,@fin_edate datetime)
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  select  distinct [contract].contract_no,
    contractor.c_surname_company,
    contractor.c_first_names,
    contractor.c_initials ,
    pbu_code.pbu_code,
    ac_code=cast(odps.OD_MiscF_Get_ACID([contract].contract_no)as varchar(10)),
      amount=cast((select abs(sum(odps.OD_RPF_PCGetSum(payment.invoice_id,'TAX')) ) from
      payment where
      payment.invoice_date between @sdate and @edate and
      payment.contract_no = [contract].contract_no and
      payment.contractor_supplier_no = contractor.contractor_supplier_no) as decimal(30,6)),
    yearamount=cast(isnull( (select abs(sum(payment_component.pc_amount)) from
      payment,
      payment_component,
      payment_component_type,
      payment_component_group where
      payment.contract_no = [contract].contract_no and
      payment.contractor_supplier_no = contractor.contractor_supplier_no and
      payment.invoice_id = payment_component.invoice_id and
      payment_component.pct_id = payment_component_type.pct_id and
      payment_component_type.pcg_id = payment_component_group.pcg_id and
      payment_component_group.pcg_short_code = 'TAX' and
      payment.invoice_date between @fin_sdate and @fin_edate),0) as decimal(30,6)) from
    rd.contract_renewals,
    rd.contractor_renewals,
    rd.[contract],
    pbu_code,
    rd.contractor where
    (contractor_renewals.contract_no = contract_renewals.contract_no) and
    pbu_code.pbu_id = [contract].pbu_id and
    contractor_renewals.contractor_supplier_no = contractor.contractor_supplier_no and
    (contractor_renewals.contract_seq_number = contract_renewals.contract_seq_number) and
    ([contract].contract_no = contract_renewals.contract_no) 
and
    --    and(contract.con_active_sequence=contract_renewals.contract_seq_number)
    exists(select invoice_id from
      payment where
      payment.contractor_supplier_no = contractor.contractor_supplier_no and
      payment.contract_no = [contract].contract_no and
      payment.invoice_date between @fin_sdate and @fin_edate) and
    (select abs(sum(payment_component.pc_amount)) from
      payment,
      payment_component,
      payment_component_type,
      payment_component_group where
      payment.contract_no = [contract].contract_no and
      payment.contractor_supplier_no = contractor.contractor_supplier_no and
      payment.invoice_id = payment_component.invoice_id and
      payment_component.pct_id = payment_component_type.pct_id and
      payment_component_type.pcg_id = payment_component_group.pcg_id and
      payment_component_group.pcg_short_code = 'TAX' and
      payment.invoice_date between @fin_sdate and @fin_edate) <> 0 order by
    [contract].contract_no asc  
--  contractor_renewals.contract_seq_number asc,
--  contractor_renewals.cr_effective_date asc

end
GO
