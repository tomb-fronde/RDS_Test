/*
exec sp_ContractsBenchmark 3, '21-Mar-2020'
*/
CREATE PROCEDURE [rd].[sp_ContractsBenchmark](
      @inRgCode int
    , @inEffDate datetime)
AS 
BEGIN
--------------------------------------------------------------------------
-- TJB Frequencies & Vehicles 31-Mar-2022 NEW                           --
--     Adapted from query in Entity.Ruraldw.ContractsBenchmark          --
-- Used by NationalFuelOverride.cs                                      --
-- This proc finds contracts affected by a change in fuel rate.         --                                                  --
-- The original returned details of the contract's f_GetLatestVehicle() --
-- This version returns all contracts and their vehicles along with     --
-- other details including each vehicle's override fuel rate and the    --
-- standard fuel rate, the contract's BM and each vehicle's Vehicle BM. --                     --
-- Note: inEffDate added primarily for testing and debugging purposes;  --
--       previously it was getdate().                                   --
--------------------------------------------------------------------------
    SET NOCOUNT ON

    SELECT distinct
           cr.contract_no              as contract
         , cr.contract_seq_number      as sequence
         , cr.con_start_date           as 'start'
         , cr.con_rates_effective_date as 'effective'
         , cr.con_expiry_date          as expiry 
         , cr.con_rg_code_at_renewal   as rg_code
         , rf.vehicle_number
         , (SELECT v.ft_key FROM rd.vehicle v
             WHERE v.vehicle_number = rf.vehicle_number) as fuel_key
         , (SELECT vor_fuel_rate FROM rd.vehicle_override_rate vor
             WHERE vor.contract_no = cr.contract_no 
               AND vor.contract_seq_number = cr.contract_seq_number
               AND vor.vehicle_number = rf.vehicle_number
               AND vor.vor_effective_date =
                      (SELECT max(vor2.vor_effective_date) 
                         FROM rd.vehicle_override_rate vor2
                        WHERE vor2.contract_no = vor.contract_no 
                          AND vor2.contract_seq_number = vor.contract_seq_number
						  AND vor2.vehicle_number = vor.vehicle_number)
               AND vor.vor_effective_date >= cr.con_rates_effective_date)  as vor_fuel_rate
         , (SELECT fr_fuel_rate FROM rd.fuel_rates
             WHERE ft_key = 
                     (SELECT v.ft_key FROM rd.vehicle v 
                       WHERE v.vehicle_number = rf.vehicle_number) 
               AND rg_code = cr.con_rg_code_at_renewal  
               AND rr_rates_effective_date = cr.con_rates_effective_date) as fr_fuel_rate
         , rd.BenchmarkCalc2021(cr.contract_no, cr.contract_seq_number)   as benchmark
         , rd.BenchmarkCalcVeh2021(cr.contract_no, cr.contract_seq_number, rf.vehicle_number) as veh_benchmark
      FROM rd.contract_renewals cr
         , rd.contract c
         , rd.route_frequency rf
         , rd.contract_vehical cv
     WHERE c.contract_no = cr.contract_no 
       AND cr.contract_seq_number = c.con_active_sequence
       AND c.con_date_terminated is null 
       AND cr.con_acceptance_flag = 'Y'
       AND cr.con_expiry_date >= @inEffDate   -- getdate() 
       and cv.contract_no = cr.contract_no
       and cv.contract_seq_number = cr.contract_seq_number
       and cv.cv_vehical_status = 'A'
       AND (c.rg_code = @inRgCode OR @inRgCode = -1)
       and rf.contract_no = cv.contract_no
       and rf.vehicle_number = cv.vehicle_number
       and rf.rf_active = 'Y'
     ORDER BY cr.contract_no, rf.vehicle_number
END