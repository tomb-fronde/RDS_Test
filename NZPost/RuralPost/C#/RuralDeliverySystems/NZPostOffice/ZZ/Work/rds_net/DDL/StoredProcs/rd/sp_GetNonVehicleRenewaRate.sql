/****** Object:  StoredProcedure [rd].[sp_GetNonVehicleRenewaRate]    Script Date: 08/05/2008 10:20:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for stored procedure sp_GetNonVehicleRenewaRate : 
--

create procedure [rd].[sp_GetNonVehicleRenewaRate](
@inRGCode int,
@in_EffectDate datetime)
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  select non_vehicle_rate.rg_code,
    non_vehicle_rate.nvr_rates_effective_date,
    non_vehicle_rate.nvr_wage_hourly_rate,
    non_vehicle_rate.nvr_vehicle_insurance_base_premium,
    non_vehicle_rate.nvr_public_liability_rate,
    non_vehicle_rate.nvr_carrier_risk_rate,
    non_vehicle_rate.nvr_acc_rate,
    non_vehicle_rate.nvr_item_proc_rate_per_hr,
    non_vehicle_rate.nvr_frozen_indicator,
    non_vehicle_rate.nvr_contract_start,
    non_vehicle_rate.nvr_contract_end,
    non_vehicle_rate.nvr_accounting,
    non_vehicle_rate.nvr_telephone,
    non_vehicle_rate.nvr_sundries,
    non_vehicle_rate.nvr_acc_rate_amount,
    non_vehicle_rate.nvr_uniform from
    non_vehicle_rate where
    (non_vehicle_rate.rg_code = @inRGCode or @inRGCode is null) and
    (non_vehicle_rate.nvr_rates_effective_date = @in_EffectDate)
end
GO
