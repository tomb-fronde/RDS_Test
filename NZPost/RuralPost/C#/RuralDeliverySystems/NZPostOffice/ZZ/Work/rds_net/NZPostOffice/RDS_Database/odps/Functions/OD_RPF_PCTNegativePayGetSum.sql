
--
-- Definition for user-defined function OD_RPF_PCTNegativePayGetSum : 
--

create function [odps].[OD_RPF_PCTNegativePayGetSum](@Invoice int,@ShortCode char(5))
returns decimal(12,2)
AS
BEGIN

  declare @amt decimal(12,2)
  select @amt = sum(t_payment_component.pc_amount) 
    from t_payment_component,
    payment_component_type,payment_component_group where
    t_payment_component.invoice_id = @invoice and
    t_payment_component.pct_id = payment_component_type.pct_id and
    payment_component_type.pcg_id = payment_component_group.pcg_id and
    payment_component_group.pcg_short_code = @ShortCode
  if @amt is null
    return 0
  else
    return @amt
return -1
end