
--
-- Definition for stored procedure sp_DDDW_RenewalGroupList : 
--

create procedure [rd].[sp_DDDW_RenewalGroupList]
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  select rg_code,rg_description from renewal_group
end