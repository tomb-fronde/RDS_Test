
CREATE FUNCTION [rd].[f_GetVehConsumptionRates_whatif](
	      @inContractNo  int
        , @inSequenceNo  int
        , @inEffDate datetime
        , @inVehicleNo   int)
RETURNS numeric(12,2)
-- TJB Frequencies & Vehicles 19-Feb-2021
-- Adapted from f_GetConsumptionRates_whatif; simplified query
-- See also f_getVehContractDelDays_whatif, f_getVehFuelRates_whatif, 
--          f_getVehInsurance_whatif
--
-- TJB 4635 - Sept 2004
-- Variation on f_getConsumptionRates for whatif calculation
-- Drops RG_Code from selection condition (see below)
-- See also f_getFuelRates_whatif, getContractDelDays_whatif, f_getInsurance_whatif
AS
BEGIN
  declare @vn_ConsumptionRate numeric(12,2)
  
  select @vn_ConsumptionRate = fr.fr_fuel_consumtion_rate 
    from rd.vehicle v
       , rd.fuel_rates fr
   where v.vehicle_number = @inVehicleNo
     and fr.ft_key = v.ft_key 
     and fr.rr_rates_effective_date = @inEffDate
     
  return @vn_ConsumptionRate
End