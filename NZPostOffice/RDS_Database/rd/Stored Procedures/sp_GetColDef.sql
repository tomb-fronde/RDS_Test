create procedure [rd].[sp_GetColDef] @inTabl CHAR(128) ,@inCreator CHAR(128) 

AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
   select   '        '+cname+' '+coltype+CASE WHEN length IS NULL THEN '' ELSE '('+length+(case when sysleng = 0 then '' else ','+ sysleng
end)+')'
END+',' AS coldef from
   rd.syscolumns where
   tname = @inTabl and
   creator = @inCreator
end