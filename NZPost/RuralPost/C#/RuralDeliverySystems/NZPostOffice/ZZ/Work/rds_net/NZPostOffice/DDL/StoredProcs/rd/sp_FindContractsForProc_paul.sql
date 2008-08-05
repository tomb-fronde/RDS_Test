/****** Object:  StoredProcedure [rd].[sp_FindContractsForProc_paul]    Script Date: 08/05/2008 10:19:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for stored procedure sp_FindContractsForProc_paul : 
--

create procedure [rd].[sp_FindContractsForProc_paul](@in_Region int,@in_RgCode int,@in_Contract int)
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  select contract.contract_no,
    contract.con_active_sequence,
    max_sequence=contract_renewals.contract_seq_number,
    contract.con_title,
    con_acceptance_flag from
    contract join
    outlet on
    contract.con_base_office = outlet.outlet_id join
    contract_renewals on
    (contract.contract_no = contract_renewals.contract_no and
    contract_renewals.contract_seq_number = (select max(contract_seq_number) from
      contract_renewals where
      contract_renewals.contract_no = contract.contract_no)/*--by HYang,0*/) where
    (contract.contract_no = @in_Contract or @in_Contract is null) and
    (contract.rg_code = @in_RgCode or @in_RgCode is null) and
    (outlet.region_id = @in_Region or @in_Region is null) and
    (contract_renewals.contract_seq_number > contract.con_active_sequence or
    contract.con_active_sequence is null or
    contract_renewals.con_rates_effective_date < 
    (select max(rr_rates_effective_date) from
      renewal_rate where
      rg_code = (select rg_code from contract as c where c.contract_no = contract_renewals.contract_no))) and
    contract_renewals.contract_seq_number <> isnull(contract.con_active_sequence,0)
end
GO
