
--
-- Definition for stored procedure sp_RptRouteDescription : 
--

create procedure [rd].[sp_RptRouteDescription](@inContract int,@inSequence int)
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  select contract_renewals.contract_no,
    contract_renewals.contract_seq_number,
    contract.con_title,
    contract_renewals.con_start_date,
    contractor.c_surname_company,
    contractor.c_first_names,
    contractor.c_initials,
    route_description.sf_key,
    standard_frequency.sf_description,
    route_description.rf_delivery_days,
    route_freq_point_type.rfpt_description,
    route_description.rd_time_at_point,
    route_description.rd_description_of_point,
    route_description.rf_distance_of_leg,
    route_freq_verbs.rfv_description,
    route_freq_verbs_2.rfv_description,
    route_description.rf_running_total,
    outlet.o_name,
    region.rgn_name,
    contract.con_rd_ref_text from
    contract join
    outlet  on contract.con_base_office = outlet.outlet_id join
    contract_renewals on
    contract.contract_no = contract_renewals.contract_no and
    contract_renewals.contract_seq_number = @inSequence left outer join
    route_description on
    contract.contract_no = route_description.contract_no
	 join region on
    outlet.region_id = region.region_id
	 join contractor_renewals on
    contract_renewals.contract_no = contractor_renewals.contract_no and
    contract_renewals.contract_seq_number = contractor_renewals.contract_seq_number and
    contract_renewals.con_date_last_assigned = contractor_renewals.cr_effective_date
	 join contractor on
    contractor_renewals.contractor_supplier_no = contractor.contractor_supplier_no
	 left outer join
    standard_frequency on
    route_description.sf_key = standard_frequency.sf_key left outer join
    route_freq_point_type on
    route_description.rfpd_id = route_freq_point_type.rfpt_id left outer join
    route_freq_verbs on
    route_description.rfv_id = route_freq_verbs.rfv_id left outer join
    route_freq_verbs as route_freq_verbs_2 on
/*!
    contract join
    outlet as o on contract.con_base_office = o.outlet_id join
    contract_renewals as cr on
    contract.contract_no = cr.contract_no and
    cr.contract_seq_number = @inSequence left outer join
    route_description as rd on
    contract.contract_no = rd.contract_no,
    outlet join
    region on
    outlet.region_id = region.region_id,
    contract_renewals join
    contractor_renewals as crr on
    contract_renewals.contract_no = crr.contract_no and
    contract_renewals.contract_seq_number = crr.contract_seq_number and
    contract_renewals.con_date_last_assigned = crr.cr_effective_date,
    contractor_renewals join
    contractor on
    contractor_renewals.contractor_supplier_no = contractor.contractor_supplier_no,
    route_description left outer join
    standard_frequency on
    route_description.sf_key = standard_frequency.sf_key left outer join
    route_freq_point_type on
    route_description.rfpd_id = route_freq_point_type.rfpt_id left outer join
    route_freq_verbs on
    route_description.rfv_id = route_freq_verbs.rfv_id left outer join
    route_freq_verbs as route_freq_verbs_2 on
*/
    route_description.rfv_id_2 = route_freq_verbs_2.rfv_id where
    contract.contract_no = @inContract order by
    standard_frequency.sf_description asc,
    route_description.rf_delivery_days asc,
    route_description.rd_sequence asc
end