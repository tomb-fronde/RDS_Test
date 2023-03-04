
--
-- Definition for stored procedure sp_GetFuelRates2001 : 
--

--
-- Definition for stored procedure sp_GetFuelRates2001 : 
--

create procedure [rd].[sp_GetFuelRates2001](@inRgCode int,@in_Date datetime)
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
    fuel_rates.rr_rates_effective_date = @in_Date) and
    fuel_rates.rg_code = @inRgCode
end