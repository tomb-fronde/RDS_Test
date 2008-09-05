/****** Object:  StoredProcedure [rd].[sp_GetFuelRates]    Script Date: 08/05/2008 10:20:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for stored procedure sp_GetFuelRates : 
--

--
-- Definition for stored procedure sp_GetFuelRates : 
--

create procedure [rd].[sp_GetFuelRates](@in_Date datetime)
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  select fuel_type.ft_key,
    fuel_rates.rg_code,
    fuel_rates.rr_rates_effective_date,
    fuel_rates.fr_fuel_rate,
    fuel_rates.fr_fuel_consumtion_rate,
    fuel_type.ft_description from
    fuel_type left outer join
    fuel_rates on
    (fuel_type.ft_key = fuel_rates.ft_key and
    fuel_rates.rr_rates_effective_date = @in_Date)
--and fuel_rates.rg_code=in_RenewalGroup
end
GO
