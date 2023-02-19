
--
-- Definition for user-defined function GetFinYear : 
--

create function [rd].[GetFinYear](@indate datetime,@intype char(1))
returns datetime
AS
BEGIN

  declare @v_fsdate datetime,
  @v_esdate datetime
  if month(@indate) > 3
    begin
      select @v_fsdate=convert(datetime,convert(varchar,year(@indate))+'/07/01')
      select @v_esdate=convert(datetime,convert(varchar,year(@indate)+1)+'/06/30')
    end
  else
    begin
      select @v_fsdate=convert(datetime,convert(varchar,year(@indate)-1)+'/07/01')
      select @v_esdate=convert(datetime,convert(varchar,year(@indate))+'/06/30')
    end
  if @intype = 'S'
    return(@v_fsdate)
  else
    return(@v_esdate)
return getdate()
end