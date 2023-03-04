
--
-- Definition for user-defined function f_GetDeliveryDays : 
--

create function [rd].[f_GetDeliveryDays](@ai_cust_id int)
returns char(7)
AS
BEGIN

  declare @sret char(7),
  @stemp1 char(7)
  /*declare Delivery_days  cursor for select address_frequency_sequence.rf_delivery_days from
      address,
      address_frequency_sequence,
      customer_address_moves,
      rds_customer where
      (address_frequency_sequence.adr_id = address.adr_id) and
      (customer_address_moves.adr_id = address.adr_id) and
      (rds_customer.cust_id = customer_address_moves.cust_id) and
      ((rds_customer.master_cust_id is null) and
      (rds_customer.cust_id = @ai_cust_id))
  open Delivery_days
  fetch next from Delivery_days into @stemp1
  select @sret=isnull(@stemp1,'NNNNNNN')
  close Delivery_days*/
select top 1 @stemp1=address_frequency_sequence.rf_delivery_days from
      address,
      address_frequency_sequence,
      customer_address_moves,
      rds_customer where
      (address_frequency_sequence.adr_id = address.adr_id) and
      (customer_address_moves.adr_id = address.adr_id) and
      (rds_customer.cust_id = customer_address_moves.cust_id) and
      ((rds_customer.master_cust_id is null) and
      (rds_customer.cust_id = @ai_cust_id))
  select @sret=isnull(@stemp1,'NNNNNNN')

  return(@sret)
end