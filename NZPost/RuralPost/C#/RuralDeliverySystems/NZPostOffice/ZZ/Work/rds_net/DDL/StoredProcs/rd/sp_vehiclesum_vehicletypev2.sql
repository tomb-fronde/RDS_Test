/****** Object:  StoredProcedure [rd].[sp_vehiclesum_vehicletypev2]    Script Date: 08/05/2008 10:23:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [rd].[sp_vehiclesum_vehicletypev2](@inRegion int,@inOutlet int,@inrengroup int,@inContract_Type int)
-- TJB  SR4670  Sept 2005
as -- Reorganised where clauses to match related procedures''
begin
set CONCAT_NULL_YIELDS_NULL off
  select vehicle_type.vt_description,
    (select Count(distinct vehicle.vehicle_number) from
      outlet join contract as co on
--!      outlet.outlet_id = co.con_base_office,
--!      contract_renewals join contract as con on con.contract_no = contract_renewals.contract_no join contract_vehical as conv on
--!      contract_renewals.contract_no = conv.contract_no and
--!      contract_renewals.contract_seq_number = conv.contract_seq_number and
      outlet.outlet_id = co.con_base_office
      join contract_renewals on co.contract_no = contract_renewals.contract_no join contract_vehical as conv on
      contract_renewals.contract_no = conv.contract_no and
      contract_renewals.contract_seq_number = conv.contract_seq_number and
      -- TJB  SR4670  Sept 2005 copying change: PBY 12/06/2002 SR#4401
      -- and contract_vehical.cv_vehical_status = 'A'
      -- Changed sequence number to con_active_sequence 
      -- to avoid multiple rows error in f_GetLatestVehicle
--!      conv.vehicle_number = rd.f_GetLatestVehicle(con.contract_no,con.con_active_sequence),
--!      contract_vehical join vehicle on contract_vehical.vehicle_number = vehicle.vehicle_number,
--!      contract join types_for_contract on
--!      types_for_contract.contract_no = contract.contract_no where
      conv.vehicle_number = rd.f_GetLatestVehicle(co.contract_no,co.con_active_sequence)
		 join vehicle on conv.vehicle_number = vehicle.vehicle_number
		join types_for_contract on
      types_for_contract.contract_no = co.contract_no where
      (outlet.region_id = @inRegion or @inRegion = 0) and
      (outlet.outlet_id = @inOutlet or @inOutlet = 0) and
      (types_for_contract.ct_key = @inContract_type or @inContract_type = 0) and
      (contract_renewals.con_rg_code_at_renewal = @inrengroup or(@inrengroup = 0 or @inrengroup is null)) and
      (co.con_date_terminated is null or co.con_date_terminated >= rd.today()) and
      (vehicle.vt_key = vehicle_type.vt_key)) from
    vehicle_type where
    vt_description not in('boat','motor cycle','truck','bus','minibus','other','others') union
  select 'Other',
    --         sum(
    (select Count(distinct vehicle.vehicle_number) from
      outlet join contract as co on
--!      outlet.outlet_id = co.con_base_office,
--!      contract_renewals join contract as con on con.contract_no = contract_renewals.contract_no join contract_vehical as conv on
--!      contract_renewals.contract_no = conv.contract_no and
--!      contract_renewals.contract_seq_number = conv.contract_seq_number and
      outlet.outlet_id = co.con_base_office
	  join contract_renewals on co.contract_no = contract_renewals.contract_no join contract_vehical as conv on
      contract_renewals.contract_no = conv.contract_no and
      contract_renewals.contract_seq_number = conv.contract_seq_number and
      -- TJB  SR4670  Sept 2005 copying change: PBY 12/06/2002 SR#4401
      -- and contract_vehical.cv_vehical_status = 'A'
      -- Changed sequence number to con_active_sequence 
      -- to avoid multiple rows error in f_GetLatestVehicle
--!      conv.vehicle_number = rd.f_GetLatestVehicle(con.contract_no,con.con_active_sequence),
--!      contract_vehical join vehicle on contract_vehical.vehicle_number = vehicle.vehicle_number,
--!      contract join types_for_contract on
--!      types_for_contract.contract_no = contract.contract_no where
      conv.vehicle_number = rd.f_GetLatestVehicle(co.contract_no,co.con_active_sequence)
	  join vehicle on conv.vehicle_number = vehicle.vehicle_number
	  join types_for_contract on
      types_for_contract.contract_no = co.contract_no where
      (outlet.region_id = @inRegion or @inRegion = 0) and
      (outlet.outlet_id = @inOutlet or @inOutlet = 0) and
      (types_for_contract.ct_key = @inContract_type or @inContract_type = 0) and
      (contract_renewals.con_rg_code_at_renewal = @inrengroup or(@inrengroup = 0 or @inrengroup is null)) and
      (co.con_date_terminated is null or co.con_date_terminated >= rd.today()) and
      (vehicle.vt_key = vehicle_type.vt_key)) from
    --         )
    vehicle_type where
    vt_description in('boat','motor cycle','truck','bus','minibus','other','others')
end
GO
