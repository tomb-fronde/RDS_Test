/****** Object:  StoredProcedure [rd].[sp_get_non_vehicle_override_rates]    Script Date: 08/05/2008 10:19:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for stored procedure sp_get_non_vehicle_override_rates : 
--

create procedure [rd].[sp_get_non_vehicle_override_rates](@incontract_no int,@incontract_seq_no int)
-- TJB  SR4661  May2005
as -- Added delivery and processing wage rates
begin
set CONCAT_NULL_YIELDS_NULL off
  select contract_no,
    contract_seq_number,
    nvor_wage_hourly_rate,
    nvor_public_liability_rate_2,
    nvor_carrier_risk_rate,
    nvor_acc_rate,
    nvor_item_proc_rate_per_hour,
    nvor_frozen,
    nvor_accounting,
    nvor_telephone,
    nvor_sundries,
    nvor_acc_rate_amount,
    nvor_uniform,
    nvor_delivery_wage_rate,
    nvor_processing_wage_rate from
    non_vehicle_override_rate where
    contract_no = @incontract_no and
    contract_seq_number = @incontract_seq_no
end
GO
