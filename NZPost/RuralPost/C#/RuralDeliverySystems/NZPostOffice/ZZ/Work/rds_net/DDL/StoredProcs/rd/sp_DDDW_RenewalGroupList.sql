/****** Object:  StoredProcedure [rd].[sp_DDDW_RenewalGroupList]    Script Date: 08/05/2008 10:18:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for stored procedure sp_DDDW_RenewalGroupList : 
--

create procedure [rd].[sp_DDDW_RenewalGroupList]
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  select rg_code,rg_description from renewal_group
end
GO
