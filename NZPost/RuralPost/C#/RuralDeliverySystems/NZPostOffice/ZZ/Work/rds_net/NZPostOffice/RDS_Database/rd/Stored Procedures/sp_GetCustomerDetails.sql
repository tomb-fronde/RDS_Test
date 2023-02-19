

--
-- Definition for stored procedure sp_GetCustomerDetails : 
--

--
-- Definition for stored procedure sp_GetCustomerDetails : 
--

create procedure [rd].[sp_GetCustomerDetails]
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  -- PBY 30/05/2002 SR#4389 Extended f_GetContractNo char size from 60 to 300.
  select distinct rds_customer.cust_id,
    rds_customer.cust_title,
    rds_customer.cust_initials,
    rds_customer.cust_surname_company,
    rds_customer.cust_phone_day,
    rds_customer.cust_phone_night,
    rds_customer.cust_phone_mobile,
    rds_customer.cust_dir_listing_ind,
    rds_customer.cust_dir_listing_text,
    rds_customer.cust_date_commenced,
    rds_customer.cust_adpost_quantity,
    rd.f_GetCustomerAddresses(rds_customer.cust_id),
    rd.f_GetMailCategory(rds_customer.cust_id),
    rd.f_GetDeliveryDays(rds_customer.cust_id),
    rd.f_GetRecipients(rds_customer.cust_id),
    rd.f_GetContractNo(rds_customer.cust_id) from
    rds_customer where
    rds_customer.cust_id = any(select customer_id from report_temp)
end

SET CONCAT_NULL_YIELDS_NULL OFF;