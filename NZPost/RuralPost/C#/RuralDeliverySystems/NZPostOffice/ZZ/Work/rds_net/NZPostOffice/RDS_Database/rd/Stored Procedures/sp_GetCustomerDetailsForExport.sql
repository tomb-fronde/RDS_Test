
--
-- Definition for stored procedure sp_GetCustomerDetailsForExport : 
--

--
-- Definition for stored procedure sp_GetCustomerDetailsForExport : 
--

create procedure [rd].[sp_GetCustomerDetailsForExport]
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  select distinct rds_customer.cust_id,
    rds_customer.cust_title,
    rds_customer.cust_initials,
    rds_customer.cust_surname_company,
    rds_customer.cust_phone_day,
    rds_customer.cust_phone_night,
    rds_customer.cust_phone_mobile,
    rd.f_GetCustomerAddresses(rds_customer.cust_id),
    rd.f_GetMailCategory(rds_customer.cust_id),
    rd.f_GetRecipients(rds_customer.cust_id),
    rd.f_GetContractNo(rds_customer.cust_id) from
    rds_customer where
    rds_customer.cust_id = any(select customer_id from report_temp)
end