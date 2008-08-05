/****** Object:  UserDefinedFunction [rd].[GetDailyDistForReg]    Script Date: 08/05/2008 11:24:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for user-defined function GetDailyDistForReg : 
--

create function [rd].[GetDailyDistForReg](@inRegion int)
returns decimal(10,2)
AS
BEGIN

  --declare
  /* Watcom only
  err_notfound exception for sqlstate value '02000'
  */
  declare cur_getdistance cursor for select sum(route_frequency.rf_distance*
      rate_days.rtd_days_per_annum)/
      max(rate_days.rtd_days_per_annum) from
      contract join
      outlet on
      contract.con_base_office = outlet.outlet_id and
      outlet.region_id = @inRegion join
      contract_renewals on
      contract.contract_no = contract_renewals.contract_no and
      contract.con_active_sequence = contract_renewals.contract_seq_number join
      route_frequency on
      contract.contract_no = route_frequency.contract_no and
--!      rou.rf_active = 'Y',
--!      route_frequency join
      route_frequency.rf_active = 'Y' join
      rate_days on
--!      route_frequency.sf_key = rate_days.sf_key,
--!      outlet as ou join
      route_frequency.sf_key = rate_days.sf_key join
      region on
      outlet.region_id = region.region_id where
      contract_renewals.con_rg_code_at_renewal = rate_days.rg_code and
      contract_renewals.con_rates_effective_date = rate_days.rr_rates_effective_date and
      contract.contract_no = 
      any(select types_for_contract.contract_no from
        types_for_contract join contract_type on types_for_contract.ct_key = contract_type.ct_key
		where
        contract_type.ct_rd_ref_mandatory = 'Y')
      group by contract.contract_no,contract_renewals.contract_seq_number

  declare @dDailyDistance decimal(10,2),
  @dTotalDailyDistance decimal(10,2)

  select @dTotalDailyDistance=0
  open cur_getdistance
  /* Watcom only
  CursorLoop:
  */while 1=1 
    begin
      fetch next from cur_GetDistance into @dDailyDistance
      if @@fetch_status < 0
        break
        /* Watcom only
        CursorLoop
        */
      if @dDailyDistance is not null
        select @dTotalDailyDistance=@dTotalDailyDistance+@dDailyDistance
    end
  close cur_GetDistance
  return @dTotalDailyDistance
end
GO
