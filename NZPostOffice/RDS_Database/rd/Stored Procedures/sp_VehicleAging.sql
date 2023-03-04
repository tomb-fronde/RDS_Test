
--
-- Definition for stored procedure sp_VehicleAging : 
--
create procedure [rd].[sp_VehicleAging](@inRegion int,@inOutlet int,@inRenewalGroup int,@inContractType int)
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
   
select 
contract_no,
rgn_name,
con_expiry_date,
con_distance_at_renewal,  
    -- PBY 12/06/2002 SR#4401
    --    (select isnull((select max(cv.vehicle_number) 
    --                    from contract_vehical as cv 
    --                    where cv.contract_seq_number=contract.con_active_sequence 
    --                    and cv.contract_no=contract.contract_no 
    --                    and cv_vehical_status='N' 
    --                    and cv.contract_seq_number=(select max(cv2.contract_seq_number) 
    --                                                from contract_vehical as cv2 
    --                                                where cv.contract_no=cv2.contract_no 
    --                                                and cv.cv_vehical_status=cv2.cv_vehical_status)),
    --                    (select max(cv.vehicle_number) 
    --                    from contract_vehical as cv 
    --                    where cv.contract_no=contract.contract_no 
    --                    and cv_vehical_status='A' 
    --                    and cv.contract_seq_number=(select max(cv2.contract_seq_number) 
    --                                                from contract_vehical as cv2 
    --                                                where cv.contract_no=cv2.contract_no 
    --                                                and cv.cv_vehical_status=cv2.cv_vehical_status))) 
    --     from dummy) as vehicle_no,  
vehicle_no,
rg_description,
con_active_sequence,
contract_type,
vage
from 
(
select [contract].contract_no,
    region.rgn_name,
    contract_renewals.con_expiry_date,
    contract_renewals.con_distance_at_renewal,    
vehicle_no=rd.f_GetLatestVehicle(contract_renewals.contract_no,contract_renewals.contract_seq_number),
    renewal_group.rg_description,
    con_active_sequence=contract.con_active_sequence,
    contract_type.contract_type,
    vage=(select(year(con_expiry_date)-v_vehicle_year) from vehicle where vehicle.vehicle_number = rd.f_GetLatestVehicle(contract_renewals.contract_no,contract_renewals.contract_seq_number)) 
,cr_contract_no = contract_renewals.contract_no
,cr_contract_seq_number = contract_renewals.contract_seq_number
,con_start_date
from
    [contract],
    contract_renewals,
    outlet,
    region,
    renewal_group,
    types_for_contract,
    contract_type 
where
    (contract_renewals.contract_no = contract.contract_no) and
    (region.region_id = outlet.region_id) and
    (contract.con_base_office = outlet.outlet_id) and
    (contract_renewals.contract_seq_number = contract.con_active_sequence) and
    (contract.rg_code = renewal_group.rg_code) and
    (contract.contract_no = types_for_contract.contract_no) and
    (contract_type.ct_key = types_for_contract.ct_key) and
    ((types_for_contract.ct_key = @inContractType and @inContractType > 0) or(@inContractType = 0)) and
    ((outlet.outlet_id = @inOutlet and @inOutlet > 0) or(@inOutlet = 0)) and
    ((outlet.region_id = @inRegion and @inRegion > 0) or(@inRegion = 0)) and
    ((contract.rg_code = @inRenewalGroup and @inRenewalGroup > 0) or(@inRenewalGroup = 0)) and
    contract_renewals.con_expiry_date > rd.today()
) as atable
where
(vehicle_no > 0) and
    exists(select vehicle.vehicle_number from vehicle where(vehicle.vehicle_number = vehicle_no 
 and
      ((year(con_expiry_date)-v_vehicle_year) > 5) or
      ((select isnull(contract_vehical.start_kms,0) from
        contract_vehical where
        contract_vehical.contract_no = cr_contract_no and
        contract_vehical.contract_seq_number = cr_contract_seq_number and
        contract_vehical.vehicle_number = vehicle_no )+
      isnull((con_distance_at_renewal*datediff(day,con_start_date,con_expiry_date)/365),200001) > 200000))) 
order by
rgn_name asc,
con_expiry_date asc,
vage desc,
contract_no asc 



end