/****** Object:  UserDefinedFunction [odps].[OD_MiscF_GetFirstDayofMonth]    Script Date: 08/05/2008 11:22:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


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
GO
