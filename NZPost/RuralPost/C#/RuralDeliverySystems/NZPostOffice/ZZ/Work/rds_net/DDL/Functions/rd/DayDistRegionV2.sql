/****** Object:  UserDefinedFunction [rd].[DayDistRegionV2]    Script Date: 08/05/2008 11:23:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for user-defined function DayDistRegionV2 : 
--

create function [rd].[DayDistRegionV2](@inRegion int,@inOutlet int,@inRenGroup int,@inContractType int)
returns decimal(10,2)
AS
BEGIN

  /* declare
  Watcom only
  err_notfound exception for sqlstate value '02000'
  */
  declare cur_getdistance  cursor for  select sum(route_frequency.rf_distance*rate_days.rtd_days_per_annum)/max(rate_days.rtd_days_per_annum) from
      contract join
      outlet on
      contract.con_base_office = outlet.outlet_id and
      (outlet.region_id = @inRegion or @inRegion = 0) and
      (outlet.outlet_id = @inOutlet or @inOutlet = 0) join
      contract_renewals on
      contract.contract_no = contract_renewals.contract_no and
      contract.con_active_sequence = contract_renewals.contract_seq_number join
      route_frequency on
      contract.contract_no = route_frequency.contract_no and
      route_frequency.rf_active = 'Y'
	  join rate_days on
      route_frequency.sf_key = rate_days.sf_key where
      contract_renewals.con_rg_code_at_renewal = rate_days.rg_code and
      contract_renewals.con_rates_effective_date = rate_days.rr_rates_effective_date and
      ((contract.con_base_cont_type = @inContractType and @inContractType > 0) or
      (@inContractType = 0 or @inContractType is null)) and
      contract.con_date_terminated is null and
      (contract_renewals.contract_no = contract.contract_no) and
      (contract_renewals.contract_seq_number = contract.con_active_sequence) and
      (contract.rg_code = @inRenGroup or @inRenGroup = 0)
      group by contract.contract_no,contract_renewals.contract_seq_number
   declare @dDailyDistance decimal(10,2)
   declare @dTotalDailyDistance decimal(10,2)
  select @dTotalDailyDistance=0
  open cur_getdistance
  /* Watcom only
  CursorLoop:
  */while 1=1 
    begin
      fetch next  from cur_GetDistance into @dDailyDistance
      if @@fetch_status <0
        break

     /* if sqlstate = err_notfound
        break
        /* Watcom only
        CursorLoop
        */
*/
      if @dDailyDistance is not null
        select @dTotalDailyDistance=@dTotalDailyDistance+@dDailyDistance
    end
  close cur_GetDistance
  return @dTotalDailyDistance
end
GO
