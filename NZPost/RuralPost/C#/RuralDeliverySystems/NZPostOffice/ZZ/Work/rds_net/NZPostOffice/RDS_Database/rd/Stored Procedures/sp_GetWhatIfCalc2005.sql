
CREATE PROCEDURE [rd].[sp_GetWhatIfCalc2005](
	@inContract int, 
	@inSequence int, 
	@inRGCode int, 
	@inEffectDate datetime, 
	@inVolumeSource varchar(60)
	)
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
  --  declare nWageHourlyRate 		numeric(10,2);              -- TJB SR4661
  declare @nDeliveryWageRate numeric(10,2) -- TJB SR4661
  declare @nProcessingWageRate numeric(10,2) -- TJB SR4661
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
  declare @nNumRows integer
  declare @nRouteDistance numeric(10,2)
  declare @nDeliveryHours numeric(10,2)
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
  declare @nReliefCost real    -- Added:  TJB SR4661
  declare @nReliefWeeks real   -- Added:  TJB SR4703
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
  declare @nSundriesKTot numeric(8,2)
  declare @nMultiplier integer
  declare @vrr_nominal_vehical_value numeric(10,2)
  --  declare vrr_wage_hourly_rate 		numeric(10,2);          -- TJB SR4661
  declare @vrr_del_wage_rate numeric(10,2) -- TJB SR4661
  declare @vrr_proc_wage_rate numeric(10,2) -- TJB SR4661
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
  declare @nVtKey integer

  declare @nActivityRatio real    -- TJB RPCR_133 July-2019: Added (for convenience)

  -- Volumes at renewal
  select @nVolume2=contract_renewals.con_volume_at_renewal 
    from contract_renewals where
    contract_renewals.contract_no = @inContract and
    contract_renewals.contract_seq_number = @inSequence
    
  -- Count letters according to source
  -- TJB  SR4684 bug fix  Aug 2006
  -- Removed large_parcels from volume calculations
  --  select (artical_count.ac_w1_medium_letters
  --          + artical_count.ac_w1_other_envelopes
  --          + artical_count.ac_w1_small_parcels
  --          + artical_count.ac_w1_large_parcels
  --          + artical_count.ac_w2_medium_letters
  --          + artical_count.ac_w2_other_envelopes
  --          + artical_count.ac_w2_small_parcels
  --          + artical_count.ac_w2_large_parcels
  --         )*artical_count.ac_scale_factor
  select @nVolume1avg=(artical_count.ac_w1_medium_letters
                       + artical_count.ac_w1_other_envelopes
                       + artical_count.ac_w1_small_parcels
                       + artical_count.ac_w2_medium_letters
                       + artical_count.ac_w2_other_envelopes
                       + artical_count.ac_w2_small_parcels
                       )* artical_count.ac_scale_factor 
    from artical_count 
   where artical_count.ac_start_week_period
                   = (select max(artical_count.ac_start_week_period) 
                        from artical_count 
                       where artical_count.contract_no = @inContract) and
                             artical_count.contract_no = @inContract and
                             (@inVolumeSource = 'last_article_count' 
                               or @inVolumeSource = 'average_article_count') and
                             artical_count.ac_scale_factor is not null

  --Count article counts according to source - ok!
  -- TJB  SR4684 bug fix  Aug 2006
  -- Removed large_parcels from volume calculations
  --  select (artical_count.ac_w1_medium_letters
  --          + artical_count.ac_w1_other_envelopes
  --          + artical_count.ac_w1_small_parcels
  --          + artical_count.ac_w1_large_parcels
  --          + artical_count.ac_w2_medium_letters
  --          + artical_count.ac_w2_other_envelopes
  --          + artical_count.ac_w2_small_parcels
  --          + artical_count.ac_w2_large_parcels
  --         )*artical_count.ac_scale_factor
  select @nVolume2avg=(artical_count.ac_w1_medium_letters
                       + artical_count.ac_w1_other_envelopes
                       + artical_count.ac_w1_small_parcels
                       + artical_count.ac_w2_medium_letters
                       + artical_count.ac_w2_other_envelopes
                       + artical_count.ac_w2_small_parcels
                       ) * artical_count.ac_scale_factor 
    from artical_count 
   where artical_count.ac_start_week_period 
                = (select max(artical_count.ac_start_week_period) 
                     from artical_count 
                    where artical_count.contract_no = @inContract and
                          artical_count.ac_start_week_period <> 
                                  (select max(artical_count.ac_start_week_period) 
                                     from artical_count 
                                    where artical_count.contract_no = @inContract)) and
         artical_count.contract_no = @inContract and
         (@inVolumeSource = 'last_but_one_article_count' 
           or @inVolumeSource = 'average_article_count') and
         artical_count.ac_scale_factor is not null
         
  select @nVolume2= @nVolume2avg  
   where @inVolumeSource = 'last_but_one_article_count' and
         @nVolume2avg is not null
         
  select @nVolume2=@nVolume1avg  
   where @inVolumeSource = 'last_article_count' and
         @nVolume1avg is not null
         
  select @nVolume2=(@nVolume1avg+@nVolume2avg)/2  
   where @inVolumeSource = 'average_article_count' and
         @nVolume2avg > 0 and
         @nVolume1avg is not null
         
  select @nVolume2=@nVolume1avg  
   where @inVolumeSource = 'average_article_count' and
         (@nVolume2avg = 0 or @nVolume2avg is null)
         
  --Get rates and their overrides  
  select top 1
    @nNominalVehical=isNull(vor.vor_nominal_vehicle_value,vr.vr_nominal_vehicle_value),
    @nRemainingEconomicLife=v.v_remaining_economic_life,
    -- isNull(nvor.nvor_wage_hourly_rate,nvr.nvr_wage_hourly_rate) as wage_rate,                -- TJB SR4661
    @nDeliveryWageRate=isNull(nvor.nvor_delivery_wage_rate,nvr.nvr_delivery_wage_rate),       -- TJB SR4661
    @nProcessingWageRate=isNull(nvor.nvor_processing_wage_rate,nvr.nvr_processing_wage_rate), -- TJB SR4661
    @nReliefWeeks = isNull(nvor.nvor_relief_weeks,nvr.nvr_relief_weeks),                      -- TJB RPCR_041
    @nRepairsMaint=isNull(vor.vor_repairs_maintenance_rate,vr.vr_repairs_maintenance_rate),
    @nTyreTubes=isNull(vor.vor_tyre_tubes_rate,vr.vr_tyre_tubes_rate),
    @nVehicalAllow=isNull(vor.vor_vehical_allowance_rate,vr.vr_vehicle_allowance_rate),
    -- TJB SR4635
    -- f_GetInsurance(inContract,inSequence,inEffectDate) as insurance, //ins $
    @nVehicalInsure=rd.f_GetInsurance_whatif(@inContract,@inSequence,@inEffectDate), --ins $
    @nPublicLia=isNull(nvor.nvor_public_liability_rate_2,nvr.nvr_public_liability_rate),
    @nCarrierRisk=isNull(nvor.nvor_carrier_risk_rate,nvr.nvr_carrier_risk_rate),
    @nACCRate=isNull(nvor.nvor_acc_rate,nvr.nvr_acc_rate),
    @nACCAmount=isNull(nvor.nvor_acc_rate_amount,nvr.nvr_acc_rate_amount),
    @nLicence=isNull(vor.vor_licence_rate,vr.vr_licence_rate),
    @nRateOfReturn=isNull(vor.vor_vehicle_rate_of_return_pct,vr.vr_vehicle_rate_of_return_pct),
    @nSalvageRatio=isNull(vor.vor_salvage_ratio,vr.vr_salvage_ratio),
    @nItemsHour=isNull(nvor.nvor_item_proc_rate_per_hour,nvr.nvr_item_proc_rate_per_hr),
    -- TJB SR4635
    -- isNull(vor.vor_fuel_rate,f_GetFuelRates(inContract,inSequence,inEffectDate)) as fuel,
    @nFuel=isNull(vor.vor_fuel_rate,rd.f_GetFuelRates_whatif(@inContract,@inSequence,@inEffectDate)),
    -- TJB SR4635
    -- isNull(vor_consumption_rate,f_GetConsumptionRates(inContract,inSequence,inEffectDate)) as consumption,
    @nConsumption=isNull(vor_consumption_rate,rd.f_GetConsumptionRates_whatif(@inContract,@inSequence,@inEffectDate)),
    @nAccounting=isNull(nvor.nvor_accounting,nvr.nvr_accounting),
    @nTelephone=isNull(nvor.nvor_telephone,nvr.nvr_telephone),
    @nSundries=isNull(nvor.nvor_sundries,nvr.nvr_sundries),
    @nRucrate=isNull(vor.vor_ruc,vr.vr_ruc),
    @nSundriesK=isNull(vor.vor_sundries_k,vr.vr_sundries_k),
    @nInsurancePct=isNull(vr.vr_vehicle_value_insurance_pct,0),
    @nLivery=isNull(vor.vor_livery,vr.vr_livery),
    @nUniform=isNull(nvor_uniform,nvr_uniform),
    @nVtKey=v.vt_key 
  from
    contract_renewals as cr 
        left outer join non_vehicle_override_rate as nvor 
             on cr.contract_no = nvor.contract_no and 
                cr.contract_seq_number = nvor.contract_seq_number
        left outer join vehicle_override_rate as vor 
             on cr.contract_no = vor.contract_no and 
             cr.contract_seq_number = vor.contract_seq_number, 
    contract_vehical as cv,
    vehicle as v,
    contract as c,
    non_vehicle_rate as nvr,
    vehicle_type as vt 
        left outer join vehicle_rate as vr 
             on vt.vt_key = vr.vt_key
where
    cv.contract_no = cr.contract_no and
    cv.contract_seq_number = cr.contract_seq_number and
    v.vehicle_number = cv.vehicle_number and
    vt.vt_key = v.vt_key and
    c.contract_no = cr.contract_no and
    v.vehicle_number = rd.f_GetLatestVehicle(@inContract,@inSequence) and
    --and c.rg_code=nvr.rg_code
    -- TJB SR4635
    -- nvr.rg_code = inRGCode and
    cr.contract_no = @inContract and
    cr.contract_seq_number = @inSequence and
    nvr.nvr_rates_effective_date = @inEffectDate and
    vr.vr_rates_effective_date = @inEffectDate and
    (nvor.nvor_effective_date is null or                         -- TJB RPCR_099 Jan-2016: Added
        nvor.nvor_effective_date = vor.vor_effective_date)       --
  order by
    vor.vor_effective_date desc

  select @nNominalVehical=isnull(@nNominalVehical,0)
  select @nRemainingEconomicLife=isnull(@nRemainingEconomicLife,0)
  select @nDeliveryWageRate=isnull(@nDeliveryWageRate,0)
  select @nProcessingWageRate=isnull(@nProcessingWageRate,0)
  select @nRepairsMaint=isnull(@nRepairsMaint,0)
  select @nTyreTubes=isnull(@nTyreTubes,0)
  select @nVehicalAllow=isnull(@nVehicalAllow,0)
  select @nVehicalInsure=isnull(@nVehicalInsure,0)
  select @nPublicLia=isnull(@nPublicLia,0)
  select @nCarrierRisk=isnull(@nCarrierRisk,0)
  select @nACCRate=isnull(@nACCRate,0)
  select @nACCAmount=isnull(@nACCAmount,0)
  select @nLicence=isnull(@nLicence,0)
  select @nRateOfReturn=isnull(@nRateOfReturn,0)
  select @nSalvageRatio=isnull(@nSalvageRatio,0)
  select @nItemsHour=isnull(@nItemsHour,0)
  select @nFuel=isnull(@nFuel,0)
  select @nConsumption=isnull(@nConsumption,0)
  select @nAccounting=isnull(@nAccounting,0)
  select @nTelephone=isnull(@nTelephone,0)
  select @nSundries=isnull(@nSundries,0)
  select @nRucrate=isnull(@nRucrate,0)
  select @nSundriesK=isnull(@nSundriesK,0)
  select @nInsurancePct=isnull(@nInsurancePct,0)
  select @nLivery=isnull(@nLivery,0)
  select @nUniform=isnull(@nUniform,0)

  -- Select contract renewal start date
  select @dStartDate=con_start_date 
    from contract_renewals 
   where contract_renewals.contract_no = @inContract and
         contract_renewals.contract_seq_number = @inSequence

  --Get end date
  select @dEndDate=con_start_date 
    from contract_renewals 
   where contract_renewals.contract_no = @inContract and
         contract_renewals.contract_seq_number = @inSequence+1

      -- Added TJB  SR4703  Sep-2007
      -- Removed  TJB  RPCR_041  Nov-2012
      -- if @inEffectDate >= '2007 Oct 31'
      --   set @nReliefWeeks = 5
      -- else
      --   set @nReliefWeeks = 4

  --Get other FD rates depending on source
  if @inVolumeSource = 'last_but_one_article_count' 
  or @inVolumeSource = 'last_article_count' 
  or @inVolumeSource = 'average_article_count'
    select @nNumRows=count(*),
           -- TJB SR4635 - GecContractDelDays changed to ignore inRGCode
           -- GetContractDelDays(contract_renewals.contract_no,contract_renewals.contract_seq_number,inRGcode,inEffectDate),
           @nDeliveryDays=rd.GetContractDelDays_whatif(contract_renewals.contract_no,@inRGcode,@inEffectDate),
           -- contract_renewals.con_distance_at_renewal+sum(ifnull(frequency_distances.fd_distance,0,frequency_distances.fd_distance)*rate_days.rtd_days_per_annum),
           @nRouteDistance=rd.getcontractdistance(@inContract,@inSequence),
           @nDeliveryHours=contract_renewals.con_del_hrs_week_at_renewal
                           + sum(isnull(frequency_distances.fd_delivery_hrs_per_week,0)),
           @nProcessingHours=contract_renewals.con_processing_hours_per_week
                           + sum(isnull(frequency_distances.fd_processing_hrs_week,0)),
           @nVolume=@nVolume2,
           @iNumberCusts=isnull(contract_renewals.con_no_customers_at_renewal,0)
                           + isnull(contract_renewals.con_no_cmb_custs_at_renewal,0)
                           + sum(isnull(frequency_distances.fd_no_of_boxes,0))
                           + sum(isnull(frequency_distances.fd_no_cmb_customers,0)) 
       -- TJB  RD7_0049  Sept2009
       -- Changed to match Sybase version
       -- from
       --     contract_renewals 
       --         INNER JOIN route_frequency 
       --             on contract_renewals.contract_no = route_frequency.contract_no
       --         INNER JOIN frequency_distances 
       --             on route_frequency.contract_no = frequency_distances.contract_no and
       --                route_frequency.sf_key = frequency_distances.sf_key and
       --                route_frequency.rf_delivery_days = frequency_distances.rf_delivery_days and
       --                frequency_distances.fd_effective_date >= @dStartDate and
       --                @dStartDate is not null and
       --                (@dEndDate is null or @dEndDate >= frequency_distances.fd_effective_date)
       --         INNER JOIN rate_days 
       --             ON route_frequency.sf_key = rate_days.sf_key
       from
           contract_renewals,
           route_frequency 
               left outer join frequency_distances 
                   on route_frequency.contract_no = frequency_distances.contract_no and
                      route_frequency.sf_key = frequency_distances.sf_key and
                      route_frequency.rf_delivery_days = frequency_distances.rf_delivery_days and
                      frequency_distances.fd_effective_date >= @dStartDate and
                      @dStartDate is not null and
                      (@dEndDate is null or @dEndDate >= frequency_distances.fd_effective_date),
           rate_days 
     where
           contract_renewals.contract_no = route_frequency.contract_no and
           route_frequency.sf_key = rate_days.sf_key and
           rate_days.rr_rates_effective_date = @inEffectDate and
           -- TJB SR4635
           -- (rate_days.rg_code = inRgCode and
           contract_renewals.contract_no = @inContract and
           contract_renewals.contract_seq_number = @inSequence
     group by 
           contract_renewals.contract_no,
           contract_renewals.contract_seq_number,
           contract_renewals.con_rg_code_at_renewal,
           contract_renewals.con_rates_effective_date,
           contract_renewals.con_distance_at_renewal,
           contract_renewals.con_del_hrs_week_at_renewal,
           contract_renewals.con_processing_hours_per_week,
           contract_renewals.con_volume_at_renewal,
           contract_renewals.con_no_customers_at_renewal,
           contract_renewals.con_no_cmb_custs_at_renewal
  else
    select @nNumRows=count(*),
           -- TJB SR4635
           -- GetContractDelDays(contract_renewals.contract_no,contract_renewals.contract_seq_number,inRGcode,inEffectDate),
           @nDeliveryDays=rd.GetContractDelDays_whatif(contract_renewals.contract_no,@inRGcode,@inEffectDate),
           @nRouteDistance=contract_renewals.con_distance_at_renewal
                           + sum(isnull(frequency_distances.fd_distance,0)* rate_days.rtd_days_per_annum),
           @nDeliveryHours=contract_renewals.con_del_hrs_week_at_renewal
                           + sum(isnull(frequency_distances.fd_delivery_hrs_per_week,0)),
           @nProcessingHours=contract_renewals.con_processing_hours_per_week
                           + sum(isnull(frequency_distances.fd_processing_hrs_week,0)),
           @nVolume=@nVolume2+sum(isnull(frequency_distances.fd_volume,0)),
           @iNumberCusts=isnull(contract_renewals.con_no_customers_at_renewal,0)
                           + isnull(contract_renewals.con_no_cmb_custs_at_renewal,0)
                           + sum(isnull(frequency_distances.fd_no_of_boxes,0))
                           + sum(isnull(frequency_distances.fd_no_cmb_customers,0)) 
      from
           contract_renewals,
           route_frequency 
               left outer join frequency_distances 
                   on route_frequency.contract_no = frequency_distances.contract_no and
                      route_frequency.sf_key = frequency_distances.sf_key and
                      route_frequency.rf_delivery_days = frequency_distances.rf_delivery_days and
                      frequency_distances.fd_effective_date >= @dStartDate and
                      @dStartDate is not null and
                      (@dEndDate is null 
                          or @dEndDate >= frequency_distances.fd_effective_date),
           rate_days 
     where
           (contract_renewals.contract_no = route_frequency.contract_no) and
           (route_frequency.sf_key = rate_days.sf_key) and
           (rate_days.rr_rates_effective_date = @inEffectDate) and
           -- TJB SR4635
           -- (rate_days.rg_code = inRgCode) and
           (contract_renewals.contract_no = @inContract) and
           (contract_renewals.contract_seq_number = @inSequence)
     group by 
           contract_renewals.contract_no,
           contract_renewals.contract_seq_number,
           contract_renewals.con_rg_code_at_renewal,
           contract_renewals.con_rates_effective_date,
           contract_renewals.con_distance_at_renewal,
           contract_renewals.con_del_hrs_week_at_renewal,
           contract_renewals.con_processing_hours_per_week,
           contract_renewals.con_volume_at_renewal,
           contract_renewals.con_no_customers_at_renewal,
           contract_renewals.con_no_cmb_custs_at_renewal

  select @nNumRows=isnull(@nNumRows,0)
  select @nDeliveryDays=isnull(@nDeliveryDays,0)
  select @nRouteDistance=isnull(@nRouteDistance,0)
  select @nDeliveryHours=isnull(@nDeliveryHours,0)
  select @nProcessingHours=isnull(@nProcessingHours,0)
  select @nVolume=isnull(@nVolume,0)
  select @iNumberCusts=isnull(@iNumberCusts,0)

  --get contract adjustments
  select @nCurrentPayment=(contract_renewals.con_renewal_payment_value),
         @nExtensions=(select sum(contract_adjustments.ca_amount) 
                         from contract_adjustments 
                        where contract_renewals.contract_no = contract_adjustments.contract_no and
                              contract_renewals.contract_seq_number = contract_adjustments.contract_seq_number and
                              contract_adjustments.ca_date_paid is not null)
    from contract_renewals 
   where contract_no = @inContract and
         contract_seq_number = @inSequence

  --Get frequency adjsutments  
  select @nSumAdjustments=sum(fd_amount_to_pay) 
    from frequency_adjustments 
   where contract_no = @inContract and
         contract_seq_number = @inSequence and
         fd_paid_to_date is not null

  select @nCurrentPayment=isnull(@nCurrentPayment,0)
  select @nExtensions=isnull(@nExtensions,0)
  select @nSumAdjustments=isnull(@nSumAdjustments,0)

  --Calculate current payment    
  --  set nCurrentPayment=nCurrentPayment+ifnull(nSumAdjustments,0,nSumAdjustments);
  select @nCurrentPayment=@nCurrentPayment+@nSumAdjustments
  --Get max delivery days

  select @nMaxDeliveryDays=max(rate_days.rtd_days_per_annum) 
    from rate_days 
   where rate_days.rr_rates_effective_date = @inEffectDate

  -- TJB SR4635
  -- and rate_days.rg_code = inRgCode;
  --If max days per week>4, assume deldays = maxdeldays
  select @nMaxdays=sum(standard_frequency.sf_days_week) 
    from rate_days,
         standard_frequency,
         route_frequency 
   where standard_frequency.sf_key = rate_days.sf_key and
         route_frequency.sf_key = standard_frequency.sf_key and
         -- TJB SR4635
         -- rate_days.rg_code = inRgCode and
         rate_days.rr_rates_effective_date = @inEffectDate and
         route_frequency.contract_no = @inContract and
         route_frequency.rf_active = 'Y'

  select @nMaxDeliveryDays=isnull(@nMaxDeliveryDays,0)
  select @nMaxDays=isnull(@nMaxDays,0)
  if @nMaxdays > 4
      select @nDeliveryDays=@nMaxDeliveryDays

  --Calculate certain ratios
  if(@nDeliveryDays <> 0)
  BEGIN
      select @nRouteDistancePerDay=@nRouteDistance/@nDeliveryDays
  END

  --Depreciation
  -- PBY 26/06/2002 SR#4415 Added nRouteDistance/1000 to VehicleDepreciation
  -- calcuation if REL > 0  
  --  if @nRemainingEconomicLife > 0
  --    select VehicleDepreciation
  --      =(@nRouteDistance/1000)*
  --      ((1-(isNull(@nSalvageRatio,0)/100))*isNull(@nNominalVehical,0)*1000)/
  --      @nRemainingEconomicLife
  if @nRemainingEconomicLife <= 0 --else
      select @nVehicleDepreciation=@nRouteDistance*(@nVehicalAllow/1000)

  select @nFuelCostPerAnnum=(@nConsumption/100)*@nRouteDistance*(@nFuel/100)
  select @nRepairsPerAnnum=@nRepairsMaint*(@nRouteDistance/1000)
  select @nTyresTubesPerAnnum=@nTyreTubes*(@nRouteDistance/1000)
  -- select nSundriesK*(nRouteDistance/1000) into nSundriesKTot;
  select @nSundriesKTot=@nSundriesK*(@nRouteDistance/1000)

  -- TJB SR4661: Changed nWageHourlyRate to nDeliveryWageRate and nProcessingWageRate
  select @nDeliveryCost=((round(@nDeliveryHours,2))*52)*@nDeliveryWageRate
  if(@nItemsHour<>0)
  BEGIN
      select @nProcessingCost=((((@nVolume/@nItemsHour)/365)*7)*52)*@nProcessingWageRate
      select @nReliefCost=((round(@nDeliveryHours,2))*@nReliefWeeks)*@nDeliveryWageRate  -- Added: TJB  SR4661
                             + ((((@nVolume/@nItemsHour)/365)*7)*@nReliefWeeks)*@nProcessingWageRate
  END

  -- TJB RPCR_133 July-2019: Added Activity Ratio
  -- Changed effect to 100% by commenting out the calculations below
  --select @nActivityRatio = @nDeliveryDays/@nMaxDeliveryDays
  IF(@nMaxDeliveryDays<>0)
  BEGIN
      --select @nPublicLiabilityCost=@nPublicLia*(@nActivityRatio)
      select @nPublicLiabilityCost=@nPublicLia
  END

  select @nACCPerAnnum=(@nAccRate/100)*(@nDeliveryCost+@nProcessingCost+@nReliefCost)
                       + @nACCAmount    -- TJB SR4661: bug fix: accAmount wasn''t included

  --Benchmark 2001
  IF(@nMaxDeliveryDays<>0)
  BEGIN
      select @nVehicleInsurance=@nVehicalInsure
      --                              * (@nActivityRatio)
      select @nLicensing=@nLicence
      --                     * (@nActivityRatio)
      select @nCarrierRiskRate=@nCarrierRisk
      --                              * (@nActivityRatio)
      select @nRateofReturnCost=rd.GetRateReturn(@nNominalVehical,@nRateOfReturn,@nSalvageRatio)
      --                              * (@nActivityRatio)
  END

  select @nLiveryPerAnnum=@nLivery            -- *(@nRouteDistance/1000)
      --                     * (@nActivityRatio)
  select @nUniformPerAnnum=@nUniform           -- *(@nRouteDistance/1000)
      --                     * (@nActivityRatio)
  --Find out if the vehicle is diesel
  select @nTempint=count(contractor_renewals.contract_no) 
    from rd.contractor_renewals,
         rd.contract_vehical,
         rd.vehicle,
         rd.fuel_type 
   where (contractor_renewals.contract_no = @inContract) and
         (contractor_renewals.contract_seq_number = @inSequence) and
         (contractor_renewals.contract_no = contract_vehical.contract_no) and
         (contractor_renewals.contract_seq_number = contract_vehical.contract_seq_number) and
         (contract_vehical.vehicle_number = vehicle.vehicle_number) and
         (vehicle.ft_key = fuel_type.ft_key) and
         (fuel_type.ft_description like 'diesel%') and
         (vehicle.vehicle_number = rd.f_GetLatestVehicle(@inContract,@inSequence))
  if @ntempint = 0
  begin
      select @nRUC=0.0
      select @nMultiplier=0
  end
  else
  begin
      select @nMultiplier=1
      select @nRUC=@nRUCRate*(@nRouteDistance/1000)
  end

  --Calculate the benchmark
  select @nVehicleDepreciation=isnull(@nVehicleDepreciation,0)
  select @nFuelCostPerAnnum=isnull(@nFuelCostPerAnnum,0)
  select @nRepairsPerAnnum=isnull(@nRepairsPerAnnum,0)
  select @nTyresTubesPerAnnum=isnull(@nTyresTubesPerAnnum,0)
  select @nDeliveryCost=isnull(@nDeliveryCost,0)
  select @nProcessingCost=isnull(@nProcessingCost,0)
  select @nReliefCost=isnull(@nReliefCost,0)
  select @nPublicLiabilityCost=isnull(@nPublicLiabilityCost,0)
  select @nACCPerAnnum=isnull(@nACCPerAnnum,0)
  select @nVehicleInsurance=isnull(@nVehicleInsurance,0)
  select @nLicensing=isnull(@nLicensing,0)
  select @nCarrierRiskRate=isnull(@nCarrierRiskRate,0)
  select @nAccounting=isnull(@nAccounting,0)
  select @nTelephone=isnull(@nTelephone,0)
  select @nSundries=isnull(@nSundries,0)
  select @nRUC=isnull(@nRUC,0)
  select @nSundriesKTot=isnull(@nSundriesKTot,0)
  select @nLiveryPerAnnum=isnull(@nLiveryPerAnnum,0)
  select @nRateOfReturnCost=isnull(@nRateOfReturnCost,0)
  select @nBenchmark
         = @nVehicleDepreciation+
           @nFuelCostPerAnnum+
           @nRepairsPerAnnum+
           @nTyresTubesPerAnnum+
           @nDeliveryCost+
           @nProcessingCost+
           @nReliefCost+ -- Added: TJB  SR4661
           @nPublicLiabilityCost+
           @nACCPerAnnum+
           @nVehicleInsurance+
           @nLicensing+
           @nCarrierRiskRate+
           @nAccounting+
           @nTelephone+
           @nSundries+
           @nRUC+
           @nSundriesKTot+
           @nLiveryPerAnnum+
           @nUniformPerAnnum

  --Final; BM
  --  set nFinalBenchmark = nBenchmark + nRateOfReturnCost;
  select @nFinalBenchmark=Round(@nBenchmark+@nRateOfReturnCost,1)

  --Get contract title
  select @sConTitle=con_title,
         @sRDFile=con_rd_paper_file_text,
         @sRCMFile=con_rcm_paper_file_text 
    from contract 
   where contract_no = @inContract

  --get standard rates 
  select @vrr_nominal_vehical_value=vehicle_rate.vr_nominal_vehicle_value,
         -- non_vehicle_rate.nvr_wage_hourly_rate,       -- TJB SR4661
         @vrr_del_wage_rate=non_vehicle_rate.nvr_delivery_wage_rate, -- TJB SR4661
         @vrr_proc_wage_rate=non_vehicle_rate.nvr_processing_wage_rate, -- TJB SR4661
         @vrr_repairs_maintenance_rate=vehicle_rate.vr_repairs_maintenance_rate,
         @vrr_tyre_tubes_rate=vehicle_rate.vr_tyre_tubes_rate,
         @vrr_vehical_allowance_rate=vehicle_rate.vr_vehicle_allowance_rate,
         @vrr_vehical_insurance_premium=non_vehicle_rate.nvr_vehicle_insurance_base_premium,
         -- vehicle_rate.vr_vehicle_value_insurance_pct,   
         @vrr_public_liability_rate=non_vehicle_rate.nvr_public_liability_rate,
         @vrr_carrier_risk_rate=non_vehicle_rate.nvr_carrier_risk_rate,
         @vrr_acc_rate=non_vehicle_rate.nvr_acc_rate,
         @vrr_licence_rate=vehicle_rate.vr_licence_rate,
         @vrr_vehical_rate_of_return_pct=vehicle_rate.vr_vehicle_rate_of_return_pct,
         @vrr_salvage_ratio=vehicle_rate.vr_salvage_ratio,
         @vrr_item_proc_rate_per_hr=non_vehicle_rate.nvr_item_proc_rate_per_hr,
         @vrr_ruc=vehicle_rate.vr_ruc,
         @vrr_accounting=non_vehicle_rate.nvr_accounting,
         @vrr_telephone=non_vehicle_rate.nvr_telephone,
         @vrr_sundries=non_vehicle_rate.nvr_sundries,
         @vrr_sundriesK=vehicle_rate.vr_sundries_k 
    from [contract],
         non_vehicle_rate,
         --vehicle_type,
         --vehicle_rate,
         contract_renewals,
         contract_vehical,
         vehicle,
         vehicle_type 
             left outer join vehicle_rate 
                  on vehicle_type.vt_key = vehicle_rate.vt_key 
   where
         -- TJB SR4635
         -- contract.rg_code *= non_vehicle_rate.rg_code and
         contract_renewals.contract_no = contract.contract_no and
         contract_vehical.contract_no = contract_renewals.contract_no and
         contract_vehical.contract_seq_number = contract_renewals.contract_seq_number and
         vehicle.vehicle_number = contract_vehical.vehicle_number and
         vehicle_type.vt_key = vehicle.vt_key and
         non_vehicle_rate.nvr_rates_effective_date = @inEffectDate and
         contract_renewals.contract_no = @inContract and
         contract_renewals.contract_seq_number = @inSequence and
         vehicle.vehicle_number = rd.f_GetLatestVehicle(@inContract,@inSequence) and
         vehicle_rate.vr_rates_effective_date = @inEffectDate

  --return the values  
  --insert into t_benchmark(renewalgroup,nominalvehiclevalue) values('what-if',nRepairsPerAnnum);
  select @inContract  as inContract,
         @inSequence       as inSequence,
         @sConTitle        as sConTitle,
         @nNominalVehical,
         -- nWageHourlyRate,                -- TJB SR4661
         @nDeliveryWageRate,                -- TJB SR4661
         @nRepairsMaint,
         @nTyreTubes,
         @nVehicalAllow,
         @nVehicalInsure,
         @nPublicLia,
         @nCarrierRisk,
         @nACCRate,
         @nLicence,
         @nRateOfReturn,
         @nSalvageRatio,
         @nItemsHour       as ItemsHour,
         @nFuel,
         @nConsumption,
         @nRouteDistance,
         @nDeliveryHours   as DeliveryHours,
         @nProcessingHours as ProcessingHours,
         @nVolume          as Volume,
         @nDeliveryDays    as DeliveryDays,
         @nMaxDeliveryDays as MaxDeliveryDays,
         @iNumberCusts     as NumberCusts,
         @nRouteDistancePerDay,
         @nVehicleDepreciation,
         @nFuelCostPerAnnum,
         @nRepairsPerAnnum,
         @nTyresTubesPerAnnum,
         @nDeliveryCost,
         @nProcessingCost,
         @nPublicLiabilityCost,
         @nACCPerAnnum,
         @nVehicleInsurance,
         @nLicensing,
         @nCarrierRiskRate,
         @nBenchmark,
         @nRateOfReturnCost,
         @nFinalBenchmark,
         @nRetainedAllowances,
         @nCurrentPayment,
         @nSFKey,
         @nRFDistance      as RFDistance,
         @cDeliveryDays    as DeliveryDays,
         nDaysYear=0,
         nDaysWeek=0,
         itemspercust=0,
         'Y'               as rf_active,
         '',
         0.0,
         @nAccounting,
         @nTelephone,
         @nSundries,
         @nRUCRate,
         @vrr_nominal_vehical_value,
         -- vrr_wage_hourly_rate,           -- TJB SR4661
         @vrr_del_wage_rate,                -- TJB SR4661
         @vrr_repairs_maintenance_rate,
         @vrr_tyre_tubes_rate,
         @vrr_vehical_allowance_rate,
         @vrr_vehical_insurance_premium,
         @vrr_public_liability_rate,
         @vrr_carrier_risk_rate,
         @vrr_acc_rate,
         @vrr_licence_rate,
         @vrr_vehical_rate_of_return_pct,
         @vrr_salvage_ratio,
         @vrr_item_proc_rate_per_hr,
         @vrr_ruc,
         @vrr_accounting,
         @vrr_telephone,
         @vrr_sundries,
         @vrr_sundriesK,
         @nSundriesK,
         @nMultiplier,
         @nInsurancePct,
         @nLivery,
         @nUniform,
         @nACCAmount,
         @nVtKey,
         @nReliefCost,                      -- Added TJB SR4596
         @nProcessingWageRate,              -- TJB SR4661
         @vrr_proc_wage_rate,
         @nReliefWeeks                      -- TJB SR4703

END