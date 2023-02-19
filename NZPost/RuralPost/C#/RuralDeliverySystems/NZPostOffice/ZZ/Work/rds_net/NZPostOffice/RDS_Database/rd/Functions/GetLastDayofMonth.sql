

--
-- Definition for user-defined function GetLastDayofMonth : 
--

create function [rd].[GetLastDayofMonth](@indate datetime)
returns datetime
AS
BEGIN

  declare @p_temp datetime,
  @p_temp2 datetime
  select @p_temp = rd.ymd(year(@indate),month(@indate),28) 
 
  select @p_temp2 = dateadd(day,1,@p_temp) 
 
  if month(@p_temp) <> month(@p_temp2)
    return(dateadd(day,-1,@p_temp2))
  select @p_temp2 = dateadd(day,2,@p_temp) 
 
  if month(@p_temp) <> month(@p_temp2)
    return(dateadd(day,-1,@p_temp2))
  select @p_temp2 = dateadd(day,3,@p_temp) 
 
  if month(@p_temp) <> month(@p_temp2)
    return(dateadd(day,-1,@p_temp2))
  return(rd.ymd(year(@indate),month(@indate),31))
end