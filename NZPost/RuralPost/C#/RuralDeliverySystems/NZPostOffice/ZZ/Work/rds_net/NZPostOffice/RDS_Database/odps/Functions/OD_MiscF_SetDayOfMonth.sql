--select [odps].[OD_MiscF_SetDayOfMonth]( 20, getdate())

CREATE FUNCTION [odps].[OD_MiscF_SetDayOfMonth] (
    @inDay int,
    @inDate datetime)
RETURNS datetime
AS
BEGIN
  -- TJB  RPCR_128  June-2019: New
  -- Returns the @inDay of @inDate 
  declare @returndate datetime
  set @returnDate = dateadd(day,@inDay - day(@inDate),@inDate)
  set @returnDate = DATEADD(dd, DATEDIFF(dd, 0, @returnDate), 0)
  
  return @returndate
END