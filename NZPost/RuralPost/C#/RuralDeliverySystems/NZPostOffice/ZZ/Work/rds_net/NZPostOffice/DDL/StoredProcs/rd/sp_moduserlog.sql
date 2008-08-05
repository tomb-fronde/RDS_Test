/****** Object:  StoredProcedure [rd].[sp_moduserlog]    Script Date: 08/05/2008 10:21:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for stored procedure sp_moduserlog : 
--

create procedure [rd].[sp_moduserlog](@cuserid char(20),@dExpiryDate datetime,@lGraceLogins int) AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  update userids set
    u_last_login_date = getdate(),
    u_last_login_time = getdate(),
    u_password_expiry = @dExpiryDate,
    u_grace_logins = @lGraceLogins where
    u_userid = @cUserid
  return @@error
end
GO
