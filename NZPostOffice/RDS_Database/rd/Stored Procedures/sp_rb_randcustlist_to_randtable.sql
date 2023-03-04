
--
-- Definition for stored procedure sp_rb_randcustlist_to_randtable : 
--

create procedure [rd].[sp_rb_randcustlist_to_randtable](@rowno int) AS
BEGIN
 insert into t_rand_customer select distinct custid from t_customer where rownum = @rowno end