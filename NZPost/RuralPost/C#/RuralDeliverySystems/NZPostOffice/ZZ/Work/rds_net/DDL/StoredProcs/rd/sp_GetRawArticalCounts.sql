/****** Object:  StoredProcedure [rd].[sp_GetRawArticalCounts]    Script Date: 08/05/2008 10:20:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for stored procedure sp_GetRawArticalCounts : 
--

create procedure [rd].[sp_GetRawArticalCounts](
@in_Contract int,
@in_WeekPeriod int)
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  select contract_no,
    ac_start_week_period,
    ac_w1_medium_letters,
    ac_w1_other_envelopes,
    ac_w1_small_parcels,
    ac_w1_large_parcels,
    ac_w1_inward_mail,
    ac_w2_medium_letters,
    ac_w2_other_envelopes,
    ac_w2_small_parcels,
    ac_w2_large_parcels,
    ac_w2_inward_mail from
    artical_count where
    contract_no = @in_Contract and
    ac_start_week_period = @in_WeekPeriod
end
GO
