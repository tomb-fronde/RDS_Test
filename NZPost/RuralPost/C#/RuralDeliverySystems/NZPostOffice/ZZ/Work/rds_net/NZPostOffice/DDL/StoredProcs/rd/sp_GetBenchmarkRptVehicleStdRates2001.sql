/****** Object:  StoredProcedure [rd].[sp_GetBenchmarkRptVehicleStdRates2001]    Script Date: 08/05/2008 10:19:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for stored procedure sp_GetBenchmarkRptVehicleStdRates2001 : 
--

--
-- Definition for stored procedure sp_GetBenchmarkRptVehicleStdRates2001 : 
--

create procedure [rd].[sp_GetBenchmarkRptVehicleStdRates2001]
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  select vt_description as VehicleType,'Net Vehicle Value ($)' as Formula,vr_nominal_vehicle_value as Value from vehicle_rate,vehicle_type where vehicle_type.vt_key = vehicle_rate.vt_key union
  select vt_description,'Rep Maint Rate ($/1000k)',vr_repairs_maintenance_rate from vehicle_rate,vehicle_type where vehicle_type.vt_key = vehicle_rate.vt_key union
  select vt_description,'Tyres ($/1000k)',vr_tyre_tubes_rate from vehicle_rate,vehicle_type where vehicle_type.vt_key = vehicle_rate.vt_key union
  select vt_description,'Vehicle Allowance ($/1000k)',vr_vehicle_allowance_rate from vehicle_rate,vehicle_type where vehicle_type.vt_key = vehicle_rate.vt_key union
  select vt_description,'Relicensing ($ pa)',vr_licence_rate from vehicle_rate,vehicle_type where vehicle_type.vt_key = vehicle_rate.vt_key union
  select vt_description,'Vehicle Rate Of Return (%)',vr_vehicle_rate_of_return_pct from vehicle_rate,vehicle_type where vehicle_type.vt_key = vehicle_rate.vt_key union
  select vt_description,'Salvage Ratio (%)',vr_salvage_ratio from vehicle_rate,vehicle_type where vehicle_type.vt_key = vehicle_rate.vt_key union
  select vt_description,'Road User Charges ($/1000k)',vr_ruc from vehicle_rate,vehicle_type where vehicle_type.vt_key = vehicle_rate.vt_key union
  select vt_description,'Rep Maint Rate ($/1000k)',vr_sundries_k from vehicle_rate,vehicle_type where vehicle_type.vt_key = vehicle_rate.vt_key union
  select vt_description,'Sundries ($/1000k)',vr_vehicle_value_insurance_pct from vehicle_rate,vehicle_type where vehicle_type.vt_key = vehicle_rate.vt_key union
  select vt_description,'Rep Maint Rate ($/1000k)',vr_livery from vehicle_rate,vehicle_type where vehicle_type.vt_key = vehicle_rate.vt_key
end
GO
