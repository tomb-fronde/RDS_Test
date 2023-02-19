
--
-- Definition for stored procedure OD_CTS_AccountCodes : 
--

create procedure [rd].[OD_CTS_AccountCodes]
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  select Account_Codes.ac_id,
    Account_Codes.ac_code,
    Account_Codes.ac_description from
    odps.account_codes order by 2 asc
end