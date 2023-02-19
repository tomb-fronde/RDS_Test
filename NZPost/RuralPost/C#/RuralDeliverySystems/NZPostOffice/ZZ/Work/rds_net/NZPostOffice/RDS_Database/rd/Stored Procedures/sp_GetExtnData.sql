
--
-- Definition for stored procedure sp_GetExtnData : 
--

create procedure [rd].[sp_GetExtnData](@in_contract int)
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  declare @nWageHourlyRate decimal(10,2)
  declare @nRepairsMaint decimal(10,2)
  declare @nTyreTubes decimal(10,2)
  declare @nVehicalAllow decimal(10,2)
  declare @nACCRate decimal(10,2)
  declare @nItemsHour decimal(10,2)
  declare @nFuel decimal(10,2)
  declare @nConsumption decimal(10,2)
  declare @dStartDate datetime
  declare @nSequenceNo int
  declare @nCounter int
  select @dStartDate=con_start_date,@nSequenceNo=contract_seq_number 
  from contract_renewals 
  where contract_renewals.contract_no = @in_Contract and
    contract_renewals.contract_seq_number = (select max(contract_seq_number) from
      contract_renewals where contract_no = @in_Contract)
  select @nWageHourlyRate=isnull(contract_rates.rr_wage_hourly_rate,renewal_rate.rr_wage_hourly_rate),
    @nRepairsMaint=isnull(contract_rates.rr_repairs_maintenance_rate,renewal_rate.rr_repairs_maintenance_rate),
    @nTyreTubes=isnull(contract_rates.rr_tyre_tubes_rate,renewal_rate.rr_tyre_tubes_rate),
    @nVehicalAllow=isnull(contract_rates.rr_vehical_allowance_rate,renewal_rate.rr_vehical_allowance_rate),
    @nACCRate=isnull(contract_rates.rr_acc_rate,renewal_rate.rr_acc_rate),
    @nItemsHour=isnull(contract_rates.rr_item_proc_rate_per_hour,renewal_rate.rr_item_proc_rate_per_hr),
    @nFuel=isnull(contract_rates.rr_fuel_rate,fuel_rates.fr_fuel_rate),
    @nConsumption=isnull(contract_rates.rr_consumption_rate,fuel_rates.fr_fuel_consumtion_rate)
  from contract_renewals 
    left outer join contract_rates on
    contract_renewals.contract_no = contract_rates.contract_no and
    contract_renewals.contract_seq_number = contract_rates.contract_seq_number 
    join renewal_rate on
    contract_renewals.con_rg_code_at_renewal = renewal_rate.rg_code and
    contract_renewals.con_rates_effective_date = renewal_rate.rr_rates_effective_date 
    join contract_vehical on
    contract_renewals.contract_no = contract_vehical.contract_no and
    contract_renewals.contract_seq_number = contract_vehical.contract_seq_number and
    contract_vehical.cv_vehical_status = 'A'
    join vehicle on
    contract_vehical.vehicle_number = vehicle.vehicle_number
    join fuel_type on
    vehicle.ft_key = fuel_type.ft_key
    join fuel_rates on
    fuel_type.ft_key = fuel_rates.ft_key where
    fuel_rates.rg_code = renewal_rate.rg_code and
    fuel_rates.rr_rates_effective_date = renewal_rate.rr_rates_effective_date and
    contract_renewals.contract_no = @in_contract and
    contract_renewals.contract_seq_number = @nSequenceNo
  select @nCounter=count(*) from frequency_distances 
  where contract_no = @in_contract and
    frequency_distances.fd_effective_date >= @dStartDate and
    @dStartDate is not null
  if @nCounter > 0
    select contract.contract_no,
      contract.con_title,
      num_rows=count(*),
      distance=(sum(isnull(contract_renewals.con_distance_at_renewal,0))/count(*))+
      sum(isnull(frequency_distances.fd_distance,0)*rate_days.rtd_days_per_annum),
      boxes=(sum(isnull(contract_renewals.con_no_customers_at_renewal,0))/count(*))+
      sum(isnull(frequency_distances.fd_no_of_boxes,0)),
      rural_bags=(sum(isnull(contract_renewals.con_no_rural_private_bags_at_renewal,0))/count(*))+
      sum(isnull(frequency_distances.fd_no_rural_bags,0)),
      other_bags=(sum(isnull(contract_renewals.con_no_other_bags_at_renewal,0))/count(*))+
      sum(isnull(frequency_distances.fd_no_other_bags,0)),
      private_bags=(sum(isnull(contract_renewals.con_no_private_bags_at_renewal,0))/count(*))+
      sum(isnull(frequency_distances.fd_no_private_bags,0)),
      post_offices=(sum(isnull(contract_renewals.con_no_post_offices_at_renewal,0))/count(*))+
      sum(isnull(frequency_distances.fd_no_post_offices,0)),
      no_cmbs=(sum(isnull(contract_renewals.con_no_cmbs_at_renewal,0))/count(*))+
      sum(isnull(frequency_distances.fd_no_cmbs,0)),
      no_cmb_customers=(sum(isnull(contract_renewals.con_no_cmb_custs_at_renewal,0))/count(*))+
      sum(isnull(frequency_distances.fd_no_cmb_customers,0)),
      del_hrs=(sum(isnull(contract_renewals.con_del_hrs_week_at_renewal,0))/count(*))+
      sum(isnull(frequency_distances.fd_delivery_hrs_per_week,0)),
      proc_hrs=(sum(isnull(contract_renewals.con_processing_hours_per_week,0))/count(*))+
      sum(isnull(frequency_distances.fd_processing_hrs_week,0)),
      mail_volume=(sum(isnull(contract_renewals.con_volume_at_renewal,0))/count(*))+
      sum(isnull(frequency_distances.fd_volume,0)),
      extn_effective_date=rd.today(),
      extn_distance=0,
      extn_boxes=0,
      extn_rural_bags=0,
      extn_other_bags=0,
      extn_private_bags=0,
      extn_post_offices=0,
      extn_no_cmbs=0,
      extn_no_cmb_customers=0,
      extn_del_hrs=0,
      extn_proc_hrs=0,
      extn_mail_volume=0,
      extn_reason=space(250),
      no_del_days_year=0,
      @nWageHourlyRate,
      @nRepairsMaint,
      @nTyreTubes,
      @nVehicalAllow,
      @nACCRate,
      rr_item_proc_rate_per_hr=@nItemsHour,
      @nFuel,
      @nConsumption,0 
    from contract 
      join contract_renewals on
      contract.contract_no = contract_renewals.contract_no and
      contract.con_active_sequence = contract_renewals.contract_seq_number 
      join frequency_distances on
      (contract_renewals.contract_no = frequency_distances.contract_no and
      frequency_distances.fd_effective_date >= @dStartDate and @dStartDate is not null)--,0),
      join  standard_frequency on
      frequency_distances.sf_key = standard_frequency.sf_key
      join rate_days on
      standard_frequency.sf_key = rate_days.sf_key 
    where contract.contract_no = @in_contract and
      rate_days.rg_code = contract_renewals.con_rg_code_at_renewal and
      rate_days.rr_rates_effective_date = contract_renewals.con_rates_effective_date
      group by contract.contract_no,contract.con_title--,rr_item_proc_rate_per_hr
  else
    select contract.contract_no,
      contract.con_title,
      1,
      isnull(contract_renewals.con_distance_at_renewal,0),
      isnull(contract_renewals.con_no_customers_at_renewal,0),
      isnull(contract_renewals.con_no_rural_private_bags_at_renewal,0),
      isnull(contract_renewals.con_no_other_bags_at_renewal,0),
      isnull(contract_renewals.con_no_private_bags_at_renewal,0),
      isnull(contract_renewals.con_no_post_offices_at_renewal,0),
      isnull(contract_renewals.con_no_cmbs_at_renewal,0),
      isnull(contract_renewals.con_no_cmb_custs_at_renewal,0),
      isnull(contract_renewals.con_del_hrs_week_at_renewal,0),
      isnull(contract_renewals.con_processing_hours_per_week,0),
      isnull(contract_renewals.con_volume_at_renewal,0),
      extn_effective_date=rd.today(),
      extn_distance=0,
      extn_boxes=0,
      extn_rural_bags=0,
      extn_other_bags=0,
      extn_private_bags=0,
      extn_post_offices=0,
      extn_no_cmbs=0,
      extn_no_cmb_customers=0,
      extn_del_hrs=0,
      extn_proc_hrs=0,
      extn_mail_volume=0,
      extn_reason=space(250),
      no_del_days_year=0,
      @nWageHourlyRate,
      @nRepairsMaint,
      @nTyreTubes,
      @nVehicalAllow,
      @nACCRate,
      rr_item_proc_rate_per_hr=@nItemsHour,
      @nFuel,
      @nConsumption,0 
    from contract 
      join  contract_renewals on
      contract.contract_no = contract_renewals.contract_no and
      contract.con_active_sequence = contract_renewals.contract_seq_number 
    where contract.contract_no = @in_contract
end