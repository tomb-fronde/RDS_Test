
CREATE procedure [rd].[sp_SearchForAddress_v2b](
	@in_AdrNum varchar(40),
	@in_RoadName varchar(50),
	@in_RoadType int,
	@in_RoadSuffix int,
	@in_Suburb varchar(50),
	@in_Town varchar(50),
	@in_Contract int,
	@in_RDNo varchar(40),
	@in_Surname varchar(45),
	@in_Initials varchar(30),
	@in_UI_UserId varchar(20),
	@in_ComponentId int,
	@in_rd_contract int,
	@in_dpid int)
-- 
-- TJB  RPCR_043  Nov-2012
-- Changed Adr_no,Unit separator from "-" to "/"
--
-- TJB  RPCR_030  Oct-2011
-- Add postcode to returned values
--
-- TJB  RPCR_026  Aug-2011: Fixup
-- Changed unit/number separator from "/" to "-"
--
-- TJB  RPCR_026  July-2011
-- Added seq_num to returned values
--
-- TJB  NPAD2  Apr 2006  BF016
--
-- TJB  NPAD2  Apr 2006  pre-go-live
-- Remove references to suburb
-- Separate out the authorization from all searches
-- Separate out dpid search (improved performance dramatically)
--
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
as
-- Change town and suburb parameters to names (were IDs)
begin
set CONCAT_NULL_YIELDS_NULL off
  declare @authorized integer
  if exists(select rds_user_rights.region_id 
              from rds_user_rights
                 , rds_user_id
                 , rds_user_id_group
                 , towncity 
             where rds_user_id.ui_id = rds_user_id_group.ui_id 
               and rds_user_id_group.ug_id = rds_user_rights.ug_id 
               and (rds_user_rights.rur_read = 'Y') 
               and (rds_user_id.ui_userid = @in_UI_UserId) 
               and (rds_user_rights.rc_id = @in_ComponentId) 
               and (towncity.region_id = rds_user_rights.region_id 
                    or (rds_user_rights.region_id = 0 
                        and towncity.region_id = (select rds_user.region_id from rds_user 
                                                   where rds_user.u_id = rds_user_id.u_id)) 
                    or (rds_user_rights.region_id = 0 
                        and -1 = (select rds_user.region_id from rds_user 
                                   where rds_user.u_id = rds_user_id.u_id))))
    select @authorized=1
  else
    select @authorized=0

  if @in_dpid is not null and @in_dpid > 0
    select addr.adr_id,
           rds_customer.cust_id,
           rds_customer.cust_surname_company,
           rds_customer.cust_initials,
           adr_num=upper(case when addr.adr_unit is null then '' else addr.adr_unit+'/' end 
                         + isnull(addr.adr_no,'')+isnull(addr.adr_alpha,'')),
           road_name=(select isnull(road_name,'')
                             + case when rt.rt_name is null then '' else ' '+rt.rt_name end
                             + case when rs.rs_name is null then '' else ' '+rs.rs_name end 
                        from road as rd left outer join road_type as rt on rd.rt_id=rt.rt_id 
                                        left outer join road_suffix as rs on rd.rs_id=rs.rs_id 
                       where rd.road_id = addr.road_id),
           addr.sl_id,
           addr.tc_id,
           addr.adr_rd_no,
           addr.road_id,
           adr_unit=right(space(10)+addr.adr_unit,10),
           adr_no=right(space(10)+addr.adr_no,10),
           adr_alpha=upper(addr.adr_alpha), 
           seq_num,
           post_code
      from address as addr,
           road,
           rds_customer,
           customer_address_moves,
           post_code
     where road.road_id = addr.road_id 
       and rds_customer.cust_id = customer_address_moves.cust_id 
       and rds_customer.master_cust_id is null 
       and customer_address_moves.adr_id = addr.adr_id 
       and customer_address_moves.move_out_date is null 
       and @authorized = 1 
       and addr.dp_id = @in_dpid 
       and post_code.post_code_id = addr.post_code_id
  union
    select addr.adr_id,
           null,
           null,
           null,
           adr_num=upper(case when addr.adr_unit is null then '' else addr.adr_unit+'/' end
                         + isnull(addr.adr_no,'')+isnull(addr.adr_alpha,'')),
           road_name=(select isnull(road_name,'')
                             + case when rt.rt_name is null then '' else ' '+rt.rt_name end
                             + case when rs.rs_name is null then '' else ' '+rs.rs_name end 
                        from road as rd left outer join road_type as rt on rd.rt_id=rt.rt_id 
                                        left outer join road_suffix as rs on rd.rs_id=rs.rs_id 
                       where rd.road_id = addr.road_id),
           addr.sl_id,
           addr.tc_id,
           addr.adr_rd_no,
           addr.road_id,
           adr_unit=right(space(10)+addr.adr_unit,10),
           adr_no=right(space(10)+addr.adr_no,10),
           adr_alpha=upper(addr.adr_alpha) , 
           seq_num,
           post_code
      from address as addr,
           road, 
           post_code 
     where road.road_id = addr.road_id 
       and not addr.adr_id = any(select customer_address_moves.adr_id 
                                   from customer_address_moves
                                      , rds_customer 
                                  where rds_customer.cust_id = customer_address_moves.cust_id 
                                    and customer_address_moves.move_out_date is null 
                                    and rds_customer.master_cust_id is null) 
       and @authorized = 1 
       and @in_dpid = addr.dp_id 
       and post_code.post_code_id = addr.post_code_id

 else if @in_roadName <> '' and
         @in_Town <> '' and
         @in_surname = '' and
         @in_Contract = 0 and
         @in_RDNo = ''
    select addr.adr_id,
           rds_customer.cust_id,
           rds_customer.cust_surname_company,
           rds_customer.cust_initials,
           adr_num=upper(case when addr.adr_unit is null then '' else addr.adr_unit+'/' end
                         + isnull(addr.adr_no,'')+isnull(addr.adr_alpha,'')),
           road_name=(select isnull(road_name,'')
                             + case when rt.rt_name is null then '' else ' '+rt.rt_name end
                             + case when rs.rs_name is null then '' else ' '+rs.rs_name end 
                        from road as rd left outer join road_type as rt on rd.rt_id=rt.rt_id 
                                        left outer join road_suffix as rs on rd.rs_id=rs.rs_id 
                       where rd.road_id = addr.road_id),
           addr.sl_id,
           addr.tc_id,
           addr.adr_rd_no,
           addr.road_id,
           adr_unit=right(space(10)+addr.adr_unit,10),
           adr_no=right(space(10)+addr.adr_no,10),
           adr_alpha=upper(addr.adr_alpha), 
           seq_num,
           post_code 
      from address as addr left outer join suburblocality on addr.sl_id=suburblocality.sl_id
                           left outer join towncity on addr.tc_id=towncity.tc_id,
           road,
           rds_customer,
           customer_address_moves, 
           post_code 
     where road.road_id = addr.road_id 
       and customer_address_moves.adr_id = addr.adr_id 
       and customer_address_moves.move_out_date is null 
       and rds_customer.cust_id = customer_address_moves.cust_id 
       and rds_customer.master_cust_id is null 
       and @authorized = 1 
       and (@in_AdrNum = '' or upper(case when addr.adr_unit is null then '' else addr.adr_unit+'/' end
                                     + isnull(addr.adr_no,'') + isnull(addr.adr_alpha,'')) 
                               like @in_AdrNum+'%') 
           -- and (in_RoadId     = 0  or addr.road_id = in_RoadId) 
       and road.road_name = @in_roadName 
       and (@in_roadType = 0 or road.rt_id = @in_roadType) 
       and (@in_roadSuffix = 0 or road.rs_id = @in_roadSuffix) 
           -- and (in_SuburbId   = 0  or addr.sl_id     = in_SuburbId) 
       and (@in_Suburb = '' or sl_name = @in_Suburb) 
           -- and addr.tc_id     = in_TownId
       and tc_name = @in_Town 
       and ((@in_rd_contract = 1 and addr.contract_no between 5000 and 5999) 
             or (@in_rd_contract = 0 and addr.contract_no not between 5000 and 5999) 
             or (addr.contract_no is null))
       and post_code.post_code_id = addr.post_code_id
 union
    select addr.adr_id,
           null,
           null,
           null,
           adr_num=upper(case when addr.adr_unit is null then '' else addr.adr_unit+'/' end
                         + isnull(addr.adr_no,'')+isnull(addr.adr_alpha,'')),
           road_name=(select isnull(road_name,'')
                             + case when rt.rt_name is null then '' else ' '+rt.rt_name end
                             + case when rs.rs_name is null then '' else ' '+rs.rs_name end 
                        from road as rd left outer join road_type as rt on rd.rt_id=rt.rt_id 
                                        left outer join road_suffix as rs on rd.rs_id=rs.rs_id 
                       where rd.road_id = addr.road_id),
           addr.sl_id,
           addr.tc_id,
           addr.adr_rd_no,
           addr.road_id,
           adr_unit = right(space(10)+addr.adr_unit,10),
           adr_no = right(space(10)+addr.adr_no,10),
           adr_alpha = upper(addr.adr_alpha) , 
           seq_num,
           post_code
      from address as addr left outer join suburblocality on addr.sl_id=suburblocality.sl_id
                           left outer join towncity on addr.tc_id=towncity.tc_id,
           road, 
           post_code 
     where road.road_id = addr.road_id 
       and not addr.adr_id = any(select customer_address_moves.adr_id 
                                   from customer_address_moves
                                      , rds_customer 
                                  where rds_customer.cust_id = customer_address_moves.cust_id 
                                    and customer_address_moves.move_out_date is null 
                                    and rds_customer.master_cust_id is null) 
       and @authorized = 1 
       and (@in_AdrNum = '' or upper(case when addr.adr_unit is null then '' else addr.adr_unit+'/' end
                                     + isnull(addr.adr_no,'') + isnull(addr.adr_alpha,'')) 
                                like @in_AdrNum+'%') 
            -- and (in_RoadId     = 0  or addr.road_id = in_RoadId) 
       and road.road_name = @in_roadName 
       and (@in_roadType = 0 or road.rt_id = @in_roadType) 
       and (@in_roadSuffix = 0 or road.rs_id = @in_roadSuffix) 
           -- and (in_SuburbId   = 0  or addr.sl_id     = in_SuburbId) 
       and (@in_Suburb = '' or sl_name = @in_Suburb) 
           -- and addr.tc_id     = in_TownId
       and tc_name = @in_Town 
       and ((@in_rd_contract = 1 and addr.contract_no between 5000 and 5999) 
             or (@in_rd_contract = 0 and addr.contract_no not between 5000 and 5999) 
             or (addr.contract_no is null))
       and post_code.post_code_id = addr.post_code_id
  else
    select addr.adr_id,
           rds_customer.cust_id,
           rds_customer.cust_surname_company,
           rds_customer.cust_initials,
           adr_num=upper(case when addr.adr_unit is null then '' else addr.adr_unit+'/' end
                         + isnull(addr.adr_no,'')+isnull(addr.adr_alpha,'')),
           road_name=(select isnull(road_name,'')
                             + case when rt.rt_name is null then '' else ' '+rt.rt_name end
                             + case when rs.rs_name is null then '' else ' '+rs.rs_name end 
                        from road as rd left outer join road_type as rt on rd.rt_id=rt.rt_id 
                                        left outer join road_suffix as rs on rd.rs_id=rs.rs_id 
                       where rd.road_id = addr.road_id),
           addr.sl_id,
           addr.tc_id,
           addr.adr_rd_no,
           addr.road_id,
           adr_unit=right(space(10)+addr.adr_unit,10),
           adr_no=right(space(10)+addr.adr_no,10),
           adr_alpha=upper(addr.adr_alpha), 
           seq_num,
           post_code 
      from address as addr left outer join suburblocality on addr.sl_id=suburblocality.sl_id
                           left outer join towncity on addr.tc_id=towncity.tc_id,
           road,
           rds_customer,
           customer_address_moves, 
           post_code 
     where road.road_id = addr.road_id 
       and customer_address_moves.adr_id = addr.adr_id 
       and customer_address_moves.move_out_date is null 
       and rds_customer.cust_id = customer_address_moves.cust_id 
       and rds_customer.master_cust_id is null 
       and @authorized = 1 
       and (@in_AdrNum = '' or upper(case when addr.adr_unit is null then '' else addr.adr_unit+'/' end
                                     + isnull(addr.adr_no,'')+isnull(addr.adr_alpha,'')) 
                                like @in_AdrNum+'%') 
           -- and (in_RoadId     = 0  or addr.road_id = in_RoadId)
       and (@in_roadName = '' or road.road_name = @in_roadName) 
       and (@in_roadType = 0 or road.rt_id = @in_roadType) 
       and (@in_roadSuffix = 0 or road.rs_id = @in_roadSuffix) 
           -- and (in_SuburbId   = 0  or addr.sl_id     = in_SuburbId)
       and (@in_Suburb = '' or sl_name = @in_Suburb) 
           -- and (in_TownId     = 0  or addr.tc_id     = in_TownId)
       and (@in_Town = '' or tc_name = @in_Town) 
       and (@in_Contract = 0 or addr.contract_no = @in_Contract) 
       and (@in_RDNo = '' or addr.adr_rd_no like @in_RDNo+'%') 
       and (@in_Surname = '' or rds_customer.cust_surname_company like @in_Surname+'%') 
       and (@in_Initials = '' or rds_customer.cust_initials like @in_Initials+'%') 
       and ((@in_rd_contract = 1 and addr.contract_no between 5000 and 5999) 
             or (@in_rd_contract = 0 and addr.contract_no not between 5000 and 5999) 
             or (addr.contract_no is null))
       and post_code.post_code_id = addr.post_code_id
 union
    select addr.adr_id,
           null,
           null,
           null,
           adr_num=upper(case when addr.adr_unit is null then '' else addr.adr_unit+'/' end
                         + isnull(addr.adr_no,'')+isnull(addr.adr_alpha,'')),
           road_name=(select isnull(road_name,'')
                             + case when rt.rt_name is null then '' else ' '+rt.rt_name end
                             + case when rs.rs_name is null then '' else ' '+rs.rs_name end 
                        from road as rd left outer join road_type as rt on rd.rt_id=rt.rt_id 
                                        left outer join road_suffix as rs on rd.rs_id=rs.rs_id 
                       where rd.road_id = addr.road_id),
           addr.sl_id,
           addr.tc_id,
           addr.adr_rd_no,
           addr.road_id,
           adr_unit=right(space(10)+addr.adr_unit,10),
           adr_no=right(space(10)+addr.adr_no,10),
           adr_alpha=upper(addr.adr_alpha), 
           seq_num,
           post_code 
      from address as addr left outer join suburblocality on addr.sl_id=suburblocality.sl_id
                           left outer join towncity on addr.tc_id=towncity.tc_id,
           road, 
           post_code 
     where road.road_id = addr.road_id 
       and not addr.adr_id = any(select customer_address_moves.adr_id 
                                   from customer_address_moves
                                      , rds_customer 
                                  where rds_customer.cust_id = customer_address_moves.cust_id 
                                    and customer_address_moves.move_out_date is null 
                                    and rds_customer.master_cust_id is null) 
                                    and @authorized = 1 
                                    and (@in_AdrNum = '' or upper(case when addr.adr_unit is null then '' else addr.adr_unit+'/' end
                                                                  + isnull(addr.adr_no,'')+isnull(addr.adr_alpha,'')) 
                                                             like @in_AdrNum+'%') 
           -- and (in_RoadId     = 0  or addr.road_id = in_RoadId) 
       and (@in_roadName = '' or road.road_name = @in_roadName) 
       and (@in_roadType = 0 or road.rt_id = @in_roadType) 
       and (@in_roadSuffix = 0 or road.rs_id = @in_roadSuffix) 
           -- and (in_SuburbId   = 0  or addr.sl_id     = in_SuburbId) 
       and (@in_Suburb = '' or sl_name = @in_Suburb) 
           -- and (in_TownId     = 0  or addr.tc_id     = in_TownId) 
       and (@in_Town = '' or tc_name = @in_Town) 
       and (@in_Contract = 0 or addr.contract_no = @in_Contract) 
       and (@in_RDNo = '' or addr.adr_rd_no like @in_RDNo+'%') 
       and (@in_Surname = '') 
       and (@in_Initials = '') 
       and ((@in_rd_contract = 1 and addr.contract_no between 5000 and 5999) 
             or (@in_rd_contract = 0 and addr.contract_no not between 5000 and 5999) 
             or (addr.contract_no is null))
       and post_code.post_code_id = addr.post_code_id
  order by rds_customer.cust_id
end