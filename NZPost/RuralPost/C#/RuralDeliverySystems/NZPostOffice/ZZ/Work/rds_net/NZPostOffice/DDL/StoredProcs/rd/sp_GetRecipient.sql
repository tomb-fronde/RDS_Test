/****** Object:  StoredProcedure [rd].[sp_GetRecipient]    Script Date: 08/05/2008 10:20:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--
-- Definition for stored procedure sp_GetRecipient : 
--

create procedure [rd].[sp_GetRecipient](
@in_cust_id int)
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  select recipient.cust_id,
    recipient.recipient_id,
    recipient.rc_surname_company,
    recipient.rc_first_names from
    recipient where
    recipient.cust_id = @in_cust_id
end
GO
