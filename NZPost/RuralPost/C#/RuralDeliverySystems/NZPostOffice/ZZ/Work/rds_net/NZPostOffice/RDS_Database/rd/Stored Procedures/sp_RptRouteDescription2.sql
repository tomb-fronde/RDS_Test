
--
-- Definition for stored procedure sp_RptRouteDescription2 : 
--

create procedure  [rd].[sp_RptRouteDescription2](@inContract int,@inSequence int)
-- TJB  Sept 2005  NPAD2 address schema changes
-- Added adr_unit number and road_suffix to relevant parts of address returned
as -- Added adr_alpha (missing in original)
begin
set CONCAT_NULL_YIELDS_NULL off
  -- PBY 24/07/2002 SR#4437 Address not displayed correctly
  select cr.contract_no,
    cr.contract_seq_number,
    con_title=left(contract.con_title,60),
    cr.con_start_date,
    c_surname_company=left(contractor.c_surname_company,40),
    c_first_names=left(contractor.c_first_names,40),
    c_initials=left(contractor.c_initials,10),
    route_description.sf_key,
    sf_description=left(standard_frequency.sf_description,35),
    route_description.rf_delivery_days,
    rfpt_description=left(route_freq_point_type.rfpt_description,40),
    route_description.rd_time_at_point,
    rd_description_of_point=left(case when route_description.cust_id is null then 
    route_description.rd_description_of_point else
    (select case when addr.adr_unit is null then '' else addr.adr_unit+'/'end+
      ISNULL(addr.adr_no,'')+
      ISNULL(addr.adr_alpha,'')+
      case when road.road_name is null then '' else ' '+road.road_name end+
      case when rt.rt_name is null then '' else ' '+rt.rt_name end +
      case when rs.rs_name is null then '' else ' '+rs.rs_name end  from
      address as addr left outer join road on addr.road_id=road.road_id left outer join
      road_type as rt on rt.rt_id=road.rt_id left outer join
      road_suffix as rs on road.rs_id=rs.rs_id where
      addr.adr_id = route_description.adr_id) end ,
    40),
    --  PBY 24/07/2002 Commented Out
    --    left(ifnull(cust_id,rd_description_of_point,(select a.adr_no+' '+r.Road_name+' '+rt.rt_name from Address as a,Road as r,road_type as rt where a.road_id = r.road_id and r.rt_id = rt.rt_id and a.adr_id = route_description.adr_id)),40) as rd_description_of_point,
    route_description.rf_distance_of_leg,
    rfv_description=left(route_freq_verbs.rfv_description,40),
    rfv_description_2=left(route_freq_verbs_2.rfv_description,40),
    route_description.rf_running_total,
    left(o.o_name,40),
    left(region.rgn_name,40),
    left(contract.con_rd_ref_text,35),
    left(rf.rf_annotation,500),
    left(rf.rf_annotation_print,1),
    route_description.cust_id 
from
    contract join
    outlet as o on
    contract.con_base_office = o.outlet_id join
    contract_renewals as cr on
    contract.contract_no = cr.contract_no and
    cr.contract_seq_number = @inSequence left outer join
    route_description  on
    contract.contract_no = route_description.contract_no
    join
    region on
    o.region_id = region.region_id
    join
    contractor_renewals as crr on
    cr.contract_no = crr.contract_no and
    cr.contract_seq_number = crr.contract_seq_number and
    cr.con_date_last_assigned = crr.cr_effective_date
	 join
    contractor on
    crr.contractor_supplier_no = contractor.contractor_supplier_no
 left outer join
    standard_frequency on
    route_description.sf_key = standard_frequency.sf_key left outer join
    route_freq_point_type on
    route_description.rfpd_id = route_freq_point_type.rfpt_id left outer join
    route_freq_verbs on
    route_description.rfv_id = route_freq_verbs.rfv_id left outer join
    route_freq_verbs as route_freq_verbs_2 on
    route_description.rfv_id_2 = route_freq_verbs_2.rfv_id,route_frequency as rf 
where
    rf.contract_no = contract.contract_no and
    rf.sf_key = route_description.sf_key and
    rf.rf_delivery_days = route_description.rf_delivery_days and
    contract.contract_no = @inContract and
    rf.rf_active = 'Y' order by
    standard_frequency.sf_description asc,
    route_description.rf_delivery_days asc,
    route_description.rd_sequence asc
end