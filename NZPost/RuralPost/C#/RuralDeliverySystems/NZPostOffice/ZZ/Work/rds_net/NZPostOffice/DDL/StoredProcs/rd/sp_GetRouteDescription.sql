/****** Object:  StoredProcedure [rd].[sp_GetRouteDescription]    Script Date: 08/05/2008 10:21:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for stored procedure sp_GetRouteDescription : 
--

--
-- Definition for stored procedure sp_GetRouteDescription : 
--

create procedure [rd].[sp_GetRouteDescription](@inContract int,@inSFKey int,@inDelDays char(7))
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  select sf_key,
    contract_no,
    rd_sequence,
    rf_delivery_days,
    rd_description_of_point=case when cust_id is null then rd_description_of_point else (select c.cust_surname_company+', '+c.cust_initials from customer as c where c.cust_id = route_description.cust_id) end ,
    rd_time_at_point,
    rfv_id,
    rfpd_id,
    rf_distance_of_leg,
    rf_running_total,
    rfv_id_2,
    cust_id from
    route_description where
    contract_no = @inContract and
    sf_key = @inSFKey and
    rf_delivery_days = @inDelDays order by
    rd_sequence asc
end
GO
