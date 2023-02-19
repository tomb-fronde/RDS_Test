-- DROP FUNCTION [rd].[f_GetAllowanceAmount]
/*
  select ca.contract_no, alt.alt_description, ca.ca_effective_date
       , ca.ca_annual_amount
       , [rd].[f_GetAllowanceAmount](ca.contract_no, ca.alt_key, ca_effective_date)
	              as net_amount
    from rd.contract_allowance ca 
               join rd.allowance_type alt
	                on alt.alt_key = ca.alt_key
   where ca.contract_no = 50002
	 and ca.alt_key = 55
   order by ca.ca_effective_date desc
*/
CREATE FUNCTION [rd].[f_GetAllowanceAmount](
        @Contract int
      , @alt_key int
      , @EffDate datetime)
RETURNS decimal(10,2)
AS
BEGIN
  -- Returns the net amount (summed ca_annual_amount) from all previous
  -- allowance entries in contract_allowance.

  declare @Total decimal(10,2)
  
  select @Total = sum(ca.ca_annual_amount)
    from rd.contract_allowance ca
   where ca.contract_no = @Contract
     and ca.alt_key = @alt_key
     and ca.ca_effective_date <= @EffDate

   return @Total
END