/****** Object:  StoredProcedure [rd].[sp_GetRenewalRatesWithRegion2001a]    Script Date: 08/05/2008 10:20:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for stored procedure sp_GetRenewalRatesWithRegion2001a : 
--

create procedure [rd].[sp_GetRenewalRatesWithRegion2001a](@inregion int)
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  if @inregion > 0
    select distinct non_vehicle_rate.rg_code,
      non_vehicle_rate.nvr_rates_effective_date,
      non_vehicle_rate.nvr_frozen_indicator,
      rd.f_CheckRates(non_vehicle_rate.rg_code,non_vehicle_rate.nvr_rates_effective_date) from
      contract,
      outlet,
      non_vehicle_rate where
      outlet.outlet_id = contract.con_lodgement_office and
      contract.rg_code = non_vehicle_rate.rg_code and
      outlet.region_id = @inregion order by
      non_vehicle_rate.nvr_rates_effective_date asc
  else
    select distinct non_vehicle_rate.rg_code,
      non_vehicle_rate.nvr_rates_effective_date,
      non_vehicle_rate.nvr_frozen_indicator,
      rd.f_CheckRates(non_vehicle_rate.rg_code,non_vehicle_rate.nvr_rates_effective_date) from
      non_vehicle_rate order by
      2 asc
end
GO
