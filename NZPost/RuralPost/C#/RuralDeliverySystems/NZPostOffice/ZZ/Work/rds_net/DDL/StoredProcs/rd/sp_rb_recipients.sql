/****** Object:  StoredProcedure [rd].[sp_rb_recipients]    Script Date: 08/05/2008 10:22:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for stored procedure sp_rb_recipients : 
--

create procedure [rd].[sp_rb_recipients](@cust int,@printrecipient char(1))
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  select rd.trim(recipient.rc_surname_company) + ' ' + rd.trim(recipient.rc_first_names) from
    recipient where
    (recipient.cust_id = @cust) and
    (@printrecipient = 'Y') order by 1 asc
end
GO
