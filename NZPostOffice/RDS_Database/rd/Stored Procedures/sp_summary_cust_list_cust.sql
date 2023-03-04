
CREATE procedure [rd].[sp_summary_cust_list_cust](
	@in_contract_no int,
	@in_sf_key      int,
	@in_rd_del_days char(7))
as
begin
--
-- TJB Release 6.8.9 fixup  Nov 2005  NEW
-- Sort sequenced and unsequenced by customer, with no-customer addresses last
-- Use '99999' as sequence number for unsequenced (data window strips these values)
-- and 'ZZZZZ' for customer surname and initials where there''s no customer (again
-- the datawindow strips these values out), so the sorting works.
--
-- Note: the sortorder parameter is no longer used.
--
-- See 
--      sp_summary_cust_list
--      sp_summary_cust_list_hdr
--      sp_summary_cust_list_seq
--      sp_summary_cust_list_unseq

  set CONCAT_NULL_YIELDS_NULL off
  
  select 
         afs_seq_num=case when address_frequency_sequence.seq_num is NULL
                                          then 99999
                                      else address_frequency_sequence.seq_num end,
         adr_num = case when addr1.adr_unit is null 
                        then '' 
                        else addr1.adr_unit+'/' end 
                   + addr1.adr_no,
         road_name = road.road_name,
         rt_name = road_type.rt_name 
                   + case when road_suffix.rs_name is null 
                          then '' 
                          else ' '+road_suffix.rs_name end,
         sl_name = suburblocality.sl_name,
         cust_title = rds_customer.cust_title,
         cust_surname_company = case when rds_customer.cust_surname_company is null 
                                     then 'ZZZZZ' 
                                     else rds_customer.cust_surname_company end,
         cust_initials=rds_customer.cust_initials,
         adr_alpha=addr1.adr_alpha,
         adr_id=addr1.adr_id 
    from 
         rd.address as addr1 left outer join rd.road 
                               on addr1.road_id = road.road_id 
                          left outer join rd.road_type 
                               on road.rt_id = road_type.rt_id 
                          left outer join rd.road_suffix 
                               on road_suffix.rs_id = road.rs_id
                          left outer join rd.suburblocality 
                               on suburblocality.sl_id = addr1.sl_id
                          left outer join (rd.customer_address_moves join rd.rds_customer 
                                                                  on  rds_customer.cust_id = customer_address_moves.cust_id 
                                                                  and customer_address_moves.move_out_date is null 
                                                                  and rds_customer.master_cust_id is null) 
                                     on customer_address_moves.adr_id = addr1.adr_id
        left outer join  rd.address_frequency_sequence  on address_frequency_sequence.adr_id = addr1.adr_id
   where
         addr1.contract_no = @in_contract_no and
         ((address_frequency_sequence.adr_id = addr1.adr_id and
         address_frequency_sequence.sf_key = @in_sf_key and
         address_frequency_sequence.rf_delivery_days = @in_rd_del_days) 
            or (address_frequency_sequence.adr_id is NULL))
   order by
         afs_seq_num asc,
	 cust_surname_company asc,
         cust_initials asc,
         road_name asc,
         rt_name asc,sl_name asc,
         adr_num asc


end