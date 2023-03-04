
--
-- Definition for stored procedure sp_sync : 
--

create procedure [odps].[sp_sync](@a_sync_name char(30)= 'ALL') 
as
if upper(@a_sync_name) <> 'ALL' 
select sync_no,sync_name,sync_value 
from sync 
where 
sync_name = @a_sync_name
else 
select sync_no,sync_name,sync_value
 from sync