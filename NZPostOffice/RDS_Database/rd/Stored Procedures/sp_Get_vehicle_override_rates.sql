
CREATE PROCEDURE [rd].[sp_Get_vehicle_override_rates](
	  @inContractNo int
	, @inSequenceNo int
	, @inVehicleNo  int)
-- TJB  Frequencies & Values  15-Jan-2021
-- Added inVehicleNo parameter
-- (also changed parameter names and added table alias)
AS
BEGIN
  set NOCOUNT ON
  set CONCAT_NULL_YIELDS_NULL off
  
  select top 1 
         vor.contract_no
       , vor.contract_seq_number
       , vor.vor_nominal_vehicle_value
       , vor.vor_repairs_maintenance_rate
       , vor.vor_tyre_tubes_rate
       , vor.vor_vehical_allowance_rate
       , vor.vor_licence_rate
       , vor.vor_vehicle_rate_of_return_pct
       , vor.vor_salvage_ratio
       , vor.vor_ruc
       , vor.vor_sundries_k
       , vor.vor_vehicle_insurance_premium
       , vor.vor_fuel_rate
       , vor.vor_consumption_rate
       , vor.vor_livery
       , vor.vor_effective_date
       , vor.vehicle_number
    from vehicle_override_rate vor
   where vor.contract_no = @inContractNo
     and vor.contract_seq_number = @inSequenceNo
     and (vor.vehicle_number = @inVehicleNo
           or vor.vehicle_number is null
           or @inVehicleNo is null)
   order by
         vor.vor_effective_date desc
END