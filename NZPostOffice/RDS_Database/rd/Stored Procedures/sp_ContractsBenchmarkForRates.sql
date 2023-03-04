/*
   exec sp_ContractsBenchmarkForRates 3, '1-Mar-2020'
*/
CREATE PROCEDURE [rd].sp_ContractsBenchmarkForRates(
      @inRgCode int
    , @inEffDate datetime)
AS    
BEGIN
-----------------------------------------------------------------------------
-- TJB Frequencies & Vehicles 11-Mar-2022 NEW                              --
--     Adapted from query in RDS.Entity.Ruraldw.ContractsBenchmarkForRates --
-- Used by NationalFuelOverride.cs                                         --
-- Similar to sp_ContractsBenchmark, this finds contracts affected by      --
-- a change in RUC rate.                                                   --
-- The original returned details of the contract's f_GetLatestVehicle()    --
-- This version returns all contracts and their vehicles along with other  --
-- details including each vehicle's override RUC rate and the standard     --
-- RUC rate, the contract's BM and each vehicle's Vehicle BM.              --
-- Note: inEffDate added primarily for testing and debugging purposes;     --
--       previously it was getdate().                                      --
-----------------------------------------------------------------------------
    SET NOCOUNT ON

    SELECT distinct
           cr.contract_no
         , cr.contract_seq_number
         , cr.con_start_date
         , cr.con_rates_effective_date
         , cr.con_expiry_date
         , cr.con_rg_code_at_renewal
         , rf.vehicle_number
         , (SELECT vr_ruc FROM rd.vehicle_rate vr
             WHERE vr.vt_key = v.vt_key
               AND vr.vr_rates_effective_date = cr.con_rates_effective_date) as standard_ruc_rate
         , (SELECT vor_ruc FROM rd.vehicle_override_rate vor
             WHERE vor.contract_no = cr.contract_no
               AND vor.contract_seq_number = cr.contract_seq_number
			   AND vor.vehicle_number = rf.vehicle_number
               AND vor.vor_effective_date 
                       = (SELECT max(vor2.vor_effective_date) 
                            FROM rd.vehicle_override_rate vor2 
                           WHERE vor2.contract_no = vor.contract_no 
                             AND vor2.contract_seq_number = vor.contract_seq_number
							 AND vor2.vehicle_number = vor.vehicle_number)
               AND vor.vor_effective_date >= cr.con_rates_effective_date)    as override_ruc_rate
         , rd.BenchmarkCalc2021(cr.contract_no, cr.contract_seq_number)     as benchmark 
         , rd.BenchmarkCalcVeh2021(cr.contract_no, cr.contract_seq_number, rf.vehicle_number)  as veh_benchmark 
      FROM rd.contract_renewals cr
         , rd.contract c
         , rd.contract_vehical cv
         , rd.route_frequency rf
         , rd.vehicle v
         , rd.fuel_type ft
     WHERE c.contract_no = cr.contract_no
       AND c.con_active_sequence = cr.contract_seq_number
       AND c.con_date_terminated is null 
       AND cr.con_acceptance_flag = 'Y'
       AND cr.con_expiry_date >= @inEffDate   -- etdate() 
       AND cv.contract_no = cr.contract_no 
       AND cv.contract_seq_number = cr.contract_seq_number
       AND (c.rg_code = @inRgCode OR @inRgCode = -1)
       and rf.contract_no = cv.contract_no
       and rf.vehicle_number = cv.vehicle_number
       and rf.rf_active = 'Y'
       AND v.vehicle_number = cv.vehicle_number 
       AND ft.ft_key = v.ft_key
       AND ft.ft_description like '%diesel%' 
     ORDER BY cr.contract_no, rf.vehicle_number

END