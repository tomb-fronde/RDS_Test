
CREATE function [rd].[f_GetVehInsurance_Whatif](
	@inContractNo  int,
	@inSequenceNo  int,
	@inEffDate datetime,
	@inVehicleNo   int)
returns int
-- TJB Frequencies & Vehicles 18-Feb-2021
-- Adapted from f_GetInsurance_Whatif
-- See also f_getVehConsumptionRates_whatif, f_getVehFuelRates_whatif, 
--          f_getVehContractDelDays_whatif
-- [14-Jul-2021] "Fixed"? seems to work better with multiple vehicles
--
-- TJB  RD7_0049  Sept2009          
-- Fixed bug in calculation.  Matched calc to benchmark calculation
-- (though the joins are different).
--
-- TJB 4635 - Sept 04
-- Variation on f_getInsurance for whatif calculation
-- Drops RG_Code from selection condition (see below)
-- See also f_getFuelRates_whatif, f_getConsumptionRates_whatif, getContractDelDays_whatif
as
-- --> also rewrote where clause to rationalise and improve efficiency
begin

/*  Swapped for code from f_GetVehicleInsurance  ****************
  declare @vn_insurance_baserate numeric(12,2),
          @vn_insurance_override numeric(12,2)

  select top 1 
         @vn_insurance_baserate = 
                 isNull(vor.vor_vehicle_insurance_premium,
                          (isNull(nvr.nvr_vehicle_insurance_base_premium,0)
                   + isNull(vr.vr_vehicle_value_insurance_pct/100,0)
                       * isNull(vor.vor_nominal_vehicle_value,
                                isNull(vr.vr_nominal_vehicle_value,0))))
    from rd.contract_vehical as cv 
                left outer join  rd.vehicle_override_rate as vor 
                     on  vor.contract_no = cv.contract_no and 
                         vor.contract_seq_number = cv.contract_seq_number,
         rd.vehicle as v,
         rd.vehicle_rate as vr,
         rd.non_vehicle_rate as nvr
   where cv.contract_no = @inContractNo
     and cv.contract_seq_number = @inSequenceNo
         --and cv.vehicle_number = rd.f_GetLatestVehicle(@in_contractNo,@inSequenceNo)
     and cv.vehicle_number = @inVehicleNo
     and v.vehicle_number = cv.vehicle_number
     and vr.vt_key = v.vt_key
     and vr.vr_rates_effective_date = @inEffDate
     and nvr.nvr_rates_effective_date = @inEffDate  
   order by
         vor.vor_effective_date desc

  return @vn_insurance_baserate
*****************************************************************/
  declare @vehicle_insurance numeric(12,2)

  select top 1 
         @vehicle_insurance = 
                 isNull(vor.vor_vehicle_insurance_premium,
                          (isNull(nvr.nvr_vehicle_insurance_base_premium,0)
                           + isNull(vr.vr_vehicle_value_insurance_pct/100,0)
                                * isNull(vor.vor_nominal_vehicle_value,
                                          isNull(vr.vr_nominal_vehicle_value,0))))
    from rd.vehicle_type vt left outer join rd.vehicle_rate vr
              on vt.vt_key = vr.vt_key,
         rd.contract c left outer join rd.non_vehicle_rate nvr
              on c.rg_code = nvr.rg_code,
         rd.contract_renewals cr left outer join rd.vehicle_override_rate vor
              on cr.contract_no = vor.contract_no 
              and cr.contract_seq_number = vor.contract_seq_number
              and vor.vehicle_number = @inVehicleNo,
         rd.contract_vehical cv,
         rd.vehicle v
   where v.vehicle_number = cv.vehicle_number and
         vt.vt_key = v.vt_key and
         cr.contract_no = c.contract_no and
         cr.contract_no = cv.contract_no and
         cr.contract_seq_number = cv.contract_seq_number and
         cv.contract_no = @inContractNo and
         cv.contract_seq_number = @inSequenceNo and
         vr.vr_rates_effective_date = @inEffDate and
         --cv.vehicle_number = rd.f_GetLatestVehicle(@inContractNo,@inSequenceNo) and
         cv.vehicle_number = @inVehicleNo and
         nvr.nvr_rates_effective_date = @inEffDate 
   order by
         vor.vor_effective_date desc
         
  return @vehicle_insurance

end