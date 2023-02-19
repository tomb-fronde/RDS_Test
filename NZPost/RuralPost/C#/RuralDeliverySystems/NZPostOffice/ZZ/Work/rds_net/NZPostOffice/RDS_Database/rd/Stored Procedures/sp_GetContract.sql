
--
-- Definition for stored procedure sp_GetContract : 
--

--
-- Definition for stored procedure sp_GetContract : 
--

create procedure [rd].[sp_GetContract](@in_Contract int)
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  select contract.contract_no,
    contract.rg_code,
    contract.con_old_mail_service_no,
    contract.con_title,
    contract.con_rd_paper_file_text,
    contract.con_rcm_paper_file_text,
    contract.con_base_office,
    con_base_office_name=(select outlet.o_name from outlet where outlet.outlet_id = contract.con_base_office),
    region_id=(select outlet.region_id from outlet where outlet_id = contract.con_base_office),
    contract.con_lodgement_office,
    con_lodgement_office_name=(select outlet.o_name from outlet where outlet.outlet_id = contract.con_lodgement_office),
    contract.con_active_sequence,
    contract.con_base_cont_type,
    contract.con_rd_ref_text,
    contract.con_last_service_review,
    contract.con_last_delivery_check,
    contract.con_last_work_msrmnt_check,
    contract.con_lngth_sealed_road,
    contract.con_lngth_unsealed_road,
    contract.con_date_terminated from
    contract where
    contract.contract_no = @in_Contract
end