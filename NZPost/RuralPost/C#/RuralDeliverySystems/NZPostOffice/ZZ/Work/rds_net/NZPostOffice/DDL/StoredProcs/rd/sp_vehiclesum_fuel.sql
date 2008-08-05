/****** Object:  StoredProcedure [rd].[sp_vehiclesum_fuel]    Script Date: 08/05/2008 10:23:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for stored procedure sp_vehiclesum_fuel : 
--

create procedure [rd].[sp_vehiclesum_fuel](
@region int,
@outlet int)
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  select fuel_type.ft_description,
    count(vehicle.vehicle_number) 
  from  
    contract_renewals left outer join contract on contract_renewals.contract_no=contract.contract_no,
    contract_vehical left outer join contract_renewals cr2 on 
    contract_vehical.contract_no=cr2.contract_no 
    and contract_vehical.contract_seq_number=cr2.contract_seq_number,
    contract c2 left outer join outlet on 
    c2.con_lodgement_office=outlet.outlet_id and c2.con_base_office=outlet.outlet_id,
    FUEL_TYPE left outer join vehicle on FUEL_TYPE.ft_key=vehicle.ft_key,
    VEHICLE v2 left outer join CONTRACT_VEHICAL  cv2 on v2.vehicle_number=cv2.vehicle_number
where
    ((outlet.region_id = @region and @region <> -1) or
    (@region = -1)) and ((outlet.outlet_id = @outlet and
    @outlet <> -1) or  (@outlet = -1))
    group by fuel_type.ft_description union
  select 'TOTAL',
    count(distinct vehicle.vehicle_number) 
 from
    contract_renewals left outer join contract on contract_renewals.contract_no=contract.contract_no,
    contract_vehical left outer join contract_renewals  cr2 on 
    contract_vehical.contract_no=cr2.contract_no 
    and contract_vehical.contract_seq_number=cr2.contract_seq_number,
    contract c2 left outer join outlet on 
    c2.con_lodgement_office=outlet.outlet_id and c2.con_base_office=outlet.outlet_id,
    FUEL_TYPE left outer join vehicle on FUEL_TYPE.ft_key=vehicle.ft_key,
    VEHICLE v2 left outer join CONTRACT_VEHICAL cv2 on v2.vehicle_number=cv2.vehicle_number
where
    ((outlet.region_id = @region and  @region <> -1) or
    (@region = -1)) and ((outlet.outlet_id = @outlet and
    @outlet <> -1) or(@outlet = -1))
end
GO
