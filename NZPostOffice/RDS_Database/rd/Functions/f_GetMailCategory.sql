


--
-- Definition for user-defined function f_GetMailCategory : 
--

create function [rd].[f_GetMailCategory](@ai_cust_id int)
returns char(2000)
AS
BEGIN

  declare @sret varchar(2000),
  @stemp varchar(100)
  declare mail_cat cursor for select 'Business' from
      rd.rds_customer where
      rds_customer.cust_business = 'Y' and
      (rds_customer.cust_id = @ai_cust_id) union
    select 'Rural Residential' from
      rd.rds_customer where
      rds_customer.cust_rural_resident = 'Y' and
      (rds_customer.cust_id = @ai_cust_id) union
    select 'Rural Farmer' from
      rd.rds_customer where
      rds_customer.cust_rural_farmer = 'Y' and
      (rds_customer.cust_id = @ai_cust_id)
  open mail_cat
  fetch next from mail_cat into @stemp
  select @sret=@stemp
  close mail_cat
  return(@sret)
end