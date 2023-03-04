

--
-- Definition for stored procedure sp_SearchForAddress : 
--

create procedure [rd].[sp_SearchForAddress](@in_AdrNum char(40),@in_RoadId int,@in_SuburbId int,@in_TownId int,@in_Contract int,@in_RDNo char(40),@in_Surname char(45),@in_Initials char(30),@in_UI_UserId char(20),@in_ComponentId int)
-- TJB  Sept 2005  NPAD2 address schema changes
as -- Added adr_unit number and road_suffix to relevant parts of address returned
begin
set CONCAT_NULL_YIELDS_NULL off
  select addr.adr_id,
    rds_customer.cust_id,
    rds_customer.cust_surname_company,
    rds_customer.cust_initials,
    adr_num=upper(case when addr.adr_unit is null then '' else addr.adr_unit+'/' end+
    addr.adr_no+addr.adr_alpha) ,
    road_name=(select road_name+
      case when rt.rt_name is null then '' else ' '+rt.rt_name end +
      case when rs.rs_name is null then '' else ' '+rs.rs_name end  from
      road as rd left outer join road_type as rt on rd.rt_id=rt.rt_id left outer join
      road_suffix as rs on rd.rs_id=rs.rs_id where
      rd.road_id = addr.road_id),
    addr.sl_id,
    addr.tc_id,
    addr.adr_rd_no,
    addr.road_id,
    adr_unit=right(space(10)+addr.adr_unit,10),
    adr_no=right(space(10)+addr.adr_no,10),
    adr_alpha=upper(addr.adr_alpha) from
    address as addr,
    rds_customer,
    customer_address_moves,
    towncity where
    rds_customer.cust_id = customer_address_moves.cust_id and
    customer_address_moves.adr_id = addr.adr_id and
    addr.tc_id = towncity.tc_id and
    customer_address_moves.move_out_date is null and
    rds_customer.master_cust_id is null and
    exists(select rds_user_rights.region_id from
      rds_user_rights,
      rds_user_id,
      rds_user_id_group where
      rds_user_id.ui_id = rds_user_id_group.ui_id and
      rds_user_id_group.ug_id = rds_user_rights.ug_id and
      (rds_user_rights.rur_read = 'Y') and
      (rds_user_id.ui_userid = @in_UI_UserId) and
      (rds_user_rights.rc_id = @in_ComponentId) and
      (towncity.region_id = rds_user_rights.region_id or
      (rds_user_rights.region_id = 0 and
      towncity.region_id = (select rds_user.region_id from rds_user where
        rds_user.u_id = rds_user_id.u_id)) or
      (rds_user_rights.region_id = 0 and
      -1 = (select rds_user.region_id from rds_user where
        rds_user.u_id = rds_user_id.u_id)))) and
    (@in_AdrNum = '' or upper(case when addr.adr_unit is null then '' else addr.adr_unit+'/' end+
    addr.adr_no+addr.adr_alpha) like @in_AdrNum+'%') and
    (@in_RoadId = 0 or addr.road_id = @in_RoadId) and
    (@in_SuburbId = 0 or addr.sl_id = @in_SuburbId) and
    (@in_TownId = 0 or addr.tc_id = @in_TownId) and
    (@in_Contract = 0 or addr.contract_no = @in_Contract) and
    (@in_RDNo = '' or addr.adr_rd_no like @in_RDNo+'%') and
    (@in_Surname = '' or rds_customer.cust_surname_company like @in_Surname+'%') and
    (@in_Initials = '' or rds_customer.cust_initials like @in_Initials+'%') union
  select addr.adr_id,
    null,
    null,
    null,
    upper(case when addr.adr_unit is null then '' else addr.adr_unit+'/' end +
    addr.adr_no+addr.adr_alpha) as adr_num,
    road_name=(select road_name+
      case when rt.rt_name is null then '' else ' '+rt.rt_name end +
      case when rs.rs_name is null then '' else ' '+rs.rs_name end from
      road as rd left outer join road_type as rt on rd.rt_id=rt.rt_id left outer join
      road_suffix as rs on rd.rs_id=rs.rs_id where
      rd.road_id = addr.road_id),
    addr.sl_id,
    addr.tc_id,
    addr.adr_rd_no,
    addr.road_id,
    adr_unit=right(space(10)+addr.adr_unit,10),
    adr_no=right(space(10)+addr.adr_no,10),
    adr_alpha=upper(addr.adr_alpha) from
    address as addr,
    towncity where
    addr.tc_id = towncity.tc_id and
    not addr.adr_id = any(select customer_address_moves.adr_id from
      customer_address_moves,rds_customer where
      rds_customer.cust_id = customer_address_moves.cust_id and
      customer_address_moves.move_out_date is null and
      rds_customer.master_cust_id is null) and
    exists(select rds_user_rights.region_id from
      rds_user_rights,
      rds_user_id,
      rds_user_id_group where
      rds_user_id.ui_id = rds_user_id_group.ui_id and
      rds_user_id_group.ug_id = rds_user_rights.ug_id and
      (rds_user_rights.rur_read = 'Y') and
      (rds_user_id.ui_userid = @in_UI_UserId) and
      (rds_user_rights.rc_id = @in_ComponentId) and
      (towncity.region_id = rds_user_rights.region_id or
      (rds_user_rights.region_id = 0 and
      towncity.region_id = (select rds_user.region_id from rds_user where
        rds_user.u_id = rds_user_id.u_id)) or
      (rds_user_rights.region_id = 0 and
      -1 = (select rds_user.region_id from rds_user where
        rds_user.u_id = rds_user_id.u_id)))) and
    (@in_AdrNum = '' or upper(case when addr.adr_unit is null then '' else addr.adr_unit+'/' end +
    addr.adr_no+addr.adr_alpha) like @in_AdrNum+'%') and
    (@in_RoadId = 0 or addr.road_id = @in_RoadId) and
    (@in_SuburbId = 0 or addr.sl_id = @in_SuburbId) and
    (@in_TownId = 0 or addr.tc_id = @in_TownId) and
    (@in_Contract = 0 or addr.contract_no = @in_Contract) and
    (@in_RDNo = '' or addr.adr_rd_no like @in_RDNo+'%') and
    (@in_Surname = '') and
    (@in_Initials = '')
end