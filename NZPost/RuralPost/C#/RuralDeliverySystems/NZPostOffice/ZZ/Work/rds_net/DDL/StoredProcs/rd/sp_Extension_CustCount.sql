/****** Object:  StoredProcedure [rd].[sp_Extension_CustCount]    Script Date: 08/05/2008 10:18:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for stored procedure sp_Extension_CustCount : 
--

create procedure [rd].[sp_Extension_CustCount](@inContract int,@inRegion int,@inType char(1))
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  if @intype = '1'
    select cnt=count(*) from
      contract as c,
      outlet as o where
      c.contract_no = @inContract and
      o.outlet_id = c.con_lodgement_office and
      o.region_id = @inregion
  else
    select count(*) from
      contract as c where
      c.contract_no = @inContract
end
GO
