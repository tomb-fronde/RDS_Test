
-- exec [sp_DDDW_contractor_vehicles] 45013

CREATE procedure [rd].[sp_DDDW_contractor_vehicles] (@inContractNo int)
-- TJB Frequencies Nov 2020 NEW
-- Returns a list of all the vehicles used by the contractor of 
-- contract $InContractNo and used for all contracts that 
-- contractor has.  The list returned has the vehicle number and
-- a synthetic vehicle name (rego number + make + model).
-- NOTE: This list includes vehicles from contracts that have been 
-- terminated.
AS
BEGIN
  set NOCOUNT ON
  set CONCAT_NULL_YIELDS_NULL OFF
  
  declare @contractor_no int
  declare @contract_seq int
  
  select @contract_seq = rd.GetConSeqNo(@inContractNo)
  
  select @contractor_no = cor.contractor_supplier_no 
    from rd.contractor cor
       , rd.contractor_renewals crr
   where crr.contract_no = @inContractNo
     and crr.contract_seq_number = @contract_seq
   and cor.contractor_supplier_no = crr.contractor_supplier_no
   
  select distinct v.vehicle_number
       , isnull(v.v_vehicle_registration_number,'')
            +isnull(' '+v.v_vehicle_make,'') 
            + isnull(' '+v.v_vehicle_model,'')
	 as vehicle_name
    from rd.vehicle v
       , rd.contract_vehical cv
       , rd.contractor_renewals cr
       , [rd].[contract] c 
   where cr.contractor_supplier_no = @contractor_no
     and cr.contract_seq_number = rd.GetConSeqNo(cr.contract_no)
     and c.contract_no = cr.contract_no
     --and c.con_date_terminated is null
     and cv.contract_no = cr.contract_no
     and cv.contract_seq_number = cr.contract_seq_number
     and v.vehicle_number = cv.vehicle_number
  
END