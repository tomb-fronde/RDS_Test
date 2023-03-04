



--
-- Definition for stored procedure get_redundant : 
--

create procedure -- This is a temporary procedure to find redundant town_road rows
[rd].[get_redundant]
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  create table #distinct_entry(
    tc_id integer null,
    rd_id integer null,
    )
create table #dist_string(
    pairing char(40) null,
    ) 
create table #tc_rd_string(
    pairing char(40) null,
    )
  -- get the distinct town and road pairings
  insert into #distinct_entry(tc_id,
    rd_id)
    select distinct tc_id,road_id from
      address
  -- build distinct strings
  insert into #dist_string(pairing)
    select convert(varchar,tc_id)+' '+convert(varchar,rd_id) from
      #distinct_entry
  -- put entries from town_road into temp table
  insert into #tc_rd_string(pairing)
    select convert(varchar,tc_id)+' '+convert(varchar,road_id) from
      town_road
  select pairing from
    #tc_rd_string where
    not pairing = any(select pairing from #dist_string)
end