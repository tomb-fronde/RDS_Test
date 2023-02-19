
CREATE PROCEDURE [rd].[sp_GetBenchmarkRpt2020](
	@inContract int,
	@inSequence int)
	
-- TJB  RPCR_147 Bugfix July-2020
-- Released version was based on July-2019 version of 
-- sp_GetBenchmarkRpt2013.  Folded in RPCR_147 Bugfix 
-- Sept-2019 changes.
--
-- TJB  RPCR_147 May-2020
-- Derived from [rd].[sp_GetBenchmarkRpt2013]
-- Added route frequencies 6-12
--
-- TJB RPCR_133 Fix Sep-2019 (comment added July-2020)
-- Some commented-out variables (to remove activity 
-- scaling) needed for returned results
--
-- TJB  RPCR_133 July-2019
-- Changed 'activity ratio' from (DeliveryDays/MaxDeliveryDays) to
-- 100% (ie removed scaling) from most fixed costs except ACC.
--
-- TJB  RPCR_101 Feb 2016
-- Changed Livery and Wardrobe calculations to p/a (were /1000Km)
--
-- TJB  RPCR_099  Jan-2016
-- Add WHERE condition to 'get rates' query (see nvor_effective_date)
--
-- TJB  Release 7.1.10 Fixups  Aug-2013
-- Accumulate BM data in t_bm_piecerates table
--
-- TJB  RPCR_054 Jul-2013
-- To accomodate new piecerate suppliers, changed to save piecerate values in 
-- t_bm_piecerates table (as well as returning first 5 in returned values - may
-- remove this later)
-- Renamed sp_GetBenchmarkRpt2010 to sp_GetBenchmarkRpt2013
--
-- TJB  RPCR_041  Nov-2012
-- Use nvr_relief_weeks from non_vehicle_rate table rather than 
-- a hard-coded value
--
-- TJB  RPI_029  June-2011
-- Merged RPCR_017 and RPCR_021 changes
--
-- TJB RPCR_021  Oct-2010
-- Change to use the supplier name from database table rather than
-- the hard-coded override for Kiwimail.
--
-- TJB  RPCR_017 July-2010
-- Add condition on allowance: include only if approved
--
-- TJB  RD7_0047 Sept 2009
-- Fix nProcessingWageRate determination
-- Uncommented-out use of @inSequence in join
-- Now matches BenchmarkCalc2005
-- Calculate Processing Hrs/Wk as used in calculations (Processing cost etc)
--     this matches what WhatIf displays (calculated in C# app).
--
-- TJB  SR4684  Fixups  July 2006
-- Change call to f_estParcelPostValue
--    nWageHourlyRate    numeric(10,2),        -- TJB SR4661
--
-- TJB  SR4684  June 2006
-- Added estimation of Parcel Post value if no actual deliveries had been made
-- (see calls to f_estParcelPostValue)
--
-- TJB  SR4661  May 2005 - Significant changes
-- Changed delivery and processing cose calculations
-- Added relief cost calculation and associated changes
-- Added relief cost to returned results
-- Split nWageHourlyRate into nDeliveryWageRate and nProcessingWageRate
--
-- PBY Modified 28-Mar-2002
-- Original:
--    f_GetFuelRates(cr.contract_no,cr.contract_seq_number,cr.con_rates_effective_date)) as fuel,
--    f_GetConsumptionRates(c.contract_no,cr.contract_seq_number,cr.con_rates_effective_date) as consumption,
-- Modified to:
--     isNull(vor.vor_fuel_rate,f_GetFuelRates(cr.contract_no,cr.contract_seq_number,cr.con_rates_effective_date)) as fuel,
--     isNull(vor.vor_consumption_rate,f_GetConsumptionRates(c.contract_no,cr.contract_seq_number,cr.con_rates_effective_date)) as consumption,
AS
BEGIN
  set NOCOUNT ON
  set CONCAT_NULL_YIELDS_NULL off
  
  declare cur_getsupplier cursor for 
	SELECT prs_key,prs_description 
	  FROM piece_rate_supplier
                  
  declare cur_getfrequencies cursor for 
	SELECT standard_frequency.sf_description
	     , route_frequency.rf_delivery_days
	     , route_frequency.rf_distance
          FROM standard_frequency
             , route_frequency
         WHERE standard_frequency.sf_key = route_frequency.sf_key
           AND route_frequency.contract_no = @inContract
           AND route_frequency.rf_active = 'Y'
           AND route_frequency.rf_distance > 0


  declare @nNominalVehical numeric(10,2)
  --  declare nWageHourlyRate      numeric(10,2);         -- TJB SR4661
  declare @nDeliveryWageRate numeric(10,2)                -- TJB SR4661
  declare @nProcessingWageRate numeric(10,2)              -- TJB SR4661
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
  declare @dExpiryDate datetime;
  declare @sConTitle char(60)
  declare @iNumberCusts integer
  declare @sRDFile char(40)
  declare @sRCMFile char(40)
  declare @nCurrentPayment numeric(10,2)
  declare @nExtensions numeric(10,2)
  declare @nNumRows integer
  declare @nRouteDistance numeric(10,2)
  declare @nDeliveryHours numeric(10,3)
  declare @nProcessingHours numeric(10,2)
  declare @nContractVolume numeric(10,2)
  declare @nDeliveryDays numeric(10,2)
  declare @nDeliveryDaysForReport numeric(10,2)
  declare @nMaxDeliveryDays numeric(10,2)
  declare @nRouteDistancePerDay real
  declare @nVehicleDepreciation real
  declare @nFuelCostPerAnnum real
  declare @nRepairsPerAnnum real
  declare @nTyresTubesPerAnnum real
  declare @nDeliveryCost real
  declare @nProcessingCost real
  declare @nReliefCost real                             -- Added:  TJB  SR4661
  declare @nReliefWeeks real                            -- Added:  TJB  SR4703
  declare @dEffectDate datetime                         -- Added:  TJB  SR4703
  declare @nPublicLiabilityCost real
  declare @nACCPerAnnum real
  declare @nBenchmark real
  declare @nVehicleInsurance real
  declare @nLicensing real
  declare @nCarrierRiskRate real
  declare @nRateOfReturnCost real
  declare @nFinalBenchmark real
  declare @nRetainedAllowances numeric(10,2)
  declare @nPRSKey1 integer
  declare @nPRSKey2 integer
  declare @nPRSKey3 integer
  declare @nPRSKey4 integer
  declare @nPRSKey5 integer
  declare @sPieceRateSupplier1 char(50)
  declare @sPieceRateSupplier2 char(50)
  declare @sPieceRateSupplier3 char(50)
  declare @sPieceRateSupplier4 char(50)
  declare @sPieceRateSupplier5 char(50)
  declare @nPieceRate1 numeric(10,2)
  declare @nPieceRate2 numeric(10,2)
  declare @nPieceRate3 numeric(10,2)
  declare @nPieceRate4 numeric(10,2)
  declare @nPieceRate5 numeric(10,2)
  declare @sRenewalGroup char(40)
  declare @nRenewalGroup integer
  declare @dRenewalDate datetime
  declare @nSumAdjustments numeric(10,2)
  declare @nRUC numeric(8,2)
  declare @nRUCRate numeric(8,2)
  declare @nAccounting numeric(8,2)
  declare @nTelephone numeric(8,2)
  declare @nSundries numeric(8,2)
  declare @nTempint integer
  declare @nSundriesK numeric(8,2)
  declare @PRStartDate datetime
  declare @PREndDate datetime
  --New 2001
  declare @nRemainingEconomicLife integer
  declare @nInsurancePct numeric(12,2)
  declare @nLivery numeric(12,2)
  declare @nUniform numeric(12,2)
  declare @nACCAmount numeric(12,2)
  declare @nLiveryPerAnnum numeric(12,2)
  declare @nUniformPerAnnum numeric(12,2)

  declare @nMaxDays            integer
  declare @nLoop               integer
  declare @nRowCount           integer
  declare @nRow                integer
  declare @nPRSKey             integer
  declare @sPieceRateSupplier  varchar(50)
  declare @nPieceRate          numeric(10,2)

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
  -- TJB RPCR_147 May-2020 Added
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
  
  declare @nActivityRatio real    -- TJB RPCR_133 July-2019: Added (for convenience)
  
  --///////////////////////////////// get rates //////////////////////////////////////////
  select top 1 
         @nNominalVehical        = isNull(vor.vor_nominal_vehicle_value,vr.vr_nominal_vehicle_value),
         @nRemainingEconomicLife = v.v_remaining_economic_life,
         -- isNull(nvor.nvor_wage_hourly_rate,nvr.nvr_wage_hourly_rate) as wage_rate,                         -- TJB SR4661
         @nDeliveryWageRate      = isNull(nvor.nvor_delivery_wage_rate,nvr.nvr_delivery_wage_rate),        -- TJB SR4661
         @nProcessingWageRate    = isNull(nvor.nvor_processing_wage_rate,nvr.nvr_processing_wage_rate),    -- TJB SR4661
         @nReliefWeeks           = isNull(nvor.nvor_relief_weeks,nvr.nvr_relief_weeks),                    -- TJB RPCR_041
         @nRepairsMaint          = isNull(vor.vor_repairs_maintenance_rate,vr.vr_repairs_maintenance_rate),
         @nTyreTubes             = isNull(vor.vor_tyre_tubes_rate,vr.vr_tyre_tubes_rate),
         @nVehicalAllow          = isNull(vor.vor_vehical_allowance_rate,vr.vr_vehicle_allowance_rate),
         @nVehicalInsure         = rd.f_GetInsurance(c.contract_no,cr.contract_seq_number,cr.con_rates_effective_date), --ins $
         @nPublicLia             = isNull(nvor.nvor_public_liability_rate_2,nvr.nvr_public_liability_rate),
         @nCarrierRisk           = isNull(nvor.nvor_carrier_risk_rate,nvr.nvr_carrier_risk_rate),
         @nACCRate               = isNull(nvor.nvor_acc_rate,nvr.nvr_acc_rate),
         @nLicence               = isNull(vor.vor_licence_rate,vr.vr_licence_rate),
         @nRateOfReturn          = isNull(vor.vor_vehicle_rate_of_return_pct,vr.vr_vehicle_rate_of_return_pct),
         @nSalvageRatio          = isNull(vor.vor_salvage_ratio,vr.vr_salvage_ratio),
         @nItemsHour             = isNull(nvor.nvor_item_proc_rate_per_hour,nvr.nvr_item_proc_rate_per_hr),
         @nFuel                  = isNull(vor.vor_fuel_rate,rd.f_GetFuelRates(c.contract_no,cr.contract_seq_number,cr.con_rates_effective_date)),
         @nConsumption           = isNull(vor.vor_consumption_rate,rd.f_GetConsumptionRates(c.contract_no,cr.contract_seq_number,cr.con_rates_effective_date)),
         @sRenewalGroup          = rg_description,
         @nRenewalGroup          = rg.rg_code,
         @dRenewalDate           = cr.con_rates_effective_date,
         @nAccounting            = isNull(nvor.nvor_accounting,nvr.nvr_accounting),
         @nTelephone             = isNull(nvor.nvor_telephone,nvr.nvr_telephone),
         @nSundries              = isNull(nvor.nvor_sundries,nvr.nvr_sundries),
         @nRucrate               = isNull(vor.vor_ruc,vr.vr_ruc),
         @nSundriesK             = isNull(vor.vor_sundries_k,vr.vr_sundries_k),
         @nInsurancePct          = isNull(vr.vr_vehicle_value_insurance_pct,0),
         @nLivery                = isNull(vor.vor_livery,vr.vr_livery),
         @nUniform               = isNull(nvor_uniform,nvr_uniform),
         @nACCAmount             = isNull(nvor.nvor_acc_rate_amount,nvr.nvr_acc_rate_amount)  
    from
         contract_renewals as cr
             left outer join non_vehicle_override_rate as nvor 
                 on cr.contract_no = nvor.contract_no and
                    cr.contract_seq_number = nvor.contract_seq_number  -- TJB RD7_0047: added
     	    left outer join vehicle_override_rate as vor 
     	         on cr.contract_no = vor.contract_no and
          	    cr.contract_seq_number = vor.contract_seq_number,
     --    vehicle_override_rate as vor,
     --    non_vehicle_override_rate as nvor,
         contract_vehical as cv,
         vehicle as v,
         contract as c,
         non_vehicle_rate as nvr,
         vehicle_type as vt,
         vehicle_rate as vr,
         renewal_group as rg
   where
         rg.rg_code = c.rg_code and 
         vt.vt_key = vr.vt_key and
         cv.contract_no = cr.contract_no and
         cv.contract_seq_number = cr.contract_seq_number and
         v.vehicle_number = cv.vehicle_number and
         vt.vt_key = v.vt_key and
         c.contract_no = cr.contract_no and
         v.vehicle_number = rd.f_GetLatestVehicle(c.contract_no,cr.contract_seq_number) and
         c.rg_code = nvr.rg_code and
         cr.contract_no = @inContract and
         cr.contract_seq_number = @inSequence and
         nvr.nvr_rates_effective_date = cr.con_rates_effective_date and
         vr.vr_rates_effective_date = cr.con_rates_effective_date and
         (nvor.nvor_effective_date is null                           -- TJB RPCR_099 Jan-2016: Added
	      or nvor.nvor_effective_date = vor.vor_effective_date)  -- 
   order by 
         vor.vor_effective_date desc

  if @@error <> 0
    RAISERROR('',10,1)
    
  -- TJB  RD7_0005 Aug 2008 - Apply SR4721 change
  -- TJB  SR4721 July 2008 - moved dExpiryDate to inSequence contract from inSequence+1's 
  --con start and end
  select @dStartDate  = con_start_date
       , @dEffectDate = con_rates_effective_date
       , @dExpiryDate = con_expiry_date
    from rd.contract_renewals
   where contract_renewals.contract_no = @inContract
     and contract_renewals.contract_seq_number = @inSequence;

  select @dEndDate = con_start_date
    from contract_renewals
   where contract_renewals.contract_no = @inContract
     and contract_renewals.contract_seq_number = @inSequence+1;

      -- Added TJB  SR4703  Sep 2007
      -- Removed:  TJB  RPCR_041  Nov-2012
      -- if @dEffectDate >= '2007 Oct 31' 
      --   set @nReliefWeeks = 5
      -- else
      --   set @nReliefWeeks = 4
    
  --frequency rates
  select @nNumRows         = count(*),
         @nDeliveryDays    = rd.GetContractDelDays(contract_renewals.contract_no,
                                                   contract_renewals.contract_seq_number,
                                                   contract_renewals.con_rg_code_at_renewal,
                                                   contract_renewals.con_rates_effective_date),
         @nRouteDistance   = contract_renewals.con_distance_at_renewal
                             + sum(isnull(frequency_distances.fd_distance,0)*rate_days.rtd_days_per_annum),
         @nDeliveryHours   = contract_renewals.con_del_hrs_week_at_renewal
                             + sum(isnull(frequency_distances.fd_delivery_hrs_per_week,0)),
                             
         @nProcessingHours = contract_renewals.con_processing_hours_per_week
                             + sum(isnull(frequency_distances.fd_processing_hrs_week,0)),
                             
         @nContractVolume  = contract_renewals.con_volume_at_renewal
                             + sum(isnull(frequency_distances.fd_volume, 0)),
         @iNumberCusts     = isnull(contract_renewals.con_no_customers_at_renewal,0)
                             + isnull(contract_renewals.con_no_cmb_custs_at_renewal,0)
                             + sum(isnull(frequency_distances.fd_no_of_boxes,0))
                             + sum(isnull(frequency_distances.fd_no_cmb_customers,0))
   from  contract_renewals,
         route_frequency left outer join frequency_distances 
                              on route_frequency.contract_no = frequency_distances.contract_no and
                                 route_frequency.sf_key = frequency_distances.sf_key and
                                 route_frequency.rf_delivery_days = frequency_distances.rf_delivery_days and
                                 frequency_distances.fd_effective_date >= @dStartDate and
                                 @dStartDate is not null and
                                 (@dEndDate is null or @dEndDate >= frequency_distances.fd_effective_date),
         rate_days 
   where contract_renewals.contract_no = route_frequency.contract_no and
         route_frequency.sf_key = rate_days.sf_key and
         contract_renewals.con_rates_effective_date = rate_days.rr_rates_effective_date and
         contract_renewals.con_rg_code_at_renewal = rate_days.rg_code and
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

  --days per annum
  select @nMaxDeliveryDays = max(rate_days.rtd_days_per_annum)
    from contract_renewals join rate_days 
                on contract_renewals.con_rg_code_at_renewal = rate_days.rg_code and
                   contract_renewals.con_rates_effective_date = rate_days.rr_rates_effective_date 
   where contract_renewals.contract_no = @inContract and
         contract_renewals.contract_seq_number = @inSequence
  
  -- If max days per week>4, assume deldays = maxdeldays
  select @nMaxdays = sum(standard_frequency.sf_days_week)
    from rate_days,
         standard_frequency,
         route_frequency,
         contract,
         contract_renewals 
   where standard_frequency.sf_key = rate_days.sf_key and
         route_frequency.sf_key = standard_frequency.sf_key and
         rate_days.rg_code = contract.rg_code and
         contract.contract_no = route_frequency.contract_no and
         route_frequency.contract_no = @inContract and
         route_frequency.rf_active = 'Y' and
         contract_renewals.contract_no = contract.contract_no and
         contract_renewals.contract_seq_number = @inSequence and
         contract_renewals.con_rates_effective_date = rate_days.rr_rates_effective_date

  -- to prevent the deliverydays from being changed if the nMaxDays are >4
  -- in order to show correct deliverydays on the report.
  select @nDeliveryDaysForReport = @nDeliveryDays

  if @nMaxdays > 4
    select @nDeliveryDays=@nMaxDeliveryDays

  select @nSumAdjustments = sum(fd_amount_to_pay)
    from frequency_adjustments 
   where contract_no = @inContract and
         contract_seq_number = @inSequence and
         fd_paid_to_date is not null
         
  select @nRouteDistancePerDay = round(@nRouteDistance/@nDeliveryDays,2)

  --New depreciation computation 2001
  -- PBY 26/06/2002 SR#4415 Added nRouteDistance/1000 to VehicleDepreciation
  -- calcuation if REL > 0  
  if @nRemainingEconomicLife > 0
    select @nVehicleDepreciation = (@nRouteDistance/1000)
                                         *((1-(isNull(@nSalvageRatio,0)/100))*isNull(@nNominalVehical,0)*1000)
                                         /@nRemainingEconomicLife
  else
    select @nVehicleDepreciation = @nRouteDistance*(@nVehicalAllow/1000)

  select @nFuelCostPerAnnum      = round((@nConsumption/100)*@nRouteDistance*(@nFuel/100),2)
  select @nRepairsPerAnnum       = round(@nRouteDistance*(@nRepairsMaint/1000),2)
  select @nTyresTubesPerAnnum    = round(@nTyreTubes*(@nRouteDistance/1000),2)
         -- TJB SR4661: Replaced nWageHourlyRate with nDeliveryWageRate and nProcessingWageRate
  select @nDeliveryCost          = (round(@nDeliveryHours,2)*52)*@nDeliveryWageRate
  select @nReliefCost            = (round(@nDeliveryHours,2)*@nReliefWeeks)*@nDeliveryWageRate   -- Added:  TJB  SR4661
                                       +round(((((@nContractVolume/@nItemsHour)/365)*7)*@nReliefWeeks)
                                       *@nProcessingWageRate,2)
  select @nProcessingCost        = round(((((@nContractVolume/@nItemsHour)/365)*7)*52)*@nProcessingWageRate,2)
  select @nACCPerAnnum           = round((@nAccRate/100)*(@nDeliveryCost+@nProcessingCost+@nReliefCost),2)
                                       +isNull(@nACCAmount,0)

         -- TJB RPCR_133 July-2019 Added activity ratio
         -- Changed activity ratio effect to 100% by commenting out the calculations below
  select @nActivityRatio = @nDeliveryDays/@nMaxDeliveryDays
  
         -- TJB RPCR_133 Fix Sept-2019 
  --select @nPublicLiabilityCost   = round(@nPublicLia*@nActivityRatio,2)
  --select @nVehicleInsurance      = @nVehicalInsure*(@nDeliveryDays/@nMaxDeliveryDays)
  --select @nLiveryPerAnnum        = @nLivery*(@nDeliveryDays/@nMaxDeliveryDays)         -- *(@nRouteDistance/1000)
  --select @nUniformPerAnnum       = @nUniform*(@nDeliveryDays/@nMaxDeliveryDays)        -- *(@nRouteDistance/1000)
  --select @nLicensing             = @nLicence*(@nDeliveryDays/@nMaxDeliveryDays)
  --select @nCarrierRiskRate       = @nCarrierRisk*(@nDeliveryDays/@nMaxDeliveryDays)
  --select @nAccounting            = round(@nAccounting*(@nDeliveryDays/@nMaxDeliveryDays),2)
  --select @nTelephone             = round(@nTelephone*(@nDeliveryDays/@nMaxDeliveryDays),2)
  --select @nSundries              = round(@nSundries*(@nDeliveryDays/@nMaxDeliveryDays),2)
  --select @nRateofReturnCost      = rd.GetRateReturn(@nNominalVehical,@nRateOfReturn,@nSalvageRatio)
  --                                       *(@nDeliveryDays/@nMaxDeliveryDays)

  select @nPublicLiabilityCost   = round(@nPublicLia,2)
  select @nVehicleInsurance      = @nVehicalInsure -- *(@nDeliveryDays/@nMaxDeliveryDays)
  select @nLiveryPerAnnum        = @nLivery        -- *(@nDeliveryDays/@nMaxDeliveryDays)         -- *(@nRouteDistance/1000)
  select @nUniformPerAnnum       = @nUniform       -- *(@nDeliveryDays/@nMaxDeliveryDays)        -- *(@nRouteDistance/1000)
  select @nLicensing             = @nLicence       -- *(@nDeliveryDays/@nMaxDeliveryDays)
  select @nCarrierRiskRate       = @nCarrierRisk   -- *(@nDeliveryDays/@nMaxDeliveryDays)
  select @nAccounting            = round(@nAccounting,2)
  select @nTelephone             = round(@nTelephone,2)
  select @nSundries              = round(@nSundries,2)
  select @nSundriesK             = round(@nSundriesK*(@nRouteDistance/1000),2)
  select @nRateofReturnCost      = rd.GetRateReturn(@nNominalVehical,@nRateOfReturn,@nSalvageRatio)
                                         *(@nDeliveryDays/@nMaxDeliveryDays)

         --determine if diesel
  select @nTempint = count(contractor_renewals.contract_no)
    from rd.contractor_renewals,
         rd.contract_vehical,
         rd.vehicle,
         rd.fuel_type 
   where contractor_renewals.contract_no = @inContract and
         contractor_renewals.contract_seq_number = @inSequence and
         contractor_renewals.contract_no = contract_vehical.contract_no and
         contractor_renewals.contract_seq_number = contract_vehical.contract_seq_number and
         contract_vehical.vehicle_number = vehicle.vehicle_number and
         vehicle.ft_key = fuel_type.ft_key and
         fuel_type.ft_description like 'diesel%' and
         vehicle.vehicle_number = rd.f_GetLatestVehicle(@inContract,@inSequence)
         -- and(contract_vehical.cv_vehical_status='A')
         
  if @@error <> 0 
    RAISERROR('',10,1)
    
  if @ntempint = 0
    select @nRUC = 0.0
  else
    select @nRUC = round(@nRucRate*(@nRouteDistance/1000),2)
    
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
                       isnull(@nReliefCost,0)+            -- Added:  TJB  SR4661
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
    from contract 
   where contract_no = @inContract
   
  select @nRetainedAllowances = sum(ca_annual_amount)
    from contract_allowance 
   where contract_no = @inContract
     and contract_allowance.ca_approved = 'Y'   -- TJB RPCR_017 July-2010: added
   
  select @nRowCount = count(*)
    from piece_rate_supplier

  if @nRowCount > 0
  begin

  /*-----------------------------------------------------------------------------
   * TJB  Aug 2008  RD7_0005
   *      Apply SR4721 changes
   *          For contracts with a start date > 1-May-2007
   *              - change 'KiwiPost' to 'ReachMedia'
   *              - Skip any 'Skyroad' supplier values
   *          Roll up unrolled loop:
   *
   * Below for n = [1..5]
   *
   *   open cur_getsupplier
   *
   *   if @nRowCount >= 1
   *   begin
   *       fetch next from cur_getsupplier into @nPRSKey1, @sPieceRateSupplier1
   *
   *       select @nPieceRate1 = sum(prd_cost) 
   *         from piece_rate_delivery join piece_rate_type 
   *                   on piece_rate_delivery.prt_key = piece_rate_type.prt_key 
   *        where contract_no = @inContract and
   *              prs_key = @nPRSKey1 and
   *              prd_date between @PRStartDate and @PREndDate
   *
   *       if @nPieceRate1 is null and @sPieceRateSupplier1 = 'ParcelPost'
   *       begin
   *           select @nPieceRate1         = rd.f_estParcelPostValue(@inContract,@inSequence,@nRenewalGroup,
   *                                                         @PRStartDate,@PREndDate,@dStartDate,@dEndDate)
   *           select @sPieceRateSupplier1 = 'Estimated ' + @sPieceRateSupplier1
   *       end
   *   end
   */-----------------------------------------------------------------------------

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
          fetch next from cur_getsupplier into @nPRSKey, @sPieceRateSupplier
           
          if @@fetch_status < 0  break
          
          -- TJB Oct-2010
          -- Use supplier name from database table with no override
          -- if @nPRSKey = 1 and @dStartDate >= '2007-May-01'        -- Change 'KiwiMail' to 'Reachmedia'
          --     select @sPieceRateSupplier = 'Reachmedia'

          -- TJB July-2013: changed if test from hard-coded prs_key to description
          -- if not @nPRSKey = 3 or @dStartDate < '2007-May-01'      -- sPieceRateSupplier = 'SkyRoad' 
          if not rtrim(@sPieceRateSupplier) = 'SkyRoad' or @dStartDate < '2007-May-01'
          begin
              select @nPieceRate = sum(prd_cost)  
                from piece_rate_delivery join piece_rate_type 
                          on piece_rate_delivery.prt_key=piece_rate_type.prt_key 
               where contract_no = @inContract and
                     prs_key     = @nPRSKey and
                     prd_date between @PRStartDate and @PREndDate
 
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
	      insert into t_bm_piecerates
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
  -- TJB RPCR_147 May-2020 - Add frequencies 6 - 12
  
  SELECT @nRowCount = count(*)
    FROM standard_frequency
       , route_frequency
   WHERE standard_frequency.sf_key = route_frequency.sf_key
     AND route_frequency.contract_no = @inContract
     AND route_frequency.rf_active = 'Y'
     AND route_frequency.rf_distance > 0

  if @nRowCount > 0
  begin
      open cur_getfrequencies

      select @nrow = 0
      while 1 = 1 
      begin
          fetch next from cur_getfrequencies into   @sFreqDescr, @sFreqDays, @dFreqDist

           
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
  set @nProcessingHours = round(((@nContractVolume/@nItemsHour)/365)*7,2)

  select @inContract		 as	inContract,
         @inSequence		 as	inSequence,
         @sConTitle		 as	sConTitle,
         @sRDFile		 as	sRDFile,
         @sRCMFile		 as	sRCMFile,
         @nNominalVehical	 as	nNominalVehical,
         -- nWageHourlyRate              -- TJB SR4661		
         @nDeliveryWageRate 	 as	nDeliveryWageRate,           -- TJB SR4661
         @nRepairsMaint		 as	nRepairsMaint,
         @nTyreTubes		 as	nTyreTubes,
         @nVehicalAllow		 as	nVehicalAllow,
         @nVehicalInsure	 as	nVehicalInsure,
         @nPublicLia		 as	nPublicLia,
         @nCarrierRisk		 as	nCarrierRisk,
         @nACCRate		 as	nACCRate,
         @nLicence		 as	nLicence,
         @nRateOfReturn		 as	nRateOfReturn,
         @nSalvageRatio		 as	nSalvageRatio,
         @nItemsHour		 as	nItemsHour,
         @nFuel			 as	nFuel,
         @nConsumption		 as	nConsumption,
         @nRouteDistance	 as	nRouteDistance,
         @nDeliveryHours	 as	nDeliveryHours,
         @nProcessingHours	 as	nProcessingHours,
         @nContractVolume	 as	nContractVolume,
         @nDeliveryDays		 as	nDeliveryDays,
         @nMaxDeliveryDays	 as	nMaxDeliveryDays,
         @iNumberCusts		 as	iNumberCusts,
         @nRouteDistancePerDay	 as	nRouteDistancePerDay,
         @nVehicleDepreciation	 as	nVehicleDepreciation,
         @nFuelCostPerAnnum	 as	nFuelCostPerAnnum,
         @nRepairsPerAnnum	 as	nRepairsPerAnnum,
         @nTyresTubesPerAnnum	 as	nTyresTubesPerAnnum,
         @nDeliveryCost		 as	nDeliveryCost,
         @nProcessingCost	 as	nProcessingCost,
         @nPublicLiabilityCost	 as	nPublicLiabilityCost,
         @nACCPerAnnum		 as	nACCPerAnnum,
         @nVehicleInsurance	 as	nVehicleInsurance,
         @nLicensing		 as	nLicensing,
         @nCarrierRiskRate	 as	nCarrierRiskRate,
         @nBenchmark		 as	nBenchmark,
         @nRateOfReturnCost	 as	nRateOfReturnCost,
         @nFinalBenchmark	 as	nFinalBenchmark,
         @nRetainedAllowances	 as	nRetainedAllowances,
         @nCurrentPayment	 as	nCurrentPayment,
         @sPieceRateSupplier1	 as	sPieceRateSupplier1,
         @nPieceRate1		 as	nPieceRate1,
         @sPieceRateSupplier2	 as	sPieceRateSupplier2,
         @nPieceRate2		 as	nPieceRate2,
         @sPieceRateSupplier3	 as	sPieceRateSupplier3,
         @nPieceRate3		 as	nPieceRate3,
         @sPieceRateSupplier4	 as	sPieceRateSupplier4,
         @nPieceRate4		 as	nPieceRate4,
         @sPieceRateSupplier5	 as	sPieceRateSupplier5,
         @nPieceRate5		 as	nPieceRate5,
         @sRenewalGroup		 as	sRenewalGroup,
         @dRenewalDate		 as	dRenewalDate,
         @nAccounting		 as	nAccounting,
         @nTelephone		 as	nTelephone,
         @nSundries		 as	nSundries,
         @nRuc			 as	nRuc,
         @nSundriesK		 as	nSundriesK,
         @nLiveryPerAnnum	 as	nLiveryPerAnnum,
         @nUniformPerAnnum	 as	nUniformPerAnnum,
         @nDeliveryDaysForReport as	nDeliveryDaysForReport,
         @nReliefCost 		 as	nReliefCost,               -- Added:  TJB  SR4661
         @dStartDate		 as	dStartDate,
         @dEndDate		 as	dEndDate,
         @PRStartDate		 as	PRStartDate,
         @PREndDate		 as	PREndDate,
         @dExpiryDate		 as	dExpiryDate
       , @sFreqDescr1            as     sFreqDescr1
       , @sFreqDays1             as     sFreqDays1
       , @dFreqDist1             as     dFreqDist1
       , @sFreqDescr2            as     sFreqDescr2
       , @sFreqDays2             as     sFreqDays2 
       , @dFreqDist2             as     dFreqDist2 
       , @sFreqDescr3            as     sFreqDescr3
       , @sFreqDays3             as     sFreqDays3 
       , @dFreqDist3             as     dFreqDist3 
       , @sFreqDescr4            as     sFreqDescr4
       , @sFreqDays4             as     sFreqDays4 
       , @dFreqDist4             as     dFreqDist4 
       , @sFreqDescr5            as     sFreqDescr5
       , @sFreqDays5             as     sFreqDays5 
       , @dFreqDist5             as     dFreqDist5 
  -- TJB RPCR_147 May-2020 Added 
       , @sFreqDescr6            as     sFreqDescr6
       , @sFreqDays6             as     sFreqDays6 
       , @dFreqDist6             as     dFreqDist6 
       , @sFreqDescr7            as     sFreqDescr7
       , @sFreqDays7             as     sFreqDays7 
       , @dFreqDist7             as     dFreqDist7 
       , @sFreqDescr8            as     sFreqDescr8
       , @sFreqDays8             as     sFreqDays8 
       , @dFreqDist8             as     dFreqDist8 
       , @sFreqDescr9            as     sFreqDescr9
       , @sFreqDays9             as     sFreqDays9 
       , @dFreqDist9             as     dFreqDist9 
       , @sFreqDescr10           as     sFreqDescr10
       , @sFreqDays10            as     sFreqDays10 
       , @dFreqDist10            as     dFreqDist10 
       , @sFreqDescr11           as     sFreqDescr11
       , @sFreqDays11            as     sFreqDays11 
       , @dFreqDist11            as     dFreqDist11 
       , @sFreqDescr12           as     sFreqDescr12
       , @sFreqDays12            as     sFreqDays12 
       , @dFreqDist12            as     dFreqDist12 
  
END