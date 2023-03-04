
--
-- Definition for stored procedure sp_occupation_list : 
--

create procedure -- Tim Chan 24/03/2003
-- This is a new procedure written as part of the resolution to service request 4474_01
-- 
[rd].[sp_occupation_list]
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  select occ.occupation_description,occ.occupation_id from
    occupation as occ order by
    occ.occupation_description asc
end