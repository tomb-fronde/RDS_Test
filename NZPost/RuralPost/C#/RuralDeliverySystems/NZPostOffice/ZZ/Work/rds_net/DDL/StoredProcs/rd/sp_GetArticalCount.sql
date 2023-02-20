/****** Object:  StoredProcedure [rd].[sp_GetArticalCount]    Script Date: 08/05/2008 10:19:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [rd].[sp_GetArticalCount] @in_Contract INT 

AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
   select   contract_no ,ac_start_week_period ,contract_seq_number,ac_w1_medium_letters ,
   ac_w1_other_envelopes ,
   ac_w1_small_parcels ,ac_w1_large_parcels ,
   ac_w1_inward_mail ,ac_scale_factor from
   rd.artical_count where
   contract_no = @in_Contract order by ac_start_week_period asc
end
GO
