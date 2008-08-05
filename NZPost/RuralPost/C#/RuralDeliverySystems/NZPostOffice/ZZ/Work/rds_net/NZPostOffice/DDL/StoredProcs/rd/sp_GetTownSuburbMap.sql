/****** Object:  StoredProcedure [rd].[sp_GetTownSuburbMap]    Script Date: 08/05/2008 10:21:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for stored procedure sp_GetTownSuburbMap : 
--

create procedure [rd].[sp_GetTownSuburbMap] AS
BEGIN
  select towncity.tc_id,
    towncity.region_id,
    towncity.tc_name,
    suburblocality.sl_id,
    suburblocality.sl_name from
    towncity,
    suburblocality,
    town_suburb where
    (town_suburb.sl_id = suburblocality.sl_id) and
    (town_suburb.tc_id = towncity.tc_id)
end
GO
