/****** Object:  StoredProcedure [rd].[sp_GetColDef]    Script Date: 08/05/2008 10:19:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [rd].[sp_GetColDef] @inTabl CHAR(128) ,@inCreator CHAR(128) 

AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
   select   '        '+cname+' '+coltype+CASE WHEN length IS NULL THEN '' ELSE '('+length+(case when sysleng = 0 then '' else ','+ sysleng
end)+')'
GO
