
CREATE PROCEDURE [rd].[sp_GetWhatIfCalc2021](
	@inContract int, 
	@inSequence int, 
	@inRGCode int, 
	@inEffectDate datetime, 
	@inVolumeSource varchar(60)
	)
-- TJB  Frequencies & Vehicles 17-Jan-2021
-- Adapted from sp_GetWhatIfCalc2005 to cater for contracts that may 
--    include several vehicles.
-- Simplified the method of determining @vTempint (whether RUC needs
--     to be included). Method previously used in BenchmarkCalcVeh2005.
-- [1-Mar-2021]  Added @sVtList
-- [13-Jul-2021] Fix Route distance calc
-- [15-Jul-2021] Changed a couple of values in results to pass annual values
-- [20-Jul-2021] Changed Accounting to accumulate
-- [23-Jul-2021] Removed @SumFdDistance from Route distance calc 
--
-- TJB  RPCR_133 July-2019
-- Changed 'activity ratio' from (DeliveryDays/MaxDeliveryDays) to
-- 100% (ie removed scaling) from most fixed costs except ACC.
--
-- TJB  RPCR_101 Feb 2016
-- Changed Livery and Wardrobe calculations to p/a (were /1000Km)
--
-- TJB  RPCR_099  Jan-2016
-- Add where condition to 'get rates' query (see nvor_effective_date)
--
-- TJB  RPCR_041  Nov-2012
-- Use nvr_relief_weeks from non_vehicle_rate table rather than 
-- a hard-coded value.  Changed type to real (was int).
--
-- TJB  RD7_0049  Sept2009
-- Changed 'FROM' part
--
-- TJB  SR4684 bug fix  Aug 2006
-- Removed large_parcels from volume calculations
--	nWageHourlyRate 	numeric(10,2),          -- TJB SR4661
--
-- TJB SR4661 - May 2005    - Significant changes
-- Change delivery and processing calc
-- - Base on 52 weeks (change from 56)
-- - Split rates into two separate rates
-- - Add "Relief" calculation (4 weeks)
-- Split nWageHourlyRate into nDeliveryWageRate and nProcessingWageRate
-- also split returned vrr_wage_hourly_rate into vrr_del_wage_rate vrr_proc_wage_rate
-- v2: return only non-null values.
--
-- TJB SR4635 - Sept 2004
-- Removed (commented out) all use of RG Code in selection criteria.
-- It was used, along with the effective date, to select rates and values from some tables.
-- When used in some Whatif scenarios, the two wouldn''t match, nothing would be found, and
-- the calculations would be incorrect. 
-- See also f_getFuelRates_whatif
--          f_getConsumptionRates_whatif
--          f_getInsurance_whatif
--          getContractDelDays_whatif
AS
BEGIN
  set NOCOUNT ON
  set CONCAT_NULL_YIELDS_NULL off

  declare @nNominalVehical numeric(10,2)
  declare @nRemainingEconomicLife integer
  declare @nDeliveryWageRate numeric(10,2)
  declare @nProcessingWageRate numeric(10,2)
  declare @nRepairsMaint numeric(10,2)
  declare @nTyreTubes numeric(10,2)
  declare @nVehicalAllow numeric(10,2)
  declare @nVehicalInsure numeric(10,2)
  declare @nPublicLia numeric(10,2)
  declare @nCarrierRisk numeric(10,2)
  declare @nACCRate numeric(10,2)
  --new 2001
  declare @nInsurancePct numeric(10,2)
  declare @nACCAmount numeric(10,2)
  declare @nLivery numeric(10,2)
  declare @nUniform numeric(10,2)
  declare @nLiveryPerAnnum numeric(12,2)
  declare @nUniformPerAnnum numeric(12,2)
  declare @nMaxDays integer
  --end new
  declare @nLicence numeric(10,2)
  declare @nRateOfReturn numeric(10,2)
  declare @nSalvageRatio numeric(10,2)
  declare @nItemsHour numeric(10,2)
  declare @nFuel numeric(10,2)
  declare @nConsumption numeric(10,2)
  declare @dStartDate datetime
  declare @dEndDate datetime
  declare @sConTitle char(60)
  declare @iNumberCusts integer
  declare @sRDFile char(40)
  declare @sRCMFile char(40)
  declare @nCurrentPayment numeric(10,2)
  declare @nExtensions numeric(10,2)
  declare @RouteDistance  numeric(10,2)
  declare @nRouteDistance numeric(10,2)
  declare @nDeliveryHours numeric(10,2)
  declare @nProcessingHours numeric(10,2)
  declare @nVolume numeric(10,2)
  declare @DeliveryDays numeric(10,2)
  declare @nDeliveryDays numeric(10,2)
  declare @nMaxDeliveryDays numeric(10,2)
  declare @RouteDistancePerDay  real
  declare @nRouteDistancePerDay real
  declare @nVehicleDepreciation real
  declare @nFuelCostPerAnnum real
  declare @nRepairsPerAnnum real
  declare @nTyresTubesPerAnnum real
  declare @nDeliveryCost real
  declare @nProcessingCost real
  declare @nReliefCost real
  declare @nReliefWeeks real
  declare @nPublicLiabilityCost real
  declare @nACCPerAnnum real
  declare @nBenchmark real
  declare @nVehicleInsurance real
  declare @nLicensing real
  declare @nCarrierRiskRate real
  declare @nRateOfReturnCost real
  declare @nFinalBenchmark real
  declare @nRetainedAllowances numeric(10,2)
  declare @nSFKey integer
  declare @nRFDistance numeric(10,2)
  declare @cDeliveryDays char(7)
  declare @nVolume2 numeric(10,2)
  declare @nVolume1avg numeric(10,2)
  declare @nVolume2avg numeric(10,2)
  declare @nSumAdjustments numeric(10,2)
  declare @nTempint integer
  declare @nRUC numeric(8,2)
  declare @nRUCRate numeric(8,2)
  declare @nAccounting numeric(8,2)
  declare @nTelephone numeric(8,2)
  declare @nSundries numeric(8,2)
  declare @nSundriesK numeric(8,2)
  declare @nMultiplier integer
  declare @vrr_nominal_vehical_value numeric(10,2)
  declare @vrr_del_wage_rate numeric(10,2)
  declare @vrr_proc_wage_rate numeric(10,2)
  declare @vrr_repairs_maintenance_rate numeric(10,2)
  declare @vrr_tyre_tubes_rate numeric(10,2)
  declare @vrr_vehical_allowance_rate numeric(10,2)
  declare @vrr_vehical_insurance_premium numeric(10,2)
  declare @vrr_public_liability_rate numeric(10,2)
  declare @vrr_carrier_risk_rate numeric(10,2)
  declare @vrr_acc_rate numeric(10,2)
  declare @vrr_licence_rate numeric(10,2)
  declare @vrr_vehical_rate_of_return_pct numeric(10,2)
  declare @vrr_salvage_ratio numeric(10,2)
  declare @vrr_item_proc_rate_per_hr numeric(10,2)
  declare @vrr_frozen_indicator numeric(10,2)
  declare @vrr_contract_start numeric(10,2)
  declare @vrr_contract_end numeric(10,2)
  declare @vrr_ruc numeric(10,2)
  declare @vrr_accounting numeric(10,2)
  declare @vrr_telephone numeric(10,2)
  declare @vrr_sundries numeric(10,2)
  declare @vrr_sundriesK numeric(10,2)

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
  declare @sVtList varchar(511)
  
  declare @SumRfDistance numeric(10,2)
  declare @sumFdDistance numeric(10,2)

  declare @nActivityRatio real    -- TJB RPCR_133 July-2019: Added (for convenience)

  -- Volumes at renewal
  select @nVolume2 = cr.con_volume_at_renewal 
    from rd.contract_renewals cr
   where cr.contract_no         = @inContract 
     and cr.contract_seq_number = @inSequence
    
  -- Count letters according to source
  select @nVolume1avg=(ac1.ac_w1_medium_letters
                       + ac1.ac_w1_other_envelopes
                       + ac1.ac_w1_small_parcels
                       + ac1.ac_w2_medium_letters
                       + ac1.ac_w2_other_envelopes
                       + ac1.ac_w2_small_parcels
                       )* ac1.ac_scale_factor 
    from rd.artical_count ac1
   where ac1.ac_start_week_period
                   = (select max(ac2.ac_start_week_period) 
                        from rd.artical_count ac2
                       where ac2.contract_no = @inContract) 
     and ac1.contract_no = @inContract 
     and (@inVolumeSource = 'last_article_count' 
           or @inVolumeSource = 'average_article_count') 
     and ac1.ac_scale_factor is not null

  --Count article counts according to source - ok!
  select @nVolume2avg=(ac1.ac_w1_medium_letters
                       + ac1.ac_w1_other_envelopes
                       + ac1.ac_w1_small_parcels
                       + ac1.ac_w2_medium_letters
                       + ac1.ac_w2_other_envelopes
                       + ac1.ac_w2_small_parcels
                       ) * ac1.ac_scale_factor 
    from rd.artical_count ac1
   where ac1.ac_start_week_period 
                = (select max(ac2.ac_start_week_period) 
                     from rd.artical_count ac2
                    where ac2.contract_no = @inContract and
                          ac2.ac_start_week_period <> 
                                  (select max(ac3.ac_start_week_period) 
                                     from rd.artical_count ac3
                                    where ac3.contract_no = @inContract))
     and ac1.contract_no = @inContract 
     and (@inVolumeSource = 'last_but_one_article_count' 
           or @inVolumeSource = 'average_article_count') 
     and ac1.ac_scale_factor is not null
         
  select @nVolume2 = @nVolume2avg  
   where @inVolumeSource = 'last_but_one_article_count' 
     and @nVolume2avg is not null
         
  select @nVolume2 = @nVolume1avg  
   where @inVolumeSource = 'last_article_count' 
     and @nVolume1avg is not null
         
  select @nVolume2 = (@nVolume1avg+@nVolume2avg)/2  
   where @inVolumeSource = 'average_article_count' 
     and @nVolume2avg > 0 
     and @nVolume1avg is not null
         
  select @nVolume2 = @nVolume1avg  
   where @inVolumeSource = 'average_article_count' 
     and (@nVolume2avg = 0 or @nVolume2avg is null)
         
  --Get rates and their overrides  
  -- TJB Frequencies Jan-2021
  -- Changed to calculate vehicle costs by vehicle
  declare @FuelCostPerAnnum real
  declare @RepairsPerAnnum real
  declare @TyresTubesPerAnnum real
  declare @VehicleInsurance real
  declare @LiveryPerAnnum numeric(12,2)
  declare @Licensing real
  declare @RateofReturnCost real
  declare @RUC numeric(8,2)
  declare @SundriesK numeric(8,2)
  declare @VehicleDepreciation real

  declare @nRow            int
  declare @VehicleNo       int
  declare @nVtKey          int
  declare @ContractVehicle int
  declare @crEffectiveDate datetime

  declare cur_getContractVehicles cursor for 
		select distinct isnull(rf.vehicle_number,cv.vehicle_number)
		  from rd.route_frequency rf
		     , rd.contract_vehical cv
		 where rf.contract_no = @inContract
		   and rf.rf_active = 'Y'
		   and cv.contract_no = rf.contract_no
		   and cv.contract_seq_number = @inSequence
		   and cv.cv_vehical_status = 'A'

  select @ContractVehicle = rd.f_GetContractVehicle(@inContract, @inSequence)

  -- Select contract renewal start date
  select @dStartDate = cr.con_start_date 
    from rd.contract_renewals cr
   where cr.contract_no         = @inContract 
     and cr.contract_seq_number = @inSequence

  --Get end date
  select @dEndDate = cr.con_start_date 
    from rd.contract_renewals cr
   where cr.contract_no         = @inContract 
     and cr.contract_seq_number = @inSequence+1

  -- Determine the deliveryDays and MaxDeliveryDays for the whole contract
  -- NOTE: @nRouteDistance is calculated within the cursor loop below
  if @inVolumeSource = 'last_but_one_article_count' 
  or @inVolumeSource = 'last_article_count' 
  or @inVolumeSource = 'average_article_count'
  begin
    select @nDeliveryDays    = rd.GetContractDelDays(cr.contract_no,cr.contract_seq_number,cr.con_rg_code_at_renewal,cr.con_rates_effective_date)
         --, @nRouteDistance   = rd.getcontractdistance(@inContract,@inSequence)
         , @nDeliveryHours   = cr.con_del_hrs_week_at_renewal
                                 + sum(isnull(fd.fd_delivery_hrs_per_week,0))
         , @nProcessingHours = cr.con_processing_hours_per_week
                                 + sum(isnull(fd.fd_processing_hrs_week,0))
         , @iNumberCusts     = isnull(cr.con_no_customers_at_renewal,0)
                                 + isnull(cr.con_no_cmb_custs_at_renewal,0)
                                 + sum(isnull(fd.fd_no_of_boxes,0))
                                 + sum(isnull(fd.fd_no_cmb_customers,0)) 
         , @nVolume          = @nVolume2
       from rd.contract_renewals cr
          , rd.rate_days rd
          , rd.route_frequency rf
               left outer join rd.frequency_distances fd
                   on rf.contract_no = fd.contract_no 
                   and rf.sf_key = fd.sf_key 
                   and rf.rf_delivery_days = fd.rf_delivery_days 
                   and fd.fd_effective_date >= @dStartDate 
                   and @dStartDate is not null 
                   and (@dEndDate is null 
                         or @dEndDate >= fd.fd_effective_date)
     where cr.contract_no = @inContract 
       and cr.contract_seq_number = @inSequence
       and rf.contract_no = cr.contract_no 
       and rf.rf_active = 'Y'
       and rd.sf_key = rf.sf_key 
       and rd.rg_code = @inRGCode 
       and rd.rr_rates_effective_date = @inEffectDate 
     group by 
           cr.contract_no
         , cr.contract_seq_number
         , cr.con_rg_code_at_renewal
         , cr.con_rates_effective_date
         , cr.con_distance_at_renewal
         , cr.con_del_hrs_week_at_renewal
         , cr.con_processing_hours_per_week
         , cr.con_volume_at_renewal
         , cr.con_no_customers_at_renewal
         , cr.con_no_cmb_custs_at_renewal
  end
  else   -- @inVolumeSource = 'last_renewal'
  begin
    select @nDeliveryDays    = rd.GetContractDelDays(cr.contract_no,cr.contract_seq_number,cr.con_rg_code_at_renewal,cr.con_rates_effective_date)
         --, @nRouteDistance   = cr.con_distance_at_renewal
         --                        + sum(isnull(fd.fd_distance,0)* rd.rtd_days_per_annum)
         , @nDeliveryHours   = cr.con_del_hrs_week_at_renewal
                                 + sum(isnull(fd.fd_delivery_hrs_per_week,0))
         , @nProcessingHours = cr.con_processing_hours_per_week
                                 + sum(isnull(fd.fd_processing_hrs_week,0))
         , @iNumberCusts     = isnull(cr.con_no_customers_at_renewal,0)
                                 + isnull(cr.con_no_cmb_custs_at_renewal,0)
                                 + sum(isnull(fd.fd_no_of_boxes,0))
                                 + sum(isnull(fd.fd_no_cmb_customers,0)) 
         , @nVolume          = @nVolume2
                                 + sum(isnull(fd.fd_volume,0))
      from rd.contract_renewals cr
         , rd.rate_days rd
         , rd.route_frequency rf
               left outer join rd.frequency_distances fd
                   on rf.contract_no = fd.contract_no 
                   and rf.sf_key = fd.sf_key 
                   and rf.rf_delivery_days = fd.rf_delivery_days 
                   and fd.fd_effective_date >= @dStartDate 
                   and @dStartDate is not null 
                   and (@dEndDate is null 
                          or @dEndDate >= fd.fd_effective_date)
     where cr.contract_no = @inContract
       and cr.contract_seq_number = @inSequence
       and rf.contract_no = cr.contract_no
       and rf.rf_active = 'Y'
       and rd.sf_key = rf.sf_key
       and rd.rg_code = @inRGCode 
       and rd.rr_rates_effective_date = @inEffectDate
     group by 
           cr.contract_no
         , cr.contract_seq_number
         , cr.con_rg_code_at_renewal
         , cr.con_rates_effective_date
         , cr.con_distance_at_renewal
         , cr.con_del_hrs_week_at_renewal
         , cr.con_processing_hours_per_week
         , cr.con_volume_at_renewal
         , cr.con_no_customers_at_renewal
         , cr.con_no_cmb_custs_at_renewal
  end
  
  select @nDeliveryHours   = isnull(@nDeliveryHours,0)
       , @nProcessingHours = isnull(@nProcessingHours,0)
       , @nVolume          = isnull(@nVolume,0)
       , @iNumberCusts     = isnull(@iNumberCusts,0)

  --get contract adjustments
  select @nCurrentPayment = (cr.con_renewal_payment_value)
       , @nExtensions = (select sum(ca.ca_amount) 
                           from rd.contract_adjustments ca
                          where cr.contract_no = ca.contract_no 
                            and cr.contract_seq_number = ca.contract_seq_number 
                            and ca.ca_date_paid is not null)
    from rd.contract_renewals cr
   where cr.contract_no         = @inContract 
     and cr.contract_seq_number = @inSequence

  --Get frequency adjustments  
  select @nSumAdjustments = sum(fa.fd_amount_to_pay) 
    from rd.frequency_adjustments fa
   where fa.contract_no         = @inContract 
     and fa.contract_seq_number = @inSequence 
     and fa.fd_paid_to_date is not null

  select @nCurrentPayment = isnull(@nCurrentPayment,0)
       , @nExtensions     = isnull(@nExtensions,0)
       , @nSumAdjustments = isnull(@nSumAdjustments,0)

  --Calculate current payment    
  select @nCurrentPayment = @nCurrentPayment + @nSumAdjustments

  -- Get and process vehicle rates
  open cur_getContractVehicles

  select @nRow = 0, @sVtList = ''
  while 1 = 1 
  begin
      fetch next from cur_getContractVehicles into @VehicleNo
           
      if @@fetch_status < 0  
          break

      select @nRow = @nRow + 1

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
           , @nVehicalInsure  = isnull(rd.f_GetVehInsurance_whatif(cv.contract_no,@inSequence, @inEffectDate, @VehicleNo),0)
           , @nFuel           = isNull(vor.vor_fuel_rate
                                    ,rd.f_GetVehFuelRates_whatif(cv.contract_no,@inSequence, @inEffectDate, @VehicleNo))
           , @nConsumption    = isNull(vor_consumption_rate
                                    ,rd.f_GetVehConsumptionRates_whatif(cv.contract_no, @inSequence, @inEffectDate, @VehicleNo))
           , @nInsurancePct   = isNull(vr.vr_vehicle_value_insurance_pct,0)
           , @nRemainingEconomicLife = isNull(v.v_remaining_economic_life,0)
           , @nVtKey          = v.vt_key
        from rd.contract_vehical cv 
                 left outer join rd.vehicle_override_rate as vor 
                      on vor.contract_no = cv.contract_no
                      and vor.contract_seq_number = cv.contract_seq_number
                      and vor.vehicle_number      = cv.vehicle_number
                      and vor.vor_effective_date >= @inEffectDate
           , rd.vehicle as v
           , rd.vehicle_rate as vr
       where cv.contract_no         = @inContract 
         and cv.contract_seq_number = @inSequence
         and cv.vehicle_number      = @VehicleNo
         and v.vehicle_number       = cv.vehicle_number
         and vr.vt_key              = v.vt_key 
         and vr.vr_rates_effective_date = @inEffectDate
       order by vor.vor_effective_date desc  -- "top 1" selects most recent overrides

      -- Get the vehicle's number of delivery days (maximum per week)
      select @DeliveryDays = rd.f_GetConVehicleDelDays( @inContract, @inRGCode, @inEffectDate, @VehicleNo )

      -- Calculate the vehicle's route distance (per year)
      if @inVolumeSource = 'last_but_one_article_count' 
      or @inVolumeSource = 'last_article_count' 
      or @inVolumeSource = 'average_article_count'
      begin
        select @RouteDistance = rd.f_getvehiclecontractdistance(@inContract,@inSequence,@VehicleNo)
          from rd.contract_renewals cr
             , rd.rate_days rd
             , rd.route_frequency rf
                   left outer join rd.frequency_distances fd
                        on rf.contract_no = fd.contract_no 
                        and rf.sf_key = fd.sf_key 
                        and rf.rf_delivery_days = fd.rf_delivery_days 
                        and fd.fd_effective_date >= @dStartDate 
                        and @dStartDate is not null 
                        and (@dEndDate is null 
                              or @dEndDate >= fd.fd_effective_date)
         where cr.contract_no = @inContract 
           and cr.contract_seq_number = @inSequence
           and rf.contract_no = cr.contract_no 
           and rf.rf_active = 'Y'
           and rf.vehicle_number = @VehicleNo
           and rd.sf_key = rf.sf_key 
           and rd.rg_code = @inRGCode 
           and rd.rr_rates_effective_date = @inEffectDate 
         group by 
               cr.con_distance_at_renewal
      end
      else   -- @inVolumeSource = 'last_renewal'
      begin
          select @SumRfDistance = sum(isnull(rf.rf_distance,0) * rd.rtd_days_per_annum)
            from rd.contract_renewals cr
               , rd.rate_days rd
               , rd.route_frequency rf
           where cr.contract_no = @inContract 
             and cr.contract_seq_number = @inSequence 
             and rf.contract_no = cr.contract_no
             and rf.rf_active = 'Y'
             and rf.vehicle_number = @VehicleNo
             and rd.rg_code = @inRGCode 
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
                           and @dStartDate is not null 
                           and fd.fd_effective_date >= @dStartDate 
                           and (@dEndDate is null 
                                 or fd.fd_effective_date < @dEndDate)
           where cr.contract_no = @inContract 
             and cr.contract_seq_number = @inSequence 
             and rf.contract_no = cr.contract_no
             and rf.rf_active = 'Y'
             and rf.vehicle_number = @VehicleNo
             and rd.rg_code = @inRGCode 
             and rd.sf_key = rf.sf_key 
             and rd.rr_rates_effective_date = cr.con_rates_effective_date
           group by 
                 cr.con_distance_at_renewal

          -- TJB Frequencies & Vehicles [23-Jul-2021] 
          -- Removed @SumFdDistance from Route distance calc 
          select @RouteDistance = @SumRfDistance -- + @SumFdDistance
      end       

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

      select @ntempint = count(fuel_type.ft_key)
        from rd.vehicle
           , rd.fuel_type 
       where vehicle.vehicle_number = @VehicleNo 
         and fuel_type.ft_key = vehicle.ft_key 
         and fuel_type.ft_description like 'diesel%'

      if @ntempint = 0
      begin
          select @RUC=0.0
               , @nMultiplier = 0
      end
      else
      begin
          select @RUC=@nRUCRate*(@RouteDistance/1000)
               , @nMultiplier = 1
      end

      -- Accumulate contract vehicle totals
      select @nFuelCostPerAnnum    = isnull(@nFuelCostPerAnnum,0)    + isnull(@FuelCostPerAnnum,0)
           , @nRepairsPerAnnum     = isnull(@nRepairsPerAnnum,0)     + isnull(@RepairsPerAnnum,0)
           , @nTyresTubesPerAnnum  = isnull(@nTyresTubesPerAnnum,0)  + isnull(@TyresTubesPerAnnum,0)
           , @nLiveryPerAnnum      = isnull(@nLiveryPerAnnum,0)      + isnull(@LiveryPerAnnum,0)
           , @nLicensing           = isnull(@nLicensing,0)           + isnull(@Licensing,0)
           , @nVehicleInsurance    = isnull(@nVehicleInsurance,0)    + isnull(@VehicleInsurance,0)
           , @nRateofReturnCost    = isnull(@nRateofReturnCost,0)    + isnull(@RateofReturnCost,0)
           , @nSundriesK           = isnull(@nSundriesK,0)           + isnull(@SundriesK,0)
           , @nRUC                 = isnull(@nRUC,0)                 + isnull(@RUC,0)
           , @nRouteDistance       = isnull(@nRouteDistance,0)       + isnull(@RouteDistance,0)
           , @nRouteDistancePerDay = isnull(@nRouteDistancePerDay,0) + isnull(@RouteDistancePerDay,0)
           , @nVehicleDepreciation = isnull(@nVehicleDepreciation,0) + isnull(@VehicleDepreciation,0)

      -- Add the vehicle's vt_key to the vt key lis
      select @sVtList = @sVtList + convert(varchar,@nVtKey)+','
      
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

      -- First, accumulate those that accumulate
      select @nPublicLia    = isnull(@nPublicLia,0)   + isnull(@PublicLia,0)
           , @nCarrierRisk  = isnull(@nCarrierRisk,0) + isnull(@CarrierRisk,0)
           , @nAccounting   = isnull(@nAccounting,0)  + isnull(@Accounting,0)
           , @nTelephone    = isnull(@nTelephone,0)   + isnull(@Telephone,0)
           , @nSundries     = isnull(@nSundries,0)    + isnull(@Sundries,0)
           , @nUniform      = isnull(@nUniform,0)     + isnull(@Uniform,0)
             
      -- Next, Keep the one-offs.  
      if (@VehicleNo = @ContractVehicle)
      begin
          select @nDeliveryWageRate   = isNull(@DeliveryWageRate,0) 
               , @nProcessingWageRate = isNull(@ProcessingWageRate,0)
               , @nItemsHour          = isNull(@ItemsHour ,0)
               , @nACCRate            = isNull(@ACCRate,0)
               , @nACCAmount          = isNull(@ACCAmount,0)
               , @nReliefWeeks        = isNull(@ReliefWeeks,0)
      end
  end -- cur_getContractVehicles loop

  close cur_getContractVehicles

  select @nMaxDeliveryDays = max(rd.rtd_days_per_annum)
    from rd.contract_renewals cr 
                     join rd.rate_days rd
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

/*  This is probably unnecessary
  select @nNominalVehical=isnull(@nNominalVehical,0)
       , @nRemainingEconomicLife=isnull(@nRemainingEconomicLife,0)
       , @nDeliveryWageRate=isnull(@nDeliveryWageRate,0)
       , @nProcessingWageRate=isnull(@nProcessingWageRate,0)
       , @nRepairsMaint=isnull(@nRepairsMaint,0)
       , @nTyreTubes=isnull(@nTyreTubes,0)
       , @nVehicalAllow=isnull(@nVehicalAllow,0)
       , @nVehicalInsure=isnull(@nVehicalInsure,0)
       , @nPublicLia=isnull(@nPublicLia,0)
       , @nCarrierRisk=isnull(@nCarrierRisk,0)
       , @nACCRate=isnull(@nACCRate,0)
       , @nACCAmount=isnull(@nACCAmount,0)
       , @nLicence=isnull(@nLicence,0)
       , @nRateOfReturn=isnull(@nRateOfReturn,0)
       , @nSalvageRatio=isnull(@nSalvageRatio,0)
       , @nItemsHour=isnull(@nItemsHour,0)
       , @nFuel=isnull(@nFuel,0)
       , @nConsumption=isnull(@nConsumption,0)
       , @nAccounting=isnull(@nAccounting,0)
       , @nTelephone=isnull(@nTelephone,0)
       , @nSundries=isnull(@nSundries,0)
       , @nRucrate=isnull(@nRucrate,0)
       , @nSundriesK=isnull(@nSundriesK,0)
       , @nInsurancePct=isnull(@nInsurancePct,0)
       , @nLivery=isnull(@nLivery,0)
       , @nUniform=isnull(@nUniform,0)
*/
  --Calculate the benchmark
  select @nBenchmark =
         isnull(@nVehicleDepreciation,0)
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
       
  --Final; BM
  select @nFinalBenchmark = Round(@nBenchmark + isnull(@nRateofReturnCost,0), 1)

  --Get contract title
  select @sConTitle = c.con_title
       , @sRDFile = c.con_rd_paper_file_text
       , @sRCMFile = c.con_rcm_paper_file_text 
    from rd.contract c
   where c.contract_no = @inContract

  --get standard rates 
  select @vrr_nominal_vehical_value      = vr.vr_nominal_vehicle_value
       , @vrr_del_wage_rate              = nvr.nvr_delivery_wage_rate
       , @vrr_proc_wage_rate             = nvr.nvr_processing_wage_rate
       , @vrr_repairs_maintenance_rate   = vr.vr_repairs_maintenance_rate
       , @vrr_tyre_tubes_rate            = vr.vr_tyre_tubes_rate
       , @vrr_vehical_allowance_rate     = vr.vr_vehicle_allowance_rate
       , @vrr_vehical_insurance_premium  = nvr.nvr_vehicle_insurance_base_premium
       , @vrr_public_liability_rate      = nvr.nvr_public_liability_rate
       , @vrr_carrier_risk_rate          = nvr.nvr_carrier_risk_rate
       , @vrr_acc_rate                   = nvr.nvr_acc_rate
       , @vrr_licence_rate               = vr.vr_licence_rate
       , @vrr_vehical_rate_of_return_pct = vr.vr_vehicle_rate_of_return_pct
       , @vrr_salvage_ratio              = vr.vr_salvage_ratio
       , @vrr_item_proc_rate_per_hr      = nvr.nvr_item_proc_rate_per_hr
       , @vrr_ruc                        = vr.vr_ruc
       , @vrr_accounting                 = nvr.nvr_accounting
       , @vrr_telephone                  = nvr.nvr_telephone
       , @vrr_sundries                   = nvr.nvr_sundries
       , @vrr_sundriesK                  = vr.vr_sundries_k 
    from rd.contract_vehical cv
       , rd.non_vehicle_rate nvr
       , rd.vehicle v
       , rd.vehicle_type vt
             left outer join rd.vehicle_rate vr
                  on vr.vt_key = vt.vt_key 
   where cv.contract_no = @inContract 
     and cv.contract_seq_number = @inSequence 
     and v.vehicle_number = cv.vehicle_number 
     and vt.vt_key = v.vt_key 
     and nvr.nvr_rates_effective_date = @inEffectDate 
     and vr.vr_rates_effective_date = @inEffectDate

  --return the values  
  select @inContract           as inContract
       , @inSequence           as inSequence
       , @sConTitle            as sConTitle
       , @nNominalVehical      as nNominalVehical
       , @nDeliveryWageRate    as nDeliveryWageRate
       , @nRepairsMaint        as nRepairsMaint
       , @nTyreTubes           as nTyreTubes
       , @nVehicalAllow        as nVehicalAllow
       , @nVehicalInsure       as nVehicalInsure
       , @nPublicLia           as nPublicLia
       , @nCarrierRisk         as nCarrierRisk
       , @nACCRate             as nACCRate
       , @nLicence             as nLicence
       , @nRateOfReturn        as nRateOfReturn
       , @nSalvageRatio        as nSalvageRatio
       , @nItemsHour           as nItemsHour
       , @nFuel                as nFuel
       , @nConsumption         as nConsumption
       , @nRouteDistance       as nRouteDistance
       , @nDeliveryHours       as DeliveryHours
       , @nProcessingHours     as ProcessingHours
       , @nVolume              as Volume
       , @nDeliveryDays        as DeliveryDays
       , @nMaxDeliveryDays     as MaxDeliveryDays
       , @iNumberCusts         as NumberCusts
       , @nRouteDistancePerDay as nRouteDistancePerDay
       , @nVehicleDepreciation as nVehicleDepreciation
       , @nFuelCostPerAnnum    as nFuelCostPerAnnum
       , @nRepairsPerAnnum     as nRepairsPerAnnum
       , @nTyresTubesPerAnnum  as nTyresTubesPerAnnum
       , @nDeliveryCost        as nDeliveryCost
       , @nProcessingCost      as nProcessingCost
       , @nPublicLiabilityCost as nPublicLiabilityCost
       , @nACCPerAnnum         as nACCPerAnnum
       , @nVehicleInsurance    as nVehicleInsurance
       , @nLicensing           as nLicensing
       , @nCarrierRiskRate     as nCarrierRiskRate
       , @nBenchmark           as nBenchmark
       , @nRateOfReturnCost    as nRateOfReturnCost
       , @nFinalBenchmark      as nFinalBenchmark
       , @nRetainedAllowances  as nRetainedAllowances
       , @nCurrentPayment      as nCurrentPayment
       , @nSFKey               as nSFKey
       , @nRFDistance          as RFDistance
       , @cDeliveryDays        as DeliveryDays
       , 0                     as DaysPerYear
       , 0                     as DaysPerWeek
       , 0                     as ItemsPerCust
       , 'Y'                   as rf_active
       , ''
       , 0.0
       , @nAccounting          as nAccounting
       , @nTelephone           as nTelephone
       , @nSundries            as nSundries
       --, @nRUCRate             as nRUCRate   -- TJB July-2021
       , @nRUC                 as nRUC
       , @vrr_nominal_vehical_value      as vrr_nominal_vehical_value
       , @vrr_del_wage_rate              as vrr_del_wage_rate
       , @vrr_repairs_maintenance_rate   as vrr_repairs_maintenance_rate
       , @vrr_tyre_tubes_rate            as vrr_tyre_tubes_rate
       , @vrr_vehical_allowance_rate     as vrr_vehical_allowance_rate
       , @vrr_vehical_insurance_premium  as vrr_vehical_insurance_premium
       , @vrr_public_liability_rate      as vrr_public_liability_rate
       , @vrr_carrier_risk_rate          as vrr_carrier_risk_rate
       , @vrr_acc_rate                   as vrr_acc_rate
       , @vrr_licence_rate               as vrr_licence_rate
       , @vrr_vehical_rate_of_return_pct as vrr_vehical_rate_of_return_pct
       , @vrr_salvage_ratio              as vrr_salvage_ratio
       , @vrr_item_proc_rate_per_hr      as vrr_item_proc_rate_per_hr
       , @vrr_ruc                        as vrr_ruc
       , @vrr_accounting                 as vrr_accounting
       , @vrr_telephone                  as vrr_telephone
       , @vrr_sundries                   as vrr_sundries
       , @vrr_sundriesK                  as vrr_sundriesK
       , @nSundriesK           as nSundriesK
       , @nMultiplier          as nMultiplier
       , @nInsurancePct        as nInsurancePct
       --, @nLivery              as nLivery    -- TJB July-2021
       , @nLiveryPerAnnum      as nLiveryPerAnnum
       --, @nUniform             as nUniform   -- TJB July-2021
       , @nUniformPerAnnum     as nUniformPerAnnum
       , @nACCAmount           as nACCAmount
       , @nVtKey               as nVtKey
       , @nReliefCost          as nReliefCost
       , @nProcessingWageRate  as nProcessingWageRate
       , @vrr_proc_wage_rate   as vrr_proc_wage_rate
       , @nReliefWeeks         as nReliefWeeks
       , @sVtList              as sVtList
END