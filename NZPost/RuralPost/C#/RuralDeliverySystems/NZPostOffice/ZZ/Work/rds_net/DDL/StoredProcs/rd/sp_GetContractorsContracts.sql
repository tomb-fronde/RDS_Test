/****** Object:  StoredProcedure [rd].[sp_GetContractorsContracts]    Script Date: 08/05/2008 10:19:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for stored procedure sp_GetContractorsContracts : 
--

--
-- Definition for stored procedure sp_GetContractorsContracts : 
--

create procedure [rd].[sp_GetContractorsContracts](@in_Contractor int)
AS
BEGIN
  select distinct
    c.contract_no,
    c.con_title from
    contract as c,
    contractor_renewals as cr,
    contract_renewals as conr where
    c.contract_no = cr.contract_no and
    cr.contractor_supplier_no = @in_Contractor and
    conr.contract_no = c.contract_no and
    conr.contract_seq_number = cr.contract_seq_number and
    cr.cr_effective_date = (select max(cr_effective_date) from contractor_renewals where contract_no = c.contract_no and contract_seq_number = conr.contract_seq_number) order by
    c.con_title asc
end
GO
