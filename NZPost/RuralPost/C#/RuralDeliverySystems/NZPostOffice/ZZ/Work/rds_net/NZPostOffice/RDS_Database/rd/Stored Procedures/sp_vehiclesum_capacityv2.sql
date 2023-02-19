
create procedure [rd].[sp_vehiclesum_capacityv2](
@inRegion int,
@inOutlet int,
@inrengroup int,
@inContract_Type int)
-- TJB  SR4670  Sept 2005
as -- Reorganised where clauses to match related procedures''
begin
set CONCAT_NULL_YIELDS_NULL off
  declare @nUpto2Litres int
  declare @nAt2Litres int
  declare @nOver2Litres int
  declare @nUnknown int

  select @nUpto2Litres=Count(distinct vehicle.vehicle_number) 
--!  from outlet join contract on outlet.outlet_id = contract.con_base_office,
--!    contract_renewals join contract as c1 on contract_renewals.contract_no=c1.contract_no join contract_vehical on
  from outlet join contract on outlet.outlet_id = contract.con_base_office
	join contract_renewals on contract_renewals.contract_no=contract.contract_no join contract_vehical on
    contract_renewals.contract_no = contract_vehical.contract_no and
    contract_renewals.contract_seq_number = contract_vehical.contract_seq_number and
    
    -- PBY 12/06/2002 SR#4401
    -- and contract_vehical.cv_vehical_status = 'A'
    -- TJB  SR4670  Sept-2005
    -- Changed sequence number to con_active_sequence 
    -- to avoid multiple rows error in f_GetLatestVehicle
--!    contract_vehical.vehicle_number = rd.f_GetLatestVehicle(c1.contract_no,c1.con_active_sequence),
--!    contract_vehical cv2 join vehicle on  cv2.vehicle_number=vehicle.vehicle_number,
--!    contract c2 join types_for_contract on types_for_contract.contract_no = c2.contract_no 
    contract_vehical.vehicle_number = rd.f_GetLatestVehicle(contract.contract_no,contract.con_active_sequence)
	join vehicle on  contract_vehical.vehicle_number=vehicle.vehicle_number
	join types_for_contract on types_for_contract.contract_no = contract.contract_no 
  where
    (outlet.region_id = @inRegion or @inRegion = 0) and
    (outlet.outlet_id = @inOutlet or @inOutlet = 0) and
    (types_for_contract.ct_key = @inContract_type or @inContract_type = 0) and
    (contract_renewals.con_rg_code_at_renewal = @inrengroup or(@inrengroup = 0 or @inrengroup is null)) and
    (contract.con_date_terminated is null or contract.con_date_terminated >= rd.today()) and
    vehicle.v_vehicle_cc_rating < 1975

  select @nAt2Litres=Count(distinct vehicle.vehicle_number) 
  from 
--!    outlet join contract on outlet.outlet_id = contract.con_base_office,
--!    contract_renewals join contract as c1 on contract_renewals.contract_no=c1.contract_no join contract_vehical on
    outlet join contract on outlet.outlet_id = contract.con_base_office
    join contract_renewals on contract_renewals.contract_no=contract.contract_no join contract_vehical on
    contract_renewals.contract_no = contract_vehical.contract_no and
    contract_renewals.contract_seq_number = contract_vehical.contract_seq_number and
    -- PBY 12/06/2002 SR#4401
    -- and contract_vehical.cv_vehical_status = 'A'
    -- TJB  SR4670  Sept-2005
    -- Changed sequence number to con_active_sequence 
    -- to avoid multiple rows error in f_GetLatestVehicle
--!    contract_vehical.vehicle_number = rd.f_GetLatestVehicle(c1.contract_no,c1.con_active_sequence),
--!    contract_vehical cv2 join vehicle on cv2.vehicle_number=vehicle.vehicle_number,
--!    contract c2 join types_for_contract on types_for_contract.contract_no = c2.contract_no 
    contract_vehical.vehicle_number = rd.f_GetLatestVehicle(contract.contract_no,contract.con_active_sequence)
    join vehicle on contract_vehical.vehicle_number=vehicle.vehicle_number
	join types_for_contract on types_for_contract.contract_no = contract.contract_no 

 where
    (outlet.region_id = @inRegion or @inRegion = 0) and
    (outlet.outlet_id = @inOutlet or @inOutlet = 0) and
    (types_for_contract.ct_key = @inContract_type or @inContract_type = 0) and
    (contract_renewals.con_rg_code_at_renewal = @inrengroup or(@inrengroup = 0 or @inrengroup is null)) and
    (contract.con_date_terminated is null or contract.con_date_terminated >= rd.today()) and
    vehicle.v_vehicle_cc_rating between 1975 and 2025

  select @nOver2Litres=Count(distinct vehicle.vehicle_number) 
  from 
--!    outlet join contract on outlet.outlet_id = contract.con_base_office,
--!    contract_renewals join contract as c1 on contract_renewals.contract_no=c1.contract_no  join contract_vehical on
    outlet join contract on outlet.outlet_id = contract.con_base_office
    join contract_renewals on contract_renewals.contract_no=contract.contract_no  join contract_vehical on    
	contract_renewals.contract_no = contract_vehical.contract_no and
    contract_renewals.contract_seq_number = contract_vehical.contract_seq_number and
    -- PBY 12/06/2002 SR#4401
    -- and contract_vehical.cv_vehical_status = 'A'
    -- TJB  SR4670  Sept-2005
    -- Changed sequence number to con_active_sequence 
    -- to avoid multiple rows error in f_GetLatestVehicle
--!    contract_vehical.vehicle_number = rd.f_GetLatestVehicle(c1.contract_no,c1.con_active_sequence),
--!    contract_vehical cv2 join vehicle on cv2.vehicle_number=vehicle.vehicle_number,
--!    contract c2 join types_for_contract on types_for_contract.contract_no = c2.contract_no 
    contract_vehical.vehicle_number = rd.f_GetLatestVehicle(contract.contract_no,contract.con_active_sequence)
	join vehicle on contract_vehical.vehicle_number=vehicle.vehicle_number
	join types_for_contract on types_for_contract.contract_no = contract.contract_no 

  where
    (outlet.region_id = @inRegion or @inRegion = 0) and
    (outlet.outlet_id = @inOutlet or @inOutlet = 0) and
    (types_for_contract.ct_key = @inContract_type or @inContract_type = 0) and
    (contract_renewals.con_rg_code_at_renewal = @inrengroup or(@inrengroup = 0 or @inrengroup is null)) and
    (contract.con_date_terminated is null or contract.con_date_terminated >= rd.today()) and
    vehicle.v_vehicle_cc_rating > 2025

  select @nUnknown=Count(distinct vehicle.vehicle_number) 
  from 
--!    outlet join contract on outlet.outlet_id = contract.con_base_office,
--!    contract_renewals join contract as c1 on contract_renewals.contract_no=c1.contract_no join contract_vehical on
    outlet join contract on outlet.outlet_id = contract.con_base_office
    join contract_renewals on contract_renewals.contract_no=contract.contract_no join contract_vehical on
    contract_renewals.contract_no = contract_vehical.contract_no and
    contract_renewals.contract_seq_number = contract_vehical.contract_seq_number and
    -- PBY 12/06/2002 SR#4401
    -- and contract_vehical.cv_vehical_status = 'A'
    -- TJB  SR4670  Sept-2005
    -- Changed sequence number to con_active_sequence 
    -- to avoid multiple rows error in f_GetLatestVehicle
--!    contract_vehical.vehicle_number =rd.f_GetLatestVehicle(c1.contract_no,c1.con_active_sequence),
--!    contract_vehical  cv2 join vehicle on cv2.vehicle_number=vehicle.vehicle_number,
--!    contract c2 join types_for_contract on
--!    types_for_contract.contract_no = c2.contract_no where
    contract_vehical.vehicle_number =rd.f_GetLatestVehicle(contract.contract_no,contract.con_active_sequence)
	join vehicle on contract_vehical.vehicle_number=vehicle.vehicle_number
	join types_for_contract on
    types_for_contract.contract_no = contract.contract_no where
    (outlet.region_id = @inRegion or @inRegion = 0) and
    (outlet.outlet_id = @inOutlet or @inOutlet = 0) and
    (types_for_contract.ct_key = @inContract_type or @inContract_type = 0) and
    (contract_renewals.con_rg_code_at_renewal = @inrengroup or(@inrengroup = 0 or @inrengroup is null)) and
    (contract.con_date_terminated is null or contract.con_date_terminated >= rd.today()) and
    vehicle.v_vehicle_cc_rating is null

  select @nUpto2Litres,
    @nAt2Litres,
    @nOver2Litres,
    @nUnknown 
end