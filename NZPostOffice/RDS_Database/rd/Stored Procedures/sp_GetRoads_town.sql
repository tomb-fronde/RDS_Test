 

--
-- Definition for stored procedure sp_GetRoads_town : 
--
 
create procedure [rd].[sp_GetRoads_town](@town_id int)
-- TJB  Sept 2005  NPAD2 address schema changes
-- Added road_suffix to relevant parts of addresses returned
-- TJB  OCT 2005
as -- Added RD no to temp tables so count is by road+rd_no
begin
set CONCAT_NULL_YIELDS_NULL off
 create table #road_ids(
    rd_id integer null,
    rd_no integer null,
    )
create table #del_counts(
    rd_id integer null,
    rd_no integer null,
    del_count integer null,
    ) 
insert into #road_ids(rd_id,rd_no)
    select distinct road_id,adr_rd_no from
      address where
      tc_id = @town_id
  insert into #del_counts(rd_id,rd_no,del_count)
    select distinct(addr.road_id),
      addr.adr_rd_no,
      count(addr.adr_id) from
      address as addr,
      #road_ids as rdi where
      addr.road_id = rdi.rd_id and
      addr.adr_rd_no = rdi.rd_no and
      addr.tc_id = @town_id
      group by addr.road_id,addr.adr_rd_no
  --  select distinct(rd.Road_name + ' ' +  rt.rt_name), 
  select road_name=rd.road_name +
    case when rt.rt_name is null then '' else ' '+rt.rt_name end+
    case when rs.rs_name is null then '' else ' '+rs.rs_name end,
    dc.rd_no,
    tc.tc_name,
    dc.del_count from
    #del_counts as dc,
    road as rd left outer join road_type as rt on rd.rt_id=rt.rt_id left outer join
    road_suffix as rs on rd.rs_id=rs.rs_id,
    towncity as tc where
    rd.road_id = dc.rd_id and
    tc.tc_id = @town_id
    --and addr.road_id = rd.road_id
    -- NOTE: the 'road_name' here is the alias for the road_name+road_type+road_suffix in the select part
    --       Also: this "group by" is probably redundant.
    group by road_name,
    dc.rd_no,
    tc.tc_name,
    dc.del_count,
 rt.rt_name,
 rs.rs_name
 order by
    road_name asc,dc.rd_no asc
end