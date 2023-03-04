
/*
 select [rd].[BenchmarkCalc2021]( 5011, 25)
 select [rd].[BenchmarkCalcVeh2021]( 5011, 25, 3966)
 select [rd].[BenchmarkCalcVeh2021]( 5011, 25, 4602)
*/
CREATE FUNCTION [rd].[BenchmarkCalcVeh2021](
	@inContract int,
	@inSequence int,
	@inVehicle  int)
RETURNS real
-- Calculates the basic single-value benchmark amount 
-- where a contract may include several vehicles
AS
BEGIN
-- TJB Frequencies & Vehicles  7-Feb-2022 
-- Derived from BenchmarkCalc2021

  declare @nNominalVehical numeric(10,2)
  declare @nRepairsMaint numeric(10,2)
  declare @nTyreTubes numeric(10,2)
  declare @nVehicalAllow numeric(10,2)
  declare @nLicence numeric(10,2)
  declare @nRateOfReturn numeric(10,2)
  declare @nSalvageRatio numeric(10,2)
  declare @nRUCRate numeric(8,2)
  declare @nSundriesK numeric(8,2)
  declare @nLivery numeric(12,2)
  declare @nVehicalInsure numeric(10,2)
  declare @nFuel numeric(10,2)
  declare @nConsumption numeric(10,2)
  declare @nRemainingEconomicLife int

  declare @nDeliveryWageRate numeric(10,2)
  declare @nProcessingWageRate numeric(10,2)
  declare @nPublicLia numeric(10,2)
  declare @nCarrierRisk numeric(10,2)
  declare @nACCRate numeric(10,2)
  declare @nACCAmount numeric(12,2)
  declare @nItemsHour numeric(10,2)
  declare @nAccounting numeric(8,2)
  declare @nTelephone numeric(8,2)
  declare @nSundries numeric(8,2)
  declare @nUniform numeric(12,2)
  declare @nReliefWeeks real

  declare @DeliveryWageRate numeric(10,2)
  declare @ProcessingWageRate numeric(10,2)
  declare @PublicLia numeric(10,2)
  declare @CarrierRisk numeric(10,2)
  declare @ACCRate numeric(10,2)
  declare @ACCAmount numeric(12,2)
  declare @ItemsHour numeric(10,2)
  declare @Accounting numeric(8,2)
  declare @Telephone numeric(8,2)
  declare @Sundries numeric(8,2)
  declare @Uniform numeric(12,2)
  declare @ReliefWeeks real

  declare @dStartDate datetime
  declare @dEndDate datetime
  declare @dEffectDate datetime

  declare @nNumRows int
  declare @DeliveryDays numeric(10,2)
  declare @nDeliveryDays numeric(10,2)
  declare @nDeliveryHours numeric(10,3)
  declare @nProcessingHours numeric(10,2)
  declare @nVolume numeric(10,2)
  declare @nMaxDeliveryDays numeric(10,2)
  declare @nMaxdays int

  declare @RouteDistance numeric(10,2)
  declare @nRouteDistance numeric(10,2)
  declare @RouteDistancePerDay real
  declare @VehicleDepreciation real
  declare @nRouteDistancePerDay real
  declare @nVehicleDepreciation real
  declare @SumRfDistance numeric(10,2)
  declare @sumFdDistance numeric(10,2)

  declare @nFuelCostPerAnnum real
  declare @nRepairsPerAnnum real
  declare @nTyresTubesPerAnnum real
  declare @nVehicleInsurance real
  declare @nLiveryPerAnnum numeric(12,2)
  declare @nLicensing real
  declare @nRateofReturnCost real

  declare @nDeliveryCost real
  declare @nProcessingCost real
  declare @nReliefCost real
  declare @nPublicLiabilityCost real
  declare @nACCPerAnnum real
  declare @nUniformPerAnnum numeric(12,2)
  declare @nCarrierRiskRate real

  declare @nTempint int
  declare @nRUC numeric(8,2)
  declare @nBenchmark real

  declare @SundriesK numeric(8,2)

  declare @FuelCostPerAnnum real
  declare @RepairsPerAnnum real
  declare @TyresTubesPerAnnum real
  declare @VehicleInsurance real
  declare @LiveryPerAnnum numeric(12,2)
  declare @Licensing real
  declare @RateofReturnCost real
  declare @RUC numeric(8,2)

  declare @rg_code         int
  declare @nRow            int
  declare @VehicleNo       int
  declare @nVtKey          int
  declare @crEffectiveDate datetime

  -- declare cur_getContractVehicles cursor for 
  --    select distinct isnull(rf.vehicle_number,cv.vehicle_number)
  --      from rd.route_frequency rf
  --         , rd.contract_vehical cv
  --     where rf.contract_no = @inContract
  --       and rf.rf_active = 'Y'
  --       and cv.contract_no = rf.contract_no
  --       and cv.contract_seq_number = @inSequence
  --       and cv.cv_vehical_status = 'A'

  select @rg_code = rg_code from rd.contract
   where contract_no = @inContract
         
  select @dStartDate  = cr.con_start_date
       , @dEffectDate = cr.con_rates_effective_date
    from rd.contract_renewals cr
   where cr.contract_no         = @inContract
     and cr.contract_seq_number = @inSequence

  select @dEndDate = cr.con_start_date
    from rd.contract_renewals cr
   where cr.contract_no         = @inContract 
     and cr.contract_seq_number = @inSequence+1
     
--  -- Get and process vehicle rates
--  open cur_getContractVehicles
--  select @nRow = 0
--  while 1 = 1 
--  begin
--      fetch next from cur_getContractVehicles into @VehicleNo
--      if @@fetch_status < 0  
--          break
--      select @nRow = @nRow + 1

     select @VehicleNo = @inVehicle

      -- Get vehicle rates
      select top 1
             @nNominalVehical = isNull(vor.vor_nominal_vehicle_value,vr.vr_nominal_vehicle_value)
           , @nRepairsMaint   = isNull(vor.vor_repairs_maintenance_rate,vr.vr_repairs_maintenance_rate)
           , @nTyreTubes      = isNull(vor.vor_tyre_tubes_rate,vr.vr_tyre_tubes_rate)
           , @nVehicalAllow   = isNull(vor.vor_vehical_allowance_rate,vr.vr_vehicle_allowance_rate)
           , @nLicence        = isNull(vor.vor_licence_rate,vr.vr_licence_rate)
           , @nRateOfReturn   = isNull(vor.vor_vehicle_rate_of_return_pct,vr.vr_vehicle_rate_of_return_pct)
           , @nSalvageRatio   = isNull(vor.vor_salvage_ratio,vr.vr_salvage_ratio)
           , @nRucrate        = isNull(vor.vor_ruc,vr.vr_ruc)
           , @SundriesK       = isNull(vor.vor_sundries_k,vr.vr_sundries_k)
           , @nLivery         = isNull(vor.vor_livery,vr.vr_livery)
           , @nVehicalInsure  = isnull(rd.f_GetVehicleInsurance(cv.contract_no,@inSequence, @VehicleNo, @dEffectDate),0)
           , @nFuel           = isNull(vor.vor_fuel_rate
                                    ,rd.f_GetVehicleFuelRates(cv.contract_no,@inSequence, @VehicleNo, @dEffectDate))
           , @nConsumption    = isNull(vor_consumption_rate
                                    ,rd.f_GetVehicleConsumptionRates(cv.contract_no, @inSequence, @VehicleNo, @dEffectDate))
           , @nRemainingEconomicLife = v.v_remaining_economic_life
           , @nVtKey   = v.vt_key
        from rd.contract_vehical cv 
                 left outer join rd.vehicle_override_rate as vor 
                      on vor.contract_no = cv.contract_no
                      and vor.contract_seq_number = cv.contract_seq_number
                      and vor.vehicle_number      = cv.vehicle_number
                      and vor.vor_effective_date >= @dEffectDate
           , rd.vehicle as v
           , rd.vehicle_rate as vr
       where cv.contract_no         = @inContract 
         and cv.contract_seq_number = @inSequence
         and cv.vehicle_number      = @VehicleNo
         and v.vehicle_number       = cv.vehicle_number
         and vr.vt_key              = v.vt_key 
         and vr.vr_rates_effective_date = @dEffectDate
       order by vor.vor_effective_date desc  -- "top 1" selects most recent overrides

      -- Get the vehicle's number of delivery days (maximim per week)
      select @DeliveryDays = rd.f_GetConVehicleDelDays( @inContract, @rg_code, @dEffectDate, @VehicleNo )
      
      -- Calculate the vehicle's route distance (per year)
      select @SumRfDistance = sum(isnull(rf.rf_distance,0) * rd.rtd_days_per_annum)
        from rd.contract_renewals cr
           , rd.rate_days rd
           , rd.route_frequency rf
       where cr.contract_no = @inContract 
         and cr.contract_seq_number = @inSequence 
         and rf.contract_no = cr.contract_no
         and rf.rf_active = 'Y'
         and rf.vehicle_number = @VehicleNo
         and rd.rg_code = @rg_code 
         and rd.sf_key = rf.sf_key 
         and rd.rr_rates_effective_date = cr.con_rates_effective_date
       group by 
             cr.con_distance_at_renewal
      
      select @SumFdDistance = sum(isnull(fd.fd_distance,0) * rd.rtd_days_per_annum)
        from rd.contract_renewals cr
           , rd.rate_days rd
           , rd.route_frequency rf
                  left outer join rd.frequency_distances fd
                       on fd.contract_no = rf.contract_no 
                       and fd.sf_key = rf.sf_key 
                       and fd.rf_delivery_days = rf.rf_delivery_days 
                       and rf.vehicle_number = @VehicleNo  -- added to match BenchmarkRpt
                       and @dStartDate is not null 
                       and fd.fd_effective_date >= @dStartDate 
                       and (@dEndDate is null 
                             or fd.fd_effective_date < @dEndDate)
       where cr.contract_no = @inContract 
         and cr.contract_seq_number = @inSequence 
         and rf.contract_no = cr.contract_no
         and rf.rf_active = 'Y'
         and rf.vehicle_number = @VehicleNo
         and rd.rg_code = @rg_code 
         and rd.sf_key = rf.sf_key 
         and rd.rr_rates_effective_date = cr.con_rates_effective_date
       group by 
             cr.con_distance_at_renewal
      
      -- TJB Frequencies & Vehicles 23-Jul-2021
      -- Removed @SumFdDistance from Route distance calc; BM2021 now yields "correct" results
      select @RouteDistance = @SumRfDistance -- + @SumFdDistance
      
      -- Calculate the vehicle's route distance/day and depreciation
      select @RouteDistancePerDay = @RouteDistance/@DeliveryDays

      if @nRemainingEconomicLife > 0
      begin
        select @VehicleDepreciation 
                    = (@RouteDistance/1000)
                         *((1-(isNull(@nSalvageRatio,0)/100))
                                  *isNull(@nNominalVehical,0)*1000)
                      /@nRemainingEconomicLife
      end
      else
        select @VehicleDepreciation = @nVehicalAllow*(@RouteDistance/1000)
      
      -- Calculate the vehicle costs per vehicle
      select @FuelCostPerAnnum    = @nConsumption*(@nFuel/100)*(@RouteDistance/100)
           , @RepairsPerAnnum     = @nRepairsMaint*(@RouteDistance/1000)
           , @TyresTubesPerAnnum  = @nTyreTubes*(@RouteDistance/1000)
           , @VehicleInsurance    = @nVehicalInsure
           , @LiveryPerAnnum      = @nLivery
           , @Licensing           = @nLicence
           , @RateofReturnCost    = rd.GetRateReturn(@nNominalVehical,@nRateOfReturn,@nSalvageRatio)
           , @RateofReturnCost    = round(@RateofReturnCost,2)
           , @SundriesK           = @SundriesK*(@RouteDistance/1000)


      -- TJB  Frequencies & Vehicles  Jan-2021
      -- Simplified the method of determining @vTempint (whether RUC needs
      -- to be included). Method previously used in BenchmarkCalcVeh2005.
/*      
      select @nTempint=count(cr.contract_no)
        from rd.contractor_renewals cr
           , rd.contract_vehical cv
           , rd.vehicle v
           , rd.fuel_type ft 
       where cr.contract_no = @inContract
         and cr.contract_seq_number = @inSequence
         and cr.contract_no = cv.contract_no
         and cr.contract_seq_number = cv.contract_seq_number
         and cv.vehicle_number = v.vehicle_number
         and v.ft_key = ft.ft_key
         and ft.ft_description like 'diesel%'
         and v.vehicle_number = @VehicleNo  --rd.f_GetLatestVehicle(@inContract,@inSequence))
*/
      select @ntempint = count(fuel_type.ft_key)
        from rd.vehicle
           , rd.fuel_type 
       where vehicle.vehicle_number = @VehicleNo 
         and fuel_type.ft_key = vehicle.ft_key 
         and fuel_type.ft_description like 'diesel%'

      if @ntempint = 0
          select @RUC=0.0
      else
          select @RUC=@nRUCRate*(@RouteDistance/1000)

      -- Accumulate contract vehicle totals
      select @nFuelCostPerAnnum    = isnull(@nFuelCostPerAnnum,0)    + isnull(@FuelCostPerAnnum,0)
           , @nRepairsPerAnnum     = isnull(@nRepairsPerAnnum,0)     + isnull(@RepairsPerAnnum,0)
           , @nTyresTubesPerAnnum  = isnull(@nTyresTubesPerAnnum,0)  + isnull(@TyresTubesPerAnnum,0)
           , @nVehicleInsurance    = isnull(@nVehicleInsurance,0)    + isnull(@VehicleInsurance,0)
           , @nLiveryPerAnnum      = isnull(@nLiveryPerAnnum,0)      + isnull(@LiveryPerAnnum,0)
           , @nLicensing           = isnull(@nLicensing,0)           + isnull(@Licensing,0)
           , @nRateofReturnCost    = isnull(@nRateofReturnCost,0)    + isnull(@RateofReturnCost,0)
           , @nSundriesK           = isnull(@nSundriesK,0)           + isnull(@SundriesK,0)
           , @nRUC                 = isnull(@nRUC,0)                 + isnull(@RUC,0)
           , @nRouteDistance       = isnull(@nRouteDistance,0)       + isnull(@RouteDistance,0)
           , @nRouteDistancePerDay = isnull(@nRouteDistancePerDay,0) + isnull(@RouteDistancePerDay,0)
           , @nVehicleDepreciation = isnull(@nVehicleDepreciation,0) + isnull(@VehicleDepreciation,0)

      -- Get non-vehicle rates
      select top 1
             @DeliveryWageRate   = isNull(nvor.nvor_delivery_wage_rate,nvr.nvr_delivery_wage_rate), 
             @ProcessingWageRate = isNull(nvor.nvor_processing_wage_rate,nvr.nvr_processing_wage_rate), 
             @ReliefWeeks        = isNull(nvor.nvor_relief_weeks,nvr.nvr_relief_weeks),
             @PublicLia          = isNull(nvor.nvor_public_liability_rate_2,nvr.nvr_public_liability_rate),
             @CarrierRisk        = isNull(nvor.nvor_carrier_risk_rate,nvr.nvr_carrier_risk_rate),
             @ACCRate            = isNull(nvor.nvor_acc_rate,nvr.nvr_acc_rate),
             @ACCAmount          = isNull(nvor.nvor_acc_rate_amount,nvr.nvr_acc_rate_amount),
             @ItemsHour          = isNull(nvor.nvor_item_proc_rate_per_hour,nvr.nvr_item_proc_rate_per_hr),
             @Accounting         = isNull(nvor.nvor_accounting,nvr.nvr_accounting),
             @Telephone          = isNull(nvor.nvor_telephone,nvr.nvr_telephone),
             @Sundries           = isNull(nvor.nvor_sundries,nvr.nvr_sundries),
             @Uniform            = isNull(nvor_uniform,nvr_uniform)
        from rd.contract_renewals as cr 
                 left outer join rd.non_vehicle_override_rate as nvor  
                     on nvor.contract_no = cr.contract_no 
                     and nvor.contract_seq_number  = cr.contract_seq_number
                     and nvor.vehicle_number       = @VehicleNo
                     and nvor.nvor_effective_date >= cr.con_rates_effective_date 
           , rd.non_vehicle_rate as nvr
       where cr.contract_no = @inContract 
         and cr.contract_seq_number = @inSequence 
         and nvr.rg_code = cr.con_rg_code_at_renewal 
         and nvr.nvr_rates_effective_date = cr.con_rates_effective_date 
       order by nvor.nvor_effective_date desc  -- "top 1" selects most recent overrides

      -- Some non-vehicle rates accumulate the per-vehicle rates and some are one-off
      --   Processing Wage Rate    once per contract
      --   Delivery Wage Rate      once per contract
      --   Public Liability ($pa)       per vehicle (accumulating)
      --   Carrier Risk ($pa)           per vehicle (accumulating)
      --   Item Proces Rate/Hr     once per contract
      --   Accounting ($pa)             per vehicle (accumulating)
      --   Telephone ($pa)              per vehicle (accumulating)
      --   Sundries ($pa)               per vehicle (accumulating)
      --   ACC (%)                 once per contract
      --   ACC ($)                 once per contract
      --   Wardrobe ($pa) [Uniform]     per vehicle (accumulating)
      --   Relief Weeks            once per contract

      -- First, accumulate those that accumulate; these are treated as per-vehicle costs
      select @nPublicLia    = isnull(@nPublicLia,0)   + isnull(@PublicLia,0)
           , @nCarrierRisk  = isnull(@nCarrierRisk,0) + isnull(@CarrierRisk,0)
           , @nAccounting   = isnull(@nAccounting,0)  + isnull(@Accounting,0)
           , @nTelephone    = isnull(@nTelephone,0)   + isnull(@Telephone,0)
           , @nSundries     = isnull(@nSundries,0)    + isnull(@Sundries,0)
           , @nUniform      = isnull(@nUniform,0)     + isnull(@Uniform,0)
             
      -- Next, Keep the one-offs from the last of the contract's vehicles
      select @nDeliveryWageRate   = isNull(@DeliveryWageRate,0) 
           , @nProcessingWageRate = isNull(@ProcessingWageRate,0)
           , @nItemsHour          = isNull(@ItemsHour ,0)
           , @nACCRate            = isNull(@ACCRate,0)
           , @nACCAmount          = isNull(@ACCAmount,0)
           , @nReliefWeeks        = isNull(@ReliefWeeks,0)

--  end -- cur_getContractVehicles loop

--  close cur_getContractVehicles


  -- Determine the deliveryDays and MaxDeliveryDays for the whole contract
  select @nDeliveryDays=rd.GetContractDelDays(cr.contract_no,cr.contract_seq_number,cr.con_rg_code_at_renewal,cr.con_rates_effective_date)
       , @nRouteDistance=cr.con_distance_at_renewal + sum(isnull(fd.fd_distance,0) * rd.rtd_days_per_annum)
       , @nDeliveryHours=cr.con_del_hrs_week_at_renewal + sum(isnull(fd.fd_delivery_hrs_per_week,0))
       , @nProcessingHours=cr.con_processing_hours_per_week + sum(isnull(fd.fd_processing_hrs_week,0))
       , @nVolume=cr.con_volume_at_renewal + sum(isnull(fd.fd_volume,0))
    from rd.contract_renewals cr
       , rd.route_frequency rf left outer join rd.frequency_distances  fd
                              on rf.contract_no = fd.contract_no 
                              and rf.sf_key = fd.sf_key 
                              and rf.rf_delivery_days = fd.rf_delivery_days 
                              and fd.fd_effective_date >= @dStartDate 
                              and @dStartDate is not null 
                              and (@dEndDate is null 
                                    or @dEndDate >= fd.fd_effective_date)
       , rd.rate_days rd
   where cr.contract_no = rf.contract_no
     and rf.sf_key = rd.sf_key 
     and rf.rf_active = 'Y'
     and cr.con_rates_effective_date = rd.rr_rates_effective_date 
     and cr.con_rg_code_at_renewal = rd.rg_code 
     and cr.contract_no = @inCOntract 
     and cr.contract_seq_number = @inSequence 
   group by 
         cr.contract_no
       , cr.contract_seq_number
       , cr.con_rg_code_at_renewal
       , cr.con_rates_effective_date
       , cr.con_distance_at_renewal
       , cr.con_del_hrs_week_at_renewal
       , cr.con_processing_hours_per_week
       , cr.con_volume_at_renewal

  select @nMaxDeliveryDays = max(rd.rtd_days_per_annum)
    from rd.contract_renewals cr join rd.rate_days rd
                      on cr.con_rg_code_at_renewal = rd.rg_code 
                      and cr.con_rates_effective_date = rd.rr_rates_effective_date
   where cr.contract_no         = @inContract 
     and cr.contract_seq_number = @inSequence
     
  --If max days per week>4, assume deldays = maxdeldays
  select @nMaxdays = sum(sf.sf_days_week)
    from rd.rate_days rd
       , rd.standard_frequency sf
       , rd.route_frequency rf
       , rd.contract_renewals cr
   where cr.contract_no = @inContract 
     and cr.contract_seq_number = @inSequence 
     and rf.contract_no = cr.contract_no 
     and rf.rf_active = 'Y' 
     and sf.sf_key = rf.sf_key 
     and rd.sf_key = sf.sf_key 
     and rd.rg_code = cr.con_rg_code_at_renewal 
     and rd.rr_rates_effective_date 
                      = cr.con_rates_effective_date  
  if @nMaxdays > 4
      select @nDeliveryDays=@nMaxDeliveryDays

  -- Calculate non-vehicle costs
  select @nAccounting          = round(@nAccounting,2)
  select @nTelephone           = round(@nTelephone,2)
  select @nSundries            = round(@nSundries,2)
  select @nCarrierRiskRate     = @nCarrierRisk
  select @nUniformPerAnnum     = @nUniform
  select @nDeliveryCost        = ((round(@nDeliveryHours,2))*52)       * @nDeliveryWageRate
  select @nProcessingCost      = ((((@nVolume/@nItemsHour)/365)*7)*52) * @nProcessingWageRate
  select @nReliefCost          = ((round(@nDeliveryHours,2)) * @nReliefWeeks) * @nDeliveryWageRate -- Added: TJB SR4661
                                     + ((((@nVolume/@nItemsHour)/365)*7) * @nReliefWeeks) * @nProcessingWageRate
  select @nACCPerAnnum         = (@nAccRate/100) * (@nDeliveryCost+@nProcessingCost + @nReliefCost) + isNull(@nACCAmount,0)
  select @nPublicLiabilityCost = round(@nPublicLia,2)  --@nPublicLia*(@nDeliveryDays/@nMaxDeliveryDays)
                                         -- TJB Jan 2021 removed activity ratio from PublicLiability
                                         --              to match BenchmarkCalc and WhatIf
  
  -- Calculate the benchmark and end
  select @nBenchmark
       = isnull(@nVehicleDepreciation,0)
       + isnull(@nFuelCostPerAnnum,0)
       + isnull(@nRUC,0)
       + isnull(@nAccounting,0)
       + isnull(@nSundries,0)
       + isnull(@nTelephone,0)
       + isnull(@nRepairsPerAnnum,0)
       + isnull(@nTyresTubesPerAnnum,0)
       + isnull(@nDeliveryCost,0)
       + isnull(@nProcessingCost,0)
       + isnull(@nReliefCost,0)
       + isnull(@nPublicLiabilityCost,0)
       + isnull(@nACCPerAnnum,0)
       + isnull(@nVehicleInsurance,0)
       + isnull(@nLicensing,0)
       + isnull(@nCarrierRiskRate,0)
       + isnull(@nSundriesK,0)
       + isnull(@nLiveryPerAnnum,0)
       + isnull(@nUniformPerAnnum,0)
       + isnull(@nRateofReturnCost,0) 

  select @nBenchmark=Round(@nBenchmark+.49,0)

  return @nBenchmark
END