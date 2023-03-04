

--
-- Definition for stored procedure OD_RPS_IR13_Interface_Detail : 
--

create procedure [odps].[OD_RPS_IR13_Interface_Detail](@StartDate datetime,@EndDate datetime)
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  select distinct Owner_Driver_IRD_Number=odps.OD_MiscF_ParseIRDNo(contractor.c_ird_no),
    Owner_Driver_name=contractor.c_surname_company + isnull(', ' + contractor.c_first_names,''),
    Owner_Driver_Address=contractor.c_address,
    Owner_Driver_GST_Number=contractor.c_gst_number,
    Contract_ID=p1.contract_no,
    tax=(select abs(sum(pc_amount)) from
      payment as p,
      payment_component,
      payment_component_type,
      payment_component_group where
      payment_component.pct_id = payment_component_type.pct_id and
      payment_component_group.pcg_id = payment_component_type.pcg_id and
      payment_component_group.pcg_Short_code = 'TAX' and
      p.invoice_id = payment_component.invoice_id and
      p.contractor_supplier_no = contractor.contractor_supplier_no and
      p.invoice_date between @StartDate and @EndDate),
    gross_pay=(select abs(sum(pc_amount)) from
      payment as p,
      payment_component,
      payment_component_type,
      payment_component_group where
      payment_component.pct_id = payment_component_type.pct_id and
      payment_component_group.pcg_id = payment_component_type.pcg_id and
      payment_component_group.pcg_Short_code in('GP','OGP') and
      p.invoice_id = payment_component.invoice_id and
      p.contractor_supplier_no = contractor.contractor_supplier_no and
      p.invoice_date between @StartDate and @EndDate),
    start_date=case when (select min(contractor_renewals.cr_effective_date) from
      rd.contractor_renewals where
      (contractor_renewals.contractor_supplier_no = contractor.contractor_supplier_no) and
      contractor_renewals.cr_effective_date <= @EndDate) < @StartDate then
      @StartDate
    else
      (select min(contractor_renewals.cr_effective_date) from
        rd.contractor_renewals where
        (contractor_renewals.contractor_supplier_no = contractor.contractor_supplier_no) and
        contractor_renewals.cr_effective_date <= @EndDate)
    end,
    end_date=case when (select distinct 1 from
      rd.contractor_renewals,
      rd.contract_renewals,
      rd.contractor where
      (contract_renewals.contract_no = contractor_renewals.contract_no) and
      (contract_renewals.contract_seq_number = contractor_renewals.contract_seq_number) and
      (contractor.contractor_supplier_no = contractor_renewals.contractor_supplier_no) and
      (contract_renewals.con_expiry_date is null or contract_renewals.con_expiry_date > @EndDate)) = 1 then
      @EndDate
    else
      (select max(contract_renewals.con_expiry_date) from
        rd.contractor_renewals,
        rd.contract_renewals where
        (contract_renewals.contract_no = contractor_renewals.contract_no) and
        (contract_renewals.contract_seq_number = contractor_renewals.contract_seq_number) and
        (contractor.contractor_supplier_no = contractor_renewals.contractor_supplier_no) and
        (contract_renewals.con_expiry_date < @EndDate))
    end from
    rd.contractor,payment as p1 where
    p1.contractor_supplier_no = contractor.contractor_supplier_no and
    p1.invoice_date between @StartDate and @EndDate
end