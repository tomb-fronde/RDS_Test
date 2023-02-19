create procedure [rd].[sp_rb_custlist](@region int,@outlet int,@mailcat int,@contract int,@d_monday char(1),@d_tuesday char(1),@d_wednesday char(1),@d_thursday char(1),@d_friday char(1),@d_saturday char(1),@d_sunday char(1),@d_freq int,@dirlist char(1),@newcust datetime,@transcust datetime,@leftcust datetime,@printrecipient char(1))
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off 
select distinct 
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
customer.cust_phone_day,
customer.cust_phone_night,
customer.cust_dir_listing_text,
customer.cust_delivery_frequency,
customer.cust_delivery_days,
customer.cust_business,
customer.cust_rural_resident,
customer.cust_rural_farmer,
customer.cust_date_first_loaded,
customer.cust_date_last_transfered,
customer.cust_date_left,
customer.cust_id 
from contract,
customer,
customer_mail_category,
outlet 
where

(customer.cust_id = customer_mail_category.cust_id) 
and(@contract.contract_no = customer.contract_no) 
and(@outlet.outlet_id = @contract.con_base_office) 
and((@outlet.region_id = @REGION and @REGION <> -1) or(@REGION = -1)) 

and((@outlet.outlet_id = @OUTLET and @OUTLET <> -1) or(@OUTLET = -1)) 
and((customer_mail_category.mc_key = @MAILCAT and @MAILCAT <> -1) or(@MAILCAT = -1)) 
and((@contract.contract_no = @CONTRACT and @CONTRACT <> -1) or(@CONTRACT = -1)) 
and((LEFT(customer.cust_delivery_days,1) = @D_MONDAY or substring(customer.cust_delivery_days,2,1) = @D_TUESDAY or substring(customer.cust_delivery_days,3,1) = @D_WEDNESDAY or substring(customer.cust_delivery_days,4,1) = @D_THURSDAY or substring(customer.cust_delivery_days,5,1) = @D_FRIDAY or substring(customer.cust_delivery_days,6,1) = @D_SATURDAY or substring(customer.cust_delivery_days,7,1) = @D_SUNDAY or customer.cust_delivery_days is null)) 
and((customer.cust_dir_listing_ind = @DIRLIST)) 
and((customer.cust_delivery_frequency = @d_freq and @d_freq <> -1) or(@d_freq = -1)) and((customer.cust_date_first_loaded between @NEWCUST and rd.Today() and @NEWCUST is not null) or(@NEWCUST is null)) and((customer.cust_date_last_transfered between @TRANSCUST and rd.TODAY() and @TRANSCUST is not null) or(@TRANSCUST is null)) and((customer.cust_date_left between @LEFTCUST and rd.TODAY() and @LEFTCUST is not null) or(@LEFTCUST is null)) order by 3 asc end