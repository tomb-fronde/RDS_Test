/****** Object:  UserDefinedFunction [rd].[f_GetInsurance]    Script Date: 08/05/2008 11:24:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for user-defined function f_GetInsurance : 
--

/*07/11/2006 mkwang_msd*/
create function [rd].[f_GetInsurance](@in_contractNo int,@inSequenceNo int,@inEffDate datetime)
returns int
AS
BEGIN

  declare @vn_insurance_baserate numeric(12,2),
  @vn_insurance_override numeric(12,2)
  select top 1 @vn_insurance_baserate= isNull(vehicle_override_rate.vor_vehicle_insurance_premium,isNull(non_vehicle_rate.nvr_vehicle_insurance_base_premium,0)+
    isNull(vehicle_rate.vr_vehicle_value_insurance_pct/100,0)*case when isNull(vehicle_override_rate.vor_nominal_vehicle_value,vehicle_rate.vr_nominal_vehicle_value)=vehicle_rate.vr_nominal_vehicle_value then vehicle_rate.vr_nominal_vehicle_value else 0 end )
    from vehicle_type left outer join vehicle_rate on vehicle_type.vt_key = vehicle_rate.vt_key ,                                       
    contract left outer join non_vehicle_rate on  contract.rg_code = non_vehicle_rate.rg_code ,
    contract_renewals left outer join vehicle_override_rate on contract_renewals.contract_no = vehicle_override_rate.contract_no and contract_renewals.contract_seq_number = vehicle_override_rate.contract_seq_number,
    contract_vehical,
    vehicle
    where 
    vehicle.vehicle_number = contract_vehical.vehicle_number and
    vehicle_type.vt_key = vehicle.vt_key and
    contract_renewals.contract_no = contract.contract_no and
    contract_renewals.contract_no = contract_vehical.contract_no and
    contract_renewals.contract_seq_number = contract_vehical.contract_seq_number and
    contract_vehical.contract_no = @in_contractNo and
    contract_vehical.contract_seq_number = @inSequenceNo and
    vehicle_rate.vr_rates_effective_date = @inEffDate and
    contract_vehical.vehicle_number = rd.f_GetLatestVehicle(@in_contractNo,@inSequenceNo) and
    non_vehicle_rate.nvr_rates_effective_date = @inEffDate 
     order by
    vehicle_override_rate.vor_effective_date desc
  return @vn_insurance_baserate
end
GO
