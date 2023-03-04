/*
 select [rd].[BenchmarkCalc2021](5000, 24)
 exec [rd].[sp_GetBenchmarkRpt2021]  5000, 24
*/
CREATE PROCEDURE [rd].sp_GetBenchmarkRpt2021(
    @inContract int,
    @inSequence int)
-- Calculates the basic single-value benchmark amount 
-- where a contract may include several vehicles
--
-- TJB Frequencies & Vehicles 17-Feb-2021
-- Derived from BenchmarkCalc2021 and sp_GetBenchmarkRpt2020
-- Updated to allow for contracts with more than one vehicle.
-- [23-Feb-2021] Changed f_GetConVehicleMaxDelDays to f_GetConVehicleDelDays
-- [12-Jul-2021] Bug fix: Add handling for nNumberCusts,
--     nDeliveryDaysForReport, nCurrentPayment, nExtensions
-- [13-Jul-2021] Fix Route distance calc
-- [23-Jul-2021] Removed @SumFdDistance from Route distance calc 
AS
BEGIN
  set nocount on
  declare @nNominalVehical     numeric(10,2)
        , @nRepairsMaint       numeric(10,2)
        , @nTyreTubes          numeric(10,2)
        , @nVehicalAllow       numeric(10,2)
        , @nLicence            numeric(10,2)
        , @nRateOfReturn       numeric(10,2)
        , @nSalvageRatio       numeric(10,2)
        , @nRUCRate            numeric(8,2)
        , @nSundriesK          numeric(8,2)
        , @nLivery             numeric(12,2)
        , @nVehicalInsure      numeric(10,2)
        , @nFuel               numeric(10,2)
        , @nConsumption        numeric(10,2)
        , @nRemainingEconomicLife int

  declare @nDeliveryWageRate   numeric(10,2)
        , @nProcessingWageRate numeric(10,2)
        , @nPublicLia          numeric(10,2)
        , @nCarrierRisk        numeric(10,2)
        , @nACCRate            numeric(10,2)
        , @nACCAmount          numeric(12,2)
        , @nItemsHour          numeric(10,2)
        , @nAccounting         numeric(8,2)
        , @nTelephone          numeric(8,2)
        , @nSundries           numeric(8,2)
        , @nUniform            numeric(12,2)
        , @nReliefWeeks        real

  declare @DeliveryWageRate    numeric(10,2)
        , @ProcessingWageRate  numeric(10,2)
        , @PublicLia           numeric(10,2)
        , @CarrierRisk         numeric(10,2)
        , @ACCRate             numeric(10,2)
        , @ACCAmount           numeric(12,2)
        , @ItemsHour           numeric(10,2)
        , @Accounting          numeric(8,2)
        , @Telephone           numeric(8,2)
        , @Sundries            numeric(8,2)
        , @Uniform             numeric(12,2)
        , @ReliefWeeks         real

  declare @dStartDate          datetime
        , @dEndDate            datetime
        , @dEffectDate         datetime
        , @dExpiryDate         datetime

  declare @nNumRows            int
        , @DeliveryDays        numeric(10,2)
        , @nDeliveryDays       numeric(10,2)
        , @nDeliveryHours      numeric(10,3)
        , @nProcessingHours    numeric(10,2)
        , @nVolume             numeric(10,2)
        , @nMaxDeliveryDays    numeric(10,2)
        , @nMaxdays            int

  declare @RouteDistance        numeric(10,2)
        , @nRouteDistance       numeric(10,2)
        , @RouteDistancePerDay  real
        , @VehicleDepreciation  real
        , @nRouteDistancePerDay real
        , @nVehicleDepreciation real
        , @SumRfDistance        numeric(10,2)
        , @sumFdDistance        numeric(10,2)

  declare @nFuelCostPerAnnum   real
        , @nRepairsPerAnnum    real
        , @nTyresTubesPerAnnum real
        , @nVehicleInsurance   real
        , @nLiveryPerAnnum     numeric(12,2)
        , @nLicensing          real
        , @nRateofReturnCost   real

  declare @nDeliveryCost       real
        , @nProcessingCost     real
        , @nReliefCost         real
        , @nPublicLiabilityCost real
        , @nACCPerAnnum        real
        , @nUniformPerAnnum    numeric(12,2)
        , @nCarrierRiskRate    real

  declare @nTempint            int
        , @nRUC                numeric(8,2)
        , @nBenchmark          real
        , @SundriesK           numeric(8,2)

  declare @FuelCostPerAnnum    real
        , @RepairsPerAnnum     real
        , @TyresTubesPerAnnum  real
        , @VehicleInsurance    real
        , @LiveryPerAnnum      numeric(12,2)
        , @Licensing           real
        , @RateofReturnCost    real
        , @RUC                 numeric(8,2)

  declare @rg_code             int
        , @nRow                int
        , @VehicleNo           int
        , @nVtKey              int
        , @ContractVehicle     int
        , @crEffectiveDate     datetime

  declare @PRStartDate         datetime
        , @PREndDate           datetime
        , @nPRSKey1            integer
        , @nPRSKey2            integer
        , @nPRSKey3            integer
        , @nPRSKey4            integer
        , @nPRSKey5            integer
        , @nPieceRate1         numeric(10,2)
        , @nPieceRate2         numeric(10,2)
        , @nPieceRate3         numeric(10,2)
        , @nPieceRate4         numeric(10,2)
        , @nPieceRate5         numeric(10,2)
        , @sPieceRateSupplier1 char(50)
        , @sPieceRateSupplier2 char(50)
        , @sPieceRateSupplier3 char(50)
        , @sPieceRateSupplier4 char(50)
        , @sPieceRateSupplier5 char(50)

  declare @nFinalBenchmark     real
        , @nRetainedAllowances numeric(10,2)
        , @sRenewalGroup       char(40)
        , @nRenewalGroup       integer
        , @dRenewalDate        datetime

  declare @nLoop               integer
        , @nRowCount           integer
        , @nNumberCusts        integer
        , @nPRSKey             integer
        , @sPieceRateSupplier  varchar(50)
        , @nPieceRate          numeric(10,2)
        , @nCurrentPayment     numeric(10,2)
        , @nExtensions         numeric(10,2)
        , @nDeliveryDaysForReport numeric(10,2)
        , @sRDFile             char(40)
        , @sRCMFile            char(40)
        , @sConTitle           char(60)

  declare @sFreqDescr          varchar(35)
        , @sFreqDays           varchar(7)
        , @dFreqDist           numeric(10,2)
        , @sFreqDescr1         varchar(35)
        , @sFreqDays1          varchar(7)
        , @dFreqDist1          numeric(10,2)
        , @sFreqDescr2         varchar(35)
        , @sFreqDays2          varchar(7)
        , @dFreqDist2          numeric(10,2)
        , @sFreqDescr3         varchar(35)
        , @sFreqDays3          varchar(7)
        , @dFreqDist3          numeric(10,2)
        , @sFreqDescr4         varchar(35)
        , @sFreqDays4          varchar(7)
        , @dFreqDist4          numeric(10,2)
        , @sFreqDescr5         varchar(35)
        , @sFreqDays5          varchar(7)
        , @dFreqDist5          numeric(10,2)
        , @sFreqDescr6         varchar(35)
        , @sFreqDays6          varchar(7)
        , @dFreqDist6          numeric(10,2)
        , @sFreqDescr7         varchar(35)
        , @sFreqDays7          varchar(7)
        , @dFreqDist7          numeric(10,2)
        , @sFreqDescr8         varchar(35)
        , @sFreqDays8          varchar(7)
        , @dFreqDist8          numeric(10,2)
        , @sFreqDescr9         varchar(35)
        , @sFreqDays9          varchar(7)
        , @dFreqDist9          numeric(10,2)
        , @sFreqDescr10        varchar(35)
        , @sFreqDays10         varchar(7)
        , @dFreqDist10         numeric(10,2)
        , @sFreqDescr11        varchar(35)
        , @sFreqDays11         varchar(7)
        , @dFreqDist11         numeric(10,2)
        , @sFreqDescr12        varchar(35)
        , @sFreqDays12         varchar(7)
        , @dFreqDist12         numeric(10,2)

  declare cur_getContractVehicles cursor for 
        select distinct isnull(rf.vehicle_number,cv.vehicle_number)
          from rd.route_frequency rf
             , rd.contract_vehical cv
         where rf.contract_no = @inContract
           and rf.rf_active = 'Y'
           and cv.contract_no = rf.contract_no
           and cv.contract_seq_number = @inSequence
           and cv.cv_vehical_status = 'A'

  declare cur_getfrequencies cursor for 
    SELECT sf.sf_description
         , rf.rf_delivery_days
         , rf.rf_distance
          FROM rd.standard_frequency sf
             , rd.route_frequency rf
         WHERE sf.sf_key = rf.sf_key
           AND rf.contract_no = @inContract
           AND rf.rf_active = 'Y'
           AND rf.rf_distance > 0

  declare cur_getsupplier cursor for 
    SELECT prs_key, prs_description 
      FROM rd.piece_rate_supplier
                  
  select @rg_code = rg_code from rd.contract
   where contract_no = @inContract
         
  select @ContractVehicle = rd.f_GetContractVehicle( @inContract, @inSequence)

  select @dStartDate  = cr.con_start_date
       , @dEffectDate = cr.con_rates_effective_date
    from rd.contract_renewals cr
   where cr.contract_no         = @inContract
     and cr.contract_seq_number = @inSequence

  select @dEndDate = cr.con_start_date
    from rd.contract_renewals cr
   where cr.contract_no         = @inContract 
     and cr.contract_seq_number = @inSequence+1
     
  -- Get and process vehicle rates
  open cur_getContractVehicles

  select @nRow = 0
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
                       and rf.vehicle_number = @VehicleNo
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
      
      -- TJB Frequencies & Vehicles [23-Jul-2021]
      -- Removed @SumFdDistance from Route distance calc
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

  -- Determine the deliveryDays and MaxDeliveryDays for the whole contract
  select @nDeliveryDays=rd.GetContractDelDays(cr.contract_no,cr.contract_seq_number,cr.con_rg_code_at_renewal,cr.con_rates_effective_date)
       , @nRouteDistance=cr.con_distance_at_renewal + sum(isnull(fd.fd_distance,0) * rd.rtd_days_per_annum)
       , @nDeliveryHours=cr.con_del_hrs_week_at_renewal + sum(isnull(fd.fd_delivery_hrs_per_week,0))
       , @nProcessingHours=cr.con_processing_hours_per_week + sum(isnull(fd.fd_processing_hrs_week,0))
       , @nVolume=cr.con_volume_at_renewal + sum(isnull(fd.fd_volume,0))
       , @nNumberCusts = isnull(cr.con_no_customers_at_renewal,0)
                         + isnull(cr.con_no_cmb_custs_at_renewal,0)
                         + sum(isnull(fd.fd_no_of_boxes,0))
                         + sum(isnull(fd.fd_no_cmb_customers,0))
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
       , cr.con_no_customers_at_renewal
       , cr.con_no_cmb_custs_at_renewal

  --pay value
  select @nCurrentPayment = contract_renewals.con_renewal_payment_value,
         @nExtensions     = (select sum(distinct frequency_adjustments.fd_amount_to_pay) 
                               from frequency_adjustments 
                              where contract_renewals.contract_no = frequency_adjustments.contract_no and
                                    contract_renewals.contract_seq_number = frequency_adjustments.contract_seq_number and
                                    frequency_adjustments.fd_paid_to_date is not null) 
    from contract_renewals 
   where contract_no = @inContract and
         contract_seq_number = @inSequence

  select @nCurrentPayment=@nCurrentPayment+isnull(@nExtensions,0)

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

  -- to prevent the deliverydays from being changed if the nMaxDays are >4
  -- in order to show correct deliverydays on the report.
  select @nDeliveryDaysForReport = @nDeliveryDays

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
  


  select @nBenchmark = isnull(@nVehicleDepreciation,0)+
                       isnull(@nFuelCostPerAnnum,0)+
                       isnull(@nRUC,0)+
                       isnull(@nAccounting,0)+
                       isnull(@nSundries,0)+
                       isnull(@nTelephone,0)+
                       isnull(@nRepairsPerAnnum,0)+
                       isnull(@nTyresTubesPerAnnum,0)+
                       isnull(@nDeliveryCost,0)+
                       isnull(@nProcessingCost,0)+
                       isnull(@nReliefCost,0)+
                       isnull(@nPublicLiabilityCost,0)+
                       isnull(@nACCPerAnnum,0)+
                       isnull(@nVehicleInsurance,0)+
                       isnull(@nLicensing,0)+
                       isnull(@nCarrierRiskRate,0)+
                       isnull(@nSundriesK,0)+
                       isnull(@nLiveryPerAnnum,0)+
                       isnull(@nUniformPerAnnum,0)

  select @nFinalBenchmark = Round(@nBenchmark+@nRateOfReturnCost,2)

  select @sConTitle = con_title,
         @sRDFile   = con_rd_paper_file_text,
         @sRCMFile  = con_rcm_paper_file_text
    from rd.contract 
   where contract_no = @inContract
   
  select @nRetainedAllowances = sum(ca_annual_amount)
    from rd.contract_allowance 
   where contract_no = @inContract
     and contract_allowance.ca_approved = 'Y'
   
  select @nRowCount = count(*)
    from rd.piece_rate_supplier

  if @nRowCount > 0
  begin

      -- Determine dates for piece rates: from 1st day of this month a year ago, 
      -- to the last day of this month this year.  
      -- BUG?
      -- Should be 
      --     from today a year ago to yesterday this year?
      --  or from first day of next month a year ago to last day of this month this year?
      --  or from first day of this month a year ago to last day of last month this year?
     
      select @PRStartDate=rd.ymd(year(getdate())-1,month(getdate()),1)
      select @PREndDate=rd.getLastDayofMonth(dateadd(day,364,rd.ymd(year(getdate())-1,month(getdate()),1)))

      -- TJB  Release 7.1.10 Fixups  Aug-2013
      -- Accumulate BM data in t_bm_piecerates table
      -- Truncation done by application
      -- truncate table t_bm_piecerates

      open cur_getsupplier

      select @nrow = 0
      while 1 = 1 
      begin
          fetch next from cur_getsupplier 
                into @nPRSKey, @sPieceRateSupplier
           
          if @@fetch_status < 0  break
          
          -- TJB Oct-2010
          -- Use supplier name from database table with no override
          -- if @nPRSKey = 1 and @dStartDate >= '2007-May-01'        -- Change 'KiwiMail' to 'Reachmedia'
          --     select @sPieceRateSupplier = 'Reachmedia'

          -- TJB July-2013: changed if test from hard-coded prs_key to description
          -- if not @nPRSKey = 3 or @dStartDate < '2007-May-01'      -- sPieceRateSupplier = 'SkyRoad' 
          if not rtrim(@sPieceRateSupplier) = 'SkyRoad' or @dStartDate < '2007-May-01'
          begin
              select @nPieceRate = sum(prd.prd_cost)  
                from rd.piece_rate_delivery prd 
                          join rd.piece_rate_type prt 
                               on prd.prt_key=prt.prt_key 
               where prd.contract_no = @inContract 
                 and prt.prs_key     = @nPRSKey 
                 and prd.prd_date between @PRStartDate and @PREndDate
 
              if @nPieceRate is null and @sPieceRateSupplier = 'ParcelPost'
              begin
                  select @nPieceRate         = rd.f_estParcelPostValue(@inContract,@inSequence,@nRenewalGroup,
                                                                @PRStartDate,@PREndDate,@dStartDate,@dEndDate)
                  select @sPieceRateSupplier = 'Estimated ' + @sPieceRateSupplier
              end
              
              select @nRow = @nRow + 1;
          if @nRow = 1 
          begin
              select @nPRSKey1 = @nPRSKey
              select @sPieceRateSupplier1 = @sPieceRateSupplier
              select @nPieceRate1 = @nPieceRate
          end
          if @nRow = 2 
          begin
              select @nPRSKey2 = @nPRSKey
              select @sPieceRateSupplier2 = @sPieceRateSupplier
              select @nPieceRate2 = @nPieceRate
          end
          if @nRow = 3 
          begin
              select @nPRSKey3 = @nPRSKey
              select @sPieceRateSupplier3 = @sPieceRateSupplier
              select @nPieceRate3 = @nPieceRate
          end
          if @nRow = 4 
          begin
              select @nPRSKey4 = @nPRSKey
              select @sPieceRateSupplier4 = @sPieceRateSupplier
              select @nPieceRate4 = @nPieceRate
          end
          if @nRow = 5 
          begin
              select @nPRSKey5 = @nPRSKey
              select @sPieceRateSupplier5 = @sPieceRateSupplier
              select @nPieceRate5 = @nPieceRate
          end

              -- TJB RPCR_054 July-2013
              -- Save all piece rate totals in t_bm_piecerates for
              -- new benchmark report
          insert into rd.t_bm_piecerates
              (contract_no, prs_key, prs_description, ytd_paid)
          values
              (@inContract,@nPRSKey,@sPieceRateSupplier,@nPieceRate)
              
          end
      end
      close cur_getsupplier
  end

  /*-----------------------------------------------------------------------------
   * TJB  Sept-2010  Benchmark Report Printing
   * Add frequencies data to procedure lookup/return
   *-------------------------------------------------------------------------- */

  SELECT @nRowCount = count(*)
    FROM rd.standard_frequency sf
       , rd.route_frequency rf
   WHERE sf.sf_key = rf.sf_key
     AND rf.contract_no = @inContract
     AND rf.rf_active = 'Y'
     AND rf.rf_distance > 0

  if @nRowCount > 0
  begin
      open cur_getfrequencies

      select @nrow = 0
      while 1 = 1 
      begin
          fetch next from cur_getfrequencies 
                into   @sFreqDescr, @sFreqDays, @dFreqDist

           
          if @@fetch_status < 0  break

          select @nRow = @nRow + 1;
          if @nRow = 1 
          begin
             select @sFreqDescr1 = @sFreqDescr
             select @sFreqDays1 = @sFreqDays
             select @dFreqDist1 = @dFreqDist
          end
          if @nRow = 2 
          begin
             select @sFreqDescr2 = @sFreqDescr
             select @sFreqDays2 = @sFreqDays
             select @dFreqDist2 = @dFreqDist
          end
          if @nRow = 3 
          begin
             select @sFreqDescr3 = @sFreqDescr
             select @sFreqDays3 = @sFreqDays
             select @dFreqDist3 = @dFreqDist
          end
          if @nRow = 4 
          begin
             select @sFreqDescr4 = @sFreqDescr
             select @sFreqDays4 = @sFreqDays
             select @dFreqDist4 = @dFreqDist
          end
          if @nRow = 5 
          begin
             select @sFreqDescr5 = @sFreqDescr
             select @sFreqDays5 = @sFreqDays
             select @dFreqDist5 = @dFreqDist
          end
          if @nRow = 6 
          begin
             select @sFreqDescr6 = @sFreqDescr
             select @sFreqDays6 = @sFreqDays
             select @dFreqDist6 = @dFreqDist
          end
          if @nRow = 7 
          begin
             select @sFreqDescr7 = @sFreqDescr
             select @sFreqDays7 = @sFreqDays
             select @dFreqDist7 = @dFreqDist
          end
          if @nRow = 8 
          begin
             select @sFreqDescr8 = @sFreqDescr
             select @sFreqDays8 = @sFreqDays
             select @dFreqDist8 = @dFreqDist
          end
          if @nRow = 9 
          begin
             select @sFreqDescr9 = @sFreqDescr
             select @sFreqDays9 = @sFreqDays
             select @dFreqDist9 = @dFreqDist
          end
          if @nRow = 10 
          begin
             select @sFreqDescr10 = @sFreqDescr
             select @sFreqDays10 = @sFreqDays
             select @dFreqDist10 = @dFreqDist
          end
          if @nRow = 11 
          begin
             select @sFreqDescr11 = @sFreqDescr
             select @sFreqDays11 = @sFreqDays
             select @dFreqDist11 = @dFreqDist
          end
          if @nRow = 12 
          begin
             select @sFreqDescr12 = @sFreqDescr
             select @sFreqDays12 = @sFreqDays
             select @dFreqDist12 = @dFreqDist
          end
      end
      close cur_getfrequencies
  end

  -- TJB  RD7_0047  Sept2009  : added
  -- Calculate Processing Hrs/Wk as used in calculations (Processing cost etc)
  -- This matches what the WhatIf report displays (calculated in C# app).
  set @nProcessingHours = round(((@nVolume/@nItemsHour)/365)*7,2)

  select @inContract             as    inContract 
       , @inSequence             as    inSequence 
       , @sConTitle              as    sConTitle 
       , @sRDFile                as    sRDFile 
       , @sRCMFile               as    sRCMFile 
       , @nNominalVehical        as    nNominalVehical 
       , @nDeliveryWageRate      as    nDeliveryWageRate 
       , @nRepairsMaint          as    nRepairsMaint 
       , @nTyreTubes             as    nTyreTubes 
       , @nVehicalAllow          as    nVehicalAllow 
       , @nVehicalInsure         as    nVehicalInsure 
       , @nPublicLia             as    nPublicLia 
       , @nCarrierRisk           as    nCarrierRisk 
       , @nACCRate               as    nACCRate 
       , @nLicence               as    nLicence 
       , @nRateOfReturn          as    nRateOfReturn 
       , @nSalvageRatio          as    nSalvageRatio 
       , @nItemsHour             as    nItemsHour 
       , @nFuel                  as    nFuel 
       , @nConsumption           as    nConsumption 
       , @nRouteDistance         as    nRouteDistance 
       , @nDeliveryHours         as    nDeliveryHours 
       , @nProcessingHours       as    nProcessingHours 
       , @nVolume                as    nVolume 
       , @nDeliveryDays          as    nDeliveryDays 
       , @nMaxDeliveryDays       as    nMaxDeliveryDays 
       , @nNumberCusts           as    nNumberCusts 
       , @nRouteDistancePerDay   as    nRouteDistancePerDay 
       , @nVehicleDepreciation   as    nVehicleDepreciation 
       , @nFuelCostPerAnnum      as    nFuelCostPerAnnum 
       , @nRepairsPerAnnum       as    nRepairsPerAnnum 
       , @nTyresTubesPerAnnum    as    nTyresTubesPerAnnum 
       , @nDeliveryCost          as    nDeliveryCost 
       , @nProcessingCost        as    nProcessingCost 
       , @nPublicLiabilityCost   as    nPublicLiabilityCost 
       , @nACCPerAnnum           as    nACCPerAnnum 
       , @nVehicleInsurance      as    nVehicleInsurance 
       , @nLicensing             as    nLicensing 
       , @nCarrierRiskRate       as    nCarrierRiskRate 
       , @nBenchmark             as    nBenchmark 
       , @nRateOfReturnCost      as    nRateOfReturnCost 
       , @nFinalBenchmark        as    nFinalBenchmark 
       , @nRetainedAllowances    as    nRetainedAllowances 
       , @nCurrentPayment        as    nCurrentPayment 
       , @sPieceRateSupplier1    as    sPieceRateSupplier1 
       , @nPieceRate1            as    nPieceRate1 
       , @sPieceRateSupplier2    as    sPieceRateSupplier2 
       , @nPieceRate2            as    nPieceRate2 
       , @sPieceRateSupplier3    as    sPieceRateSupplier3 
       , @nPieceRate3            as    nPieceRate3 
       , @sPieceRateSupplier4    as    sPieceRateSupplier4 
       , @nPieceRate4            as    nPieceRate4 
       , @sPieceRateSupplier5    as    sPieceRateSupplier5 
       , @nPieceRate5            as    nPieceRate5 
       , @sRenewalGroup          as    sRenewalGroup 
       , @dRenewalDate           as    dRenewalDate 
       , @nAccounting            as    nAccounting 
       , @nTelephone             as    nTelephone 
       , @nSundries              as    nSundries 
       , @nRuc                   as    nRuc 
       , @nSundriesK             as    nSundriesK 
       , @nLiveryPerAnnum        as    nLiveryPerAnnum 
       , @nUniformPerAnnum       as    nUniformPerAnnum 
       , @nDeliveryDaysForReport as    nDeliveryDaysForReport 
       , @nReliefCost            as    nReliefCost 
       , @dStartDate             as    dStartDate 
       , @dEndDate               as    dEndDate 
       , @PRStartDate            as    PRStartDate 
       , @PREndDate              as    PREndDate 
       , @dExpiryDate            as    dExpiryDate
       , @sFreqDescr1            as    sFreqDescr1
       , @sFreqDays1             as    sFreqDays1
       , @dFreqDist1             as    dFreqDist1
       , @sFreqDescr2            as    sFreqDescr2
       , @sFreqDays2             as    sFreqDays2 
       , @dFreqDist2             as    dFreqDist2 
       , @sFreqDescr3            as    sFreqDescr3
       , @sFreqDays3             as    sFreqDays3 
       , @dFreqDist3             as    dFreqDist3 
       , @sFreqDescr4            as    sFreqDescr4
       , @sFreqDays4             as    sFreqDays4 
       , @dFreqDist4             as    dFreqDist4 
       , @sFreqDescr5            as    sFreqDescr5
       , @sFreqDays5             as    sFreqDays5 
       , @dFreqDist5             as    dFreqDist5 
       , @sFreqDescr6            as    sFreqDescr6
       , @sFreqDays6             as    sFreqDays6 
       , @dFreqDist6             as    dFreqDist6 
       , @sFreqDescr7            as    sFreqDescr7
       , @sFreqDays7             as    sFreqDays7 
       , @dFreqDist7             as    dFreqDist7 
       , @sFreqDescr8            as    sFreqDescr8
       , @sFreqDays8             as    sFreqDays8 
       , @dFreqDist8             as    dFreqDist8 
       , @sFreqDescr9            as    sFreqDescr9
       , @sFreqDays9             as    sFreqDays9 
       , @dFreqDist9             as    dFreqDist9 
       , @sFreqDescr10           as    sFreqDescr10
       , @sFreqDays10            as    sFreqDays10 
       , @dFreqDist10            as    dFreqDist10 
       , @sFreqDescr11           as    sFreqDescr11
       , @sFreqDays11            as    sFreqDays11 
       , @dFreqDist11            as    dFreqDist11 
       , @sFreqDescr12           as    sFreqDescr12
       , @sFreqDays12            as    sFreqDays12 
       , @dFreqDist12            as    dFreqDist12 

END