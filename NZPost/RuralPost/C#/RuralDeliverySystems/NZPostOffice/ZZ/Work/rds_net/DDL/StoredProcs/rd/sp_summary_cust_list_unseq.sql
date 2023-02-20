/****** Object:  StoredProcedure [rd].[sp_summary_cust_list_unseq]    Script Date: 08/05/2008 10:23:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [rd].[sp_summary_cust_list_unseq](@in_contract_no int,@in_sf_key int,@in_rd_del_days char(7),@in_sortorder char(1))
-- TJB  SR4664  July 2005  - new
-- Replaces the select in r_summary_customer_listing datawindow
-- Dropped use of v_customers view (huge performance improvement)
-- and added union to append unsequenced customers.
-- This is one of three: this one lists the unsequenced customers.
-- The others are:
--          sp_summary_cust_list_hdr
--          sp_summary_cust_list_seq
----------------------------------------------------------------
-- TJB  Sept 2005  NPAD2 Address schema changes
-- Added adr_unit and road_suffix to addresses
-----------------------------------------------------------------
-- TJB Release 6.8.9 fixup  Nov 2005
-- Added sort order parameter.  Made redundant with
as -- sp_summary_cust_list_cust.
begin
set CONCAT_NULL_YIELDS_NULL off
  select afs_seq_num=99999,
    adr_num=case when address.adr_unit is null then '' else address.adr_unit+'/' end+address.adr_no,
    road_name=road.road_name,
    rt_name=road_type.rt_name+case  when road_suffix.rs_name is null then '' else ' '+road_suffix.rs_name end,
    sl_name=suburblocality.sl_name,
    cust_title=rds_customer.cust_title,
    cust_surname_company=rds_customer.cust_surname_company,
    cust_initials=rds_customer.cust_initials,
    adr_alpha=address.adr_alpha,
    adr_id=address.adr_id from
    address left outer join address_frequency_sequence on
    address_frequency_sequence.adr_id = address.adr_id,
    address as  addr1 left outer join road on addr1.road_id=road.road_id  left outer join
    road_type on road.rt_id=road_type.rt_id left outer join
    road_suffix on road.rs_id=road_suffix.rs_id,
    address as  addr2 left outer join suburblocality on
    suburblocality.sl_id = addr2.sl_id,
    address as addr3 left outer join(
    customer_address_moves join rds_customer on
    customer_address_moves.cust_id = rds_customer.cust_id and
    customer_address_moves.move_out_date is null and
    rds_customer.master_cust_id is null) on
    addr3.adr_id = customer_address_moves.adr_id where
    addr3.contract_no = @in_contract_no and
    address_frequency_sequence.adr_id is null order by
    road_name asc,rt_name asc,sl_name asc,address.adr_no asc,address.adr_alpha asc,address.adr_unit asc
end
GO
