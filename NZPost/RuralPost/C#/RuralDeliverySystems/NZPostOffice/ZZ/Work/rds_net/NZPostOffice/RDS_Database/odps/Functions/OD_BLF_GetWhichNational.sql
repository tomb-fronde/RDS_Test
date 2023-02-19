
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