/****** Object:  StoredProcedure [odps].[od_cts_accountcodes]    Script Date: 08/05/2008 10:13:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for stored procedure OD_CTS_AccountCodes : 
--

create procedure [odps].[od_cts_accountcodes]
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  select Account_Codes.ac_id,
    Account_Codes.ac_code,
    Account_Codes.ac_description from
    odps.account_codes order by 2 asc
end
GO
