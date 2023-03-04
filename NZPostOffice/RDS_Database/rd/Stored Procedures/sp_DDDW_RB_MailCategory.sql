
--
-- Definition for stored procedure sp_DDDW_RB_MailCategory : 
--

create procedure [rd].[sp_DDDW_RB_MailCategory]
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off 
select mail_category.mc_key,mail_category.mc_description from mail_category union select-1,'<All>'  order by 2 asc 
end