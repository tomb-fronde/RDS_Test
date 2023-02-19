
--
-- Definition for stored procedure sp_interest : 
--

create procedure [rd].[sp_interest]
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  select interest.interest_id,
    interest.interest_description from
    interest order by
    interest.interest_description asc
end