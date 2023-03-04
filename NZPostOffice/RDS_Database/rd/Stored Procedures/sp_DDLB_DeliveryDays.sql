

--
-- Definition for stored procedure sp_DDLB_DeliveryDays : 
--

create procedure [rd].[sp_DDLB_DeliveryDays]
AS
BEGIN
 select-1,'<All>' union select 0,'<None>' 
union select 1,'Once a week' 
union select 2,'Twice a week' 
union select 3,'Thrice a week' 
union select 4,'Four times a week' 
union select 5,'Five times a week' 
union select 6,'Six times a week' 
union select 7,'Seven times a week' 
end