
--
-- Definition for stored procedure OD_CTS_PaymentComponentType : 
--

create procedure [odps].[OD_CTS_PaymentComponentType]
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  select pct_id,
    pct_description from
    payment_component_type order by 2 asc
end