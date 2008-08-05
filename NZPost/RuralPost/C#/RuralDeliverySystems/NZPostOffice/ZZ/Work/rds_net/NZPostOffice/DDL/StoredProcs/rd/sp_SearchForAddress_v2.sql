/****** Object:  StoredProcedure [rd].[sp_SearchForAddress_v2]    Script Date: 08/05/2008 10:22:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [rd].[sp_SearchForAddress_v2](@in_AdrNum char(40),@in_RoadName char(50),@in_RoadType int,@in_RoadSuffix int,@in_SuburbId int,@in_TownId int,@in_Contract int,@in_RDNo char(40),@in_Surname char(45),@in_Initials char(30),@in_UI_UserId char(20),@in_ComponentId int,@in_rd_contract int,@in_dpid int)
-- TJB  Sept 2005  NPAD2 address schema changes
-- Added adr_unit number and road_suffix to relevant parts of address returned
--
-- TJB  NPAD2  Mar 2006  
-- Added in_rd_contract parameter.  Flags whether to limit search to RD contracts or not.
--       in_rd_contract = 1     limit search to contract #s between 5000 and 6000 (RD)
--       in_rd_contract = 0     limit search search to contracts outside the RD range
-- Also added in_dpid parameter for search criteria
-- Changed input parameters: replaced road_id with roadName, roadType and roadSuffix
--
-- TJB  NPAD2  Apr 2006  pre-go-live
-- Remove references to suburb
-- Separate out the authorization from all searches
-- Separate out dpid search (improved performance dramatically)
--
-- TJB NPAD2  Apr 2006  production fixups bf004
as -- If the contract number is known, set in_rd_contract accordingly whatever is passed.
begin
set CONCAT_NULL_YIELDS_NULL off
  declare @authorized integer
  -- If the contract number is known, set in_rd_contract 
  -- accordingly whatever is passed.
  if @in_contract is not null
    if @in_contract between 5000 and 5999
      select @in_rd_contract=1
    else
      select @in_rd_contract=1
  if exists(select rds_user_rights.region_id from
      rds_user_rights,rds_user_id,rds_user_id_group,towncity where
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
        rds_user.u_id = rds_user_id.u_id))))
    select @authorized=1
  else
    select @authorized=0
  if @in_dpid is not null and @in_dpid > 0
    select addr.adr_id,
      rds_customer.cust_id,
      rds_customer.cust_surname_company,
      rds_customer.cust_initials,
      adr_num=upper(case when addr.adr_unit is null then '' else addr.adr_unit+'/' end+
      addr.adr_no+addr.adr_alpha),
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
      road,
      rds_customer,
      customer_address_moves where
      --, towncity 
      rds_customer.cust_id = customer_address_moves.cust_id and
      rds_customer.master_cust_id is null and
      customer_address_moves.adr_id = addr.adr_id and
      customer_address_moves.move_out_date is null and
      road.road_id = addr.road_id and
      --and towncity.tc_id = addr.tc_id 
      @authorized = 1 and
      @in_dpid = addr.dp_id union
    select addr.adr_id,
      null,
      null,
      null,
      adr_num=upper(case when addr.adr_unit is null  then '' else addr.adr_unit+'/' end +
      addr.adr_no+addr.adr_alpha),
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
      road where
      --,  towncity 
      road.road_id = addr.road_id and
      --and towncity.tc_id  = addr.tc_id 
      not addr.adr_id = any(select customer_address_moves.adr_id from
        customer_address_moves,rds_customer where
        rds_customer.cust_id = customer_address_moves.cust_id and
        customer_address_moves.move_out_date is null and
        rds_customer.master_cust_id is null) and
      @authorized = 1 and
      @in_dpid = addr.dp_id else
  if @in_roadName <> '' and @in_townid <> 0 and
  @in_surname = '' and
  @in_Contract = 0 and
  @in_RDNo = ''
    select addr.adr_id,
      rds_customer.cust_id,
      rds_customer.cust_surname_company,
      rds_customer.cust_initials,
      adr_num=upper(case when addr.adr_unit is null then '' else addr.adr_unit+'/' end +
      addr.adr_no+addr.adr_alpha),
      road_name=(select road_name+
        case when rt.rt_name is null then '' else ' '+rt.rt_name end+
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
      road,
      rds_customer,
      customer_address_moves,
      towncity where
      rds_customer.cust_id = customer_address_moves.cust_id and
      rds_customer.master_cust_id is null and
      customer_address_moves.adr_id = addr.adr_id and
      customer_address_moves.move_out_date is null and
      road.road_id = addr.road_id and
      towncity.tc_id = addr.tc_id and
      @authorized = 1 and
      (@in_AdrNum = '' or upper(case when addr.adr_unit is null then '' else addr.adr_unit+'/' end +
      addr.adr_no+addr.adr_alpha) like @in_AdrNum+'%') and
      -- and (in_RoadId     = 0  or addr.road_id = in_RoadId) 
      road.road_name = @in_roadName and
      (@in_roadType = 0 or road.rt_id = @in_roadType) and
      (@in_roadSuffix = 0 or road.rs_id = @in_roadSuffix) and
      -- and (in_SuburbId   = 0  or addr.sl_id     = in_SuburbId) 
      addr.tc_id = @in_TownId and
      ((@in_rd_contract = 1 and addr.contract_no between 5000 and 5999) or
      (@in_rd_contract = 0 and addr.contract_no not between 5000 and 5999) or
      (addr.contract_no is null)) union
    select addr.adr_id,
      null,
      null,
      null,
      adr_num=upper(case when addr.adr_unit is null then '' else addr.adr_unit+'/' end+
      addr.adr_no+addr.adr_alpha),
      road_name=(select road_name+
        case  when rt.rt_name is null then '' else ' '+rt.rt_name end+
        case  when rs.rs_name is null then '' else ' '+rs.rs_name end from
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
      road,
      towncity where
      towncity.tc_id = addr.tc_id and
      road.road_id = addr.road_id and
      not addr.adr_id = any(select customer_address_moves.adr_id from
        customer_address_moves,rds_customer where
        rds_customer.cust_id = customer_address_moves.cust_id and
        customer_address_moves.move_out_date is null and
        rds_customer.master_cust_id is null) and
      @authorized = 1 and
      (@in_AdrNum = '' or upper(case when addr.adr_unit is null then '' else addr.adr_unit+'/' end+
      addr.adr_no+addr.adr_alpha) like @in_AdrNum+'%') and
      -- and (in_RoadId     = 0  or addr.road_id = in_RoadId) 
      road.road_name = @in_roadName and
      (@in_roadType = 0 or road.rt_id = @in_roadType) and
      (@in_roadSuffix = 0 or road.rs_id = @in_roadSuffix) and
      -- and (in_SuburbId   = 0  or addr.sl_id     = in_SuburbId) 
      addr.tc_id = @in_TownId and
      ((@in_rd_contract = 1 and addr.contract_no between 5000 and 5999) or
      (@in_rd_contract = 0 and addr.contract_no not between 5000 and 5999) or
      (addr.contract_no is null))
  else
    select addr.adr_id,
      rds_customer.cust_id,
      rds_customer.cust_surname_company,
      rds_customer.cust_initials,
      adr_num=upper(case when addr.adr_unit is null then '' else addr.adr_unit+'/' end+
      addr.adr_no+addr.adr_alpha),
      road_name=(select road_name+
        case when rt.rt_name is null then  ''  else ' '+rt.rt_name end+
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
      road,
      rds_customer,
      customer_address_moves,
      towncity where
      rds_customer.cust_id = customer_address_moves.cust_id and
      rds_customer.master_cust_id is null and
      customer_address_moves.adr_id = addr.adr_id and
      customer_address_moves.move_out_date is null and
      road.road_id = addr.road_id and
      towncity.tc_id = addr.tc_id and
      @authorized = 1 and
      (@in_AdrNum = '' or upper(case when addr.adr_unit is null then '' else addr.adr_unit+'/' end+
      addr.adr_no+addr.adr_alpha) like @in_AdrNum+'%') and
      -- and (in_RoadId     = 0  or addr.road_id = in_RoadId) 
      (@in_roadName = '' or road.road_name = @in_roadName) and
      (@in_roadType = 0 or road.rt_id = @in_roadType) and
      (@in_roadSuffix = 0 or road.rs_id = @in_roadSuffix) and
      -- and (in_SuburbId   = 0  or addr.sl_id     = in_SuburbId) 
      (@in_TownId = 0 or addr.tc_id = @in_TownId) and
      (@in_Contract = 0 or addr.contract_no = @in_Contract) and
      (@in_RDNo = '' or addr.adr_rd_no like @in_RDNo+'%') and
      (@in_Surname = '' or rds_customer.cust_surname_company like @in_Surname+'%') and
      (@in_Initials = '' or rds_customer.cust_initials like @in_Initials+'%') and
      ((@in_rd_contract = 1 and addr.contract_no between 5000 and 5999) or
      (@in_rd_contract = 0 and addr.contract_no not between 5000 and 5999) or
      (addr.contract_no is null)) union
    select addr.adr_id,
      null,
      null,
      null,
      adr_num=upper(case when addr.adr_unit is null then '' else addr.adr_unit+'/' end+
      addr.adr_no+addr.adr_alpha),
      road_name=(select road_name+
        case when rt.rt_name is null then '' else ' '+rt.rt_name end+
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
      road,
      towncity where
      towncity.tc_id = addr.tc_id and
      road.road_id = addr.road_id and
      not addr.adr_id = any(select customer_address_moves.adr_id from
        customer_address_moves,rds_customer where
        rds_customer.cust_id = customer_address_moves.cust_id and
        customer_address_moves.move_out_date is null and
        rds_customer.master_cust_id is null) and
      @authorized = 1 and
      (@in_AdrNum = '' or upper(case when addr.adr_unit is null then '' else addr.adr_unit+'/' end+
      addr.adr_no+addr.adr_alpha) like @in_AdrNum+'%') and
      -- and (in_RoadId     = 0  or addr.road_id = in_RoadId) 
      (@in_roadName = '' or road.road_name = @in_roadName) and
      (@in_roadType = 0 or road.rt_id = @in_roadType) and
      (@in_roadSuffix = 0 or road.rs_id = @in_roadSuffix) and
      -- and (in_SuburbId   = 0  or addr.sl_id     = in_SuburbId) 
      (@in_TownId = 0 or addr.tc_id = @in_TownId) and
      (@in_Contract = 0 or addr.contract_no = @in_Contract) and
      (@in_RDNo = '' or addr.adr_rd_no like @in_RDNo+'%') and
      (@in_Surname = '') and
      (@in_Initials = '') and
      ((@in_rd_contract = 1 and addr.contract_no between 5000 and 5999) or
      (@in_rd_contract = 0 and addr.contract_no not between 5000 and 5999) or
      (addr.contract_no is null))
end
GO
