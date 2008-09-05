/****** Object:  UserDefinedFunction [rd].[GetContractDelDays]    Script Date: 08/05/2008 11:24:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for user-defined function GetContractDelDays : 
--

create function [rd].[GetContractDelDays]
(@inContract int,
@inSequence int,
@inRGCode int,
@inRateDate datetime)
returns int
AS
BEGIN

  declare @iMonday int
  declare @iTuesday int
  declare @iWednesday int
  declare @iThursday int
  declare @iFriday int
  declare @iSaturday int
  declare @iSunday int
  declare @iDaysInWeek int
  declare @iMaxDaysInYear int
  select @iMonday=sum(case substring(rf_delivery_days,1,1) when 'Y' then 1 else 0 end),
    @iTuesday=sum(case substring(rf_delivery_days,2,1) when 'Y' then 1 else 0 end),
    @iWednesday=sum(case substring(rf_delivery_days,3,1) when 'Y' then 1 else 0 end),
    @iThursday=sum(case substring(rf_delivery_days,4,1) when 'Y' then 1 else 0 end),
    @iFriday=sum(case substring(rf_delivery_days,5,1) when 'Y' then 1 else 0 end),
    @iSaturday=sum(case substring(rf_delivery_days,6,1) when 'Y' then 1 else 0 end),
    @iSunday=sum(case substring(rf_delivery_days,7,1) when 'Y' then 1 else 0 end) 
     from route_frequency where
    contract_no = @inContract and
    rf_active <> 'N'
  select @iDaysInWeek=(case when @iMonday > 0 then 1 else 0 end)+
    (case when @iTuesday > 0 then 1 else 0 end)+
    (case when @iWednesday > 0 then 1 else 0 end)+
    (case when @iThursday > 0 then 1 else 0 end)+
    (case when @iFriday > 0 then 1 else 0 end)+
    (case when @iSaturday > 0 then 1 else 0 end)+
    (case when @iSunday > 0 then 1 else 0 end)
  select @iMaxDaysInYear= max(rtd_days_per_annum) 
    from standard_frequency join
    rate_days on
    standard_frequency.sf_key = rate_days.sf_key and
    rate_days.rg_code = @inRgCode and
    rate_days.rr_rates_effective_date = @inRateDate and
    standard_frequency.sf_days_week = @iDaysInWeek
  return @iMaxDaysInYear
end
GO
