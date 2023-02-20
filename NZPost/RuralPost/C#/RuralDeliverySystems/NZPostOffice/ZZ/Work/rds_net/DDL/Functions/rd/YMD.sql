/****** Object:  UserDefinedFunction [rd].[YMD]    Script Date: 08/05/2008 11:25:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for user-defined function YMD : 
--

create function [rd].[YMD] (@year int,@month int,@day int
)
RETURNS datetime
AS
BEGIN

  declare @returndate datetime
	declare @datestring varchar(100)
  select @datestring=convert(varchar,@month) + '-' + convert(varchar,@day) + '-' + convert(varchar,@year)
  select @returndate=convert(datetime,@datestring,110)
  return @returndate
END
GO
