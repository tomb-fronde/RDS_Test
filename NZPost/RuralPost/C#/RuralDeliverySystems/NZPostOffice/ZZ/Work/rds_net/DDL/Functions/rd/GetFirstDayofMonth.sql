/****** Object:  UserDefinedFunction [rd].[GetFirstDayofMonth]    Script Date: 08/05/2008 11:24:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


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
GO
