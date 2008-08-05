/****** Object:  StoredProcedure [rd].[sp_DDDW_Outlets]    Script Date: 08/05/2008 10:18:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--
-- Definition for stored procedure sp_DDDW_Outlets : 
--

create procedure [rd].[sp_DDDW_Outlets](@regid int)
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off 
select outlet_id,o_name from outlet where((region_id = @regid and @regid is not null and @regid <> -1) or(1 = 1 and @regid = -1)) union select-1,'<All>'  order by 2 asc end













GO
