/****** Object:  StoredProcedure [rd].[sp_GetRegions]    Script Date: 08/05/2008 10:20:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for stored procedure sp_GetRegions : 
--

create procedure [rd].[sp_GetRegions]
AS
BEGIN
  select region_id,
    rgn_name from
    region
end
GO
