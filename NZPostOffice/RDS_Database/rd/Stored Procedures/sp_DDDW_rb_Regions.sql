
--
-- Definition for stored procedure sp_DDDW_rb_Regions : 
--

create procedure [rd].[sp_DDDW_rb_Regions](@ri int)
AS
BEGIN
  select region_id,rgn_name from
    region where
    ((region_id = @ri and @ri is not null and @ri <> -1) or
    (@ri = -1)) order by
    2 asc
end