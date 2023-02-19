
CREATE PROCEDURE [rd].[sp_get_non_vehicle_override_rates](
	  @inContractNo int
	, @inSequenceNo int
	, @inVehicleNo  int)

-- TJB  Frequencies & Vehicles  15-Jan-2021
-- Added vehicle_number parameter
--
-- TJB  RPCR_099  Jan-2016
-- Changed selection to select most-recent values, 
-- and added effective date to returned values
--
-- TJB  RPCR_041  Nov-2012
-- Added nvor_relief_weeks
--
-- TJB  SR4661  May2005
-- Added delivery and processing wage rates
AS
BEGIN
  set NOCOUNT on
  set CONCAT_NULL_YIELDS_NULL off
  
  select Top 1
         nvor.contract_no
       , nvor.contract_seq_number
       , nvor.nvor_wage_hourly_rate
       , nvor.nvor_public_liability_rate_2
       , nvor.nvor_carrier_risk_rate
       , nvor.nvor_acc_rate
       , nvor.nvor_item_proc_rate_per_hour
       , nvor.nvor_frozen
       , nvor.nvor_accounting
       , nvor.nvor_telephone
       , nvor.nvor_sundries
       , nvor.nvor_acc_rate_amount
       , nvor.nvor_uniform
       , nvor.nvor_delivery_wage_rate
       , nvor.nvor_processing_wage_rate
       , nvor.nvor_relief_weeks
       , nvor.nvor_effective_date
       , nvor.vehicle_number
    from non_vehicle_override_rate nvor
   where nvor.contract_no = @inContractNo 
     and nvor.contract_seq_number = @inSequenceNo
     and (nvor.vehicle_number = @inVehicleNo
           or nvor.vehicle_number is null
           or @inVehicleNo is null)
   order by nvor.nvor_effective_date desc   -- Gets most recent NVOR overrides
END