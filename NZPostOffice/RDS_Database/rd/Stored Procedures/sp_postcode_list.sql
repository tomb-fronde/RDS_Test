
--
-- Definition for stored procedure sp_postcode_list : 
--

create procedure -- Tim Chan 24/03/2003
-- This is a new procedure written as part of the resolution to service request 4474_01
-- 
[rd].[sp_postcode_list]
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  select pc.post_code+'   '+pc.post_mail_town,pc.post_code_id from
    post_code as pc order by
    pc.post_code asc
end