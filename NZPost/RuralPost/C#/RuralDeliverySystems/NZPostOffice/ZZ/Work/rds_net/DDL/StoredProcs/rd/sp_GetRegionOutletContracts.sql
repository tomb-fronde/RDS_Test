/****** Object:  StoredProcedure [rd].[sp_GetRegionOutletContracts]    Script Date: 08/05/2008 10:20:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for stored procedure sp_GetRegionOutletContracts : 
--

create procedure [rd].[sp_GetRegionOutletContracts](
@Inregion int,
@inOutlet int,
@inContract int)
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  select contract.contract_no,
    contract.con_title from
    contract,
    outlet where
    (contract.con_base_office = outlet.outlet_id) and
    (contract.con_active_sequence is not null) and
    ((contract.contract_no = @incontract and
    @incontract > 0) or
    (contract.con_base_office = @inoutlet and
    @inoutlet > 0 and
    @incontract = 0) or
    (outlet.region_id = @inregion and
    @inregion > 0 and
    @inoutlet = 0) or
    (@inRegion = 0 and @inoutlet = 0 and @incontract = 0)) union
  select 0,'<All Contracts>' 
end
GO
