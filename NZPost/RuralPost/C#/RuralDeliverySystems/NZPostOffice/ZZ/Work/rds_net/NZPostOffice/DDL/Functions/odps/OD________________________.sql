/****** Object:  UserDefinedFunction [odps].[OD________________________]    Script Date: 08/05/2008 11:22:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for user-defined function OD________________________ : 
--

create function [odps].[OD________________________]()
returns datetime
AS
BEGIN

  declare @l_date datetime
  return(@l_date)
end
GO
