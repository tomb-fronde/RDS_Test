Create view [rd].[v_address] as
SELECT address.adr_id, region.rgn_name, address.contract_no, address.adr_unit, address.adr_no, address.adr_alpha,
ltrim(ISNULL(address.adr_unit + '/','')+ isnull(address.adr_no,'') + ISNULL(address.adr_alpha,'') + ' ' + road.road_name + ' ' + ISNULL(road_type.rt_name,'') + ' ' + ISNULL(road_suffix.rs_name,'')) AS Delivery_Address, 
SuburbLocality.sl_name, TownCity.tc_name, address.adr_rd_no, 'RD ' + address.adr_rd_no + ' ' + TownCity.tc_name AS rd_label, 
address.dp_id, post_code.post_code, address.adr_property_identification,
(ISNULL(address.adr_unit + '/','') + address.adr_no + ISNULL(address.adr_alpha,'')) AS Street_No, 
(road.road_name + ' ' + ISNULL(road_type.rt_name,'') + ' ' + ISNULL(road_suffix.rs_name,'')) AS Street_Name, 
road.road_name, road_type.rt_name, road_suffix.rs_name,
address.adr_date_loaded, address_geocode.geocode_x, address_geocode.geocode_y, address_geocode.external_system_id
FROM address
join TownCity ON address.tc_id = TownCity.tc_id
join region ON region.region_id = TownCity.region_id
join post_code ON address.post_code_id = post_code.post_code_id
join Road ON address.road_id = Road.road_id
left outer join SuburbLocality ON SuburbLocality.sl_id = address.sl_id 
left outer join address_geocode ON address_geocode.adr_id = address.adr_id
left outer join Road_Type ON Road.rt_id = Road_Type.rt_id
left outer join road_suffix ON Road.rs_id = road_suffix.rs_id
WHERE address.contract_no < 6000
GROUP BY address.adr_id, region.rgn_name, address_geocode.geocode_x, address_geocode.geocode_y, address.contract_no, 
address.adr_no, address.adr_unit, address.adr_alpha, road.road_name, road_type.rt_name, road_suffix.rs_name,
SuburbLocality.sl_name, TownCity.tc_name, address.adr_no, address.adr_rd_no, address.adr_property_identification,
address_geocode.external_system_id, address.dp_id, post_code.post_code, address.adr_unit, address.adr_date_loaded