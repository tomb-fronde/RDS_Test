
--
-- Definition for stored procedure sp_Occupation : 
--

create procedure [rd].[sp_Occupation]
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  select occupation.occupation_id,
    occupation.occupation_description from
    occupation order by
    occupation.occupation_description asc
end