
--
-- Definition for stored procedure sp_rb_custlist_count2 : 
--

create procedure [rd].[sp_rb_custlist_count2](@region int,@outlet int,@mailcat int,@contract int,@dirlist char(1))
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
 select count(distinct customer.cust_id) from contract,customer,customer_mail_category,mail_category,outlet where(customer.cust_id = customer_mail_category.cust_id) and(@contract.contract_no = customer.contract_no) and(mail_category.mc_key = customer_mail_category.mc_key) and(@outlet.outlet_id = @contract.con_base_office) and((@outlet.region_id = @REGION and @REGION <> -1) or(@REGION = -1)) and((@outlet.outlet_id = @OUTLET and @OUTLET <> -1) or(@OUTLET = -1)) and((mail_category.mc_key = @MAILCAT and @MAILCAT <> -1) or(@MAILCAT = -1)) and((@contract.contract_no = @CONTRACT and @CONTRACT <> -1) or(@CONTRACT = -1)) and((customer.cust_dir_listing_ind = @DIRLIST)) end