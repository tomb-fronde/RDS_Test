/****** Object:  UserDefinedFunction [rd].[BenchmarkCalc]    Script Date: 08/05/2008 11:23:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create function [rd].[BenchmarkCalc](@inContract int,@inSequence int) 
RETURNS real
AS
BEGIN

  declare @nNominalVehical numeric(10,2)
  declare @nWageHourlyRate numeric(10,2)
  declare @nRepairsMaint numeric(10,2)
  declare @nTyreTubes numeric(10,2)
  declare @nVehicalAllow numeric(10,2)
  declare @nVehicalInsure numeric(10,2)
  declare @nPublicLia numeric(10,2)
  declare @nCarrierRisk numeric(10,2)
  declare @nACCRate numeric(10,2)
  declare @nLicence numeric(10,2)
  declare @nRateOfReturn numeric(10,2)
  declare @nSalvageRatio numeric(10,2)
  declare @nItemsHour numeric(10,2)
  declare @nFuel numeric(10,2)
  declare @nConsumption numeric(10,2)
  declare @dStartDate datetime
  declare @dEndDate datetime
  declare @nNumRows int 
  declare @nRouteDistance numeric(10,2)
  declare @nDeliveryHours numeric(10,3)
  declare @nProcessingHours numeric(10,2)
  declare @nVolume numeric(10,2)
  declare @nDeliveryDays numeric(10,2)
  declare @nMaxDeliveryDays numeric(10,2)
  declare @nRouteDistancePerDay real
  declare @nVehicleDepreciation real
  declare @nFuelCostPerAnnum real
  declare @nRepairsPerAnnum real
  declare @nTyresTubesPerAnnum real
  declare @nDeliveryCost real
  declare @nProcessingCost real
  declare @nPublicLiabilityCost real
  declare @nACCPerAnnum real
  declare @nBenchmark real
  declare @nVehicleInsurance real
  declare @nLicensing real
  declare @nCarrierRiskRate real
  declare @nRateReturn real
  declare @nRGCode int
  declare @dEffectDate datetime
  declare @nTempint int
  declare @Tempdec numeric(10,2)
  declare @nRUC numeric(8,2)
  declare @nRUCRate numeric(8,2)
  declare @nAccounting numeric(8,2)
  declare @nTelephone numeric(8,2)
  declare @nSundries numeric(8,2)
  declare @nSundriesK numeric(8,2)
  select @nNominalVehical=isnull(contract_rates.rr_nominal_vehical_value,renewal_rate.rr_nominal_vehical_value),
    @nWageHourlyRate=isnull(contract_rates.rr_wage_hourly_rate,renewal_rate.rr_wage_hourly_rate),
    @nRepairsMaint=isnull(contract_rates.rr_repairs_maintenance_rate,renewal_rate.rr_repairs_maintenance_rate),
    @nTyreTubes=isnull(contract_rates.rr_tyre_tubes_rate,renewal_rate.rr_tyre_tubes_rate),
    @nVehicalAllow=isnull(contract_rates.rr_vehical_allowance_rate,renewal_rate.rr_vehical_allowance_rate),
    @nVehicalInsure=isnull(contract_rates.rr_vehical_insurance_premium,renewal_rate.rr_vehical_insurance_premium),
    @nPublicLia=isnull(contract_rates.rr_public_liability_rate_2,renewal_rate.rr_public_liability_rate),
    @nCarrierRisk=isnull(contract_rates.rr_carrier_risk_rate,renewal_rate.rr_carrier_risk_rate),
    @nACCRate=isnull(contract_rates.rr_acc_rate,renewal_rate.rr_acc_rate),
    @nLicence=isnull(contract_rates.rr_licence_rate,renewal_rate.rr_licence_rate),
    @nRateOfReturn=isnull(contract_rates.rr_vehical_rate_of_return_pct,renewal_rate.rr_vehical_rate_of_return_pct),
    @nSalvageRatio=isnull(contract_rates.rr_salvage_ratio,renewal_rate.rr_salvage_ratio),
    @nItemsHour=isnull(contract_rates.rr_item_proc_rate_per_hour,renewal_rate.rr_item_proc_rate_per_hr),
    @nFuel=isnull(contract_rates.rr_fuel_rate,fuel_rates.fr_fuel_rate),
    @nConsumption=isnull(contract_rates.rr_consumption_rate,fuel_rates.fr_fuel_consumtion_rate),
    @nAccounting=isnull(contract_rates.rr_accounting,renewal_rate.rr_accounting),
    @nTelephone=isnull(contract_rates.rr_Telephone,renewal_rate.rr_Telephone),
    @nSundries=isnull(contract_rates.rr_Sundries,renewal_rate.rr_Sundries),
    @nRucRate=isnull(contract_rates.rr_RUC,renewal_rate.rr_RUC),
    @nSundriesK=isnull(contract_rates.rr_sundries_k,renewal_rate.rr_sundries_k) 
    from contract_renewals left outer join
    contract_rates on
    contract_renewals.contract_no = contract_rates.contract_no and
    contract_renewals.contract_seq_number = contract_rates.contract_seq_number join
    renewal_rate on
    contract_renewals.con_rg_code_at_renewal = renewal_rate.rg_code and
    contract_renewals.con_rates_effective_date = renewal_rate.rr_rates_effective_date join
    contract_vehical on
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
    contract_renewals.contract_no = @inContract and
    contract_renewals.contract_seq_number = @inSequence
  if @@error <> 0 /* <> was < */	--RAISERROR('',10,1)
    /* Watcom only
    resignal
    */
  return -1
  select @dStartDate=con_start_date 
    from contract_renewals where
    contract_renewals.contract_no = @inContract and
    contract_renewals.contract_seq_number = @inSequence
  select @dEndDate=con_start_date,
    @nRGCode=con_rg_code_at_renewal,
    @dEffectDate=con_rates_effective_date
    from contract_renewals where
    contract_renewals.contract_no = @inContract and
    contract_renewals.contract_seq_number = @inSequence+1
  select  @nNumRows=count(*),
    @nDeliveryDays=rd.GetContractDelDays(contract_renewals.contract_no,contract_renewals.contract_seq_number,contract_renewals.con_rg_code_at_renewal,contract_renewals.con_rates_effective_date),
    @nRouteDistance=contract_renewals.con_distance_at_renewal+sum(isnull(frequency_distances.fd_distance,0)*rate_days.rtd_days_per_annum),
    @nDeliveryHours=contract_renewals.con_del_hrs_week_at_renewal+sum(isnull(frequency_distances.fd_delivery_hrs_per_week,0)),
    @nProcessingHours=contract_renewals.con_processing_hours_per_week+sum(isnull(frequency_distances.fd_processing_hrs_week,0)),
    @nVolume=contract_renewals.con_volume_at_renewal+sum(isnull(frequency_distances.fd_volume,0))
    from contract_renewals,
    route_frequency left outer join
    frequency_distances on
    route_frequency.contract_no = frequency_distances.contract_no and
    route_frequency.sf_key = frequency_distances.sf_key and
    route_frequency.rf_delivery_days = frequency_distances.rf_delivery_days and
    frequency_distances.fd_effective_date >= @dStartDate and
    @dStartDate is not null and
    (@dEndDate is null or
    @dEndDate >= frequency_distances.fd_effective_date),
    rate_days where
    (contract_renewals.contract_no = route_frequency.contract_no) and
    (route_frequency.sf_key = rate_days.sf_key) and
    (contract_renewals.con_rates_effective_date = rate_days.rr_rates_effective_date) and
    (contract_renewals.con_rg_code_at_renewal = rate_days.rg_code) and
    (contract_renewals.contract_no = @inCOntract) and
    (contract_renewals.contract_seq_number = @inSequence)
    group by contract_renewals.contract_no,
    contract_renewals.contract_seq_number,
    contract_renewals.con_rg_code_at_renewal,
    contract_renewals.con_rates_effective_date,
    contract_renewals.con_distance_at_renewal,
    contract_renewals.con_del_hrs_week_at_renewal,
    contract_renewals.con_processing_hours_per_week,
    contract_renewals.con_volume_at_renewal
  select @nMaxDeliveryDays=max(rate_days.rtd_days_per_annum)
    from contract_renewals join
    rate_days on
    contract_renewals.con_rg_code_at_renewal = rate_days.rg_code and
    contract_renewals.con_rates_effective_date = rate_days.rr_rates_effective_date and
    contract_renewals.contract_no = @inContract and
    contract_renewals.contract_seq_number = @inSequence
  select @nRouteDistancePerDay=@nRouteDistance/@nDeliveryDays 
  select @nVehicleDepreciation=@nRouteDistance*(@nVehicalAllow/1000)  
  select @nFuelCostPerAnnum=(@nConsumption/100)*@nRouteDistance*(@nFuel/100) 
  select  @nRepairsPerAnnum=@nRouteDistance*(@nRepairsMaint/1000) 
  select @nTyresTubesPerAnnum=@nTyreTubes*(@nRouteDistance/1000)  
  select @nDeliveryCost=((@nDeliveryHours)*56)*@nWageHourlyRate  
  select @nProcessingCost=((((@nVolume/@nItemsHour)/365)*7)*56)*@nWageHourlyRate 
  select @nPublicLiabilityCost=@nPublicLia*(@nDeliveryDays/@nMaxDeliveryDays)  
  select @nACCPerAnnum=(@nAccRate/100)*(@nDeliveryCost+@nProcessingCost) 
  select @nVehicleInsurance=@nVehicalInsure*(@nDeliveryDays/@nMaxDeliveryDays) 
  select @nLicensing=@nLicence*(@nDeliveryDays/@nMaxDeliveryDays)  
  select @nCarrierRiskRate=@nCarrierRisk*(@nDeliveryDays/@nMaxDeliveryDays) 
  select @nRateReturn=rd.GetRateReturn(@nNominalVehical,@nRateOfReturn,@nSalvageRatio) 
  select @nRateReturn=@nRateReturn*(@nDeliveryDays/@nMaxDeliveryDays) 
  select @nAccounting=@nAccounting*(@nDeliveryDays/@nMaxDeliveryDays) 
  select @nTelephone=@nTelephone*(@nDeliveryDays/@nMaxDeliveryDays)  
  select @nSundries=@nSundries*(@nDeliveryDays/@nMaxDeliveryDays) 
  select  @nTempint=count(contractor_renewals.contract_no) 
    from rd.contractor_renewals,
    rd.contract_vehical,
    rd.vehicle,
    rd.fuel_type where
    (contractor_renewals.contract_no = @inContract) and
    (contractor_renewals.contract_seq_number = @inSequence) and
    (contractor_renewals.contract_no = contract_vehical.contract_no) and
    (contractor_renewals.contract_seq_number = contract_vehical.contract_seq_number) and
    (contract_vehical.vehicle_number = vehicle.vehicle_number) and
    (vehicle.ft_key = fuel_type.ft_key) and
    (fuel_type.ft_description like 'diesel%') and
    (contract_vehical.cv_vehical_status = 'A')
  if @@error <> 0 /* <> was < */	--RAISERROR('',10,1)
    /* Watcom only
    resignal
    */
   return -1
  if @ntempint = 0
    select @nRUC=0.0
  else
    select @nRUC=@nRUCRate*(@nRouteDistance/1000)
  select @nSundriesK=@nSundriesK*(@nRouteDistance/1000) 
  select @nBenchmark=isnull(@nVehicleDepreciation,0)+
    isnull(@nFuelCostPerAnnum,0)+
    isnull(@nRepairsPerAnnum,0)+
    isnull(@nTyresTubesPerAnnum,0)+
    isnull(@nDeliveryCost,0)+
    isnull(@nProcessingCost,0)+
    isnull(@nPublicLiabilityCost,0)+
    isnull(@nACCPerAnnum,0)+
    isnull(@nVehicleInsurance,0)+
    isnull(@nLicensing,0)+
    isnull(@nCarrierRiskRate,0)+
    isnull(@nRateReturn,0)+
    isnull(@nRUC,0)+
    isnull(@nTelephone,0)+
    isnull(@nSundries,0)+
    isnull(@nAccounting,0)+
    isnull(@nSundriesK,0)
  select @nBenchmark=Round(@nBenchmark+.5,0)
  return(@nBenchmark)

END
GO
