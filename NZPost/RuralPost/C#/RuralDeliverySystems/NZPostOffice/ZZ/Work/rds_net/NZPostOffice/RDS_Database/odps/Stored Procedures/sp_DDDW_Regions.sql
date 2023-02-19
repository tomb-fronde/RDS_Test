

--
-- Definition for stored procedure sp_DDDW_Regions : 
--

create procedure [odps].[sp_DDDW_Regions]
AS
BEGIN
  select region_id,
    rgn_name from
    rd.region union
  select 0,''   order by
    2 asc
end