
CREATE procedure [rd].[sp_GetExtnData2005](@in_contract int)
AS
-- TJB  RPCR_099  Jan-2016
-- Add where condition to 'get rates' query (see nvor_effective_date)
--
-- TJB RPCR_041 Nov-2012
-- Added relief weeks to returned result
--
-- TJB  SR4661  May 2005
-- hourly_wage_rate name changed to delivery_wage_rate
-- processing_wage_rate added
-- 
BEGIN
  set CONCAT_NULL_YIELDS_NULL off
  
  declare @nRemainingEconomicLife int
  --  declare nWageHourlyRate numeric(10,2);              -- TJB SR4661 May 2005
  declare @nDeliveryWageRate numeric(10,2)   -- New name
  declare @nProcessingWageRate numeric(10,2) -- Added
  declare @nRepairsMaint numeric(10,2)
  declare @nTyreTubes numeric(10,2)
  declare @nVehicalAllow numeric(10,2)
  declare @nACCRate numeric(10,2)
  declare @nACCRate2 numeric(10,2)
  declare @nItemsHour numeric(10,2)
  declare @nRUC numeric(8,2)
  declare @nFuel numeric(10,2)
  declare @nConsumption numeric(10,2)
  declare @dStartDate datetime
  declare @nSequenceNo int
  declare @nCounter int
  declare @nDepreciation2 numeric(10,2)
  declare @nNominalVehical numeric(10,2)
  declare @nSalvageRatio numeric(10,2)
  --new 2001
  declare @nInsurancePct numeric(10,2)
  declare @nACCAmount numeric(10,2)
  declare @nLivery numeric(10,2)
  declare @nUniform numeric(10,2)
  -- TWC - 08/08/2003 new for call 4546
  declare @nUse_rucs int
  declare @nVehicle int
  declare @nFt_key int
  declare @nReliefWeeks numeric(6,2)
  declare @nvrReliefWeeks numeric(6,2)
  declare @nvorReliefWeeks numeric(6,2)
  
  --Get contract start and end
  select @dStartDate=con_start_date,@nSequenceNo=contract_seq_number 
    from contract_renewals
   where contract_renewals.contract_no = @in_Contract and
         contract_renewals.contract_seq_number = 
                 (select max(contract_seq_number) 
                    from contract_renewals 
                   where contract_no = @in_Contract)

  -- TWC 08/08/2003 - get the vehicle fuel type if is deisel - set nUse_rucs to 1
  select @nFt_key=ft_key
    from vehicle 
   where vehicle_number = rd.f_GetLatestVehicle(@in_Contract,@nSequenceNo)
          -- 4 is the key for diesel
          
  select @nUse_rucs=0
  if @nFt_key = 4
    select @nUse_rucs=1
    
  --Get basic rates
  --    non_vehicle_rate.nvr_wage_hourly_rate as wage_rate,               -- TJB  SR4661  May 2005
  select @nDeliveryWageRate=non_vehicle_rate.nvr_delivery_wage_rate, -- Changed from single value 
         @nProcessingWageRate=non_vehicle_rate.nvr_processing_wage_rate, -- to two
         @nRepairsMaint=vehicle_rate.vr_repairs_maintenance_rate,
         @nTyreTubes=vehicle_rate.vr_tyre_tubes_rate,
         @nVehicalAllow=vehicle_rate.vr_vehicle_allowance_rate,
         @nACCRate2=non_vehicle_rate.nvr_acc_rate,
         @nItemsHour=non_vehicle_rate.nvr_item_proc_rate_per_hr,
         @nFuel=rd.f_GetFuelRates(contract_vehical.contract_no,contract_renewals.contract_seq_number,contract_renewals.con_rates_effective_date),
         @nConsumption=rd.f_GetConsumptionRates(contract_vehical.contract_no,contract_renewals.contract_seq_number,contract_renewals.con_rates_effective_date),
         @nRuc=vehicle_rate.vr_ruc,
         @nInsurancePct=vehicle_rate.vr_vehicle_value_insurance_pct,
         @nLivery=vehicle_rate.vr_livery,
         @nUniform=non_vehicle_rate.nvr_uniform,
         @nACCAmount=non_vehicle_rate.nvr_acc_rate_amount,
         @nRemainingEconomicLife=vehicle.v_remaining_economic_life,
         @nNominalVehical=vehicle_rate.vr_nominal_vehicle_value,
         @nSalvageRatio=vehicle_rate.vr_salvage_ratio,
         @nvrReliefWeeks = non_vehicle_rate.nvr_relief_weeks
    from contract,
         contract_renewals,
         contract_vehical,
         vehicle_type,
         vehicle,
         vehicle_rate,
         non_vehicle_rate 
   where
         contract_vehical.contract_no = contract_renewals.contract_no and
         contract_vehical.contract_seq_number = contract_renewals.contract_seq_number and
         contract_renewals.contract_no = contract.contract_no and
         vehicle.vt_key = vehicle_type.vt_key and
         vehicle.vehicle_number = contract_vehical.vehicle_number and
         vehicle_rate.vt_key = vehicle_type.vt_key and
         contract.rg_code = non_vehicle_rate.rg_code and
         non_vehicle_rate.nvr_rates_effective_date = contract_renewals.con_rates_effective_date and
         vehicle_rate.vr_rates_effective_date = contract_renewals.con_rates_effective_date and
         contract_vehical.vehicle_number =rd.f_GetLatestVehicle(contract.contract_no,contract_renewals.contract_seq_number) and
         contract.contract_no = @in_contract and
         contract_renewals.contract_seq_number = @nSequenceNo
 
 --get override rates
  select top 1
    --    isNull(non_vehicle_override_rate.nvor_wage_hourly_rate,nWageHourlyRate) as wage_rate,     -- TJB  SR4661  May 2001: split wage rate into two
         @nDeliveryWageRate=isNull(non_vehicle_override_rate.nvor_delivery_wage_rate,@nDeliveryWageRate),
         @nProcessingWageRate=isNull(non_vehicle_override_rate.nvor_processing_wage_rate,@nProcessingWageRate),
         @nRepairsMaint=isNull(vehicle_override_rate.vor_repairs_maintenance_rate,@nRepairsMaint),
         @nTyreTubes=isNull(vehicle_override_rate.vor_tyre_tubes_rate,@nTyreTubes),
         @nVehicalAllow=isNull(vehicle_override_rate.vor_vehical_allowance_rate,@nVehicalAllow),
         @nACCRate=isNull(non_vehicle_override_rate.nvor_acc_rate,@nACCRate2),
         @nItemsHour=isNull(non_vehicle_override_rate.nvor_item_proc_rate_per_hour,@nItemsHour),
         @nFuel=isNull(vehicle_override_rate.vor_fuel_rate,@nFuel),
         @nConsumption=isNull(vehicle_override_rate.vor_consumption_rate,@nConsumption),
         @nRuc=isNull(vehicle_override_rate.vor_ruc,@nRuc),
         @nInsurancePct=@nInsurancePct,
         @nLivery=isNull(vehicle_override_rate.vor_livery,@nLivery),
         @nUniform=isNull(non_vehicle_override_rate.nvor_uniform,@nUniform),
         @nACCAmount=isNull(non_vehicle_override_rate.nvor_acc_rate_amount,@nACCAmount),
         @nNominalVehical=isNull(vehicle_override_rate.vor_nominal_vehicle_value,@nNominalVehical),
         @nSalvageRatio=isNull(vehicle_override_rate.vor_salvage_ratio,@nSalvageRatio),
         @nvorReliefWeeks = non_vehicle_override_rate.nvor_relief_weeks
    from contract_renewals 
              left outer join vehicle_override_rate
                   on contract_renewals.contract_no = vehicle_override_rate.contract_no and
                      contract_renewals.contract_seq_number = vehicle_override_rate.contract_seq_number
              left outer join non_vehicle_override_rate
                   on contract_renewals.contract_no = non_vehicle_override_rate.contract_no and
                      contract_renewals.contract_seq_number = non_vehicle_override_rate.contract_seq_number 
              join contract 
                   on contract_renewals.contract_no=contract.contract_no
   where
         contract_renewals.contract_no = contract.contract_no
     and contract.contract_no = @in_contract
     and contract_renewals.contract_seq_number = @nSequenceNo
     and (non_vehicle_override_rate.nvor_effective_date is null                           -- TJB RPCR_099 Jan-2016: Added
	      or non_vehicle_override_rate.nvor_effective_date = vehicle_override_rate.vor_effective_date) 
   order by
         vor_effective_date desc

  --compute depreciation2 (only if there is remaining economic life)
  --Depreciation
  if @nRemainingEconomicLife > 0
    select @nDepreciation2=((1-(isNull(@nSalvageRatio,0)/100))*isNull(@nNominalVehical,0)*1000)/@nRemainingEconomicLife
  else
    select @nDepreciation2=0
    
  --FD stuff
  select @nCounter=count(*)  
    from frequency_distances 
   where contract_no = @in_contract and
         frequency_distances.fd_effective_date >= @dStartDate and
         @dStartDate is not null
  
  -- TJB  RPCR_041 Nov-2012
  -- Determine which relief weeks to use
  select @nReliefWeeks = isnull(@nvorReliefWeeks,@nvrReliefWeeks)

  -- Return the results
  if @nCounter > 0
    select top 1 contract.contract_no,
      contract.con_title,
      num_rows=count(*),
      distance=(sum(isnull(contract_renewals.con_distance_at_renewal,0))/count(*))
               + sum(isnull(frequency_distances.fd_distance,0)*rate_days.rtd_days_per_annum),
      boxes=(sum(isnull(contract_renewals.con_no_customers_at_renewal,0))/count(*))
               + sum(isnull(frequency_distances.fd_no_of_boxes,0)),
      rural_bags=(sum(isnull(contract_renewals.con_no_rural_private_bags_at_renewal,0))/count(*))
               + sum(isnull(frequency_distances.fd_no_rural_bags,0)),
      other_bags=(sum(isnull(contract_renewals.con_no_other_bags_at_renewal,0))/count(*))
               + sum(isnull(frequency_distances.fd_no_other_bags,0)),
      private_bags=(sum(isnull(contract_renewals.con_no_private_bags_at_renewal,0))/count(*))
               + sum(isnull(frequency_distances.fd_no_private_bags,0)),
      post_offices=(sum(isnull(contract_renewals.con_no_post_offices_at_renewal,0))/count(*))
               + sum(isnull(frequency_distances.fd_no_post_offices,0)),
      no_cmbs=(sum(isnull(contract_renewals.con_no_cmbs_at_renewal,0))/count(*))
               + sum(isnull(frequency_distances.fd_no_cmbs,0)),
      no_cmb_customers=(sum(isnull(contract_renewals.con_no_cmb_custs_at_renewal,0))/count(*))
               + sum(isnull(frequency_distances.fd_no_cmb_customers,0)),
      del_hrs=(sum(isnull(contract_renewals.con_del_hrs_week_at_renewal,0))/count(*))
               + sum(isnull(frequency_distances.fd_delivery_hrs_per_week,0)),
      proc_hrs=(sum(isnull(contract_renewals.con_processing_hours_per_week,0))/count(*))
               + sum(isnull(frequency_distances.fd_processing_hrs_week,0)),
      mail_volume=(sum(isnull(contract_renewals.con_volume_at_renewal,0))/count(*))
               + sum(isnull(frequency_distances.fd_volume,0)),
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
      --      isNull(nWageHourlyRate,0),      -- TJB  SR4661  May 2005
      isNull(@nDeliveryWageRate,0), -- Return Delivery rate in this position (processing rate below)
      repairsmaint=isNull(@nRepairsMaint,0),
      typestube=isNull(@nTyreTubes,0),
      vehicalallow=isNull(@nVehicalAllow,0),
      accrate=isNull(@nACCRate,0),
      rr_item_proc_rate_per_hr=isNull(@nItemsHour,0),
      nFuel=isNull(@nFuel,0),
      consumptionrate=isNull(@nConsumption,0),
      extnamount=0,
      @nRUC,
      --new 2001
      nInsurancePct=isNull(@nInsurancePct,0),
      nLivery=isNull(@nLivery,0),
      nUniform=isNull(@nUniform,0),
      nACCAmount=isNull(@nACCAmount,0),
      @nDepreciation2,
      use_rucs=@nUse_rucs,
      isNull(@nProcessingWageRate,0), -- TJB  SR4661  May 2005
      isnull(@nReliefWeeks,5)         -- TJB RPCR_041 Nov-2012
    from
      contract 
            join contract_renewals 
                 on contract.contract_no = contract_renewals.contract_no and
                    contract.con_active_sequence = contract_renewals.contract_seq_number 
            join frequency_distances 
                 on (contract_renewals.contract_no = frequency_distances.contract_no and
                    frequency_distances.fd_effective_date >= @dStartDate and
                    @dStartDate is not null)--,0), 
           join standard_frequency 
                 on frequency_distances.sf_key = standard_frequency.sf_key
           join rate_days 
                 on standard_frequency.sf_key = rate_days.sf_key 
    where
      contract.contract_no = @in_contract and
      rate_days.rg_code = contract_renewals.con_rg_code_at_renewal and
      rate_days.rr_rates_effective_date = contract_renewals.con_rates_effective_date
      group by contract.contract_no,contract.con_title--,rr_item_proc_rate_per_hr 
  else
    select top 1
      contract.contract_no,
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
      --      isNull(nWageHourlyRate,0),      -- TJB  SR4661  May 2005
      isNull(@nDeliveryWageRate,0), -- Return Delivery rate in this position (processing rate below)
      isNull(@nRepairsMaint,0),
      isNull(@nTyreTubes,0),
      isNull(@nVehicalAllow,0),
      isNull(@nACCRate,0),
      rr_item_proc_rate_per_hr=isNull(@nItemsHour,0),
      isNull(@nFuel,0),
      isNull(@nConsumption,0),
      0,
      nRUC=isNull(@nRUC,0),
      --New 2001
      nInsurancePct=isNull(@nInsurancePct,0),
      nLivery=isNull(@nLivery,0),
      nUniform=isNull(@nUniform,0),
      nACCAmount=isNull(@nACCAmount,0),
      @nDepreciation2,
      use_rucs=@nUse_rucs,
      isNull(@nProcessingWageRate,0),  -- TJB  SR4661  May 2005
      isnull(@nReliefWeeks,5)          -- TJB RPCR_041 Nov-2012
    from
      contract join contract_renewals 
                    on contract.contract_no = contract_renewals.contract_no and
                       contract.con_active_sequence = contract_renewals.contract_seq_number 
    where
      contract.contract_no = @in_contract
END