-- select [rd].[f_CalcAllowanceNetAmount]( 50002, 23 )
CREATE FUNCTION [rd].[f_CalcAllowanceNetAmount](
        @contract_no int
      , @alt_key int)
RETURNS numeric(10,2)
AS
BEGIN
-- Calculates the net amount of a contract's allowances 
-- (approved and not approved)
  declare @Total decimal(10,2)

  select @Total = sum(ca.ca_annual_amount)
    from rd.contract_allowance ca
   where ca.contract_no = @contract_no
     and ca.alt_key = @alt_key

  return @Total
END