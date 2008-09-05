/****** Object:  StoredProcedure [rd].[sp_vehiclesum_agev2]    Script Date: 08/05/2008 10:23:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure  [rd].[sp_vehiclesum_agev2](@inRegion int,@inOutlet int,@inRengroup int,@inContract_type int)
-- TJB  SR4670  Sept 2005
-- Reorganised where clauses to match related procedures''
--mod RB
as --28/5/2001 - exclude terminated contracts
begin
set CONCAT_NULL_YIELDS_NULL off
  declare 
  @nAgeUpto5Years int,
  @nAge5To10Years int,
  @nAgeOver10Years int,
  @nAgeUnknown int
  select @nAgeUpto5Years = Count(distinct vehicle.vehicle_number)
    from outlet join contract as con on outlet.outlet_id = con.con_base_office 
    join contract_renewals on con.contract_no = contract_renewals.contract_no
    join contract_vehical on contract_renewals.contract_no = contract_vehical.contract_no and
    contract_renewals.contract_seq_number = contract_vehical.contract_seq_number
    -- PBY 12/06/2002 SR#4401
    -- and contract_vehical.cv_vehical_status = 'A'
    -- TJB  SR4670  Sept-2005
    -- Changed sequence number to con_active_sequence 
    -- to avoid multiple rows error in f_GetLatestVehicle
    and contract_vehical.vehicle_number = rd.f_GetLatestVehicle(con.contract_no,con.con_active_sequence)
    join vehicle on contract_vehical.vehicle_number = vehicle.vehicle_number
	 join types_for_contract on
    types_for_contract.contract_no = con.contract_no where
    (outlet.region_id = @inRegion or @inRegion = 0) and
    (outlet.outlet_id = @inOutlet or @inOutlet = 0) and
    (types_for_contract.ct_key = @inContract_type or @inContract_type = 0) and
    (contract_renewals.con_rg_code_at_renewal = @inrengroup or(@inrengroup = 0 or @inrengroup is null)) and
    (con.con_date_terminated is null or con.con_date_terminated >= rd.today()) and
    (year(rd.today())-vehicle.v_vehicle_year) <= 5
    select @nAge5To10Years = Count(distinct vehicle.vehicle_number) 
    from outlet join contract as con on outlet.outlet_id = con.con_base_office
	join contract_renewals on con.contract_no = contract_renewals.contract_no
	 join contract_vehical on
    contract_renewals.contract_no = contract_vehical.contract_no and
    contract_renewals.contract_seq_number = contract_vehical.contract_seq_number
    -- PBY 12/06/2002 SR#4401
    -- and contract_vehical.cv_vehical_status = 'A'
    -- TJB  SR4670  Sept-2005
    -- Changed sequence number to con_active_sequence 
    -- to avoid multiple rows error in f_GetLatestVehicle
    and contract_vehical.vehicle_number = rd.f_GetLatestVehicle(con.contract_no,con.con_active_sequence)
    join vehicle on contract_vehical.vehicle_number = vehicle.vehicle_number
	 join types_for_contract on
    types_for_contract.contract_no = con.contract_no where
    (outlet.region_id = @inRegion or @inRegion = 0) and
    (outlet.outlet_id = @inOutlet or @inOutlet = 0) and
    (types_for_contract.ct_key = @inContract_type or @inContract_type = 0) and
    (contract_renewals.con_rg_code_at_renewal = @inrengroup or(@inrengroup = 0 or @inrengroup is null)) and
    (con.con_date_terminated is null or con.con_date_terminated >= rd.today()) and
    (year(rd.today())-vehicle.v_vehicle_year) > 5 and
    (year(rd.today())-vehicle.v_vehicle_year) <= 10
    select @nAgeOver10Years = Count(distinct vehicle.vehicle_number)
    from outlet join contract as con on
    outlet.outlet_id = con.con_base_office
	join contract_renewals on con.contract_no = contract_renewals.contract_no
	 join contract_vehical on
    contract_renewals.contract_no = contract_vehical.contract_no and
    contract_renewals.contract_seq_number = contract_vehical.contract_seq_number
    -- PBY 12/06/2002 SR#4401
    -- and contract_vehical.cv_vehical_status = 'A'
    -- TJB  SR4670  Sept-2005
    -- Changed sequence number to con_active_sequence 
    -- to avoid multiple rows error in f_GetLatestVehicle
    and contract_vehical.vehicle_number = rd.f_GetLatestVehicle(con.contract_no,con.con_active_sequence)
    join vehicle on contract_vehical.vehicle_number =vehicle.vehicle_number
	 join types_for_contract on
    types_for_contract.contract_no = con.contract_no where
    (outlet.region_id = @inRegion or @inRegion = 0) and
    (outlet.outlet_id = @inOutlet or @inOutlet = 0) and
    (types_for_contract.ct_key = @inContract_type or @inContract_type = 0) and
    (contract_renewals.con_rg_code_at_renewal = @inrengroup or(@inrengroup = 0 or @inrengroup is null)) and
    (con.con_date_terminated is null or con.con_date_terminated >= rd.today()) and
    (year(rd.today())-vehicle.v_vehicle_year) > 10
  select @nAgeUnknown = Count(distinct vehicle.vehicle_number) 
    from outlet join contract as con on
    outlet.outlet_id = con.con_base_office
	join contract_renewals on con.contract_no = contract_renewals.contract_no
	 join contract_vehical on
    contract_renewals.contract_no = contract_vehical.contract_no and
    contract_renewals.contract_seq_number = contract_vehical.contract_seq_number
    -- PBY 12/06/2002 SR#4401
    -- and contract_vehical.cv_vehical_status = 'A',
    -- TJB  SR4670  Sept-2005
    -- Changed sequence number to con_active_sequence 
    -- to avoid multiple rows error in f_GetLatestVehicle
    and contract_vehical.vehicle_number = rd.f_GetLatestVehicle(con.contract_no,con.con_active_sequence)
    join vehicle on contract_vehical.vehicle_number = vehicle.vehicle_number
	 join types_for_contract on
    types_for_contract.contract_no = con.contract_no where
    (outlet.region_id = @inRegion or @inRegion = 0) and
    (outlet.outlet_id = @inOutlet or @inOutlet = 0) and
    (types_for_contract.ct_key = @inContract_type or @inContract_type = 0) and
    (contract_renewals.con_rg_code_at_renewal = @inrengroup or(@inrengroup = 0 or @inrengroup is null)) and
    (con.con_date_terminated is null or con.con_date_terminated >= rd.today()) and
    (vehicle.v_vehicle_year is null or vehicle.v_vehicle_year = 0)
  select @nAgeUpto5Years,
    @nAge5To10Years,
    @nAgeOver10Years,
    @nAgeUnknown 
end
GO
