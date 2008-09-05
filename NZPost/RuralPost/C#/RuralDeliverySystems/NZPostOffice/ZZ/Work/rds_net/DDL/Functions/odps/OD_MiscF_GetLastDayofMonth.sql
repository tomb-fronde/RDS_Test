/****** Object:  UserDefinedFunction [odps].[OD_MiscF_GetLastDayofMonth]    Script Date: 08/05/2008 11:22:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--
-- Definition for user-defined function OD_MiscF_GetLastDayofMonth : 
--

create function [odps].[OD_MiscF_GetLastDayofMonth](@indate datetime)
returns datetime
AS
BEGIN

  declare @p_temp datetime,
  @p_temp2 datetime
  select @p_temp = dateadd (day,28 - day(@indate),@indate)
 
  select @p_temp2 = DATEADD (day,1,@p_temp)
 
  if month(@p_temp) <> month(@p_temp2)
    return(dateadd(day, -1,@p_temp2))
  select @p_temp2 = dateadd(day,2,@p_temp) 
 
  if month(@p_temp) <> month(@p_temp2)
    return(dateadd(day,-1,@p_temp2))
  select @p_temp2 = dateadd(day,3,@p_temp) 
 
  if month(@p_temp) <> month(@p_temp2)
    return(dateadd(day,-1,@p_temp2))
  return(dateadd (day,31 - day(@indate),@indate))
end
GO
