
--
-- Definition for user-defined function OD_MiscF_GetFinYear : 
--

create function [odps].[OD_MiscF_GetFinYear](@indate datetime,@intype char(1))
returns datetime
AS
BEGIN

  declare @v_fsdate datetime,
  @v_esdate datetime
  if month(@indate) > 3
    begin
      select @v_fsdate=convert(datetime,(convert(char,year(@indate))+'/04/01'))
      select @v_esdate=convert(datetime,(convert(char,year(@indate)+1)+'/03/31'))
    end
  else
    begin
      select @v_fsdate=convert(datetime,(convert(char,year(@indate)-1)+'/04/01'))
      select @v_esdate=convert(datetime,(convert(char,year(@indate))+'/03/31'))
    end
  if @intype = 'S'
    return(@v_fsdate)
  else
    return(@v_esdate)
 return (-1)
end