
CREATE procedure [odps].[OD_RPS_VolumesValues_Summary](
	@sdate datetime,
	@edate datetime,
	@inregion int)
AS
-- TJB  RPCR_059  Jan-2014
-- Renamed returned values and added prs5* and prs*name values
-- Re-ordered result columns (moved contract_type)
--
-- TJB  SR4684  June-2006
-- Added support for ParcelPost
--
-- 14/02/02 PBY Request#4326
-- Removed hardcoding of 'Kiwimail', 'CourierPost' and 'XP' from
-- sql code.  Used the corresponding piece_rate_suplier.prs_key instead.
BEGIN
set CONCAT_NULL_YIELDS_NULL off
 
  select distinct 
         contract_no=contract.contract_no,
         region=(select rgn_name from rd.region 
                  where region.region_id = outlet.region_id),
         name=c_surname_company+case when c_first_names is null 
                                     then '' 
                                     else ', '+c_first_names 
                                     end ,
         contract_type=contract_type.contract_type,
         prs1name = (select prs_description from rd.piece_rate_supplier where prs_key = 1),
         prs1volume      = (select sum(pcpr_volume) 
                              from odps.payment_component_piece_rates,
                                   odps.payment,
                                   odps.payment_component,
                                   rd.piece_rate_type,
                                   rd.piece_rate_supplier 
                             where payment.invoice_id = payment_component.invoice_id and
                                   payment.contractor_supplier_no = contractor.contractor_supplier_no and
                                   payment.contract_no = contract.contract_no and
                                   payment_component_piece_rates.prt_key = piece_rate_type.prt_key and
                                   piece_rate_type.prs_key = piece_rate_supplier.prs_key and
                                   piece_rate_supplier.prs_key = 1 and
                                   payment_component.pc_id = payment_component_piece_rates.pc_id and
                                   payment_component.invoice_id = payment.invoice_id and
                                   invoice_date = @edate),
         prs1value       = (select sum(pcpr_value) 
                              from odps.payment_component_piece_rates,
                                   odps.payment,
                                   odps.payment_component,
                                   rd.piece_rate_type,
                                   rd.piece_rate_supplier 
                             where payment.invoice_id = payment_component.invoice_id and
                                   payment.contractor_supplier_no = contractor.contractor_supplier_no and
                                   payment.contract_no = contract.contract_no and
                                   payment_component_piece_rates.prt_key = piece_rate_type.prt_key and
                                   piece_rate_type.prs_key = piece_rate_supplier.prs_key and
                                   piece_rate_supplier.prs_key = 1 and
                                   payment_component.pc_id = payment_component_piece_rates.pc_id and
                                   payment_component.invoice_id = payment.invoice_id and
                                   invoice_date = @edate),
         prs2name = (select prs_description from rd.piece_rate_supplier where prs_key = 2),
         prs2volume      = (select sum(pcpr_volume) 
                              from odps.payment_component_piece_rates,
                                   odps.payment,
                                   odps.payment_component,
                                   rd.piece_rate_type,
                                   rd.piece_rate_supplier 
                             where payment.invoice_id = payment_component.invoice_id and
                                   payment.contractor_supplier_no = contractor.contractor_supplier_no and
                                   payment.contract_no = contract.contract_no and
                                   payment_component_piece_rates.prt_key = piece_rate_type.prt_key and
                                   piece_rate_type.prs_key = piece_rate_supplier.prs_key and
                                   piece_rate_supplier.prs_key = 2 and
                                   payment_component.pc_id = payment_component_piece_rates.pc_id and
                                   payment_component.invoice_id = payment.invoice_id and
                                   invoice_date = @edate),
         prs2value       = (select sum(pcpr_value) 
                              from odps.payment_component_piece_rates,
                                   odps.payment,
                                   odps.payment_component,
                                   rd.piece_rate_type,
                                   rd.piece_rate_supplier 
                             where payment.invoice_id = payment_component.invoice_id and
                                   payment.contractor_supplier_no = contractor.contractor_supplier_no and
                                   payment.contract_no = contract.contract_no and
                                   payment_component_piece_rates.prt_key = piece_rate_type.prt_key and
                                   piece_rate_type.prs_key = piece_rate_supplier.prs_key and
                                   piece_rate_supplier.prs_key = 2 and
                                   payment_component.pc_id = payment_component_piece_rates.pc_id and
                                   payment_component.invoice_id = payment.invoice_id and
                                   invoice_date = @edate),
         prs3name = (select prs_description from rd.piece_rate_supplier where prs_key = 3),
         prs3volume      = (select sum(pcpr_volume) 
                              from odps.payment_component_piece_rates,
                                   odps.payment,
                                   odps.payment_component,
                                   rd.piece_rate_type,
                                   rd.piece_rate_supplier 
                             where payment.invoice_id = payment_component.invoice_id and
                                   payment.contractor_supplier_no = contractor.contractor_supplier_no and
                                   payment.contract_no = contract.contract_no and
                                   payment_component_piece_rates.prt_key = piece_rate_type.prt_key and
                                   piece_rate_type.prs_key = piece_rate_supplier.prs_key and
                                   piece_rate_supplier.prs_key = 3 and
                                   payment_component.pc_id = payment_component_piece_rates.pc_id and
                                   payment_component.invoice_id = payment.invoice_id and
                                   invoice_date = @edate),
         prs3value       = (select sum(pcpr_value) 
                              from odps.payment_component_piece_rates,
                                   odps.payment,
                                   odps.payment_component,
                                   rd.piece_rate_type,
                                   rd.piece_rate_supplier 
                             where payment.invoice_id = payment_component.invoice_id and
                                   payment.contractor_supplier_no = contractor.contractor_supplier_no and
                                   payment.contract_no = contract.contract_no and
                                   payment_component_piece_rates.prt_key = piece_rate_type.prt_key and
                                   piece_rate_type.prs_key = piece_rate_supplier.prs_key and
                                   piece_rate_supplier.prs_key = 3 and
                                   payment_component.pc_id = payment_component_piece_rates.pc_id and
                                   payment_component.invoice_id = payment.invoice_id and
                                   invoice_date = @edate),
         prs4name = (select prs_description from rd.piece_rate_supplier where prs_key = 4),
         prs4volume      = (select sum(pcpr_volume) 
                              from odps.payment_component_piece_rates,
                                   odps.payment,
                                   odps.payment_component,
                                   rd.piece_rate_type,
                                   rd.piece_rate_supplier 
                             where payment.invoice_id = payment_component.invoice_id and
                                   payment.contractor_supplier_no = contractor.contractor_supplier_no and
                                   payment.contract_no = contract.contract_no and
                                   payment_component_piece_rates.prt_key = piece_rate_type.prt_key and
                                   piece_rate_type.prs_key = piece_rate_supplier.prs_key and
                                   piece_rate_supplier.prs_key = 4 and
                                   payment_component.pc_id = payment_component_piece_rates.pc_id and
                                   payment_component.invoice_id = payment.invoice_id and
                                   invoice_date = @edate),
         prs4value       = (select sum(pcpr_value) 
                              from odps.payment_component_piece_rates,
                                   odps.payment,
                                   odps.payment_component,
                                   rd.piece_rate_type,
                                   rd.piece_rate_supplier 
                             where payment.invoice_id = payment_component.invoice_id and
                                   payment.contractor_supplier_no = contractor.contractor_supplier_no and
                                   payment.contract_no = contract.contract_no and
                                   payment_component_piece_rates.prt_key = piece_rate_type.prt_key and
                                   piece_rate_type.prs_key = piece_rate_supplier.prs_key and
                                   piece_rate_supplier.prs_key = 4 and
                                   payment_component.pc_id = payment_component_piece_rates.pc_id and
                                   payment_component.invoice_id = payment.invoice_id and
                                   invoice_date = @edate), 
         prs5name = isnull((select prs_description from rd.piece_rate_supplier where prs_key = 5),'Unassigned'),
         prs5volume      = (select sum(pcpr_volume) 
                              from odps.payment_component_piece_rates,
                                   odps.payment,
                                   odps.payment_component,
                                   rd.piece_rate_type,
                                   rd.piece_rate_supplier 
                             where payment.invoice_id = payment_component.invoice_id and
                                   payment.contractor_supplier_no = contractor.contractor_supplier_no and
                                   payment.contract_no = contract.contract_no and
                                   payment_component_piece_rates.prt_key = piece_rate_type.prt_key and
                                   piece_rate_type.prs_key = piece_rate_supplier.prs_key and
                                   piece_rate_supplier.prs_key = 5 and
                                   payment_component.pc_id = payment_component_piece_rates.pc_id and
                                   payment_component.invoice_id = payment.invoice_id and
                                   invoice_date = @edate),
         prs5value       = (select sum(pcpr_value) 
                              from odps.payment_component_piece_rates,
                                   odps.payment,
                                   odps.payment_component,
                                   rd.piece_rate_type,
                                   rd.piece_rate_supplier 
                             where payment.invoice_id = payment_component.invoice_id and
                                   payment.contractor_supplier_no = contractor.contractor_supplier_no and
                                   payment.contract_no = contract.contract_no and
                                   payment_component_piece_rates.prt_key = piece_rate_type.prt_key and
                                   piece_rate_type.prs_key = piece_rate_supplier.prs_key and
                                   piece_rate_supplier.prs_key = 5 and
                                   payment_component.pc_id = payment_component_piece_rates.pc_id and
                                   payment_component.invoice_id = payment.invoice_id and
                                   invoice_date = @edate)
    from rd.contract,
         rd.outlet,
         rd.contractor,
         rd.contractor_renewals,
         rd.contract_type,
         rd.types_for_contract 
   where contract.con_base_office = outlet.outlet_id and
         contractor_renewals.contractor_supplier_no = contractor.contractor_supplier_no and
         contract.contract_no = contractor_renewals.contract_no and
         types_for_contract.ct_key = contract_type.ct_key and
         types_for_contract.contract_no = contract.contract_no and
         (@inregion = 0 
             or (@inregion > 0 and outlet.region_id = @inregion)) and
         exists(select payment.contractor_supplier_no 
                  from odps.payment,
                       odps.payment_component,
                       odps.payment_component_piece_rates 
                 where payment_component.invoice_id = payment.invoice_id and
                       payment_component_piece_rates.pc_id = payment_component.pc_id and
                       payment.contract_no = contractor_renewals.contract_no and
                       payment.contractor_supplier_no = contractor_renewals.contractor_supplier_no and
                       payment.contract_seq_number = contractor_renewals.contract_seq_number and
                       payment.invoice_date = @edate) 
   order by contract_no asc
end