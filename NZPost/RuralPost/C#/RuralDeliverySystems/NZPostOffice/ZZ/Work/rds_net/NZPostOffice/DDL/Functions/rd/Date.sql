/****** Object:  UserDefinedFunction [rd].[Date]    Script Date: 08/05/2008 11:23:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for user-defined function Date : 
--

create function [rd].[Date] (@inputDate Datetime
)
RETURNS datetime
AS
BEGIN

  declare @returndate datetime
   select @returndate= DATEADD(hour, -1*datepart(hour,@inputDate), @inputDate)
  select @returndate= DATEADD(minute, -1*datepart(minute,@returndate), @returndate)
  select @returndate= DATEADD(second, -1*datepart(second,@returndate), @returndate)
	select @returndate= DATEADD(millisecond, -1*datepart(millisecond,@returndate), @returndate)
    return @returndate
END
GO
