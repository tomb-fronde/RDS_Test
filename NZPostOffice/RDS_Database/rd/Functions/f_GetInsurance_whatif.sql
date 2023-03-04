
--
-- Definition for user-defined function f_GetInsurance_whatif : 
--

CREATE function [rd].[f_GetInsurance_whatif](
	@in_contractNo int,
	@inSequenceNo int,
	@inEffDate datetime)
--
-- TJB  RD7_0049  Sept2009          
-- Fixed bug is calculation.  Matched calc to benchmark calculation
-- (though the joins are different).
--
-- TJB 4635 - Sept 04
-- Variation on f_getInsurance for whatif calculation
-- Drops RG_Code from selection condition (see below)
-- See also f_getFuelRates_whatif, f_getConsumptionRates_whatif, getContractDelDays_whatif
-- Called from sp_getWhatifCalc2001c
--
returns int
as
-- --> also rewrote where clause to rationalise and improve efficiency
begin

  declare @vn_insurance_baserate numeric(12,2),
          @vn_insurance_override numeric(12,2)

  -- TJB  RD7_0049  Sept2009          
  -- Original Select value:
  -- select top 1 
  --        @vn_insurance_baserate = 
  --                isNull(vor.vor_vehicle_insurance_premium,
  --                          isNull(nvr.nvr_vehicle_insurance_base_premium,0)
  --                + case when isNull(vor.vor_nominal_vehicle_value,vr.vr_nominal_vehicle_value)
  --                                   = vr.vr_nominal_vehicle_value 
  --                       then vr.vr_nominal_vehicle_value else 0 end
  --                    * isNull(vr.vr_vehicle_value_insurance_pct/100,0))
  select top 1 
         @vn_insurance_baserate = 
                 isNull(vor.vor_vehicle_insurance_premium,
                          (isNull(nvr.nvr_vehicle_insurance_base_premium,0)
                   + isNull(vr.vr_vehicle_value_insurance_pct/100,0)
                       * isNull(vor.vor_nominal_vehicle_value,
                                isNull(vr.vr_nominal_vehicle_value,0))))
    from contract_vehical as cv left outer join  vehicle_override_rate as vor 
             on  vor.contract_no = cv.contract_no and vor.contract_seq_number = cv.contract_seq_number,
         vehicle as v,
         vehicle_rate as vr,
         non_vehicle_rate as nvr
   where
         cv.contract_no = @in_contractNo and
         cv.contract_seq_number = @inSequenceNo and
         cv.vehicle_number = rd.f_GetLatestVehicle(@in_contractNo,@inSequenceNo) and
         v.vehicle_number = cv.vehicle_number and
         vr.vr_rates_effective_date = @inEffDate and
         vr.vt_key = v.vt_key and
         nvr.nvr_rates_effective_date = @inEffDate  
   order by
         vor.vor_effective_date desc
         
  return @vn_insurance_baserate
end