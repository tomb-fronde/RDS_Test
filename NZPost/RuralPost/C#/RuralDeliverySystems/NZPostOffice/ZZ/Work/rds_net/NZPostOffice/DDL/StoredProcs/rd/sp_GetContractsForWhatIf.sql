/****** Object:  StoredProcedure [rd].[sp_GetContractsForWhatIf]    Script Date: 08/05/2008 10:19:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for stored procedure sp_GetContractsForWhatIf : 
--

--
-- Definition for stored procedure sp_GetContractsForWhatIf : 
--

create procedure [rd].[sp_GetContractsForWhatIf](@inRegion int,@inRGCode int)
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  select contract.contract_no,
    contract.con_title,
    max(contract_renewals.contract_seq_number) from
    contract join
    outlet on
    contract.con_base_office = outlet.outlet_id join
    contract_renewals on
    contract.contract_no = contract_renewals.contract_no where
    (contract.rg_code = @inRGCode or @inRGCode = 0) and
    (outlet.region_id = @inRegion or @inRegion = 0) and
    (con_date_terminated is null or con_date_terminated > getdate())
    group by contract.contract_no,contract.con_title order by
    contract.contract_no asc
end
GO
