/****** Object:  StoredProcedure [rd].[sp_Extension_CustCount2]    Script Date: 08/05/2008 10:18:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for stored procedure sp_Extension_CustCount2 : 
--

create procedure [rd].[sp_Extension_CustCount2](@inContract int,@inComponentId int,@inUIUserId char(20))
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  select count(*) from
    contract as c,
    outlet as o where
    c.contract_no = @inContract and
    o.outlet_id = c.con_lodgement_office and
    exists(select rds_user_rights.region_id from
      rds_user_rights,
      rds_user_id,
      rds_user_id_group where
      rds_user_id.ui_id = rds_user_id_group.ui_id and
      rds_user_id_group.ug_id = rds_user_rights.ug_id and
      (rds_user_rights.rur_create = 'Y') and
      (rds_user_id.ui_userid = @inUIUserId) and
      (rds_user_rights.rc_id = @inComponentId) and
      (o.region_id = rds_user_rights.region_id or
      (rds_user_rights.region_id = 0 and o.region_id = 
      (select rds_user.region_id from
        rds_user where
        rds_user.u_id = rds_user_id.u_id)) or
      (rds_user_rights.region_id = 0 and-1 = 
      (select rds_user.region_id from
        rds_user where
        rds_user.u_id = rds_user_id.u_id))))
end
GO
