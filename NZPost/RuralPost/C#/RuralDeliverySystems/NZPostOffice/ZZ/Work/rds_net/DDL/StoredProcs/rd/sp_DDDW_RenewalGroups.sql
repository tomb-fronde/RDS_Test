/****** Object:  StoredProcedure [rd].[sp_DDDW_RenewalGroups]    Script Date: 08/05/2008 10:18:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--
-- Definition for stored procedure sp_DDDW_RenewalGroups : 
--

create procedure [rd].[sp_DDDW_RenewalGroups]
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  select rg_code,rg_description from renewal_group union
  select-1,'<All Renewal Groups>'  order by
    2 asc
end
GO
