/****** Object:  StoredProcedure [rd].[sp_Contractor32]    Script Date: 08/05/2008 10:18:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for stored procedure sp_Contractor32 : 
--

create procedure  [rd].[sp_Contractor32](@inContract int,@inRenewal int)
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  select contractor.c_surname_company,
    contractor.c_first_names,
    contractor.c_address,
    contractor.c_phone_night,
    contractor.c_phone_day from
    contractor join
    contractor_renewals on
    contractor.contractor_supplier_no = contractor_renewals.contractor_supplier_no
    join
    contract_renewals on
    contractor_renewals.contract_no = contract_renewals.contract_no and
    contractor_renewals.contract_seq_number = contract_renewals.contract_seq_number and
    contractor_renewals.cr_effective_date = contract_renewals.con_date_last_assigned and
    contract_renewals.contract_no = @inContract and
    contract_renewals.contract_seq_number = @inRenewal
end
GO
