/****** Object:  UserDefinedFunction [rd].[benchmarkCalcVeh]    Script Date: 08/05/2008 11:23:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create function [rd].[benchmarkCalcVeh](@inContract int,@inSequence int,@inVehicle int)
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
  declare @nRemainingEconomicLife int
  declare @nACCAmount numeric(12,2)
  declare @nInsurancePct numeric(12,2)
  declare @nLivery numeric(12,2)
  declare @nUniform numeric(12,2)
  declare @nLiveryPerAnnum numeric(12,2)
  declare @nUniformPerAnnum numeric(12,2)
  declare @nMaxdays int
  --  declare nACCAmount decimal(12,2);
  select top 1
    @nNominalVehical=isNull(vor.vor_nominal_vehicle_value,vr.vr_nominal_vehicle_value),
    @nRemainingEconomicLife=v.v_remaining_economic_life,
    @nWageHourlyRate=isNull(nvor.nvor_wage_hourly_rate,nvr.nvr_wage_hourly_rate),
    @nRepairsMaint=isNull(vor.vor_repairs_maintenance_rate,vr.vr_repairs_maintenance_rate),
    @nTyreTubes=isNull(vor.vor_tyre_tubes_rate,vr.vr_tyre_tubes_rate),
    @nVehicalAllow=isNull(vor.vor_vehical_allowance_rate,vr.vr_vehicle_allowance_rate),
    @nVehicalInsure=rd.f_GetInsurance(cr.contract_no,cr.contract_seq_number,cr.con_rates_effective_date), --ins $
    @nPublicLia=isNull(nvor.nvor_public_liability_rate_2,nvr.nvr_public_liability_rate),
    @nCarrierRisk=isNull(nvor.nvor_carrier_risk_rate,nvr.nvr_carrier_risk_rate),
    @nACCRate=isNull(nvor.nvor_acc_rate,nvr.nvr_acc_rate),
    @nACCAmount=isNull(nvor.nvor_acc_rate_amount,nvr.nvr_acc_rate_amount),
    @nLicence=isNull(vor.vor_licence_rate,vr.vr_licence_rate),
    @nRateOfReturn=isNull(vor.vor_vehicle_rate_of_return_pct,vr.vr_vehicle_rate_of_return_pct),
    @nSalvageRatio=isNull(vor.vor_salvage_ratio,vr.vr_salvage_ratio),
    @nItemsHour=isNull(nvor.nvor_item_proc_rate_per_hour,nvr.nvr_item_proc_rate_per_hr),
    @nFuel=isNull(vor.vor_fuel_rate,rd.f_GetConVehFuelRate(@inContract,@inSequence,@inVehicle)),
    @nConsumption=isNull(vor_consumption_rate,rd.f_GetConVehConsumptionRate(@inContract,@inSequence,@inVehicle)),
    @nAccounting=isNull(nvor.nvor_accounting,nvr.nvr_accounting),
    @nTelephone=isNull(nvor.nvor_telephone,nvr.nvr_telephone),
    @nSundries=isNull(nvor.nvor_sundries,nvr.nvr_sundries),
    @nRucrate=isNull(vor.vor_ruc,vr.vr_ruc),
    @nSundriesK=isNull(vor.vor_sundries_k,vr.vr_sundries_k),
    @nInsurancePct=isNull(vr.vr_vehicle_value_insurance_pct,0),
    @nLivery=isNull(vor.vor_livery,vr.vr_livery),
    @nUniform=isNull(nvor_uniform,nvr_uniform),
    @nACCAmount=isNull(nvor.nvor_acc_rate_amount,nvr.nvr_acc_rate_amount) 
    from
--!    contract_renewals as cr left outer join non_vehicle_override_rate as nvor  on  cr.contract_no = nvor.contract_no and cr.contract_seq_number = nvor.contract_seq_number,
--!    contract_renewals as cr1 left outer join vehicle_override_rate as vor on cr1.contract_no = vor.contract_no and cr1.contract_seq_number = vor.contract_seq_number,
    contract_renewals as cr left outer join non_vehicle_override_rate as nvor  on  cr.contract_no = nvor.contract_no and cr.contract_seq_number = nvor.contract_seq_number
    left outer join vehicle_override_rate as vor on cr.contract_no = vor.contract_no and cr.contract_seq_number = vor.contract_seq_number,
    contract_vehical as cv,
    vehicle as v,
    contract as c,
    non_vehicle_rate as nvr,
    vehicle_type as vt,
    vehicle_rate as vr
    where

    vt.vt_key = vr.vt_key and
    cv.contract_no = cr.contract_no and
    cv.contract_seq_number = cr.contract_seq_number and
    v.vehicle_number = cv.vehicle_number and
    vt.vt_key = v.vt_key and
    c.contract_no = cr.contract_no and
    v.vehicle_number = rd.f_GetLatestVehicle(cr.contract_no,cr.contract_seq_number) and
    c.rg_code = nvr.rg_code and
    cr.contract_no = @inContract and
    cr.contract_seq_number = @inSequence and
    nvr.nvr_rates_effective_date = cr.con_rates_effective_date and
    vr.vr_rates_effective_date = cr.con_rates_effective_date order by
    vor.vor_effective_date desc
  if @@error <> 0 /* <> was < */
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
  select @nNumRows=count(*),
    @nDeliveryDays=rd.GetContractDelDays(contract_renewals.contract_no,contract_renewals.contract_seq_number,contract_renewals.con_rg_code_at_renewal,contract_renewals.con_rates_effective_date),
    @nRouteDistance=contract_renewals.con_distance_at_renewal+sum(isnull(frequency_distances.fd_distance,0)*rate_days.rtd_days_per_annum),
    @nDeliveryHours=contract_renewals.con_del_hrs_week_at_renewal+sum(isnull(frequency_distances.fd_delivery_hrs_per_week,0)),
    @nProcessingHours=contract_renewals.con_processing_hours_per_week+sum(isnull(frequency_distances.fd_processing_hrs_week,0)),
    @nVolume=contract_renewals.con_volume_at_renewal+sum(isnull(frequency_distances.fd_volume,0))
  from contract_renewals,
    route_frequency left outer join frequency_distances on
    route_frequency.contract_no = frequency_distances.contract_no and
    route_frequency.sf_key = frequency_distances.sf_key and
    route_frequency.rf_delivery_days = frequency_distances.rf_delivery_days and
    frequency_distances.fd_effective_date >= @dStartDate and
    @dStartDate is not null and
    (@dEndDate is null or @dEndDate >= frequency_distances.fd_effective_date),
    rate_days where
    contract_renewals.contract_no = route_frequency.contract_no and
    route_frequency.sf_key = rate_days.sf_key and
    contract_renewals.con_rates_effective_date = rate_days.rr_rates_effective_date and
    contract_renewals.con_rg_code_at_renewal = rate_days.rg_code and
    contract_renewals.contract_no = @inContract and
    contract_renewals.contract_seq_number = @inSequence
    group by contract_renewals.contract_no,
    contract_renewals.contract_seq_number,
    contract_renewals.con_rg_code_at_renewal,
    contract_renewals.con_rates_effective_date,
    contract_renewals.con_distance_at_renewal,
    contract_renewals.con_del_hrs_week_at_renewal,
    contract_renewals.con_processing_hours_per_week,
    contract_renewals.con_volume_at_renewal
  select @nMaxDeliveryDays=max(rate_days.rtd_days_per_annum) 
    from contract_renewals join rate_days on
    contract_renewals.con_rg_code_at_renewal = rate_days.rg_code and
    contract_renewals.con_rates_effective_date = rate_days.rr_rates_effective_date and
    contract_renewals.contract_no = @inContract and
    contract_renewals.contract_seq_number = @inSequence
  --If max days per week>4, assume deldays = maxdeldays
  select @nMaxdays=sum(standard_frequency.sf_days_week) 
    from rate_days,
    standard_frequency,
    route_frequency,
    contract,contract_renewals where
    standard_frequency.sf_key = rate_days.sf_key and
    route_frequency.sf_key = standard_frequency.sf_key and
    rate_days.rg_code = contract.rg_code and
    contract.contract_no = route_frequency.contract_no and
    route_frequency.contract_no = @inContract and
    route_frequency.rf_active = 'Y' and
    contract_renewals.contract_no = contract.contract_no and
    contract_renewals.contract_seq_number = @inSequence and
    contract_renewals.con_rates_effective_date = rate_days.rr_rates_effective_date
  if @nMaxdays > 4
    select @nDeliveryDays=@nMaxDeliveryDays
  select @nRouteDistancePerDay=@nRouteDistance/@nDeliveryDays 
  --select nRouteDistance*(nVehicalAllow/1000) into nVehicleDepreciation;
  if @nRemainingEconomicLife > 0
    -- PBY 26/06/2002 SR#4415 Added nRouteDistance/1000 to VehicleDepreciation
    -- calcuation if REL > 0
    select @nVehicleDepreciation=(@nRouteDistance/1000)*((1-(isNull(@nSalvageRatio,0)/100))*isNull(@nNominalVehical,0)*1000)/@nRemainingEconomicLife
  else
    select @nVehicleDepreciation=@nRouteDistance*(@nVehicalAllow/1000)
  select @nFuelCostPerAnnum=(@nConsumption/100)*@nRouteDistance*(@nFuel/100)
  select @nRepairsPerAnnum=@nRouteDistance*(@nRepairsMaint/1000) 
  select @nTyresTubesPerAnnum=@nTyreTubes*(@nRouteDistance/1000) 
  select @nDeliveryCost=((round(@nDeliveryHours,2))*56)*@nWageHourlyRate 
  select @nProcessingCost=((((@nVolume/@nItemsHour)/365)*7)*56)*@nWageHourlyRate 
  select @nPublicLiabilityCost=@nPublicLia*(@nDeliveryDays/@nMaxDeliveryDays) 
  --select(nAccRate/100)*(nDeliveryCost+nProcessingCost) into nACCPerAnnum;
   --Benchmark 2001
  select @nACCPerAnnum=(@nAccRate/100)*(@nDeliveryCost+@nProcessingCost)+isNull(@nACCAmount,0)
  --select nVehicalInsure*(nDeliveryDays/nMaxDeliveryDays) into nVehicleInsurance;
  --Benchmark 2001
  --set nVehicleInsurance=nVehicalInsure;
  select @nVehicleInsurance=@nVehicalInsure*(@nDeliveryDays/@nMaxDeliveryDays)
  select @nLiveryPerAnnum=@nRouteDistance*(@nLivery/1000)
  select @nUniformPerAnnum=@nRouteDistance*(@nUniform/1000)
  select @nLicensing=@nLicence*(@nDeliveryDays/@nMaxDeliveryDays) 
  select @nCarrierRiskRate=@nCarrierRisk*(@nDeliveryDays/@nMaxDeliveryDays) 
  select @nRateReturn=rd.GetRateReturn(@nNominalVehical,@nRateOfReturn,@nSalvageRatio) 
  select @nRateReturn=@nRateReturn*(@nDeliveryDays/@nMaxDeliveryDays)
  select @nAccounting=@nAccounting*(@nDeliveryDays/@nMaxDeliveryDays) 
  select @nTelephone=@nTelephone*(@nDeliveryDays/@nMaxDeliveryDays)
  select @nSundries=@nSundries*(@nDeliveryDays/@nMaxDeliveryDays) 
  select @nTempint=count(contractor_renewals.contract_no) 
    from rd.contractor_renewals,
    rd.contract_vehical,
    rd.vehicle,
    rd.fuel_type where
    contractor_renewals.contract_no = @inContract and
    contractor_renewals.contract_seq_number = @inSequence and
    contractor_renewals.contract_no = contract_vehical.contract_no and
    contractor_renewals.contract_seq_number = contract_vehical.contract_seq_number and
    contract_vehical.vehicle_number = vehicle.vehicle_number and
    vehicle.ft_key = fuel_type.ft_key and
    fuel_type.ft_description like 'diesel%' and
    --and(contract_vehical.cv_vehical_status='A')
    --vehicle.vehicle_number = f_GetLatestVehicle(inContract,inSequence);
    vehicle.vehicle_number = @inVehicle
  if @@error <> 0 /* <> was < */
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
    isnull(@nSundriesK,0)+
    isnull(@nLiveryPerAnnum,0)+
    isnull(@nUniformPerAnnum,0) 
  select @nBenchmark=Round(@nBenchmark+.49,0)
  return(@nBenchmark)

END
GO
