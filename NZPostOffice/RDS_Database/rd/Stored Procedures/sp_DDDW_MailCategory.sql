
--
-- Definition for stored procedure sp_DDDW_MailCategory : 
--

create procedure [rd].[sp_DDDW_MailCategory](@in_Business char(1),@in_Residential char(1),@in_Farmer char(1))
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  select mail_category.mc_key,
    mail_category.mc_description,
    mail_category.mc_mail_category from
    mail_category where
    mail_category.mc_mail_category in(@in_Business,@in_Residential,@in_Farmer)
end