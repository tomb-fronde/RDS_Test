-- DROP FUNCTION [rd].[f_CalcActivityAllowance]
CREATE FUNCTION [rd].[f_CalcActivityAllowance](
        @alt_key int
      , @activity_count numeric(10,2))
RETURNS numeric(10,2)
AS
BEGIN
  declare @Total numeric(10,2)

  select @Total = (@activity_count * alt_wks_yr) * alt_rate
    from rd.allowance_type
   where alt_key = @alt_key

   return @Total
END