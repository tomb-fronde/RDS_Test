
CREATE FUNCTION [rd].[f_numFreqDeliveryDays](@delivery_days char(7))
RETURNS int
AS
-- TJB 18-Nov-2013
-- Count the number of 'Y's in an rf_delivery_days string
BEGIN

  declare @NumDays int
        , @i int
        , @thisChar char(1)
        , @Y char(1)
        
  set @NumDays = 0
  set @i = 1
  set @Y = 'Y'
  
  while @i <= 7
  begin
      set @thisChar = substring(@delivery_days,@i,1)
      if @thisChar = @Y
          set @NumDays = @NumDays + 1
      set @i = @i + 1
  end

  return(@NumDays)
end