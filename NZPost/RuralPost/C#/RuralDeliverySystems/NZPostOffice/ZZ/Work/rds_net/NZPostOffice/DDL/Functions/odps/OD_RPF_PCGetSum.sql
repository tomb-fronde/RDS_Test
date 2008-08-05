/****** Object:  UserDefinedFunction [odps].[OD_RPF_PCGetSum]    Script Date: 08/05/2008 11:22:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for user-defined function OD_RPF_PCGetSum : 
--

create function [odps].[OD_RPF_PCGetSum](@Invoice int,@ShortCode char(5))
returns decimal(12,2)
AS
BEGIN

  -- TJB SR4611 2 Aug 2004
  -- Add clauses to calculate taxable allowances sttributed to NZH (NZ Herald)
  -- and Guardian (amt2), then deduct this from the gross pay calculated (amt1).
  -- Note: if the '... not like ...' clauses are included in the gross pay
  -- statement, rows with NULL values in the misc_string column are also excluded.
  declare @amt1 decimal(12,2),
  @amt2 decimal(12,2)
  select @amt1 = sum(payment_component.pc_amount) 
    from payment_component,
    payment_component_type,
    payment_component_group where
    payment_component.invoice_id = @invoice and
    --Added 16/09/1999,this stops it from adding Kiwimail, Courierpost and XP.
    --So that the extension, Standard and allowance are the only values that are 
    --calculated.
    -- TJB 2-Aug-2004 - changed to 'not in ...' syntax
    payment_component.pct_id not in(7,9,13) and
    payment_component.pct_id = payment_component_type.pct_id and
    payment_component_type.pcg_id = payment_component_group.pcg_id and
    payment_component_group.pcg_short_code = @ShortCode
  select @amt2 = sum(payment_component.pc_amount) 
    from payment_component,
    payment_component_type,
    payment_component_group where
    payment_component.invoice_id = @invoice and
    payment_component.pct_id not in(7,9,13) and
    (payment_component.misc_string like '%NZH%' or
    payment_component.misc_string like '%Guardian%') and
    payment_component.pct_id = payment_component_type.pct_id and
    payment_component_type.pcg_id = payment_component_group.pcg_id and
    payment_component_group.pcg_short_code = @ShortCode
  select @amt1=isnull(@amt1,0)-isnull(@amt2,0)
  return @amt1
end
GO
