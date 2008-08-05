/****** Object:  UserDefinedFunction [rd].[f_transform_telno]    Script Date: 08/05/2008 11:24:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for user-defined function f_transform_telno : 
--

create function [rd].[f_transform_telno](@oldtelno char(20))
returns char(20)
AS
BEGIN

  declare @newtelno char(20),
  @temptelno char(20),
  @ii integer,
  @newtelno2 char(20),
  @ismobile char(1)
  if @oldtelno is null
    return @oldtelno
  select @temptelno=rd.trim(@oldtelno)
  select @newtelno2=''
  select @newtelno=''
  if left(@temptelno,4) = '021 ' or left(@temptelno,4) = '025 ' or left(@temptelno,4) = '021-' or left(@temptelno,4) = '025-'
    select @ismobile='Y'
  while len(@temptelno) > 0
    begin
      if ascii(left(@temptelno,1)) > 47 and ascii(left(@temptelno,1)) < 58
        begin
          select @newtelno=@newtelno + left(@temptelno,1)
          if left(@newtelno,2) = '00'
            select @newtelno=right(@newtelno,len(@newtelno)-1)
        end
      select @temptelno=right(@temptelno,len(@temptelno)-1)
    end
  if @newtelno = '0'
    return null
  select @newtelno2=@newtelno
  if @ismobile = 'Y'
    select @newtelno=left(@newtelno2,3) + '-' + SUBSTRING (@newtelno2,4,3) + '-' + case when len(@newtelno2) > 6 then right(@newtelno2,len(@newtelno2)-6) else '' end
  else
    if left(@newtelno,1) = '0'
      select @newtelno=left(@newtelno2,2) + '-' + SUBSTRING (@newtelno2,3,3) + '-' + case when len(@newtelno2) > 5 then right(@newtelno2,len(@newtelno2)-5) else '' end
    else
      select @newtelno=left(@newtelno2,3) + '-' + case when len(@newtelno2) > 3 then right(@newtelno2,len(@newtelno2)-3) else '' end
  if @newtelno = '--' or @newtelno = '-'
    return null
  return @newtelno
end
GO
