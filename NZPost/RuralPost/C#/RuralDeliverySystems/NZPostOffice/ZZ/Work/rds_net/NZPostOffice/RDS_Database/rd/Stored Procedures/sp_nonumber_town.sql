 

--
-- Definition for stored procedure sp_nonumber_town : 
--
 
create procedure [rd].[sp_nonumber_town](@town_id int)
-- TJB  Sept 2005  NPAD2 address schema changes
-- Added road_suffix to road name
as -- Added joins with implicit relations
begin
set CONCAT_NULL_YIELDS_NULL off
   select 
  cust_name=cust.cust_surname_company+
  case when cust.cust_initials is null then '' else ' '+cust.cust_initials end ,
  road_name=rd.road_name+
  (case when rt.rt_name is null then '' else ' '+rt.rt_name end) +
  (case when rs.rs_name is null then '' else ' '+rs.rs_name end),
  sl.sl_name,
  tc.tc_name,
  addr.adr_rd_no,
  cust.cust_phone_day,
  cust.cust_phone_night,
  cust.cust_phone_mobile
   from
  rds_customer as cust
  inner join customer_address_moves as cad
  on cust.cust_id=cad.cust_id
  inner join address as addr
  on cad.adr_id=addr.adr_id
  left outer join SuburbLocality as sl
  on addr.sl_id=sl.sl_id
  inner join TownCity as tc
  on addr.tc_id=tc.tc_id
  inner join road as rd
  on addr.road_id=rd.road_id
  left outer join road_type as rt
  on rt.rt_id=rd.rt_id
  left outer join
  road_suffix as rs on rd.rs_id=rs.rs_id 
 
   where
  addr.tc_id = @town_id and
  addr.adr_no is null and
  cust.master_cust_id is null and
  cad.move_out_date is null 
order by
    --and rd.Road_id = addr.Road_id
    --and tc.tc_id = addr.tc_id
    road_name asc,cust_name asc
end