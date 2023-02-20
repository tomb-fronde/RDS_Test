/****** Object:  StoredProcedure [rd].[OD_CTS_PBUCodes]    Script Date: 08/05/2008 10:17:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [rd].[OD_CTS_PBUCodes]
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  select PBU_Code.PBU_Code,
    PBU_Code.PBU_Description,
    PBU_Code.PBU_ID from
    odps.pbu_code order by 1 asc
end
GO
