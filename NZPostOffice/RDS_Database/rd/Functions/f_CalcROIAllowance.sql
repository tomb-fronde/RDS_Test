-- select new_net_amt = [rd].[f_CalcROIAllowance]( 65, 20000)
CREATE FUNCTION [rd].[f_CalcROIAllowance](
        @alt_key int
      , @investment decimal(10,2))
RETURNS decimal(10,2)
AS
BEGIN
  declare @Total decimal(10,2)

  select @Total = @Investment * (alt_rate/100)
    from rd.allowance_type
   where alt_key = @alt_key

   return @Total
END