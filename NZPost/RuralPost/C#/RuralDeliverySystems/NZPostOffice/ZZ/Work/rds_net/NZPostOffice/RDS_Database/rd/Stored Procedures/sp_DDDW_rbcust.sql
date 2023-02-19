
--
-- Definition for stored procedure sp_DDDW_rbcust : 
--

create procedure [rd].[sp_DDDW_rbcust](@c int)
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  select cust_id from customer where cust_id in(@c)
end