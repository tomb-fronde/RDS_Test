
create procedure  [rd].[sp_GetRouteDescription_2002](@inContract int,@inSFKey int,@inDelDays char(7))
-- TJB  Sept 2005  NPAD2 address schema changes
-- Added adr_unit number and road_suffix to relevant parts of address returned
as -- Also added adr_alpha (missing) and fixed spacing on address
begin
set CONCAT_NULL_YIELDS_NULL off
  -- PBY 16/10/2002 SR#4462 Terminal points disappeared once you make any changes through the Route Description tab page.
  -- This problem is caused by adr_id not being passed back to the datawindow properly.
  -- PBY 24/07/2002 SR#4437 Address not displayed correctly
  select sf_key,
    contract_no,
    rd_sequence,
    rf_delivery_days,
    rd_description_of_point=left(case when adr_id is null then rd_description_of_point else 
    (select case when addr.adr_unit is null then '' else addr.adr_unit+'/' end+
      ISNULL(addr.adr_no,'')+ISNULL(addr.adr_alpha,'')+
      case when addr.adr_unit+addr.adr_no+addr.adr_alpha is null then '' else ' ' end +
      ISNULL(rd2.Road_name,'')+
      case  when rt.rt_name is null then '' else ' '+rt.rt_name end +
      case  when rs.rs_name is null then '' else ' '+rs.rs_name end  from
      address as addr left outer join road as rd2 on addr.road_id=rd2.road_id
      left outer join road_type as rt on rd2.rt_id=rt.rt_id
      left outer join road_suffix as rs on rd2.rs_id=rs.rs_id where
      addr.adr_id = route_description.adr_id) end ,
    40),
    --PBY 24/07/2002 Commented Out
    --"left"(ifnull(adr_id,rd_description_of_point,(select a.adr_no+' '+r.Road_name+' '+rt.rt_name from Address as a,Road as r,road_type as rt where a.road_id = r.road_id and r.rt_id = rt.rt_id and a.adr_id = route_description.adr_id)),40) as rd_description_of_point,
    rd_time_at_point,
    rfv_id,
    rfpd_id,
    rfpt_description=(select left(rfpt_description,40) from
      route_freq_point_type where
      route_freq_point_type.rfpt_id = route_description.rfpd_id),
    rf_distance_of_leg,
    rf_running_total,
    rfv_id_2,
    cust_id,
    0,
    0,
    Adr_id from
    route_description where
    contract_no = @inContract and
    sf_key = @inSFKey and
    rf_delivery_days = @inDelDays order by
    rd_sequence asc
end