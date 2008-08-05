/****** Object:  StoredProcedure [rd].[sp_Route_Frequency]    Script Date: 08/05/2008 10:22:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for stored procedure sp_Route_Frequency : 
--

create procedure [rd].[sp_Route_Frequency](@in_Contract int)
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  select contract_no,
    sf_key,
    rf_delivery_days,
    rf_active,
    rf_monday=substring(rf_delivery_days,1,1),
    rf_tuesday=substring(rf_delivery_days,2,1),
    rf_wednesday=substring(rf_delivery_days,3,1),
    rf_thursday=substring(rf_delivery_days,4,1),
    rf_friday=substring(rf_delivery_days,5,1),
    rf_saturday=substring(rf_delivery_days,6,1),
    rf_sunday=substring(rf_delivery_days,7,1),
    rf_distance from
    route_frequency where
    contract_no = @in_Contract
end
GO
