
--
-- Definition for stored procedure sp_RptMailCarried : 
--

create procedure [rd].[sp_RptMailCarried](@inContract int,@inSequence int)
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
    standard_frequency.sf_description,
    mail_carried.rf_delivery_days,
    mail_carried.mc_dispatch_carried,
    uplift_outlet_name=uplift_outlet.o_name,
    mail_carried.mc_uplift_time,
    set_down_outlet_name=set_down_outlet.o_name,
    mail_carried.mc_set_down_time,
    region.rgn_name,
    outlet.o_name,
    contract.con_rd_ref_text from
    contract join
    outlet on
    contract.con_base_office = outlet.outlet_id join
    contract_renewals on
    contract.contract_no = contract_renewals.contract_no and
    contract_renewals.contract_seq_number = @inSequence left outer join
    mail_carried on
    contract.contract_no = mail_carried.contract_no and
    mail_carried.mc_disbanded_date is null
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
    mail_carried.sf_key = standard_frequency.sf_key left outer join
    outlet as uplift_outlet on
    mail_carried.mc_uplift_outlet = uplift_outlet.outlet_id left outer join
    outlet as set_down_outlet on
/*    contract join
    outlet as o on
    contract.con_base_office = o.outlet_id join
    contract_renewals as cr on
    contract.contract_no = cr.contract_no and
    cr.contract_seq_number = @inSequence left outer join
    mail_carried as mc on
    contract.contract_no = mc.contract_no and
    mc.mc_disbanded_date is null,
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
    mail_carried left outer join
    standard_frequency on
    mail_carried.sf_key = standard_frequency.sf_key left outer join
    outlet as uplift_outlet on
    mail_carried.mc_uplift_outlet = uplift_outlet.outlet_id left outer join
    outlet as set_down_outlet on
*/
    mail_carried.mc_set_down_outlet = set_down_outlet.outlet_id where
    contract.contract_no = @inContract order by
    standard_frequency.sf_description asc
end