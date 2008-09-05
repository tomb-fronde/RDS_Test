/****** Object:  StoredProcedure [rd].[sp_rb_custlist_mailcat]    Script Date: 08/05/2008 10:22:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for stored procedure sp_rb_custlist_mailcat : 
--

create procedure [rd].[sp_rb_custlist_mailcat](@cust int)
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
 select mail_category.mc_description from customer_mail_category,mail_category where(mail_category.mc_key = customer_mail_category.mc_key) and((customer_mail_category.cust_id = @cust)) order by 1 asc end












GO
