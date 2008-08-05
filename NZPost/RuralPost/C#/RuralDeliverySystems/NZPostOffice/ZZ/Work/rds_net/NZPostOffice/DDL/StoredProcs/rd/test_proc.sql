/****** Object:  StoredProcedure [rd].[test_proc]    Script Date: 08/05/2008 10:23:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [rd].[test_proc]  AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
/*   select   count(distinct rd.customer.cust_id) 
from rd.customer join rd.contract 
left outer join rd.customer_mail_category  --join rd.contract 
join rd.outlet on rd.contract.con_base_office = rd.outlet.outlet_id 
where rd.outlet.region_id = 6 and rd.outlet.outlet_id = 1532 
and rd.daysweek(rd.customer.cust_delivery_days) = 5
*/
return
END
GO
