
--
-- Definition for stored procedure sp_GetContCustomersv2 : 
--

--
-- Definition for stored procedure sp_GetContCustomersv2 : 
--

create procedure [rd].[sp_GetContCustomersv2](@in_Contract int)
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  select cust_id,
    cust_name=left(cust_surname_company +case when cust_initials is null then '' else ', ' + cust_initials end,63),
    cust_property_identification,
    cust_mailing_address_no,
    cust_mailing_address_road from
    customer where
    contract_no = @in_Contract order by
    cust_name asc
end