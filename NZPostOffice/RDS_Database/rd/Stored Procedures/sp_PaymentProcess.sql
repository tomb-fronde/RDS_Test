
--
-- Definition for stored procedure sp_PaymentProcess : 
--

create procedure [rd].[sp_PaymentProcess](@inPayPeriod datetime)
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  declare @dPayStartDate datetime,
  @dPayEndDate datetime,
  @dLastPayStartDate datetime,
  @dLastPayEndDate datetime
  select @dPayEndDate=@inPayPeriod
  select @dLastPayEndDate=datediff(month,@inPayPeriod,-1)
  select @dPayStartDate=datediff(day,@dLastPayEndDate,1)
  select @dLastPayStartDate=datediff(month,@dPayStartDate,-1)
  update contract_adjustments set
    ca_date_paid = @dPayEndDate where
    contract_adjustments.ca_date_paid is null and
    contract_adjustments.ca_confirmed = 'Y' and
    contract_adjustments.ca_date_occured between @dPayStartDate and @dPayEndDate
  update frequency_adjustments set
    fd_paid_to_date = @dPayEndDate where
    frequency_adjustments.fd_paid_to_date is null and
    frequency_adjustments.fd_confirmed = 'Y' and
    frequency_adjustments.fd_effective_date < @dPayStartDate
  update contract_allowance set
    ca_paid_to_date = @dPayEndDate
  select contract.contract_no,
    cr.contract_seq_number,
    contract.con_title,
    contractor.contractor_supplier_no,
    contractor_name=contractor.c_surname_company + case when contractor.c_first_names is null then case when contractor.c_initials is null then '' else ', ' + contractor.c_initials end else ', ' + contractor.c_first_names end ,
    con_renewal_payment_value=(cr.con_renewal_payment_value)/12,
    adjustments=(select sum(contract_adjustments.ca_amount) from
      contract_adjustments where
      cr.contract_no = contract_adjustments.contract_no and
      cr.contract_seq_number = contract_adjustments.contract_seq_number and
      contract_adjustments.ca_date_paid = @dPayEndDate and
      contract_adjustments.ca_confirmed = 'Y' and
      contract_adjustments.ca_date_occured between @dPayStartDate and @dPayEndDate),
    oldextn=(select sum(frequency_adjustments.fd_amount_to_pay) from
      frequency_adjustments where
      frequency_adjustments.contract_no = cr.contract_no and
      frequency_adjustments.contract_seq_number = cr.contract_seq_number and
      frequency_adjustments.fd_paid_to_date is not null and
      frequency_adjustments.fd_paid_to_date < @dPayEndDate and
      frequency_adjustments.fd_confirmed = 'Y')/12,
    newextn=(select sum(frequency_adjustments.fd_amount_to_pay) from
      frequency_adjustments where
      frequency_adjustments.contract_no = cr.contract_no and
      frequency_adjustments.contract_seq_number = cr.contract_seq_number and
      frequency_adjustments.fd_paid_to_date = @dPayEndDate and
      frequency_adjustments.fd_confirmed = 'Y' and
      frequency_adjustments.fd_effective_date < @dPayStartDate)/12,
    allowances=(select sum(contract_allowance.ca_annual_amount) from
      contract_allowance where
      contract_allowance.contract_no = contract.contract_no)/12,
    piecerates=(select sum(piece_rate_delivery.prd_cost) from
      piece_rate_delivery where
      piece_rate_delivery.contract_no = contract.contract_no) from
    contract join
    contract_renewals as cr on
    contract.contract_no = cr.contract_no and
    contract.con_active_sequence = cr.contract_seq_number
	 join  contractor_renewals on
    (cr.contract_no = contractor_renewals.contract_no and
    cr.contract_seq_number = contractor_renewals.contract_seq_number and
    cr.con_date_last_assigned = contractor_renewals.cr_effective_date/*,0*/)
    join contractor on contractor_renewals.contractor_supplier_no=contractor.contractor_supplier_no
  commit transaction
end