﻿
--
-- Definition for stored procedure sp_GetCustomer32 : 
--

--
-- Definition for stored procedure sp_GetCustomer32 : 
--

create procedure [rd].[sp_GetCustomer32](@in_Customer int)
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  select customer.cust_id,
    customer.contract_no,
    customer.cust_title,
    customer.cust_surname_company,
    customer.cust_initials,
    customer.cust_rd_number,
    customer.cust_mailing_address_no,
    customer.cust_mailing_address_road,
    customer.cust_mailing_address_locality,
    customer.cust_mail_town,
    customer.cust_nad_reference,
    customer.cust_prior_customer,
    customer.cust_phone_day,
    customer.cust_phone_night,
    customer.cust_phone_mobile,
    customer.cust_dir_listing_ind,
    customer.cust_dir_listing_text,
    customer.cust_delivery_frequency,
    customer.cust_delivery_days,
    customer.cust_business,
    customer.cust_rural_resident,
    customer.cust_rural_farmer,
    customer.cust_old_delivery_days,
    customer.cust_adpost_quantity,
    customer.cust_date_first_loaded,
    customer.cust_date_last_transfered,
    customer.cust_date_left,
    cust_date_commenced,'','','',
    customer.cust_property_identification,
    customer.cust_post_code,
    customer.cust_category,
    post_code.post_code from
    rd.customer,rd.post_code where
    customer.cust_id = @in_Customer and
    --used to get the post code    
    post_code.post_mail_town = customer.cust_mail_town
end