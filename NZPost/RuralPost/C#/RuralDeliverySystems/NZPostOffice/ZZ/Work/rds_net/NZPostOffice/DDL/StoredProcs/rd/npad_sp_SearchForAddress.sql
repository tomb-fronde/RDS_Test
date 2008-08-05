/****** Object:  StoredProcedure [rd].[npad_sp_SearchForAddress]    Script Date: 08/05/2008 10:17:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--
-- Definition for stored procedure npad_sp_SearchForAddress : 
--

create procedure [rd].[npad_sp_SearchForAddress](@in_AdrNum char(40),@in_RoadId int,@in_SuburbId int,@in_TownId int,@in_Contract int,@in_RDNo char(40),@in_Surname char(45),@in_Initials char(30),@in_UI_UserId char(20),@in_ComponentId int)
--**********************************************************
-- TJB  NPAD2 testing  Oct 2005
-- This variant is used for NPAD2 testing
-- It is used by the NPAD testing application to search
-- for addresses as NPAD would know them (with a cust name
-- if there isn''t an adr_no, and no name if there is).
--**********************************************************
-- TJB  Sept 2005  NPAD2 address schema changes
as -- Added adr_unit number and road_suffix to relevant parts of address returned
begin
set CONCAT_NULL_YIELDS_NULL off
  -- First:  all the numbered addresses that meet the criteria
  select addr.adr_id,
    rds_customer.cust_id,
    cust_surname_company=null,
    cust_initials=null,
    adr_num=upper(case when addr.adr_unit is null then '' else addr.adr_unit+'/' end +
    addr.adr_no+addr.adr_alpha),
    --(select road_name
    --        +ifnull(rt.rt_name,'',' '+rt.rt_name)
    --        +ifnull(rs.rs_name,'',' '+rs.rs_name)
    --   from road rd left outer join road_type rt
    --                left outer join road_suffix rs
    --  where rd.road_id = addr.road_id)                    as road_name,
    rd.road_name,
    addr.sl_id,
    addr.tc_id,
    addr.adr_rd_no,
    addr.road_id,
    adr_unit=right(space(10)+addr.adr_unit,10),
    adr_no=right(space(10)+addr.adr_no,10),
    adr_alpha=upper(addr.adr_alpha),
    addr.dp_id,
    master_dp_id=null,
    addr.adr_property_identification,
    pc.post_code,
    rd.rt_id,
    rd.rs_id,
    rt.rt_name,
    rs.rs_name from
    address as addr left outer join post_code as pc on addr.post_code_id = pc.post_code_id,
    road as rd left outer join road_type as rt on rd.rt_id = rt.rt_id left outer join
    road_suffix as rs on rd.rs_id = rs.rs_id,
    rds_customer,
    customer_address_moves,
    towncity where
    rds_customer.cust_id = customer_address_moves.cust_id and
    customer_address_moves.adr_id = addr.adr_id and
    addr.tc_id = towncity.tc_id and
    customer_address_moves.move_out_date is null and
    rds_customer.master_cust_id is null and
    rd.road_id = addr.road_id and
    -- and exists(select rds_user_rights.region_id 
    --              from rds_user_rights,
    --                   rds_user_id,
    --                   rds_user_id_group 
    --             where rds_user_id.ui_id = rds_user_id_group.ui_id 
    --               and rds_user_id_group.ug_id = rds_user_rights.ug_id 
    --               and (rds_user_rights.rur_read = 'Y') 
    --               and (rds_user_id.ui_userid = in_UI_UserId) 
    --               and (rds_user_rights.rc_id = in_ComponentId) 
    --               and (towncity.region_id = rds_user_rights.region_id 
    --                    or (rds_user_rights.region_id = 0 
    --                        and towncity.region_id = (select rds_user.region_id from rds_user 
    --                                                   where rds_user.u_id = rds_user_id.u_id))
    --                    or (rds_user_rights.region_id = 0 
    --                        and -1 = (select rds_user.region_id from rds_user 
    --                                   where rds_user.u_id = rds_user_id.u_id))
    --                   )
    --           ) 
    (@in_AdrNum = '' or upper(case when addr.adr_unit is null then '' else addr.adr_unit+'/' end + addr.adr_no+addr.adr_alpha) like @in_AdrNum+'%') and
    (@in_RoadId = 0 or addr.road_id = @in_RoadId) and
    (@in_SuburbId = 0 or addr.sl_id = @in_SuburbId) and
    (@in_TownId = 0 or addr.tc_id = @in_TownId) and
    (@in_Contract = 0 or addr.contract_no = @in_Contract) and
    (@in_RDNo = '' or addr.adr_rd_no like @in_RDNo+'%') and
    (@in_Surname = '' or rds_customer.cust_surname_company like @in_Surname+'%') and
    (@in_Initials = '' or rds_customer.cust_initials like @in_Initials+'%') and
    (upper(case when addr.adr_unit is null then '' else addr.adr_unit+'/' end + addr.adr_no+addr.adr_alpha) <> '' and upper(case when addr.adr_unit is null then '' else addr.adr_unit+'/' end + addr.adr_no+addr.adr_alpha) is not null) union
  -- Second:  all the un-numbered addresses that meet the criteria
  select addr.adr_id,
    rds_customer.cust_id,
    cust_surname_company=rds_customer.cust_surname_company,
    cust_initials=rds_customer.cust_initials,
    adr_num=upper(case when addr.adr_unit is null then '' else addr.adr_unit+'/' end +
    addr.adr_no+addr.adr_alpha),
    --(select road_name
    --        +ifnull(rt.rt_name,'',' '+rt.rt_name)
    --        +ifnull(rs.rs_name,'',' '+rs.rs_name)
    --   from road rd left outer join road_type rt
    --                left outer join road_suffix rs
    --  where rd.road_id = addr.road_id)                    as road_name,
    rd.road_name,
    addr.sl_id,
    addr.tc_id,
    addr.adr_rd_no,
    addr.road_id,
    adr_unit=right(space(10)+addr.adr_unit,10),
    adr_no=right(space(10)+addr.adr_no,10),
    adr_alpha=upper(addr.adr_alpha),
    cam.dp_id,
    master_dp_id=(select dp_id from customer_address_moves as cam2 where cam2.cust_id = master_cust_id),
    addr.adr_property_identification,
    pc.post_code,
    rd.rt_id,
    rd.rs_id,
    rt.rt_name,
    rs.rs_name from
    address as addr left outer join post_code as pc on addr.post_code_id = pc.post_code_id,
    road as rd left outer join road_type as rt on rd.rt_id = rt.rt_id left outer join
    road_suffix as rs on rd.rs_id = rs.rs_id,
    rds_customer,
    customer_address_moves as cam,
    towncity where
    rds_customer.cust_id = cam.cust_id and
    cam.adr_id = addr.adr_id and
    addr.tc_id = towncity.tc_id and
    cam.move_out_date is null and
    rd.road_id = addr.road_id and
    -- and rds_customer.master_cust_id is null 
    -- and exists(select rds_user_rights.region_id 
    --              from rds_user_rights,
    --                   rds_user_id,
    --                   rds_user_id_group 
    --             where rds_user_id.ui_id = rds_user_id_group.ui_id 
    --               and rds_user_id_group.ug_id = rds_user_rights.ug_id 
    --               and (rds_user_rights.rur_read = 'Y') 
    --               and (rds_user_id.ui_userid = in_UI_UserId) 
    --               and (rds_user_rights.rc_id = in_ComponentId) 
    --               and (towncity.region_id = rds_user_rights.region_id 
    --                    or (rds_user_rights.region_id = 0 
    --                        and towncity.region_id = (select rds_user.region_id from rds_user 
    --                                                   where rds_user.u_id = rds_user_id.u_id))
    --                    or (rds_user_rights.region_id = 0 
    --                        and -1 = (select rds_user.region_id from rds_user 
    --                                   where rds_user.u_id = rds_user_id.u_id))
    --                   )
    --           ) 
    --and (in_AdrNum    = '' or adr_num   like in_AdrNum+'%') 
    (@in_RoadId = 0 or addr.road_id = @in_RoadId) and
    (@in_SuburbId = 0 or addr.sl_id = @in_SuburbId) and
    (@in_TownId = 0 or addr.tc_id = @in_TownId) and
    (@in_Contract = 0 or addr.contract_no = @in_Contract) and
    (@in_RDNo = '' or addr.adr_rd_no like @in_RDNo+'%') and
    (@in_Surname = '' or rds_customer.cust_surname_company like @in_Surname+'%') and
    (@in_Initials = '' or rds_customer.cust_initials like @in_Initials+'%') and
    (upper(case when addr.adr_unit is null then '' else addr.adr_unit+'/' end + addr.adr_no+addr.adr_alpha) = '' or upper(case when addr.adr_unit is null then '' else addr.adr_unit+'/' end + addr.adr_no+addr.adr_alpha) is null) and
    (rds_customer.cust_surname_company <> '' and rds_customer.cust_surname_company is not null) union
  -- Finally, any unoccupied, numbered addresses that meet the criteria
  select addr.adr_id,
    cust_id=null,
    cust_surname_company=null,
    cust_initials=null,
    adr_num=upper(case when addr.adr_unit is null then '' else addr.adr_unit+'/' end +
    addr.adr_no+addr.adr_alpha),
    --(select road_name
    --        +ifnull(rt.rt_name,'',' '+rt.rt_name)
    --        +ifnull(rs.rs_name,'',' '+rs.rs_name)
    --   from road rd left outer join road_type rt
    --                left outer join road_suffix rs
    --  where rd.road_id = addr.road_id)                    as road_name,
    rd.road_name,
    addr.sl_id,
    addr.tc_id,
    addr.adr_rd_no,
    addr.road_id,
    adr_unit=right(space(10)+addr.adr_unit,10),
    adr_no=right(space(10)+addr.adr_no,10),
    adr_alpha=upper(addr.adr_alpha),
    addr.dp_id,
    master_dp_id=null,
    addr.adr_property_identification,
    pc.post_code,
    rd.rt_id,
    rd.rs_id,
    rt.rt_name,
    rs.rs_name from
    address as addr left outer join post_code as pc on addr.post_code_id = pc.post_code_id,
    road as rd left outer join road_type as rt on rd.rt_id = rt.rt_id left outer join
    road_suffix as rs on rd.rs_id = rs.rs_id,
    towncity where
    addr.tc_id = towncity.tc_id and
    rd.road_id = addr.road_id and
    not addr.adr_id = any(select customer_address_moves.adr_id from
      customer_address_moves,rds_customer where
      rds_customer.cust_id = customer_address_moves.cust_id and
      customer_address_moves.move_out_date is null and
      rds_customer.master_cust_id is null) and
    -- and exists(select rds_user_rights.region_id 
    --              from rds_user_rights,
    --                   rds_user_id,
    --                   rds_user_id_group 
    --             where rds_user_id.ui_id = rds_user_id_group.ui_id 
    --               and rds_user_id_group.ug_id = rds_user_rights.ug_id 
    --               and (rds_user_rights.rur_read = 'Y') 
    --               and (rds_user_id.ui_userid = in_UI_UserId) 
    --               and (rds_user_rights.rc_id = in_ComponentId) 
    --               and (towncity.region_id = rds_user_rights.region_id 
    --                    or (rds_user_rights.region_id = 0 
    --                        and towncity.region_id = (select rds_user.region_id from rds_user 
    --                                                   where rds_user.u_id = rds_user_id.u_id)) 
    --                    or (rds_user_rights.region_id = 0 
    --                        and -1 = (select rds_user.region_id from rds_user 
    --                                  where rds_user.u_id = rds_user_id.u_id))
    --                   )
    --           ) 
    (@in_AdrNum = '' or upper(case when addr.adr_unit is null then '' else addr.adr_unit+'/' end + addr.adr_no+addr.adr_alpha) like @in_AdrNum+'%') and
    (@in_RoadId = 0 or addr.road_id = @in_RoadId) and
    (@in_SuburbId = 0 or addr.sl_id = @in_SuburbId) and
    (@in_TownId = 0 or addr.tc_id = @in_TownId) and
    (@in_Contract = 0 or addr.contract_no = @in_Contract) and
    (@in_RDNo = '' or addr.adr_rd_no like @in_RDNo+'%') and
    (@in_Surname = '') and
    (@in_Initials = '') and
    (upper(case when addr.adr_unit is null then '' else addr.adr_unit+'/' end + addr.adr_no+addr.adr_alpha) <> '' and upper(case when addr.adr_unit is null then '' else addr.adr_unit+'/' end + addr.adr_no+addr.adr_alpha) is not null)
end
GO
