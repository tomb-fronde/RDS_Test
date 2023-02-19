

--
-- Definition for stored procedure sp_getUnoccupied : 
--

create procedure [rd].[sp_getUnoccupied](@con_id int)
-- TJB  Sept 2005  NPAD2 address schema changes
as -- Added adr_unit number and road_suffix to relevant parts of address returned
begin
set CONCAT_NULL_YIELDS_NULL off
  -- temp table for lastest move in dates from customer_address_moves
  create table #latest_in_temp(
    adr_id integer null,
    move_in datetime null,
    ) 
   -- temp table for lastest move in dates from customer_address_moves
  create table #latest_out_temp(
    adr_id integer null,
    move_out datetime null,
    )  -- temp table for lastest move in dates from customer_address_moves
  create table #latest_temp(
    adr_id integer null,
    ) 
  -- temp table for all address attached to a contract
  -- temp table for address'' with no customer_address_moves entry
  create table #addr_temp(
    adr_id integer null,
    road_id integer null,
    sl_id integer null,
    tc_id integer null,
    adr_no char(20) null,
    adr_rd_no char(40) null,
    ) 
  -- populate the addr_temp table
  create table #unocc_temp(
    adr_id integer null,
    road_id integer null,
    sl_id integer null,
    tc_id integer null,
    adr_no char(20) null,
    adr_rd_no char(40) null,
    )
  insert into #addr_temp(adr_id,road_id,sl_id,tc_id,adr_no,adr_rd_no)
    select addr.adr_id,
      addr.road_id,
      addr.sl_id,
      addr.tc_id,
      case when addr.adr_unit is null then '' else addr.adr_unit+'/' end +addr.adr_no+addr.adr_alpha,
      addr.adr_rd_no from
      address as addr where
      addr.contract_no = @con_id
  -- get an outer join for address and customer_address_moves - this is all those with no move entry
  insert into #unocc_temp(adr_id,road_id,sl_id,tc_id,adr_no,adr_rd_no)
    select addr.adr_id,
      addr.road_id,
      addr.sl_id,
      addr.tc_id,
      case when addr.adr_unit is null then '' else addr.adr_unit+'/' end +addr.adr_no+addr.adr_alpha,
      addr.adr_rd_no from
      address as addr left outer join customer_address_moves as cam on addr.adr_id=cam.adr_id where
      addr.contract_no = @con_id and
      cam.adr_id is null
  insert into #latest_out_temp(adr_id,move_out)
    select cam.adr_id,
      max(cam.move_out_date) from
      customer_address_moves as cam,
      rds_customer as cust,
      address as addr where
      addr.contract_no = @con_id and
      cam.adr_id = addr.adr_id and
      cust.master_cust_id is null and
      cam.cust_id = cust.cust_id
      group by cam.adr_id
  insert into #latest_in_temp(adr_id,move_in)
    select cam.adr_id,
      max(cam.move_in_date) from
      customer_address_moves as cam,
      rds_customer as cust,
      address as addr where
      addr.contract_no = @con_id and
      cam.adr_id = addr.adr_id and
      cust.master_cust_id is null and
      cam.cust_id = cust.cust_id
      group by cam.adr_id
  insert into #latest_temp(adr_id)
    select lat_out.adr_id from
      #latest_in_temp as lat_in,
      #latest_out_temp as lat_out where
      -- , addr_temp addr
      lat_in.adr_id = lat_out.adr_id and
      lat_in.move_in < lat_out.move_out
  -- do a double check - see if any of these has a missing move_out_date
  delete from #latest_temp where
    adr_id = any(select cam.adr_id from
      address as addr join customer_address_moves as cam on addr.adr_id=cam.adr_id where
      addr.contract_no = @con_id and
      cam.move_out_date is null)
  -- insert address'' into unocc_temp
  insert into #unocc_temp(adr_id,road_id,sl_id,tc_id,adr_no,adr_rd_no)
    select addr.adr_id,
      addr.road_id,
      addr.sl_id,
      addr.tc_id,
      case when addr.adr_unit is null then '' else addr.adr_unit+'/' end +addr.adr_no+addr.adr_alpha,
      addr.adr_rd_no from
      address as addr,
      #latest_temp as lat where
      addr.adr_id = lat.adr_id and
      not addr.adr_id = 
      any(select adr_id from #unocc_temp)
  -- and addr.contract_no = con_id
  select oc.adr_no,
    road_name=rd.road_name+
    case when rt.rt_name is null then null else ' '+rt.rt_name end +
    case when rs.rs_name is null then null else ' '+rs.rs_name end ,
    sl.sl_name,
    tc.tc_name,
    oc.adr_rd_no,
    @con_id,
    con.con_title from
    #unocc_temp as oc left outer join road as rd on
    rd.road_id = oc.road_id
	 left outer join road_type as rt on rd.rt_id=rt.rt_id left outer join
    road_suffix as rs on rd.rs_id=rs.rs_id
	 left outer join towncity as tc on
    (oc.tc_id = tc.tc_id),
    #unocc_temp as oc2 left outer join suburblocality as sl on
    (oc2.sl_id = sl.sl_id),
    contract as con where
    con.contract_no = @con_id order by
    -- and sl.sl_id = oc.sl_id
    -- and tc.tc_id = oc.tc_id
    -- and rd.road_id = oc.road_id
    road_name asc,oc.adr_no asc
end