/****** Object:  StoredProcedure [rd].[sp_Connect]    Script Date: 08/05/2008 10:17:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for stored procedure sp_Connect : 
--

create procedure [rd].[sp_Connect](@inUserid char(20),@inPassword char(20))
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  select u.u_cargo,
    g.gp_level_1,
    g.gp_level_2,
    g.gp_level_3,
    g.gp_level_4,
    g.gp_level_5,
    g.gp_level_6,
    g.gp_level_7,
    g.gp_level_8,
    g.gp_level_9,
    g.gp_cargo,
    u.region_id,
    u.u_password_expiry,
    u.u_grace_logins,
    u.u_code,
    u_locked_date from
    userids as u,
    user_groups as g where
    (u.gp_code = g.gp_code) and
    (u.u_userid = @inUserid) and
    (u.u_password = @inPassword)
end
GO
