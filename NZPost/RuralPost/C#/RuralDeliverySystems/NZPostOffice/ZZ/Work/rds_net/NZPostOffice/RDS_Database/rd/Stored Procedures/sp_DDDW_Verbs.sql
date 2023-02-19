

--
-- Definition for stored procedure sp_DDDW_Verbs : 
--

create procedure  [rd].[sp_DDDW_Verbs]
AS
BEGIN
  select rfv_id,rfv_description from
    route_freq_verbs order by
    rfv_description asc
end