

--
-- Definition for user-defined function OD_MiscF_GetFirstDayofMonth : 
--

create function [odps].[OD_MiscF_GetFirstDayofMonth](@indate datetime)
returns datetime
AS
BEGIN

  declare @p_firstdayofmonth datetime
  select @p_firstdayofmonth = dateadd (day,1 - day(@indate),@indate) 
 
  return(@p_firstdayofmonth)
end