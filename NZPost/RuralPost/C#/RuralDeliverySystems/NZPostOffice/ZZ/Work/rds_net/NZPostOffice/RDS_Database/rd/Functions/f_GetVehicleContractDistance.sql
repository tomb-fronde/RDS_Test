
CREATE function [rd].[f_GetVehicleContractDistance](
      @inContract int
    , @inSequence int
    , @VehicleNo  int)
returns decimal(10,2)
AS
BEGIN
  declare @nReturn decimal(10,2)
  select @nReturn=sum(route_frequency.rf_distance*rate_days.rtd_days_per_annum) 
    from route_frequency 
             join rate_days 
                 on route_frequency.sf_key = rate_days.sf_key 
             join contract_renewals 
                 on route_frequency.contract_no = contract_renewals.contract_no 
                    and contract_seq_number = @inSequence 
   where route_frequency.contract_no = @inContract 
     and route_frequency.rf_active = 'Y' 
     and route_frequency.vehicle_number = @VehicleNo
     and rate_days.rg_code = contract_renewals.con_rg_code_at_renewal 
     and rate_days.rr_rates_effective_date = contract_renewals.con_rates_effective_date
     
  return @nReturn
end