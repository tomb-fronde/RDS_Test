/****** Object:  StoredProcedure [rd].[sp_GetMiscRate]    Script Date: 08/05/2008 10:20:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for stored procedure sp_GetMiscRate : 
--

create procedure [rd].[sp_GetMiscRate](
@in_RgCode int,
@in_EffectDate datetime)
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  select misc_rate.rg_code,
    misc_rate.mr_effective_date,
    misc_rate.mr_name,
    misc_rate.mr_value,
    misc_rate.mr_km_flag,
    misc_rate.mr_annual_flag from
    misc_rate where
    (misc_rate.rg_code = @in_RgCode) and
    (misc_rate.mr_effective_date = @in_EffectDate)
end
GO
