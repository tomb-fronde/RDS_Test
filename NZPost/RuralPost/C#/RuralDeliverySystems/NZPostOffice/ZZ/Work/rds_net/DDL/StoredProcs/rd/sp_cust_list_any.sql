/****** Object:  StoredProcedure [rd].[sp_cust_list_any]    Script Date: 08/05/2008 10:18:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [rd].[sp_cust_list_any]
-- TJB  SR4683  Aug 2006
-- Change customer category counts to use the Kiwimail number at an address
--
-- TJB  Oct 2005
-- Changed: add road_unit and road_alpha as separate returned values and removed from road_no;
--          pad road_no, road_unit with spaces for sorting
--
-- TJB  Sept 2005  NPAD2 address schema changes
-- Added adr_unit number and road_suffix to relevant parts of address returned
as --
begin
set CONCAT_NULL_YIELDS_NULL off
  declare
  /* Watcom only
  err_notfound exception for sqlstate value '02000'
  ,*/
  -- TJB : no longer used
  --  declare rec_tmp char(200);
  --  declare cust_tmp integer;
  --  declare master_tmp char(200);
  @cust_count integer,
  @address_count integer,
  @blank_space char(20)
  -- first create a temporary table for recipients at an address
create table #master_temp(
    master_num integer null,
    recip_char char(200) null,
    ) 
  -- TJB: no longer used
  -- declare local temporary table master_temp1
  --               (master_num integer, recip_char char(200));     
  create table #recipient_temp(
    recip_num integer null,
    recip_char_b char(200) null,
    ) 
  -- TJB Sept 2005  Replaced the cursor - see below
  --  declare recipient_list dynamic scroll cursor for 
  --            select recip.recip_num, recip.recip_char_b
  --              from recipient_temp recip;
  --
  --  declare iRecip_num  integer;
  --  declare cRecip_char char(200);
  --  declare cAdd        char(200);
  --  insert into master_temp1 (master_num)
  --         select top 3000 cust.cust_id 
  -- get all master cust_id''s first
  -- TJB Jan 2005: Changed to select distinct customer numbers as one step
  -- TJB SR4644 Jan 2005: Increased limit on number of customers retrieved
  insert into #master_temp(master_num)
    select top 4000 cust.cust_id from
      rds_customer as cust join customer_address_moves as cam on cust.cust_id = cam.cust_id where
      cam.move_out_date is null and
      cust.master_cust_id is null
  -- get distinct list of customers       
  -- insert into master_temp (master_num)
  --        select distinct(tmp1.master_num)
  --          from master_temp1 tmp1;
  -- get all recipients names
  insert into #recipient_temp(recip_num,recip_char_b)
    select cust.master_cust_id,', '+
      rd.trim(isnull(cust.cust_surname_company,'')+' '+isnull(cust.cust_initials,'')) from
      rds_customer as cust,
      #master_temp as mast where
      cust.master_cust_id = mast.master_num and
      (cust.cust_surname_company is not null or cust.cust_initials is not null) and
      (len(cust.cust_surname_company) > 0 or len(cust.cust_initials) > 0)
  -- TJB Sept 2005 
  -- Add recipients to master list
  -- This replaces the cursor and speeds the procedure up considerably!
  update #master_temp set
    #master_temp.recip_char = #master_temp.recip_char+#recipient_temp.recip_char_b from
    #recipient_temp where
    #master_temp.master_num = #recipient_temp.recip_num
  ------------ cursor attempt
  --  open recipient_list;
  --  CursorLoop: loop
  --      set iRecip_num=0;
  --      set cRecip_char='';
  --      set cAdd = '';  
  --    
  --      fetch next recipient_list into iRecip_num, cRecip_char;
  --      if sqlstate=err_notfound then
  --        leave CursorLoop
  --      end if;
  --    
  --      -- get original char value
  --      select mast.recip_char 
  --        into cAdd     
  --        from master_temp mast
  --       where mast.master_num = iRecip_num;
  --    
  --      set cAdd = cAdd + cRecip_char;
  --    
  --      -- do update to master_temp
  --      update master_temp
  --         set master_temp.recip_char = cAdd
  --       where master_temp.master_num = iRecip_num;
  --    
  --  end loop CursorLoop;
  --  close recipient_list;
  -- get count of customers
  --select count(master_temp.master_num) 
  --into cust_count
  --from master_temp;
  --if cust_count > 1000 then
  --set cust_count = 1000;
  --end if;
  select @cust_count = count(cust.cust_id)
    from rds_customer as cust join customer_address_moves as cam on cust.cust_id = cam.cust_id where
    cam.move_out_date is null and
    cust.master_cust_id is null
  select @address_count = count(*)
    from address
  -- 20 blank spaces
  select @blank_space=space(20)
  -- main select for the procedure
  -- TJB  SR4683  Aug 2006
  -- Changed the category counts to equal the Kiwimail count, instead of 1
  --
  -- TJB SR4644 Jan 2005: Increase limit on number of customers retrieved
  --
  select top 2000
    seq_no=@address_count,
    sur_comp_name=cust.cust_surname_company,
    initials=cust.cust_initials,
    prop_title=addr.adr_property_identification,
    --substring(blank_space, 1 , (19 - length(ifnull(addr.adr_unit,'',addr.adr_unit+'/')+addr.adr_no+trim(addr.adr_alpha)))) 
    --  + ifnull(addr.adr_unit,'',addr.adr_unit+'/')+upper(addr.adr_no+trim(addr.adr_alpha))  as road_no,
    road_no=right(space(20)+rd.trim(addr.adr_no),20),
    road_name=rd.road_name+
    --ifnull(rt.rt_name,'',' '+rt.rt_name)+
    case when isnull(rt.rt_name,'') = '' then '' else ' '+rt.rt_name end + 
    --ifnull(rs.rs_name,'',' '+rs.rs_name),
    case when isnull(rs.rs_name,'') = '' then '' else ' '+rs.rs_name end,
    locality=sub.sl_name,
    rd_no=addr.adr_rd_no,
    mail_town=tc.tc_name,
    recipients=substring(mast.recip_char,3,len(mast.recip_char)-2),
    categories=(case when cust.cust_business = 'Y' then 'Business' else
      case when cust.cust_rural_farmer = 'Y' then 'Farmer' else
        case when cust.cust_rural_resident = 'Y' then 'Residential'
        end
      end
    end),kiwimail_qty=cust.cust_adpost_quantity,
    business=(case when cust.cust_business = 'Y' then isnull(cust.cust_adpost_quantity,0) else 0 end),
    residential=(case when cust.cust_rural_resident = 'Y' then isnull(cust.cust_adpost_quantity,0) else 0 end),
    farmer=(case when cust.cust_rural_farmer = 'Y' then isnull(cust.cust_adpost_quantity,0) else 0 end),
    cust_counter=@cust_count,
    road_alpha=upper(rd.trim(addr.adr_alpha)),
    road_unit=right(space(10)+addr.adr_unit,10) from
    rds_customer as cust join customer_address_moves as cam on cust.cust_id = cam.cust_id,
    address as addr left outer join suburblocality as sub on addr.sl_id = sub.sl_id
    left outer join towncity as tc on addr.tc_id = tc.tc_id
    left outer join road as rd on addr.road_id = rd.road_id
    left outer join road_type as rt on rd.rt_id = rt.rt_id
    left outer join road_suffix as rs on rd.rs_id = rs.rs_id,
    #master_temp as mast where
    mast.master_num = cust.cust_id and
    cust.master_cust_id is null and
    cust.master_cust_id is null and
    addr.adr_id = cam.adr_id
--  and addr.adr_alpha is null
end
GO
