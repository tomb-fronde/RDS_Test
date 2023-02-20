/****** Object:  StoredProcedure [rd].[sp_GetRdsUserInfo]    Script Date: 08/05/2008 10:20:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
create procedure rd.sp_GetRdsUserGroup(@AL_PARENT_ID1 int)
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  select LABEL=RDS_USER_GROUP.UG_NAME,ID=RDS_USER_GROUP.UG_ID,ACCOUNT=RDS_USER_GROUP.UG_ID,PARENT_ID1=@AL_PARENT_ID1,
    PICTINDEX=2 from RDS_USER_GROUP where @AL_PARENT_ID1 = 1 union select LABEL=RDS_USER.U_NAME,
    ID=RDS_USER_ID.UI_ID,ACCOUNT=RDS_USER.U_ID,PARENT_ID1=@AL_PARENT_ID1,PICTINDEX=3 from RDS_USER,
    RDS_USER_ID where @AL_PARENT_ID1 = 2 and RDS_USER.U_ID = RDS_USER_ID.U_ID union select LABEL=RDS_MAINTENANCE_TABLE.MT_NAME,
    ID=RDS_MAINTENANCE_TABLE.MT_ID,ACCOUNT=0,PARENT_ID1=@AL_PARENT_ID1,PICTINDEX=5 from
    RDS_MAINTENANCE_TABLE where @AL_PARENT_ID1 = 3
end
GO