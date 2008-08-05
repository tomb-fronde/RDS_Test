/****** Object:  StoredProcedure [odps].[OD_RPS_VolumesValues]    Script Date: 08/05/2008 10:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for stored procedure OD_RPS_VolumesValues : 
--

create procedure [odps].[OD_RPS_VolumesValues](@sdate datetime,@edate datetime,@inregion int)
-- 14/02/02 PBY Request#4326
-- Removed hardcoding of 'Kiwimail', 'CourierPost' and 'XP' from
-- sql code.  Used the corresponding piece_rate_suplier.prs_key instead.
as
begin
set CONCAT_NULL_YIELDS_NULL off
select distinct contract_no=contract.contract_no,
  region=(select rgn_name from rd.region where region.region_id = outlet.region_id),
  name=c_surname_company + case when c_first_names is null then '' else ', ' + c_first_names end,
  adpostvolume=(select sum(pcpr_volume) from payment_component_piece_rates,payment,payment_component,rd.piece_rate_type,rd.piece_rate_supplier where payment.invoice_id = payment_component.invoice_id and payment.contractor_supplier_no = contractor.contractor_supplier_no and payment.contract_no = contract.contract_no and payment_component_piece_rates.prt_key = piece_rate_type.prt_key and piece_rate_type.prs_key = piece_rate_supplier.prs_key and piece_rate_supplier.prs_key = 1 and payment_component.pc_id = payment_component_piece_rates.pc_id and payment_component.invoice_id = payment.invoice_id and invoice_date = @edate),
  adpostvalue=(select sum(pcpr_value) from payment_component_piece_rates,payment,payment_component,rd.piece_rate_type,rd.piece_rate_supplier where payment.invoice_id = payment_component.invoice_id and payment.contractor_supplier_no = contractor.contractor_supplier_no and payment.contract_no = contract.contract_no and payment_component_piece_rates.prt_key = piece_rate_type.prt_key and piece_rate_type.prs_key = piece_rate_supplier.prs_key and piece_rate_supplier.prs_key = 1 and payment_component.pc_id = payment_component_piece_rates.pc_id and payment_component.invoice_id = payment.invoice_id and invoice_date = @edate),
  courierpostvolume=(select sum(pcpr_volume) from payment_component_piece_rates,payment,payment_component,rd.piece_rate_type,rd.piece_rate_supplier where payment.invoice_id = payment_component.invoice_id and payment.contractor_supplier_no = contractor.contractor_supplier_no and payment.contract_no = contract.contract_no and payment_component_piece_rates.prt_key = piece_rate_type.prt_key and piece_rate_type.prs_key = piece_rate_supplier.prs_key and piece_rate_supplier.prs_key = 2 and payment_component.pc_id = payment_component_piece_rates.pc_id and payment_component.invoice_id = payment.invoice_id and invoice_date = @edate),
  courierpostvalue=(select sum(pcpr_value) from payment_component_piece_rates,payment,payment_component,rd.piece_rate_type,rd.piece_rate_supplier where payment.invoice_id = payment_component.invoice_id and payment.contractor_supplier_no = contractor.contractor_supplier_no and payment.contract_no = contract.contract_no and payment_component_piece_rates.prt_key = piece_rate_type.prt_key and piece_rate_type.prs_key = piece_rate_supplier.prs_key and piece_rate_supplier.prs_key = 2 and payment_component.pc_id = payment_component_piece_rates.pc_id and payment_component.invoice_id = payment.invoice_id and invoice_date = @edate),
  contract_type.contract_type from
  rd.contract,
  rd.outlet,
  rd.contractor,
  rd.contractor_renewals,
  rd.contract_type,rd.types_for_contract where
  (contract.con_base_office = outlet.outlet_id) and
  (contractor_renewals.contractor_supplier_no = contractor.contractor_supplier_no) and
  (contract.contract_no = contractor_renewals.contract_no) and
  (types_for_contract.ct_key = contract_type.ct_key) and
  (types_for_contract.contract_no = contract.contract_no) and
  ((outlet.region_id = @inregion and
  @inregion > 0) or
  (@inregion = 0)) and
  exists(select payment.contractor_supplier_no from
    payment,
    payment_component,
    payment_component_piece_rates where
    (payment_component.invoice_id = payment.invoice_id) and
    (payment_component_piece_rates.pc_id = payment_component.pc_id) and
    (payment.contract_no = contractor_renewals.contract_no) and
    (payment.contractor_supplier_no = contractor_renewals.contractor_supplier_no) and
    (payment.contract_seq_number = contractor_renewals.contract_seq_number) and
    ((payment.invoice_date = @edate))) order by
  1 asc

end
GO
