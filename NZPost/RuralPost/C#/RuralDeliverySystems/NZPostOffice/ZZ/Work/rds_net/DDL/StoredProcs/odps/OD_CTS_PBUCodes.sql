/****** Object:  StoredProcedure [odps].[OD_CTS_PBUCodes]    Script Date: 08/05/2008 10:13:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for stored procedure OD_CTS_PBUCodes : 
--

create procedure [odps].[OD_CTS_PBUCodes]
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  select PBU_Code.PBU_Code,
    PBU_Code.PBU_Description,
    PBU_Code.PBU_ID from
    odps.pbu_code order by 1 asc 
end
GO
