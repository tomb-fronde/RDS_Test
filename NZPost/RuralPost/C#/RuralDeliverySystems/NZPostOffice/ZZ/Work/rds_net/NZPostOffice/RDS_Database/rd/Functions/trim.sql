
--
-- Definition for user-defined function trim : 
--

create function [rd].[trim] (@input varchar(8000)
)
RETURNS varchar(8000)
AS
BEGIN

   declare @returnvalue varchar(8000)
   select @returnvalue=ltrim(rtrim(@input))
   return @returnvalue
END