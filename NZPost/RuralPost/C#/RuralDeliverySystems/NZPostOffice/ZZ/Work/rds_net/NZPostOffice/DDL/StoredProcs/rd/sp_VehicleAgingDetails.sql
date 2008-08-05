/****** Object:  StoredProcedure [rd].[sp_VehicleAgingDetails]    Script Date: 08/05/2008 10:23:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for stored procedure sp_VehicleAgingDetails : 
--

create procedure [rd].[sp_VehicleAgingDetails](@inContract int,@inSequence int,@inVehicleNo int)
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  select contract_vehical.start_kms,
    vehicle.v_vehicle_make,
    vehicle.v_vehicle_model,
    vehicle.v_vehicle_year,
    vehicle.v_vehicle_registration_number,
    vehicle.v_purchased_date,
    contract_vehical.contract_no,
    contract_vehical.contract_seq_number,
    contract_vehical.vehicle_number,
    contract_vehical.cv_vehical_status,
    PurchaseStatus=(select(case when year(v_purchased_date) = v_vehicle_year or start_kms <= 1000 then 'New' else 'Used' end) ),
    con_expiry_date=(select con_expiry_date from contract_renewals where contract_no = @inContract and contract_seq_number = @inSequence),
    con_distance_at_renewal=(select con_distance_at_renewal from contract_renewals where contract_no = @inContract and contract_seq_number = @inSequence),
    con_start_date=(select con_start_date from contract_renewals where contract_no = @inContract and contract_seq_number = @inSequence) from
    contract_vehical,
    vehicle where
    (vehicle.vehicle_number = contract_vehical.vehicle_number) and
    ((contract_vehical.contract_no = @inContract) and
    (contract_vehical.contract_seq_number = @inSequence) and
    (contract_vehical.vehicle_number = @inVehicleNo))
end
GO
