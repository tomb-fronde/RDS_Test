/****** Object:  StoredProcedure [rd].[NPAD_get_address]    Script Date: 08/05/2008 10:17:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [rd].[NPAD_get_address](@in_adrID int) AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  select address.adr_id,
    address.tc_id,
    address.road_id,
    road.road_name,
    road.rt_id,
    address.sl_id,
    address.contract_no,
    address.post_code_id,
    post_code=(select post_code from post_code where post_code_id = address.post_code_id),
    address.adr_rd_no,
    address.adr_no,
    address.adr_alpha,
    address.dp_id,
    address.adr_old_delivery_days,
    address.adr_property_identification,
    adr_freq=rd.f_getFrequency(address.adr_id,0,'N'),
    adr_num=(case when address.adr_unit is null then '' else address.adr_unit+'/' end+address.adr_no+address.adr_alpha),
    adr_freq_terminal=rd.f_getFrequency(address.adr_id,address.contract_no,'Y'),
    address.adr_last_amended_date,
    address.adr_last_amended_user,
    address.adr_unit,
    road.rs_id,
    cust.cust_id,
    cust.cust_initials,
    cust.cust_surname_company from
--!    address as adr left outer join road on adr.road_id = road.road_id,
--!    address left outer join customer_address_moves as cam on address.adr_id = cam.adr_id left outer join rds_customer as cust on cam.cust_id = cust.cust_id where
    address left outer join road on address.road_id = road.road_id
	left outer join customer_address_moves as cam on address.adr_id = cam.adr_id left outer join rds_customer as cust on cam.cust_id = cust.cust_id where
    address.adr_id = @in_adrID and
    cam.move_out_date is null and
    cust.master_cust_id is null
end
GO
