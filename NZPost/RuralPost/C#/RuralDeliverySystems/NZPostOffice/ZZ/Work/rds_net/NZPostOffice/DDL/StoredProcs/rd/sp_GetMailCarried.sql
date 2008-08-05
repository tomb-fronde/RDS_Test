/****** Object:  StoredProcedure [rd].[sp_GetMailCarried]    Script Date: 08/05/2008 10:20:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for stored procedure sp_GetMailCarried : 
--

create procedure [rd].[sp_GetMailCarried](
@inContract int,
@inSFKey int,
@inDeliveryDays char(7))
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  select sf_key,
    contract_no,
    mc_sequence_no,
    rf_delivery_days,
    mc_dispatch_carried,
    mc_uplift_time,
    mc_uplift_outlet,
    mc_uplift_outlet_name=(select o_name from outlet where outlet_id = mc_uplift_outlet),
    mc_set_down_time,
    mc_set_down_outlet,
    mc_set_down_outlet_name=(select o_name from outlet where outlet_id = mc_set_down_outlet),
    mc_disbanded_date,
    0,
    0,
    mc_set_down_next_day 
  from  mail_carried 
  where
    contract_no = @inContract and
    sf_key = @inSFKey and
    rf_delivery_days = @inDeliveryDays
end
GO
