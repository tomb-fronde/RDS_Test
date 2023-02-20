/****** Object:  UserDefinedFunction [rd].[trim]    Script Date: 08/05/2008 11:25:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

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
GO
