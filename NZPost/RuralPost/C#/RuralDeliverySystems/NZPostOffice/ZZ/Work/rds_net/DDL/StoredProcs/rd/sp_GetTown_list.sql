/****** Object:  StoredProcedure [rd].[sp_GetTown_list]    Script Date: 08/05/2008 10:21:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for stored procedure sp_GetTown_list : 
--

create procedure -- Tim Chan 04/03/2003
-- This is a new procedure written as part of the resolution to service request 4474
-- 
[rd].[sp_GetTown_list]
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  select TownCity.tc_id,TownCity.tc_name from
    TownCity order by
    TownCity.tc_name asc
end
GO
