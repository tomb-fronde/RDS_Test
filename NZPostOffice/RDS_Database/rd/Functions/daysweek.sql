
--
-- Definition for user-defined function daysweek : 
--

create function [rd].[daysweek](@inDelDays char(7))
returns int
AS
BEGIN

  declare @iLoop int,
  @iCount int
  select @iCount=0
  select @iLoop=1
  /* Watcom only
  CounterLoop:
  */while
  @iLoop <= 7
    begin
      if substring(@inDelDays,@iLoop,1) = 'Y'
        select @iCount=@iCount+1
      select @iLoop=@iLoop+1
    end
  return @iCount
end