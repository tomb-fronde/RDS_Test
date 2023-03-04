
-- exec [rd].[sp_DDDW_contract_vehicles] 5031

CREATE procedure [rd].[sp_DDDW_contract_vehicles] (@inContractNo int)
-- TJB Frequencies 16-Jan-2021 NEW
-- Returns a list of all the vehicles currently active for a contract
-- Removed 'Distinct' from select and added active check
-- Added sort order: default vehicle first
-- [16-Feb-2021] Dropped default_vehicle and changed sort order to oldset first
AS 
BEGIN
  set NOCOUNT ON
  set CONCAT_NULL_YIELDS_NULL OFF
  
  select vehicle_number
       , rd.f_VehicleName(vehicle_number)
       , cv_vehical_status
    from rd.contract_vehical
   where contract_no = @inContractNo
     and contract_seq_number = rd.GetConSeqNo(contract_no)
     and cv_vehical_status = 'A'
   order by vehicle_number
  
END