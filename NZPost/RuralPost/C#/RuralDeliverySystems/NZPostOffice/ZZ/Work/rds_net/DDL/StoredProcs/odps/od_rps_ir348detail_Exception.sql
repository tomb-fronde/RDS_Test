/****** Object:  StoredProcedure [odps].[od_rps_ir348detail_Exception]    Script Date: 08/05/2008 10:14:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [odps].[od_rps_ir348detail_Exception](@startdate datetime,@enddate datetime)
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
 begin transaction
  delete from t_ir348
  insert into t_ir348(contractor_supplier_no,start_date)
    select contractor_renewals.contractor_supplier_no,
      contractor_renewals.cr_effective_date from
      rd.contract_renewals,
      rd.contractor_renewals,
      rd.contract where
      (contractor_renewals.contract_no = contract_renewals.contract_no) and
      (contractor_renewals.contract_seq_number = contract_renewals.contract_seq_number) and
      (contract.contract_no = contract_renewals.contract_no) and
      (contract_renewals.contract_seq_number = contract.con_active_sequence or
      exists(select p.contract_seq_number from payment as p where p.contractor_supplier_no = contractor_renewals.contractor_supplier_no and p.contract_no = contract.contract_no and p.invoice_date between @startdate and @enddate)) and
      (((contract_renewals.con_start_date <= @enddate) and
      (contract.con_date_terminated is null or contract.con_date_terminated >= @startdate or datediff(day,contract.con_date_terminated,'1999-2-21') < 32 or contract.con_date_terminated between @startdate and @enddate)) or
      exists(select contractor_supplier_no from payment where invoice_date between @startdate and @enddate)) and
      contractor_renewals.cr_effective_date = 
      (select max(cr_effective_date) from rd.contractor_renewals as cr2 where
        cr2.contractor_supplier_no = contractor_renewals.contractor_supplier_no)
      group by contractor_renewals.contractor_supplier_no,cr_effective_date
  commit transaction
  select dtl='DTL','0' + 
    (case when len(c_ird_no) = 0 or c_ird_no is null then '00000000' else c_ird_no
    end),
    Employee_Full_Name=left((case when len(c_initials) > 0 then c_initials + ' '
    else '' end) + c_surname_company,20),
    tax_code=(case when len(c_ird_no) = 0 or c_ird_no is null then 'ND' else 'M' end),
    start_date=case when (select min(cr2.cr_effective_date) from rd.contractor_renewals as cr2 where cr2.contractor_supplier_no = contractor.contractor_supplier_no) between @startdate and @enddate then
      convert(char,(select min(cr2.cr_effective_date) from rd.contractor_renewals as cr2 where cr2.contractor_supplier_no = contractor.contractor_supplier_no),112)
    else
      null
    end,
    end_date=case when (select max(end_date) from t_ir348 where contractor_supplier_no = contractor.contractor_supplier_no) between @startdate and @enddate then convert(char,(select max(end_date) from t_ir348 where contractor_supplier_no = contractor.contractor_supplier_no),112)
    else '' end,Gross_Earnings=(select convert(decimal(10),isnull(round(sum(payment_component.pc_amount),0)*100,0)) from
      payment,payment_component,payment_component_type,payment_component_group where
      payment_component.invoice_id = payment.invoice_id and payment_component.pct_id = payment_component_type.pct_id and
      payment_component_group.pcg_id = payment_component_type.pcg_id and(payment_component_group.pcg_short_code in('GP','OGP')) and
      payment.contractor_supplier_no = contractor.contractor_supplier_no and
      (payment.invoice_date between @startdate and @enddate)),
    Not_Liable=(case when NZ_Post_Employee is null or NZ_Post_Employee = 'N' then convert(decimal(10),(select convert(decimal(10),isnull(round(sum(payment_component.pc_amount),0)*100,0)) from
      payment,payment_component,payment_component_type,payment_component_group where
      payment_component.invoice_id = payment.invoice_id and payment_component.pct_id = payment_component_type.pct_id and
      payment_component_group.pcg_id = payment_component_type.pcg_id and(payment_component_group.pcg_short_code in('GP','OGP')) and
      payment.contractor_supplier_no = contractor.contractor_supplier_no and
      (payment.invoice_date between @startdate and @enddate))) else 0 end),
    Lump_sum=0,
    Total_PAYE=(select isnull(convert(decimal(10),round(sum(payment_component.pc_amount)*-100,0)),0) from
      payment,payment_component,payment_component_type where
      payment_component.invoice_id = payment.invoice_id and payment_component.pct_id = payment_component_type.pct_id and
      payment.contractor_supplier_no = contractor.contractor_supplier_no and
      payment_component_type.pct_description like 'Withholding tax%' and(payment.invoice_date between @startdate and @enddate)),
    CS_Deductions=0,CS_DeductionCode='',
    SL_Deductions=0,Family_Assistance=0 from
    rd.contractor where
    contractor.contractor_supplier_no = any(select contractor_supplier_no from t_ir348) and
    ((select convert(decimal(10),isnull(round(sum(payment_component.pc_amount),0)*100,0)) from
      payment,payment_component,payment_component_type,payment_component_group where
      payment_component.invoice_id = payment.invoice_id and payment_component.pct_id = payment_component_type.pct_id and
      payment_component_group.pcg_id = payment_component_type.pcg_id and(payment_component_group.pcg_short_code in('GP','OGP')) and
      payment.contractor_supplier_no = contractor.contractor_supplier_no and
      (payment.invoice_date between @startdate and @enddate)) < 0 or (select isnull(convert(decimal(10),round(sum(payment_component.pc_amount)*-100,0)),0) from
      payment,payment_component,payment_component_type where
      payment_component.invoice_id = payment.invoice_id and payment_component.pct_id = payment_component_type.pct_id and
      payment.contractor_supplier_no = contractor.contractor_supplier_no and
      payment_component_type.pct_description like 'Withholding tax%' and(payment.invoice_date between @startdate and @enddate)) < 0) order by
    c_surname_company asc
end
GO
