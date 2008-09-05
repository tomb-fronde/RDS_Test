/****** Object:  StoredProcedure [rd].[sp_InitFuelRates]    Script Date: 08/05/2008 10:21:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for stored procedure sp_InitFuelRates : 
--

create procedure [rd].[sp_InitFuelRates](@in_RenewalGroup int,@in_Date datetime) AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  declare @dMaxDate datetime,
  @dMaxRgCode integer
  select @dMaxDate=max(rr_rates_effective_date) 
    from fuel_rates
  select @dMaxRgCode=max(rg_code) 
    from fuel_rates where
    rr_rates_effective_date = @dMaxDate
  insert into fuel_rates
    select fuel_type.ft_key,
      @in_RenewalGroup,
      @in_Date,
      fuel_rates.fr_fuel_rate,
      fuel_rates.fr_fuel_consumtion_rate from
      fuel_type join fuel_rates on fuel_type.ft_key=fuel_rates.ft_key where
      fuel_rates.rg_code = @dMaxRgCode and
      fuel_rates.rr_rates_effective_date = @dMaxDate and
      not fuel_type.ft_key = any(select ft_key from
        fuel_rates as fr where
        fr.ft_key = fuel_type.ft_key and
        fr.rg_code = @in_RenewalGroup and
        fr.rr_rates_effective_date = @in_Date)
  insert into fuel_rates
    select fuel_type.ft_key,
      @in_RenewalGroup,
      @in_Date,
      0,
      0 from
      fuel_type where
      not fuel_type.ft_key = any(select ft_key from
        fuel_rates as fr where
        fr.ft_key = fuel_type.ft_key and
        fr.rg_code = @in_RenewalGroup and
        fr.rr_rates_effective_date = @in_Date)
  commit transaction
end
GO
