
--
-- Definition for stored procedure sp_vehiclesum_age : 
--

create procedure [rd].[sp_vehiclesum_age](@inRegion int,@inOutlet int)
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  declare @nAgeUpto5Years int,
  @nAge5To10Years int,
  @nAgeOver10Years int,
  @nAgeUnknown int
  select @nAgeUpto5Years = Count(distinct vehicle.vehicle_number)
    from outlet join contract as con on
    outlet.outlet_id = con.con_base_office
	 join contract_renewals as conr on
    con.contract_no = conr.contract_no and
    con.con_active_sequence = conr.contract_seq_number
	 join contract_vehical on
    conr.contract_no = contract_vehical.contract_no and
    conr.contract_seq_number = contract_vehical.contract_seq_number and
    contract_vehical.cv_vehical_status = 'A'
	 join vehicle on contract_vehical.vehicle_number = vehicle.vehicle_number where
    (outlet.region_id = @inRegion or @inRegion = 0) and
    (outlet.outlet_id = @inOutlet or @inOutlet = 0) and
    (year(rd.today())-vehicle.v_vehicle_year) < 5
  select @nAge5To10Years = Count(distinct vehicle.vehicle_number)
    from outlet join contract as con on
    outlet.outlet_id = con.con_base_office
	 join contract_renewals on
    con.contract_no = contract_renewals.contract_no and
    con.con_active_sequence = contract_renewals.contract_seq_number
	 join contract_vehical on
    contract_renewals.contract_no = contract_vehical.contract_no and
    contract_renewals.contract_seq_number = contract_vehical.contract_seq_number and
    contract_vehical.cv_vehical_status = 'A'
	 join vehicle on contract_vehical.vehicle_number = vehicle.vehicle_number where
    (outlet.region_id = @inRegion or @inRegion = 0) and
    (outlet.outlet_id = @inOutlet or @inOutlet = 0) and
    (year(rd.today())-vehicle.v_vehicle_year) >= 5 and
    (year(rd.today())-vehicle.v_vehicle_year) < 10
  select @nAgeOver10Years = Count(distinct vehicle.vehicle_number)
    from outlet join contract as con on
    outlet.outlet_id = con.con_base_office
	 join contract_renewals on
    con.contract_no = contract_renewals.contract_no and
    con.con_active_sequence = contract_renewals.contract_seq_number
	 join contract_vehical on
    contract_renewals.contract_no = contract_vehical.contract_no and
    contract_renewals.contract_seq_number = contract_vehical.contract_seq_number and
    contract_vehical.cv_vehical_status = 'A'
	 join
    vehicle on contract_vehical.vehicle_number =vehicle.vehicle_number  where
    (outlet.region_id = @inRegion or @inRegion = 0) and
    (outlet.outlet_id = @inOutlet or @inOutlet = 0) and
    (year(rd.today())-vehicle.v_vehicle_year) >= 10
  select @nAgeUnknown = Count(distinct vehicle.vehicle_number)
    from outlet join contract as con on
    outlet.outlet_id = con.con_base_office
	 join contract_renewals on
    con.contract_no = contract_renewals.contract_no and
    con.con_active_sequence = contract_renewals.contract_seq_number
	 join contract_vehical on
    contract_renewals.contract_no = contract_vehical.contract_no and
    contract_renewals.contract_seq_number = contract_vehical.contract_seq_number and
    contract_vehical.cv_vehical_status = 'A'
	 join
    vehicle on contract_vehical.vehicle_number = vehicle.vehicle_number where
    (outlet.region_id = @inRegion or @inRegion = 0) and
    (outlet.outlet_id = @inOutlet or @inOutlet = 0) and
    vehicle.v_vehicle_year is null
  select @nAgeUpto5Years,
    @nAge5To10Years,
    @nAgeOver10Years,
    @nAgeUnknown 
end