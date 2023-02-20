/****** Object:  UserDefinedFunction [odps].[OD_BLF_GetWhichNational]    Script Date: 08/05/2008 11:22:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for user-defined function OD_BLF_GetWhichNational : 
--

create function [odps].[OD_BLF_GetWhichNational](@indate datetime)
returns int
AS
BEGIN

  declare @v_nat_id int
  select @v_nat_id = max("national".nat_id)
    from "national" where
    "national".nat_effective_date = 
    (select max(n.nat_effective_date) from
      "national" as n where n.nat_effective_date <= @indate)
  return(@v_nat_id)
end
GO
