/****** Object:  StoredProcedure [rd].[sp_GetFreqDistances]    Script Date: 08/05/2008 10:20:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create procedure [rd].[sp_GetFreqDistances](
@inContract int,
@inSFKey int,
@inDeliveryDays char(7))
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  select fd_effective_date,
    contract_no,
    sf_key,
    rf_delivery_days,
    fd_distance,
    fd_no_of_boxes,
    fd_no_rural_bags,
    fd_no_other_bags,
    fd_no_private_bags,
    fd_no_post_offices,
    fd_no_cmbs,
    fd_no_cmb_customers,
    fd_volume,
    fd_change_reason,
    fd_delivery_hrs_per_week,
    fd_processing_hrs_week from
    frequency_distances where
    (contract_no = @inContract) and
    (sf_key = @inSFKey) and
    (rf_delivery_days = @inDeliveryDays) order by
    fd_effective_date desc
end
GO
