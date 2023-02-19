/*
 select 4177, [rd].[f_GetConVehicleDelDays] ( 50216, 10, '1-Apr-2020', 4177 )
 select 2067, [rd].[f_GetConVehicleDelDays] ( 50216, 10, '1-Apr-2020', 2067 )
*/
CREATE FUNCTION [rd].[f_GetConVehicleDelDays] (
	  @inContractNo int
	, @inRGCode     int
	, @inRateDate   datetime
	, @inVehicleNo  int)
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
  
  -- This sets the iDay to 1 if 'Y' otherwise 0
  select @iMonday=sum(case substring(rf_delivery_days,1,1)    when 'Y' then 1 else 0 end),
         @iTuesday=sum(case substring(rf_delivery_days,2,1)   when 'Y' then 1 else 0 end),
         @iWednesday=sum(case substring(rf_delivery_days,3,1) when 'Y' then 1 else 0 end),
         @iThursday=sum(case substring(rf_delivery_days,4,1)  when 'Y' then 1 else 0 end),
         @iFriday=sum(case substring(rf_delivery_days,5,1)    when 'Y' then 1 else 0 end),
         @iSaturday=sum(case substring(rf_delivery_days,6,1)  when 'Y' then 1 else 0 end),
         @iSunday=sum(case substring(rf_delivery_days,7,1)    when 'Y' then 1 else 0 end) 
    from rd.route_frequency 
   where contract_no = @inContractNo 
     and rf_active <> 'N'
     and vehicle_number = @inVehicleNo
     
  -- This simply sums the number of days in a week that are 'Y'
  select @iDaysInWeek=(case when @iMonday > 0 then 1 else 0 end)+
         (case when @iTuesday > 0 then 1 else 0 end)+
         (case when @iWednesday > 0 then 1 else 0 end)+
         (case when @iThursday > 0 then 1 else 0 end)+
         (case when @iFriday > 0 then 1 else 0 end)+
         (case when @iSaturday > 0 then 1 else 0 end)+
         (case when @iSunday > 0 then 1 else 0 end)
         
  select @iMaxDaysInYear = max(rtd_days_per_annum) 
    from standard_frequency join rate_days 
              on standard_frequency.sf_key = rate_days.sf_key 
                 and rate_days.rg_code = @inRgCode 
                 and rate_days.rr_rates_effective_date = @inRateDate 
                 and standard_frequency.sf_days_week   = @iDaysInWeek
              
  return @iMaxDaysInYear
end