create procedure [rd].[sp_summary_cust_list_seq](@in_contract_no int,@in_sf_key int,@in_rd_del_days char(7),@in_sortorder char(1))
-- TJB  SR4664  July 2005  - new
-- Replaces the select in r_summary_customer_listing datawindow
-- Dropped use of v_customers view (huge performance improvement)
-- and added union to append unsequenced customers.
-- This is one of three: this one lists the sequenced customers.
-- The others are:
--          sp_summary_cust_list_hdr
--          sp_summary_cust_list_unseq
-----------------------------------------------------------------
-- TJB  Sept 2005  NPAD2 Address schema changes
-- Added adr_unit and road_suffix to addresses
-----------------------------------------------------------------
-- TJB Release 6.8.9 fixup  Nov 2005
-- Added sort order parameter.  Made redundant with
as -- sp_summary_cust_list_cust.
begin
set CONCAT_NULL_YIELDS_NULL off
  select afs_seq_num=address_frequency_sequence.seq_num,
    adr_no=case when address.adr_unit is null then '' else address.adr_unit+'/' end+address.adr_no,
    road_name=road.road_name,
    rt_name=road_type.rt_name+case when road_suffix.rs_name is null then '' else ' '+road_suffix.rs_name end,
    sl_name=suburblocality.sl_name,
    cust_title=rds_customer.cust_title,
    cust_surname_company=rds_customer.cust_surname_company,
    cust_initials=rds_customer.cust_initials,
    adr_alpha=address.adr_alpha,
    adr_id=address.adr_id from
    address as addr1 left outer join road on addr1.road_id=road.road_id left outer join
    road_type on road.rt_id=road_type.rt_id left outer join
    road_suffix on road.rs_id=road_suffix.rs_id,
    address as addr2 left outer join suburblocality on
    suburblocality.sl_id = addr2.sl_id,
    address left outer join(
    customer_address_moves join rds_customer on
    customer_address_moves.cust_id = rds_customer.cust_id and
    customer_address_moves.move_out_date is null and
    rds_customer.master_cust_id is null) on
    address.adr_id = customer_address_moves.adr_id,
    address_frequency_sequence where
    address.contract_no = @in_contract_no and
    address_frequency_sequence.adr_id = address.adr_id and
    address_frequency_sequence.sf_key = @in_sf_key and
    address_frequency_sequence.rf_delivery_days = @in_rd_del_days order by
    afs_seq_num asc
end