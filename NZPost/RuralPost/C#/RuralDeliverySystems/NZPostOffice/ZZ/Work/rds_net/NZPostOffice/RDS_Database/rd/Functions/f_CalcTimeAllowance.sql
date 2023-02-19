-- DROP FUNCTION [rd].[f_CalcTimeAllowance]
CREATE FUNCTION [rd].[f_CalcTimeAllowance](
        @alt_key int
      , @hours_wk decimal(10,2))
RETURNS decimal(10,2)
AS
BEGIN
  declare @Total decimal(10,2)

  select @Total = (@hours_wk * alt_wks_yr * alt_rate) 
                             * (1.0 + (alt_acc/100))
    from rd.allowance_type
   where alt_key = @alt_key

   return @Total
END