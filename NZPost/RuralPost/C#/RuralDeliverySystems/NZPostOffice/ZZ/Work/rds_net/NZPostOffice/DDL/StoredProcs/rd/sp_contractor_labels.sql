/****** Object:  StoredProcedure [rd].[sp_contractor_labels]    Script Date: 08/05/2008 10:18:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for stored procedure sp_contractor_labels : 
--

create procedure [rd].[sp_contractor_labels](@inregion int,@incontractor char(40),@incontracttype int,@inrengroup int,@inoutlet int,@incontracts int,@incontractflag char(1))
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  select distinct contractor.c_title,
    contractor.c_surname_company,
    contractor.c_first_names,
    contractor.c_initials,
    contractor.c_address,Label='Rural Delivery Owner Driver' from
    contract_renewals left outer join contractor_renewals on
    contract_renewals.contract_no = contractor_renewals.contract_no and
    contract_renewals.contract_seq_number = contractor_renewals.contract_seq_number and
    contract_renewals.con_date_last_assigned = contractor_renewals.cr_effective_date,
    contractor left outer join types_for_contractor on contractor.contractor_supplier_no = types_for_contractor.contractor_supplier_no,
    contract,
    outlet where
    (contractor.contractor_supplier_no = contractor_renewals.contractor_supplier_no) and
    (contract_renewals.contract_no = contract.contract_no) and
    (contract_renewals.contract_seq_number = contract.con_active_sequence) and
    (contractor_renewals.contract_seq_number = contract.con_active_sequence) and
    (contract.con_base_office = outlet.outlet_id) and
    ((outlet.region_id = @inregion and
    @inregion is not null) or
    (@inregion is null)) and
    ((contractor.c_surname_company like @incontractor + '%' and
    @incontractor is not null) or
    (@incontractor is null)) and
    ((types_for_contractor.ct_key = @incontracttype and
    @incontracttype is not null) or
    (@incontracttype is null)) and
    ((contract.rg_code = @inrengroup and
    @inrengroup is not null) or
    (@inrengroup is null)) and
    ((outlet.outlet_id = @inoutlet and
    @inoutlet is not null) or
    (@inoutlet is null)) and
    ((contract.contract_no in(@incontracts) and
    @incontractflag = 'Y') or
    (@incontractflag = 'N')) and
    contract.con_date_terminated is null
end
GO
