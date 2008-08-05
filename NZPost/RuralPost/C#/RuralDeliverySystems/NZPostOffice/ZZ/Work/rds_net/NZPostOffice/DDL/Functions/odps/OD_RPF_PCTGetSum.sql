/****** Object:  UserDefinedFunction [odps].[OD_RPF_PCTGetSum]    Script Date: 08/05/2008 11:22:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for user-defined function OD_RPF_PCTGetSum : 
--

create function [odps].[OD_RPF_PCTGetSum](@Invoice int,@ShortCode char(5))
returns decimal(12,2)
AS
BEGIN

  declare @amt decimal(12,2)
  select @amt = sum(t_payment_component.pc_amount) 
    from t_payment_component,payment_component_type,payment_component_group where
    t_payment_component.invoice_id = @invoice and
    t_payment_component.pct_id = payment_component_type.pct_id and
    --Added 16/09/1999,this stops it from adding Kiwimail ,Courierpost and XP.
    --So that the extension ,Standard and allowance are the only values that are 
    --calculated.  
    payment_component_type.pct_id <> 7 and
    payment_component_type.pct_id <> 9 and
    payment_component_type.pct_id <> 13 and
    payment_component_type.pcg_id = payment_component_group.pcg_id and
    payment_component_group.pcg_short_code = @ShortCode
  if @amt is null
    return 0
  else
    return @amt
return -1
end
GO
