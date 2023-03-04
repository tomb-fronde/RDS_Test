-- DROP FUNCTION [rd].[f_CalcDistanceAllowance]
CREATE FUNCTION [rd].[f_CalcDistanceAllowance](
        @alt_key int
      , @var_id int
      , @days_yr numeric(10,2)
      , @hours_wk numeric(10,2)
      , @dist_day numeric(10,2)
      , @costs_covered char(1)) -- 'Y' or 'N'
RETURNS numeric(10,2)
AS
BEGIN
  declare @Net_amt numeric(10,2)        
        , @Annual_hrs numeric(10,2)
        , @Time_amt numeric(10,2)
        , @Annual_dist numeric(10,2)
        , @Distance_amt numeric(10,2)
        , @Vehicle_amt numeric(10,2)
        , @Fuel_pk numeric(10,2)

  declare @alt_rate numeric(10,2)
        , @alt_wks_yr numeric(10,2)
        , @alt_acc numeric(10,2)
        , @var_carrier_pa numeric(10, 2)
        , @var_repairs_pk numeric(10, 2)
        , @var_licence_pa numeric(10, 2)
        , @var_tyres_pk numeric(10, 2)
        , @var_allowance_pk numeric(10, 2)
        , @var_insurance_pa numeric(10, 2)
        , @var_ror_pa numeric(10, 2)
        , @var_fuel_use_pk numeric(10, 2)
        , @var_fuel_rate numeric(10, 2)
        , @var_ruc_rate_pk numeric(10, 2) 

  select @alt_rate  = alt_rate 
       , @alt_wks_yr = alt_wks_yr 
	   , @alt_acc = alt_acc 
    from rd.allowance_type alt
   where alt.alt_key = @alt_key

  select @var_carrier_pa = var_carrier_pa 
       , @var_repairs_pk = var_repairs_pk 
       , @var_licence_pa = var_licence_pa 
       , @var_tyres_pk = var_tyres_pk 
       , @var_allowance_pk = var_allowance_pk 
       , @var_insurance_pa = var_insurance_pa 
       , @var_ror_pa = var_ror_pa 
       , @var_fuel_use_pk = var_fuel_use_pk 
       , @var_fuel_rate = var_fuel_rate 
       , @var_ruc_rate_pk = var_ruc_rate_pk  
    from rd.vehicle_allowance_rates var
   where var.var_id = @var_id
        
  select @Annual_hrs = (@hours_wk * @alt_wks_yr) 
  select @Time_amt = (@Annual_hrs * @alt_rate) * (1.0 + (@alt_acc / 100))

  select @Fuel_pk = (@var_fuel_use_pk * @var_fuel_rate)

  select @Annual_dist = @dist_day * @days_yr
  select @Distance_amt = (@Fuel_pk + @var_ruc_rate_pk + @var_repairs_pk + @var_tyres_pk + @var_allowance_pk) * (@Annual_dist / 1000)

  select @Vehicle_amt
              = case when (@costs_covered = 'Y')
                     then 0.0
                     else (@var_carrier_pa + @var_licence_pa + @var_insurance_pa + @var_ror_pa)
                end

  select @Net_amt = (@Time_amt + @Distance_amt + @Vehicle_amt)

  return @Net_amt
END