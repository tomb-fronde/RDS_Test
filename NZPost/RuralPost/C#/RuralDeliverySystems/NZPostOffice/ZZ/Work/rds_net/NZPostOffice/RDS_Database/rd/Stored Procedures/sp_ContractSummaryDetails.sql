
--
-- Definition for stored procedure sp_ContractSummaryDetails : 
--

create procedure [rd].[sp_ContractSummaryDetails](@inContract int,@inSequence int)
-- TJB  SR4657  June05
as -- Changed source of lastdate returned value
begin
set CONCAT_NULL_YIELDS_NULL off
  select contract.contract_no,
    contract.con_old_mail_service_no,
    contract.con_title,
    contract_renewals.con_renewal_payment_value,
    region.rgn_name,
    region.rgn_rcm_manager,
    region.rgn_telephone,
    outlet_a.o_name,
    contract_renewals.con_start_date,
    contract_renewals.con_expiry_date,
    contract.con_last_work_msrmnt_check,
    contract.con_last_delivery_check,
    ext_amt=(select sum(fa.fd_adjustment_amount) from rd.contract_renewals as cr,rd.frequency_adjustments as fa where fa.contract_no = contract.contract_no and(cr.contract_no = fa.contract_no) and(cr.contract_seq_number = fa.contract_seq_number)),
    lodgement=(select o_name from rd.outlet where outlet_id = contract.con_lodgement_office),
    contract.con_active_sequence,
    contract.con_rcm_paper_file_text,
    contract.con_rd_ref_text,
    contract.con_rd_paper_file_text,
    contract_renewals.con_acceptance_flag,
    -- TJB  SR4657  June05
    -- (select c.con_date_last_prt_for_od from contract as c where c.contract_no = contract.contract_no) as lastdate 
    lastdate=contract.cust_list_printed from
    rd.contract,
    rd.outlet as outlet_a,
    rd.contract_renewals,
    rd.region where
    (region.region_id = outlet_a.region_id) and
    (outlet_a.outlet_id = contract.con_base_office) and
    (contract.contract_no = contract_renewals.contract_no) and
    (((contract_renewals.contract_seq_number = 
    (select con_active_sequence from
      contract where
      contract.contract_no = contract_renewals.contract_no) and
    @insequence = -2)) or
    ((1 = 1 and @insequence = -1)) or
    ((contract_renewals.contract_seq_number = @insequence and
    @insequence not in(-1,-2)))) and
    ((contract.contract_no = @incontract and @incontract <> -1) or
    (@incontract = -1))
end