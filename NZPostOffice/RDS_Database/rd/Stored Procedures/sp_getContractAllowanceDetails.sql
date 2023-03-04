
CREATE PROCEDURE [rd].sp_getContractAllowanceDetails(
       @inContractNo int
     , @inAlctId     int )
AS
BEGIN
    -- TJB Allowances 5-July-2021: New
    -- Get all contract allowances of a particular calculation type,
    -- including their history and calculation factors for entity
    -- MaintainAllowancesV2.
    
    set nocount on

    SELECT ca.alt_key 
         , ca.contract_no 
         , ca.ca_effective_date 
         , ca.ca_annual_amount 
         , ca.ca_notes 
         , ca.ca_paid_to_date 
         , ca.ca_approved 
         , c.con_title 
         , ca.ca_var1 
         , ca.ca_dist_day 
         , ca.ca_hrs_wk 
         , alt.alt_description 
         , alt.alt_rate 
         , alt.alt_wks_yr 
         , alt.alt_acc 
         , alct.alct_id 
         , alct.alct_description 
         , ca.ca_doc_description 
         , ca.ca_costs_covered 
         , var.var_id 
         , var.var_description 
         , var.var_carrier_pa 
         , var.var_repairs_pk 
         , var.var_licence_pa 
         , var.var_tyres_pk 
         , var.var_allowance_pk 
         , var.var_insurance_pa 
         , var.var_ror_pa 
         , var.var_fuel_use_pk 
         , var.var_fuel_rate 
         , var.var_ruc_rate_pk 
         , ca.ca_row_changed 
         , rd.f_GetAllowanceAmount(ca.contract_no, ca.alt_key, ca_effective_date) 
      FROM rd.contract_allowance ca 
         , rd.contract c 
         , rd.allowance_type alt 
         , rd.allowance_calc_type alct 
         , rd.vehicle_allowance_rates var 
     WHERE ca.contract_no = @inContractNo 
      AND c.contract_no = ca.contract_no 
      AND alt.alt_key = ca.alt_key 
      AND alt.alct_id =  @inAlctId 
      AND alct.alct_id = alt.alct_id 
      AND (var.var_id = ca.var_id  
           or (ca.var_id is null and var.var_id = 0))
     ORDER BY alt.alt_description ASC 
        , ca.ca_effective_date DESC

END