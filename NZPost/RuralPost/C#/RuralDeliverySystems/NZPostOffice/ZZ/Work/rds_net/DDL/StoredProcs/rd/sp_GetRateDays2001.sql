/****** Object:  StoredProcedure [rd].[sp_GetRateDays2001]    Script Date: 08/05/2008 10:20:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for stored procedure sp_GetRateDays2001 : 
--

create procedure [rd].[sp_GetRateDays2001](
@inRgCode int,
@in_Date datetime)
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  select rate_days.rg_code,
    rate_days.rr_rates_effective_date,
    standard_frequency.sf_key,
    rate_days.rtd_days_per_annum,
    standard_frequency.sf_description,
    standard_frequency.sf_days_week from
    standard_frequency left outer join rate_days on 
    standard_frequency.sf_key = rate_days.sf_key and
    rate_days.rr_rates_effective_date = @in_Date and
    rate_days.rg_code = @inRgCode
end
GO
