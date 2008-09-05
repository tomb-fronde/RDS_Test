/****** Object:  StoredProcedure [rd].[sp_DDDW_Verbs]    Script Date: 08/05/2008 10:18:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--
-- Definition for stored procedure sp_DDDW_Verbs : 
--

create procedure  [rd].[sp_DDDW_Verbs]
AS
BEGIN
  select rfv_id,rfv_description from
    route_freq_verbs order by
    rfv_description asc
end
GO
