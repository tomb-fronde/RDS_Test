-- select rd.f_CheckUnapprovedAllowance( 50002, 65),  rd.f_CheckUnapprovedAllowance( 50002, 2)
CREATE FUNCTION [rd].[f_CheckUnapprovedAllowance](
        @contract_no int
      , @alt_key int)
RETURNS datetime
AS
BEGIN
-- Returns the effective date of the most-recent unapproved --
-- allowance.  Primarily used th check if there are any     --
-- unapproved allowances of the type specified.             --
-- Returns null if none found.                              --

  declare @effDate datetime

  select @effDate = max(ca_effective_date)
    from rd.contract_allowance
   where contract_no = @contract_no
     and alt_key = @alt_key
     and ca_approved != 'Y'
     
   return @effDate
 END