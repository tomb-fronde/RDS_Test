
--
-- Definition for stored procedure OD_RPS_IR66ES : 
--

create procedure [odps].[OD_RPS_IR66ES](@sdate datetime,@edate datetime)
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  select distinct contractor.c_surname_company,
    contractor.c_first_names,
    contractor.c_initials,
    StartDate=contractor_renewals.cr_effective_date,
    EndDate=(select dateadd(day,-1,min(cr.cr_effective_date)) from
      rd.contractor_renewals as cr where
      cr.contract_no = contract_renewals.contract_no and
      cr.contract_seq_number = contract_renewals.contract_seq_number and
      cr.cr_effective_date > contractor_renewals.cr_effective_date),
    TaxCategory=case contractor.c_witholding_tax_certificate when null then 'N' else case contractor.c_witholding_tax_certificate when 'N' then 'W' else 'N' end end,
    c_ird_no from
    rd.contractor,
    rd.contract_renewals,
    rd.contractor_renewals,
    rd.contract where
    contractor_renewals.contractor_supplier_no = contractor.contractor_supplier_no and
    (contractor_renewals.contract_no = contract_renewals.contract_no) and
    (contractor_renewals.contract_seq_number = contract_renewals.contract_seq_number) and
    (contract.contract_no = contract_renewals.contract_no) and
    (contract.con_active_sequence = contract_renewals.contract_seq_number) and
    ((contractor_renewals.cr_effective_date between @sdate and @edate) or
    ((select dateadd(day,-1,min(cr.cr_effective_date)) from
      rd.contractor_renewals as cr where
      cr.contract_no = contract_renewals.contract_no and
      cr.contract_seq_number = contract_renewals.contract_seq_number and
      cr.cr_effective_date > contractor_renewals.cr_effective_date) between @sdate and @edate)) and
    not contractor.contractor_supplier_no = 
    any(select contractor2.contractor_supplier_no from
      rd.contract as contract2,
      rd.contract_renewals as contract_renewals2,
      rd.contractor as contractor2,
      rd.contractor_renewals as contractor_renewals2 where
      (contractor_renewals2.contractor_supplier_no = contractor2.contractor_supplier_no) and
      (contractor_renewals2.contract_no = contract_renewals2.contract_no) and
      (contractor_renewals2.contract_seq_number = contract_renewals2.contract_seq_number) and
      (contract2.con_active_sequence = contract_renewals2.contract_seq_number) and
      (contract2.contract_no = contract_renewals2.contract_no) and
      (contractor_renewals2.cr_effective_date = contract_renewals2.con_date_last_assigned) and
      (contractor2.contractor_supplier_no = contractor.contractor_supplier_no) and
      (contract2.con_date_terminated is null) and
      (contractor_renewals2.cr_effective_date < contractor_renewals.cr_effective_date or contractor_renewals2.cr_effective_date > (select dateadd(day,-1,min(cr.cr_effective_date)) from
      rd.contractor_renewals as cr where
      cr.contract_no = contract_renewals.contract_no and
      cr.contract_seq_number = contract_renewals.contract_seq_number and
      cr.cr_effective_date > contractor_renewals.cr_effective_date)))
end