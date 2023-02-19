
--
-- Definition for stored procedure sp_vehiclesum_fueltype : 
--

create procedure [rd].[sp_vehiclesum_fueltype](
@inRegion int,
@inOutlet int)
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  select fuel_type.ft_description,
    (select Count(distinct vehicle.vehicle_number) 
  from
      outlet join contract on outlet.outlet_id = contract.con_base_office,
      contract c2 join contract_renewals on
      c2.contract_no = contract_renewals.contract_no and
      c2.con_active_sequence = contract_renewals.contract_seq_number,
      contract_renewals cr2 join contract_vehical on
      cr2.contract_no = contract_vehical.contract_no and
      cr2.contract_seq_number = contract_vehical.contract_seq_number and
      contract_vehical.cv_vehical_status = 'A',
      contract_vehical cv2  join vehicle  on cv2.vehicle_number=vehicle.vehicle_number
  where
      (outlet.region_id = @inRegion or @inRegion = 0) and
      (outlet.outlet_id = @inOutlet or @inOutlet = 0) and
      vehicle.ft_key = fuel_type.ft_key) from
    fuel_type
end