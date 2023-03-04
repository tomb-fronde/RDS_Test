
create procedure [rd].[sp_GetCustomerNoCommencement](@in_Region int,@in_Days int)
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  select customer.contract_no,
    customer.cust_title,
    customer.cust_surname_company,
    customer.cust_initials,
    customer.cust_date_first_loaded,
    contractor.c_surname_company,
    contractor.c_initials,
    contractor.c_phone_day from
    customer,
    contract_renewals,
    contractor,
    contractor_renewals,
    contract,
    outlet where
    (contract.con_base_office = outlet.outlet_id) and
    ((outlet.region_id = @in_region and @in_region is not null) or(@in_region is null)) and
    (customer.contract_no = contract_renewals.contract_no) and
    (contract.contract_no = contract_renewals.contract_no) and
    (contract.con_active_sequence = contract_renewals.contract_seq_number) and
    (contract_renewals.contract_seq_number = contractor_renewals.contract_seq_number) and
    (contractor.contractor_supplier_no = contractor_renewals.contractor_supplier_no) and
    (contract_renewals.contract_no = contractor_renewals.contract_no) and
    (contract_renewals.contract_seq_number = contractor_renewals.contract_seq_number) and
    (contract.contract_no = contract_renewals.contract_no) and
    (contract.contract_no = customer.contract_no) and
    (contractor_renewaLs.cr_effective_date = (select max(cr_effective_date) from
      contractor_renewals as cr where
      cr.contract_no = contract.contract_no and
      cr.contract_seq_number = contract_renewals.contract_seq_number)) and
    ((customer.cust_date_commenced is null and datediff(day,customer.cust_date_first_loaded,getdate()) >= @in_days))
end