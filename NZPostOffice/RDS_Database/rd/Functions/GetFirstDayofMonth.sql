

--
-- Definition for user-defined function GetFirstDayofMonth : 
--

create function [rd].[GetFirstDayofMonth](@indate datetime)
returns datetime
AS
BEGIN

  declare @p_firstdayofmonth datetime
  select @p_firstdayofmonth = rd.ymd(year(@indate),month(@indate),1) 
  
  return(@p_firstdayofmonth)
end