/****** Object:  UserDefinedFunction [odps].[v_fuelRateDescription]    Script Date: 08/05/2008 11:23:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for stored procedure OD_RPS_UpdatedContractors : 
--


--
-- Definition for user-defined function v_fuelRateDescription : 
--

--
-- Definition for user-defined function v_fuelRateDescription : 
--

create function [odps].[v_fuelRateDescription](@inDescription varchar(200))
returns varchar(200)
-- TJB  SR4654  April 2005     New
-- Called if the description is for a 'Global fuel rate change'.
-- If the description has the new wording (includes either "Increase" or "Decrease")
--    return only the first 2 lines (drop the "New standard rate...").
as -- Otherwise the whole string is returned unchanged.
begin

  declare @i integer
  select @i=CHARINDEX(@inDescription,'Increase')
  if @i = 0
    begin
      select @i=CHARINDEX(@inDescription,'Decrease')
      if @i = 0
        return @inDescription
    end
  select @i=CHARINDEX(@inDescription,'New standard')
  return substring(@inDescription,1,@i-2)
end
GO
