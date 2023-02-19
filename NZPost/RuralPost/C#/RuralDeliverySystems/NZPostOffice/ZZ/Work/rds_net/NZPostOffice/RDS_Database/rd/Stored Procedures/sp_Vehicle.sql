
--
-- Definition for stored procedure sp_Vehicle : 
--

create procedure [rd].[sp_Vehicle](@inContract int,@inSequence int)
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  select make=vehicle.v_vehicle_make,
    model=vehicle.v_vehicle_model,
    modelyear=vehicle.v_vehicle_year,
    odometer=conv.start_kms,
    cc_rating=vehicle.v_vehicle_cc_rating,
    reg_number=vehicle.v_vehicle_registration_number,
    date_purchased=vehicle.v_purchased_date,
    ruc=vehicle.v_road_user_charges_indicator,
    Purchase_value=vehicle.v_purchase_value,
    fuel_type.ft_description,
    vehicle_type.vt_description from
    contract_renewals as conr join
    contract_vehical as conv on conr.contract_no = conv.contract_no and
    conr.contract_seq_number = conv.contract_seq_number and
    conv.cv_vehical_status = 'A'
    join
    vehicle on
    conv.vehicle_number = vehicle.vehicle_number
    left outer join
    fuel_type on
    fuel_type.ft_key = vehicle.ft_key
	left outer join
    vehicle_type on
    vehicle.vt_key = vehicle_type.vt_key where
    conr.contract_no = @inContract and
    conr.contract_seq_number = @inSequence
end