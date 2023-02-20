/****** Object:  StoredProcedure [rd].[sp_Extension_RFDistance]    Script Date: 08/05/2008 10:18:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for stored procedure sp_Extension_RFDistance : 
--

create procedure [rd].[sp_Extension_RFDistance](@inContract int,@inKey int,@indays char(100))
AS
BEGIN
  select rf_distance from
    route_frequency where
    contract_no = @inContract and
    sf_key = @inkey and
    rf_delivery_days = @indays
end
GO
