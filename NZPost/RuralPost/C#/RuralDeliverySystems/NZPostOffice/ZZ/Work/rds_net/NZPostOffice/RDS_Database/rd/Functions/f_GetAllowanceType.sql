-- select rd.f_GetAllowanceType( 2 ) as name

CREATE FUNCTION [rd].[f_GetAllowanceType](@alt_key int)
returns varchar(100)
AS
BEGIN
  declare @alt_description varchar(100)

  select @alt_description = alt_description
    from rd.allowance_type
   where alt_key = @alt_key

   return @alt_description
end