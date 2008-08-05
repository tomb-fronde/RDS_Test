/****** Object:  UserDefinedFunction [rd].[GetContractDelDays_whatif]    Script Date: 08/05/2008 11:24:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for user-defined function GetContractDelDays_whatif : 
--

create function [rd].[GetContractDelDays_whatif](
@inContract int,
@inRGCode int,
@inRateDate datetime)
returns int
-- TJB 4635 - Sept 04
-- Variation on GetContractDelDays for whatif calculation
-- Drops RG_Code from selection condition (see below)
-- See also f_getConsumptionRates_whatif, f_getFuelRates_whatif, f_getInsurance_whatif
as -- Called from sp_getWhatifCalc2001c
begin

  declare @iDaysInWeek int
  declare @iMaxDaysInYear int
  select @iDaysInWeek=sum(case substring(rf_delivery_days,1,1) when 'Y' then 1 else 0 end)+
    sum(case substring(rf_delivery_days,2,1) when 'Y' then 1 else 0 end)+
    sum(case substring(rf_delivery_days,3,1) when 'Y' then 1 else 0 end)+
    sum(case substring(rf_delivery_days,4,1) when 'Y' then 1 else 0 end)+
    sum(case substring(rf_delivery_days,5,1) when 'Y' then 1 else 0 end)+
    sum(case substring(rf_delivery_days,6,1) when 'Y' then 1 else 0 end)+
    sum(case substring(rf_delivery_days,7,1) when 'Y' then 1 else 0 end)  
    from route_frequency where
    contract_no = @inContract and
    rf_active <> 'N'
  select @iMaxDaysInYear=max(rtd_days_per_annum)
    from standard_frequency join rate_days on
    standard_frequency.sf_key = rate_days.sf_key and
    rate_days.rr_rates_effective_date = @inRateDate and
    standard_frequency.sf_days_week = @iDaysInWeek
  -- TJB 4635
  --and rate_days.rg_code=inRgCode
  return @iMaxDaysInYear
end
GO
