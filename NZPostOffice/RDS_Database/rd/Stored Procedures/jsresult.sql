
create procedure [rd].[jsresult]
-- TJB  Sept 2005  NPAD2 address schema changes
-- Added adr_unit number and road_suffix to relevant parts of address returned
-- Changed adr_nad_reference to adr_dp_id
--
-- TJB  SR4681  July 2006
-- Added post code to value returned as 'cust_mail_town'
as -- was cust_nad_reference (tjb Sept''05)
begin
set CONCAT_NULL_YIELDS_NULL off
  select distinct
    cust_id=rc.cust_id,
    cust_adpost_quantity=rc.cust_adpost_quantity,
    cust_date_first_loaded=rc.cust_date_commenced,
    cust_date_last_transfered=cam.move_in_date,
    cust_date_left=null,
    contract_no=adr.contract_no,
    cust_title=rc.cust_title,
    rc.cust_surname_company,
    rc.cust_initials,
    cust_rd_number=adr.adr_rd_no,
    cust_mailing_address_no=case when adr.adr_unit is null then '' else rd.trim(adr.adr_unit)+'/' end +
    case when adr.adr_no is null then '' else rd.trim(adr.adr_no) end +
    case when adr.adr_alpha is null then '' else rd.trim(adr.adr_alpha) end,
    cust_mailing_address_road=road.road_name+
    case when road_type.rt_name is null then '' else ' '+road_type.rt_name end+
    case when road_suffix.rs_name is null then '' else ' '+road_suffix.rs_name end,
    cust_mailing_address_locality=suburblocality.sl_name,
    cust_mail_town=towncity.tc_name+'    '+post_code.post_code,
    adr_dp_id=convert(char(12),adr.dp_id),
    rc.cust_phone_day,
    rc.cust_phone_night,
    rc.cust_dir_listing_text,
    cust_delivery_days=rd.f_GetDeliveryDays(rc.cust_id),
    rc.cust_business,
    rc.cust_rural_resident,
    rc.cust_rural_farmer,
    contract.con_rd_ref_text,
    contract.con_title,
    rc.cust_dir_listing_ind,
    cust_property_identification=adr.adr_property_identification,
    cust_post_code=post_code.post_code,
    null,
    null from
    rds_customer as rc,
--!    address as adr left outer join road on adr.road_id = road.road_id left outer join road_type on road.rt_id = road_type.rt_id left outer join road_suffix on road.rs_id = road_suffix.rs_id,
--!    address as adrr left outer join suburblocality on adrr.sl_id = suburblocality.sl_id,
--!    address as adrrr left outer join towncity on adrrr.tc_id = towncity.tc_id,
    address as adr left outer join road on adr.road_id = road.road_id left outer join road_type on road.rt_id = road_type.rt_id left outer join road_suffix on road.rs_id = road_suffix.rs_id
    left outer join suburblocality on adr.sl_id = suburblocality.sl_id
	left outer join towncity on adr.tc_id = towncity.tc_id,

    customer_address_moves as cam,
    contract,
    report_temp,
    post_code where
    contract.contract_no = adr.contract_no and
    cam.adr_id = adr.adr_id and
    rc.cust_id = cam.cust_id and
    rc.master_cust_id is null and
    cam.move_out_date is null and
    post_code.post_code_id = adr.post_code_id and
    rc.cust_id = report_temp.customer_id
end