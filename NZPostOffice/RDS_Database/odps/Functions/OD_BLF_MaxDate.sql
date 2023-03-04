
--
-- Definition for user-defined function OD_BLF_MaxDate : 
--

create function [odps].[OD_BLF_MaxDate](@sdate datetime,@edate datetime)
returns datetime
AS
BEGIN

  declare @l_date datetime
  select @l_date = max(nat_effective_date) 
    from "national" where
    nat_effective_date >= @sdate and
    nat_effective_date <= @edate
  return(@l_date)
end