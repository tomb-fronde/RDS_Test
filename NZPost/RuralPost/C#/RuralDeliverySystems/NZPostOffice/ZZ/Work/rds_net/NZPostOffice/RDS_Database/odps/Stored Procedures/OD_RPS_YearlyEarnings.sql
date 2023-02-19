create procedure  [odps].[OD_RPS_YearlyEarnings](@sdate datetime,@edate datetime,@inregion int)
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
 
    select distinct region=(select rgn_name from rd.region where region.region_id = outlet.region_id),
    [contract].contract_no,
    name=c_surname_company + case  when c_initials is null then '' else ', ' + c_initials end,
    contractor.c_ird_no,
    grossearnings=(select odps.OD_RPF_PCYearlyEarnings(contractor.contractor_supplier_no,[contract].contract_no,contractor_renewals.contract_seq_number,@sdate,@edate,'GP',null)+odps.OD_RPF_PCYearlyEarnings(contractor.contractor_supplier_no,[contract].contract_no,contractor_renewals.contract_seq_number,@sdate,@edate,'OGP',null)  ), --!added 2 null in 2 functions' parameter lists
    WithholdingTax=(select odps.OD_RPF_PCGetSumYear(contractor.contractor_supplier_no,[contract].contract_no,contractor_renewals.contract_seq_number,@sdate,@edate,'TAX',null)  ),
    GST=(select-1* odps.OD_RPF_PCGetSumYear(contractor.contractor_supplier_no,[contract].contract_no,contractor_renewals.contract_seq_number,@sdate,@edate,'GST',null)  ) from
    rd.[contract],
    rd.outlet,
    rd.contractor,
    rd.contractor_renewals where
    ([contract].con_base_office = outlet.outlet_id) and
    (contractor_renewals.contractor_supplier_no = contractor.contractor_supplier_no) and
    ([contract].contract_no = contractor_renewals.contract_no) and
    ((outlet.region_id = @inregion and @inregion > 
    0) or(@inregion = 
    0)) and
    exists(select payment.contractor_supplier_no from
      payment where
      (payment.contract_no = [contract].contract_no) and
      (payment.contractor_supplier_no = contractor.contractor_supplier_no) and
      (payment.contract_seq_number = contractor_renewals.contract_seq_number) and
      ((payment.invoice_date between @sdate and @edate))) 

end