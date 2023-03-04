
--
-- Definition for user-defined function f_GetDeliveryDays : 
--

create function [rd].[f_GetDeliveryDays_names](@ai_cust_id int)
returns varchar(70)
AS
BEGIN

  declare @sret char(7), @stemp1 varchar(70)

  select @sret=rd.f_GetDeliveryDays(@ai_cust_id)
  if @sret='NNNNNNN'
	return ('')

  set @stemp1=''
  if substring(@sret,1,1) = 'Y' 
	 set @stemp1=@stemp1 + ',Monday'
  if substring(@sret,2,1) = 'Y' 
	 set @stemp1=@stemp1 + ',Tuesday'
  if substring(@sret,3,1) = 'Y' 
	 set @stemp1=@stemp1 + ',Wednesday'
  if substring(@sret,4,1) = 'Y' 
	 set @stemp1=@stemp1 + ',Thursday'
  if substring(@sret,5,1) = 'Y' 
	 set @stemp1=@stemp1 + ',Friday'
  if substring(@sret,6,1) = 'Y' 
	 set @stemp1=@stemp1 + ',Saturday'
  if substring(@sret,7,1) = 'Y' 
	 set @stemp1=@stemp1 + ',Sunday'

  if len(@stemp1) >2
     set @stemp1 = substring(@stemp1,2,len(@stemp1)-1)

  return(@stemp1)
end