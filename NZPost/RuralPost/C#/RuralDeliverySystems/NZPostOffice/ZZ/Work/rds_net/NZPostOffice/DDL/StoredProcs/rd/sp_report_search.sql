/****** Object:  StoredProcedure [rd].[sp_report_search]    Script Date: 08/05/2008 10:22:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for stored procedure sp_report_search : 
--

create procedure [rd].[sp_report_search](@inRegion int,@inOutlet int,@inRGCode int,@inSFKey int,@inCTKey int)
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  select distinct contract.contract_no,
    contract.con_active_sequence,
    con_title from
    contract join
    outlet on
    contract.con_base_office = outlet.outlet_id join
    types_for_contract on
    contract.contract_no = types_for_contract.contract_no join
    route_frequency on
    contract.contract_no = route_frequency.contract_no where
    (outlet.region_id = @inRegion or @inRegion is null) and
    (outlet.outlet_id = @inOutlet or @inOutlet is null) and
    (contract.rg_code = @inRGCode or @inRGCode is null) and
    (route_frequency.sf_key = @inSFKey or @inSFKey is null) and
    (types_for_contract.ct_key = @inCTKey or @inCTKey is null) and
    contract.con_active_sequence is not null and
    (contract.con_date_terminated is null or
    contract.con_date_terminated >= getdate()) order by
    contract.con_title asc
end
GO
