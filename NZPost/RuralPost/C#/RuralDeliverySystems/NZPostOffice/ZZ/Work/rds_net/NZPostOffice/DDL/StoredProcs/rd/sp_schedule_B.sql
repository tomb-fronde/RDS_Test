/****** Object:  StoredProcedure [rd].[sp_schedule_B]    Script Date: 08/05/2008 10:22:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for stored procedure sp_schedule_B : 
--

create procedure [rd].[sp_schedule_B](
@incontract int,
@inSequence int)
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  select contract_no=contract_renewals.contract_no,
    contract_seq_number=contract_renewals.contract_seq_number,
    con_renewal_payment_value=contract_renewals.con_renewal_payment_value,
    con_title=contract.con_title,
    gst_number=contractor.c_gst_number,
    piece_rate_pr_rate=piece_rate.pr_rate,
    piece_rate_type_prt_description=piece_rate_type.prt_description,
    piece_rate_supplier_prs_description=piece_rate_supplier.prs_description,
    piece_rate_type_prt_code=piece_rate_type.prt_code from
    contract_renewals,
    contract,
    contractor_renewals,
    contractor,
    piece_rate,
    piece_rate_type,
    piece_rate_supplier where
    (contract_renewals.contract_no = contract.contract_no) and
    (contract_renewals.contract_no = contractor_renewals.contract_no) and
    (contract_renewals.contract_seq_number = contractor_renewals.contract_seq_number) and
    (contract_renewals.con_date_last_assigned = contractor_renewals.cr_effective_date) and
    (contractor.contractor_supplier_no = contractor_renewals.contractor_supplier_no) and
    (contract_renewals.con_rg_code_at_renewal = piece_rate.rg_code) and
    (contract_renewals.con_rates_effective_date = piece_rate.pr_effective_date) and
    (piece_rate_type.prt_key = piece_rate.prt_key) and
    (piece_rate_supplier.prs_key = piece_rate_type.prs_key) and
    ((contract_renewals.contract_no = @inContract) and
    (contract_renewals.contract_seq_number = @inSequence) and
    (piece_rate.pr_active_status = 'Y') and
    (piece_rate_type.prt_print_on_schedule = 'Y'))
end
GO
