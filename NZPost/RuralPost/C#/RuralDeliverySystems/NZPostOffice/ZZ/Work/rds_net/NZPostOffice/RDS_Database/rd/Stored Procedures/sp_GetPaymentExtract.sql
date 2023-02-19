
--
-- Definition for stored procedure sp_GetPaymentExtract : 
--

create procedure [rd].[sp_GetPaymentExtract](
@inPayPeriod datetime)
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  create table #tmp_payment_process(
    contract_no int null,
    contract_seq_number int null,
    con_old_mail_service_no char(6) null,
    contract_title char(60) null,
    contractor_supplier_no int null,
    contractor_title char(10) null,
    contractor_surname_company char(40) null,
    contractor_firstnames char(40) null,
    contractor_initials char(10) null,
    payment_type char(15) null,
    payment_description char(40) null,
    payment_effective_date datetime null,
    payment_amount decimal(10,2) null)
  
  
  declare @dPayStartDate datetime
  declare @dPayEndDate datetime
  declare @dLastPayStartDate datetime
  declare @dLastPayEndDate datetime
  select @dPayEndDate=@inPayPeriod
  select @dLastPayEndDate=dateadd(Month,-1,@inPayPeriod)
  select @dPayStartDate=dateadd(Day,1,@dLastPayEndDate)
  select @dLastPayStartDate=dateadd(Month,-1,@dPayStartDate)
  delete from #tmp_payment_process
  insert into #tmp_payment_process(contract_no,
    contract_seq_number,
    con_old_mail_service_no,
    contract_title,
    contractor_supplier_no,
    contractor_title,
    contractor_surname_company,
    contractor_firstnames,
    contractor_initials,
    payment_type,
    payment_description,
    payment_effective_date,
    payment_amount)
    select contract.contract_no,
      contract_renewals.contract_seq_number,
      contract.con_old_mail_service_no,
      contract.con_title,
      contractor.contractor_supplier_no,
      contractor.c_title,
      contractor.c_surname_company,
      contractor.c_first_names,
      contractor.c_initials,'Allowances',
      allowance_type.alt_description,
      contract_allowance.ca_effective_date,
      contract_allowance.ca_annual_amount 
    from contract 
      join contract_renewals on
      contract.contract_no = contract_renewals.contract_no and
      contract.con_active_sequence = contract_renewals.contract_seq_number and
      contract.con_date_terminated is null 
      join contract_allowance on
      contract.contract_no = contract_allowance.contract_no and
      contract_allowance.ca_effective_date < @dPayStartDate and
      contract_allowance.ca_paid_to_date is null
      join allowance_type on
      contract_allowance.alt_key = allowance_type.alt_key
      join  contractor_renewals on
      contract_renewals.contract_no = contractor_renewals.contract_no and
      contract_renewals.contract_seq_number = contractor_renewals.contract_seq_number and
      contract_renewals.con_date_last_assigned = contractor_renewals.cr_effective_date
      join contractor on
      contractor_renewals.contractor_supplier_no = contractor.contractor_supplier_no
  update contract_allowance set
    contract_allowance.ca_paid_to_date = @dPayEndDate where
    contract_allowance.ca_effective_date < @dPayStartDate
  insert into #tmp_payment_process(contract_no,
    contract_seq_number,
    con_old_mail_service_no,
    contract_title,
    contractor_supplier_no,
    contractor_title,
    contractor_surname_company,
    contractor_firstnames,
    contractor_initials,
    payment_type,
    payment_description,
    payment_effective_date,
    payment_amount)
    select contract.contract_no,
      contract_renewals.contract_seq_number,
      contract.con_old_mail_service_no,
      contract.con_title,
      contractor.contractor_supplier_no,
      contractor.c_title,
      contractor.c_surname_company,
      contractor.c_first_names,
      contractor.c_initials,'Adjustments',
      contract_adjustments.ca_reason,
      contract_adjustments.ca_date_occured,
      contract_adjustments.ca_amount 
    from contract 
      join contract_renewals on
      contract.contract_no = contract_renewals.contract_no and
      contract.con_active_sequence = contract_renewals.contract_seq_number and
      contract.con_date_terminated is null 
      join contract_adjustments on
      contract.contract_no = contract_adjustments.contract_no and
      contract_adjustments.ca_date_occured <= @dPayEndDate and
      contract_adjustments.ca_date_paid is null and
      contract_adjustments.ca_confirmed = 'Y'
      join contractor_renewals on
      contract_renewals.contract_no = contractor_renewals.contract_no and
      contract_renewals.contract_seq_number = contractor_renewals.contract_seq_number and
      contract_renewals.con_date_last_assigned = contractor_renewals.cr_effective_date
      join  contractor on
      contractor_renewals.contractor_supplier_no = contractor.contractor_supplier_no
  update contract_adjustments set
    ca_date_paid = @dPayEndDate where
    contract_adjustments.ca_date_occured <= @dPayEndDate and
    contract_adjustments.ca_date_paid is null and
    contract_adjustments.ca_confirmed = 'Y'
  insert into #tmp_payment_process(contract_no,
    contract_seq_number,
    con_old_mail_service_no,
    contract_title,
    contractor_supplier_no,
    contractor_title,
    contractor_surname_company,
    contractor_firstnames,
    contractor_initials,
    payment_type,
    payment_description,
    payment_effective_date,
    payment_amount)
    select contract.contract_no,
      contract_renewals.contract_seq_number,
      contract.con_old_mail_service_no,
      contract.con_title,
      contractor.contractor_supplier_no,
      contractor.c_title,
      contractor.c_surname_company,
      contractor.c_first_names,
      contractor.c_initials,'Extensions',
      null,
      frequency_adjustments.fd_effective_date,
      frequency_adjustments.fd_amount_to_pay 
    from contract 
      join contract_renewals on
      contract.contract_no = contract_renewals.contract_no and
      contract.con_active_sequence = contract_renewals.contract_seq_number and
      contract.con_date_terminated is null 
      join  frequency_adjustments on
      contract.contract_no = frequency_adjustments.contract_no and
      frequency_adjustments.fd_effective_date < @dPayStartDate and
      frequency_adjustments.fd_paid_to_date is null and
      frequency_adjustments.fd_confirmed = 'Y'
      join contractor_renewals on
      contract_renewals.contract_no = contractor_renewals.contract_no and
      contract_renewals.contract_seq_number = contractor_renewals.contract_seq_number and
      contract_renewals.con_date_last_assigned = contractor_renewals.cr_effective_date
      join contractor on
      contractor_renewals.contractor_supplier_no = contractor.contractor_supplier_no
  update frequency_adjustments set
    fd_paid_to_date = @dPayStartDate where
    fd_confirmed = 'Y' and
    fd_effective_date < @dPayStartDate
  commit transaction
  select contract_no,
    contract_seq_number,
    con_old_mail_service_no,
    contract_title,
    contractor_supplier_no,
    contractor_title,
    contractor_surname_company,
    contractor_firstnames,
    contractor_initials,
    payment_type,
    payment_description,
    payment_effective_date,
    payment_amount from
    #tmp_payment_process
end