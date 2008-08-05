/****** Object:  StoredProcedure [rd].[sp_summary_cust_list_cust]    Script Date: 08/05/2008 10:22:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [rd].[sp_summary_cust_list_cust](@in_contract_no int,@in_sf_key int,@in_rd_del_days char(7),@in_sortorder char(1))
-- TJB Release 6.8.9 fixup  Nov 2005  NEW
-- Sort sequenced and unsequenced by customer, with no-customer addresses last
-- Use '99999' as sequence number for unsequenced (data window strips these values)
-- and 'ZZZZZ' for customer surname and initials where there''s no customer (again
-- the datawindow strips these values out), so the sorting works.
-- Note: the sortorder parameter is no longer used.
-- see 
--      sp_summary_cust_list
--      sp_summary_cust_list_hdr
--      sp_summary_cust_list_seq
as --      sp_summary_cust_list_unseq
begin
set CONCAT_NULL_YIELDS_NULL off
  select afs_seq_num=address_frequency_sequence.seq_num,
    adr_num=case when addr1.adr_unit is null then '' else addr1.adr_unit+'/' end +addr1.adr_no,
    road_name=road.road_name,
    rt_name=road_type.rt_name+case when road_suffix.rs_name is null then '' else ' '+road_suffix.rs_name end,
    sl_name=suburblocality.sl_name,
    cust_title=rds_customer.cust_title,
    cust_surname_company=case  when rds_customer.cust_surname_company is null then 'ZZZZZ' else rds_customer.cust_surname_company end,
    cust_initials=rds_customer.cust_initials,
    adr_alpha=addr1.adr_alpha,
    adr_id=addr1.adr_id from
    address as addr1 left outer join road on addr1.road_id=road.road_id left outer join 
    road_type on road_type.rt_id=road.rt_id left outer join 
    road_suffix on road.rs_id=road_suffix.rs_id,
    address as addr2 left outer join suburblocality on
    suburblocality.sl_id = addr2.sl_id,
    address as addr3 left outer join(
    customer_address_moves join rds_customer on
    customer_address_moves.cust_id = rds_customer.cust_id and
    customer_address_moves.move_out_date is null and
    rds_customer.master_cust_id is null) on
    addr3.adr_id = customer_address_moves.adr_id,
    address_frequency_sequence where
    addr1.contract_no = @in_contract_no and
    address_frequency_sequence.adr_id = addr1.adr_id and
    address_frequency_sequence.sf_key = @in_sf_key and
    address_frequency_sequence.rf_delivery_days = @in_rd_del_days 
union
  select afs_seq_num=99999,
    adr_num=case when addr4.adr_unit is null then '' else addr4.adr_unit+'/' end +addr4.adr_no,
    road_name=road.road_name,
    rt_name=road_type.rt_name+case when road_suffix.rs_name is null then '' else ' '+road_suffix.rs_name end,
    sl_name=suburblocality.sl_name,
    cust_title=rds_customer.cust_title,
    cust_surname_company=case when rds_customer.cust_surname_company is null then 'ZZZZZ' else rds_customer.cust_surname_company end,
    cust_initials=rds_customer.cust_initials,
    adr_alpha=addr4.adr_alpha,
    adr_id=addr4.adr_id from
    address as addr4 left outer join address_frequency_sequence on
    address_frequency_sequence.adr_id = addr4.adr_id,
    address as addr5 left outer join road on addr5.road_id=road.road_id left outer join
    road_type on road.rt_id=road_type.rt_id left outer join
    road_suffix on road.rs_id=road_suffix.rs_id,
    address addr6 left outer join suburblocality on
    suburblocality.sl_id = addr6.sl_id,
    address as addr7 left outer join(
    customer_address_moves join rds_customer on
    customer_address_moves.cust_id = rds_customer.cust_id and
    customer_address_moves.move_out_date is null and
    rds_customer.master_cust_id is null) on
    addr7.adr_id = customer_address_moves.adr_id where
    addr4.contract_no = @in_contract_no and
    address_frequency_sequence.adr_id is null order by
    cust_surname_company asc,cust_initials asc,afs_seq_num asc,road_name asc,rt_name asc,sl_name asc,adr_num asc


end
GO
