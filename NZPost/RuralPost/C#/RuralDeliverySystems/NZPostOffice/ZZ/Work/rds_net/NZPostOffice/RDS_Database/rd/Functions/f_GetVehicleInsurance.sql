/*
select [rd].[f_GetVehicleInsurance]( 50216, 2, 4177, '1-Apr-2019')
select [rd].[f_GetVehicleInsurance]( 50216, 2, 2067, '1-Apr-2019')
*/
CREATE function [rd].[f_GetVehicleInsurance](
	  @inContractNo  int
	, @inSequenceNo  int
	, @inVehicleNo   int
	, @inEffDate datetime)
RETURNS int
AS
BEGIN
   -- TJB Frequencies & Vehicles 20-Jan-2021
   -- Adapted from f_GetInsurance
   -- Gets the insurance cost for a vehicle
   --
   --  TJB  Aug 2009  SR7_0036
   --       Changed Select value

  declare @vehicle_insurance numeric(12,2)
 
   -- Original Select value:
   --      @vn_insurance_baserate = 
   --              isNull(vehicle_override_rate.vor_vehicle_insurance_premium,
   --                     isNull(non_vehicle_rate.nvr_vehicle_insurance_base_premium,0)
   --                     + isNull(vehicle_rate.vr_vehicle_value_insurance_pct/100,0)
   --                * case when isNull(vehicle_override_rate.vor_nominal_vehicle_value,
   --                                   vehicle_rate.vr_nominal_vehicle_value)
   --                          = vehicle_rate.vr_nominal_vehicle_value 
   --                       then vehicle_rate.vr_nominal_vehicle_value else 0 end )
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