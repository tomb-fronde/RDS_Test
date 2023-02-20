/****** Object:  StoredProcedure [rd].[sp_Extension_Deliverytime]    Script Date: 08/05/2008 10:18:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for stored procedure sp_Extension_Deliverytime : 
--

create procedure [rd].[sp_Extension_Deliverytime]
AS
BEGIN
  select del_hours_variables.dhv_travelling_speed,
    del_hours_variables.dhr_seconds_customer from
    rd.del_hours_variables
end
GO
