
--
-- Definition for stored procedure sp_vehiclesum_vehicletype : 
--

create procedure [rd].[sp_vehiclesum_vehicletype](@inRegion int,@inOutlet int)
AS
BEGIN
  select vehicle_type.vt_description,
    (select Count(distinct vehicle.vehicle_number) from
      outlet join contract on
      outlet.outlet_id = contract.con_base_office,
      contract  as con join contract_renewals on
      con.contract_no = contract_renewals.contract_no and
      con.con_active_sequence = contract_renewals.contract_seq_number,
      contract_renewals as cr join contract_vehical on
      cr.contract_no = contract_vehical.contract_no and
      cr.contract_seq_number = contract_vehical.contract_seq_number and
      contract_vehical.cv_vehical_status = 'A',
      contract_vehical as cv  join vehicle on cv.vehicle_number = vehicle.vehicle_number
where
      (outlet.region_id = @inRegion or @inRegion = 0) and
      (outlet.outlet_id = @inOutlet or @inOutlet = 0) and
      vehicle.vt_key = vehicle_type.vt_key) from
    vehicle_type
end