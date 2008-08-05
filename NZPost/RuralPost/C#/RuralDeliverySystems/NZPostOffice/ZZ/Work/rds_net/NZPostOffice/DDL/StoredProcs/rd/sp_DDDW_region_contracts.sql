/****** Object:  StoredProcedure [rd].[sp_DDDW_region_contracts]    Script Date: 08/05/2008 10:18:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--
-- Definition for stored procedure sp_DDDW_region_contracts : 
--

create procedure [rd].[sp_DDDW_region_contracts](@region int,@outlet int)
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  select contract.contract_no,
    contract.con_title from
    contract,
    outlet where
    (contract.con_base_office = outlet.outlet_id) and
    ((outlet.region_id = @region and
    @region <> -1) or
    (@region = -1)) and
    ((outlet.outlet_id = @outlet and
    @outlet <> -1) or
    (@outlet = -1)) union
  select-1,'<All>'  order by
    2 asc
end
GO
