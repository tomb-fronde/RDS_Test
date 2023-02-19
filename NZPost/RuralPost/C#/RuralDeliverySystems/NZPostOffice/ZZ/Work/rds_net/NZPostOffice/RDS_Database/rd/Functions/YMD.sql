
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