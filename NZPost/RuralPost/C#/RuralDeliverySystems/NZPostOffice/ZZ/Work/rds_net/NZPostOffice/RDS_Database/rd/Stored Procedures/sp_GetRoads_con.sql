create procedure [rd].[sp_GetRoads_con](@contract_id int)
-- TJB  Sept 2005  NPAD2 address schema changes
as -- Added road_suffix to relevant parts of addresses returned
begin
set CONCAT_NULL_YIELDS_NULL off
  create table #road_ids(
    rd_id integer null,
    )
  create table #del_counts(
    rd_id integer null,
    del_count integer null,
    ) insert into #road_ids(rd_id)
    select distinct addr.road_id from
      address as addr where
      addr.contract_no = @contract_id
  insert into #del_counts(rd_id,del_count)
    select distinct(addr.road_id),
      count(addr.adr_id) from
      address as addr,
      #road_ids as rdi where
      addr.road_id = rdi.rd_id and
      addr.contract_no = @contract_id
      group by addr.road_id
  --  select distinct(rd.Road_name + ' ' +  rt.rt_name), 
  select distinct(rd.road_name+case when rt.rt_name is null then '' else ' '+rt.rt_name end + case when rs.rs_name is null then '' else ' '+rs.rs_name end),
    addr.adr_rd_no,
    tc.tc_name,
    dc.del_count from
/*!
    address as addr join TownCity as tc on addr.tc_id=tc.tc_id,
    address as addr2 join road as rd on addr2.road_id=rd.road_id,
    road as rd2 left outer join road_type as rt on rd2.rt_id=rt.rt_id,
    road as rd3 left outer join road_suffix as rs on rd3.rs_id=rs.rs_id,
*/
    address as addr join TownCity as tc on addr.tc_id=tc.tc_id
	 join road as rd on addr.road_id=rd.road_id
	left outer join road_type as rt on rd.rt_id=rt.rt_id
	 left outer join road_suffix as rs on rd.rs_id=rs.rs_id,
    #del_counts as dc where
    addr.contract_no = @contract_id and
    --and addr.road_id = rd.road_id
    addr.road_id = dc.rd_id
    group by(rd.road_name+case when rt.rt_name is null then '' else ' '+rt.rt_name end+ case when rs.rs_name is null then '' else ' '+rs.rs_name end),    addr.adr_rd_no,
    tc.tc_name,
    dc.del_count order by
    (rd.road_name+case when  rt.rt_name is null then '' else ' '+rt.rt_name end+ case when rs.rs_name is null then '' else ' '+rs.rs_name end) asc
end