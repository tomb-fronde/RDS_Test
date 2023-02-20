/****** Object:  StoredProcedure [rd].[sp_GetRenewalRates]    Script Date: 08/05/2008 10:20:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create procedure [rd].[sp_GetRenewalRates]
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  select rg_code,
    rr_rates_effective_date,
    rr_frozen_indicator from
    renewal_rate order by
    rr_rates_effective_date desc
end
GO
