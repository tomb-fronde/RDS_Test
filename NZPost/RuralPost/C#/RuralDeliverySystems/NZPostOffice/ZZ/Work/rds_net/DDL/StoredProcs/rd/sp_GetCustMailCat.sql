/****** Object:  StoredProcedure [rd].[sp_GetCustMailCat]    Script Date: 08/05/2008 10:19:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [rd].[sp_GetCustMailCat](@in_Cust_Id int)
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  select customer_mail_category.cust_id,
    customer_mail_category.mc_key from
    customer_mail_category where
    customer_mail_category.cust_id = @in_cust_id
end
GO
