/****** Object:  StoredProcedure [rd].[sp_Get_vehicle_override_rates]    Script Date: 08/05/2008 10:19:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for stored procedure sp_Get_vehicle_override_rates : 
--

create procedure [rd].[sp_Get_vehicle_override_rates](@incontract_no int,@incontract_seq_no int) AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  select top 1 vehicle_override_rate.contract_no,
    vehicle_override_rate.contract_seq_number,
    vehicle_override_rate.vor_nominal_vehicle_value,
    vehicle_override_rate.vor_repairs_maintenance_rate,
    vehicle_override_rate.vor_tyre_tubes_rate,
    vehicle_override_rate.vor_vehical_allowance_rate,
    vehicle_override_rate.vor_licence_rate,
    vehicle_override_rate.vor_vehicle_rate_of_return_pct,
    vehicle_override_rate.vor_salvage_ratio,
    vehicle_override_rate.vor_ruc,
    vehicle_override_rate.vor_sundries_k,
    vehicle_override_rate.vor_vehicle_insurance_premium,
    vehicle_override_rate.vor_fuel_rate,
    vehicle_override_rate.vor_consumption_rate,
    vehicle_override_rate.vor_livery,
    vehicle_override_rate.vor_effective_date from
    vehicle_override_rate where
    (vehicle_override_rate.contract_no = @incontract_no) and
    (vehicle_override_rate.contract_seq_number = @incontract_seq_no) order by
    vehicle_override_rate.vor_effective_date desc
end
GO
