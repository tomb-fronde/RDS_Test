/****** Object:  StoredProcedure [odps].[OD_RPS_IR66N]    Script Date: 08/05/2008 10:14:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--
-- Definition for stored procedure OD_RPS_IR66N : 
--

create procedure [odps].[OD_RPS_IR66N](@sdate datetime,@edate datetime)
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  select GrossEarnings=(select sum(payment_component.pc_amount) from
      payment,payment_component,payment_component_type,payment_component_group where
      payment.invoice_id = payment_component.invoice_id and
      payment_component.pct_id = payment_component_type.pct_id and
      payment_component_type.pcg_id = payment_component_group.pcg_id and
      (payment_component_group.pcg_short_code = 'GP' or payment_component_group.pcg_short_code = 'OGP') and
      payment.invoice_date between @sdate and @edate),
    PayeDeductions=(select abs(sum(payment_component.pc_amount)) from
      payment,payment_component,payment_component_type,payment_component_group where
      payment.invoice_id = payment_component.invoice_id and
      payment_component.pct_id = payment_component_type.pct_id and
      payment_component_type.pcg_id = payment_component_group.pcg_id and
      payment_component_group.pcg_short_code = 'TAX' and
      payment.invoice_date between @sdate and @edate) 
end
GO
