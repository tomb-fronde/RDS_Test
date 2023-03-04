
--
-- Definition for stored procedure OD_CTS_PaymentComponents : 
--

create procedure [rd].[OD_CTS_PaymentComponents]
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  select payment_component_type.pct_id,
    payment_component_type.pct_description,
    payment_component_group.pcg_short_code from
    odps.payment_component_group,
    odps.payment_component_type where
    (payment_component_type.pcg_id = payment_component_group.pcg_id) order by 2 asc
end