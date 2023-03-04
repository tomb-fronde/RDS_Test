
--
-- Definition for stored procedure sp_GetContCustomers : 
--

--
-- Definition for stored procedure sp_GetContCustomers : 
--

create procedure [rd].[sp_GetContCustomers](@in_Contract int)
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  select cust_id,
    cust_name=left(cust_surname_company + case when cust_initials is null then '' else ', ' + cust_initials end,63),
    customer_address=left(isnull(cust_mailing_address_no,'') +case when cust_mailing_address_road is null then '' else ' ' + cust_mailing_address_road end,55) from
    customer where
    contract_no = @in_Contract order by
    cust_name asc
end