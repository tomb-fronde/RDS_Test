/****** Object:  UserDefinedFunction [rd].[today]    Script Date: 08/05/2008 11:25:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for user-defined function today : 
--

create function [rd].[today] (
)
RETURNS datetime
AS
BEGIN

  declare @nowdate datetime
  declare @returndate datetime
  select @nowdate=getdate()
  select @returndate= DATEADD(hour, -1*datepart(hour,@nowdate), @nowdate)
  select @returndate= DATEADD(minute, -1*datepart(minute,@nowdate), @returndate)
  select @returndate= DATEADD(second, -1*datepart(second,@nowdate), @returndate)
	select @returndate= DATEADD(millisecond, -1*datepart(millisecond,@nowdate), @returndate)
  
  return @returndate
END
GO
