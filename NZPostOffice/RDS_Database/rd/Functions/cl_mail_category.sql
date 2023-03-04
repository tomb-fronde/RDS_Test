
create function [rd].[cl_mail_category](@icust_id int)
returns char(2000)
AS
BEGIN

  declare @sret char(2000),
  @stemp char(100)
  declare mail_cat cursor for select mail_category.mc_description from
      rd.customer_mail_category,
      rd.mail_category where
      (mail_category.mc_key = customer_mail_category.mc_key) and
      (customer_mail_category.cust_id = @icust_id) union
    select 'Business' from
      rd.customer where
      customer.cust_business = 'Y' and
      (customer.cust_id = @icust_id) union
    select 'Rural Residential' from
      rd.customer where
      customer.cust_rural_resident = 'Y' and
      (customer.cust_id = @icust_id) union
    select 'Rural Farmer' from
      rd.customer where
      customer.cust_rural_farmer = 'Y' and
      (customer.cust_id = @icust_id)
  open mail_cat
  /* Watcom only
  myloop:
  */while 1=1 
    begin
      fetch next from mail_cat into @stemp
      if @@fetch_status < 0 
        break
        /* Watcom only
        myloop
        */
      if Len(@sret) > 0
        select @sret=@sret + char(10) + char(13)
      select @sret=@sret + @stemp
    end
  close mail_cat
  return(@sret)
end