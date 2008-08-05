/****** Object:  StoredProcedure [rd].[sp_GetVehicleRate]    Script Date: 08/05/2008 10:21:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for stored procedure sp_GetVehicleRate : 
--

create procedure [rd].[sp_GetVehicleRate](@in_vt_key int,@in_effective_date datetime)
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  select vehicle_rate.vt_key,
    vehicle_rate.vr_rates_effective_date,
    vehicle_rate.vr_nominal_vehicle_value,
    vehicle_rate.vr_repairs_maintenance_rate,
    vehicle_rate.vr_tyre_tubes_rate,
    vehicle_rate.vr_vehicle_allowance_rate,
    vehicle_rate.vr_licence_rate,
    vehicle_rate.vr_vehicle_rate_of_return_pct,
    vehicle_rate.vr_salvage_ratio,
    vehicle_rate.vr_ruc,
    vehicle_rate.vr_sundries_k,
    vehicle_rate.vr_vehicle_value_insurance_pct,
    vehicle_rate.vr_livery from
    vehicle_rate where
    vehicle_rate.vt_key = @in_vt_key and
    vehicle_rate.vr_rates_effective_date = @in_effective_date
end
GO
