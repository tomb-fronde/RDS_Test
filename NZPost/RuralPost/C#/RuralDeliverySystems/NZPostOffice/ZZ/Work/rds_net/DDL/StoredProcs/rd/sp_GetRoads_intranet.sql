/****** Object:  StoredProcedure [rd].[sp_GetRoads_intranet]    Script Date: 08/05/2008 10:21:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [rd].[sp_GetRoads_intranet]
-- MRB Aug 2006 Used to generate export file for populating
-- Rural Post Intranet Road Serach tables.
as -- Called from outside RDS application (i.e. iSQL)
begin
set CONCAT_NULL_YIELDS_NULL off
  create table #road_ids(
    rd_id integer null,
    rd_no char(3) null,
    ) 
create table #del_counts(
    rd_id integer null,
    rd_no char(3) null,
    tc_id integer null,
    contract_no integer null,
    del_count integer null,
    ) 
  create table #road_nos(
    rd_id integer null,
    rd_no char(3) null,
    tc_id integer null,
    min_no char(10) null,
    max_no char(10) null,
    ) 
insert into #road_ids(rd_id,rd_no)
    select distinct road_id,adr_rd_no from
      address where
      contract_no < 6000
  insert into #del_counts(rd_id,rd_no,tc_id,contract_no,del_count)
    select distinct(addr.road_id),
      addr.adr_rd_no,addr.tc_id,addr.contract_no,
      count(addr.adr_id) from
      address as addr,
      #road_ids as rdi where
      addr.road_id = rdi.rd_id and
      addr.adr_rd_no = rdi.rd_no and
      addr.contract_no < 6000
      group by addr.contract_no,addr.road_id,addr.adr_rd_no,addr.tc_id
  insert into #road_nos(rd_id,rd_no,tc_id,min_no,max_no)
    select road_id,adr_rd_no,tc_id,min(convert(integer,adr_no)),max(convert(integer,adr_no)) from
      address where
      contract_no < 6000
      group by contract_no,adr_rd_no,tc_id,road_id
  --  select distinct(rd.Road_name + ' ' +  rt.rt_name), 
  select dc.contract_no,
    rn.min_no,
    rn.max_no,
    rd.road_name,
    road_type=ltrim(rtrim(isnull(rt.rt_name,'')+' '+isnull(rs.rs_name,'') )),
    tc.tc_name,
    dc.rd_no,
    dc.del_count from
    #del_counts as dc,
    road as rd left outer join road_type as rt on rd.rt_id=rt.rt_id left outer join
    road_suffix as rs on rd.rs_id=rs.rs_id,
    towncity as tc,
    #road_nos as rn where
    rd.road_id = dc.rd_id and
    rd.road_id = rn.rd_id and
    dc.tc_id = tc.tc_id and
    dc.tc_id = rn.tc_id and
    dc.rd_no = rn.rd_no
    --and addr.road_id = rd.road_id
    -- NOTE: the 'road_name' here is the alias for the road_name+road_type+road_suffix in the select part
    --       Also: this "group by" is probably redundant.
    group by dc.contract_no,
    rd.road_name,
    ltrim(rtrim(isnull(rt.rt_name,'')+' '+isnull(rs.rs_name,'') )),
    dc.rd_no,
    tc.tc_name,
    dc.del_count,
    rn.min_no,
    rn.max_no order by
    road_name asc,dc.rd_no asc
end
GO
