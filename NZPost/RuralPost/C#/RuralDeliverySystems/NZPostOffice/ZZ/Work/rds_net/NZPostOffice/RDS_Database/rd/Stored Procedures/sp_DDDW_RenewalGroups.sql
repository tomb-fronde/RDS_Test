

--
-- Definition for stored procedure sp_DDDW_RenewalGroups : 
--

create procedure [rd].[sp_DDDW_RenewalGroups]
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  select rg_code,rg_description from renewal_group union
  select-1,'<All Renewal Groups>'  order by
    2 asc
end