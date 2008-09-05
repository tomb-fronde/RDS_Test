/****** Object:  StoredProcedure [rd].[sp_QS_Outlets]    Script Date: 08/05/2008 10:21:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for stored procedure sp_QS_Outlets : 
--

create procedure [rd].[sp_QS_Outlets](@in_Region int,@in_Outlet varchar(40))
-- TJB SR4579
as -- Added lookup/return of outlet type
begin
set CONCAT_NULL_YIELDS_NULL off
  --  select outlet_id,
  --    o_name
  --    from outlet
  --    where(in_Region=0 or outlet.region_id=in_Region)
  --    and o_name like in_Outlet||'%' order by o_name asc
  select outlet_id,
    o_name,
    ot_outlet_type from
    outlet,outlet_type where
    (@in_Region = 0 or outlet.region_id = @in_Region) and
    o_name like @in_Outlet + '%' and
    outlet.ot_code = outlet_type.ot_code order by
    o_name asc
end
GO
