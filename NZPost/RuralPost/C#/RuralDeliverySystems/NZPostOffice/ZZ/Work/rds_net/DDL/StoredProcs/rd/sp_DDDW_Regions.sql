/****** Object:  StoredProcedure [rd].[sp_DDDW_Regions]    Script Date: 08/05/2008 10:18:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for stored procedure sp_DDDW_Regions : 
--

create procedure [rd].[sp_DDDW_Regions]
AS
BEGIN
  select region_id,
    rgn_name from
    rd.region union
  select 0,'' order by
    2 asc
end
GO
