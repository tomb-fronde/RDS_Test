/****** Object:  StoredProcedure [rd].[sp_cust_list_con_export]    Script Date: 08/05/2008 10:18:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [rd].[sp_cust_list_con_export]
-- TJB  SR4683  Aug 2006
-- Change customer category counts to use the Kiwimail number at an address
--
-- TJB  Sept 2005  NPAD2 address schema changes
-- Added adr_unit number and road_suffix to relevant parts of address returned
--
-- TJB  SR4659  July 2005
-- Added section for CMB numbers and cmb_seq return value
as --
begin
set CONCAT_NULL_YIELDS_NULL off
  declare
  /* Watcom only
  err_notfound exception for sqlstate value '02000'
  ,*/
  @rec_tmp char(200),
  @cust_tmp integer,
  @master_tmp char(200),
  @cust_count_master integer,
  @cust_count_recip integer,
  @cust_count_cmb integer,
  @cust_count integer,
  @blank_space char(40),
  @del_pt_count integer,
  @get_recip integer
  -- temp table for the all occupied addresses
  create
    table #occ_temp(
    contract_no integer null,
    con_title char(60) null,
    adr_id integer null,
    sur_comp_name char(45) null,
    initials char(30) null,
    prop_title char(100) null,
    road_no char(20) null,
    road_alpha char(20) null,
    road_name char(61) null,
    locality char(50) null,
    rd_no char(40) null,
    mail_town char(50) null,
    recipients char(200) null,
    categories char(15) null,
    kiwimail_qty integer null,
    business integer null,
    residential integer null,
    farmer integer null,
    cust_counter integer null,
    cmb_seq integer null,
    )
  
  -- first create a temporary table for recipients at an address
  create
    table #master_temp(
    master_num integer null,
    recip_char nvarchar(200) null,
    ) 
  
  create
    table #recipient_temp(
    recip_num integer null,
    recip_char_b char(200) null,
    ) 
  -- TJB Sept 2005  Replaced the cursor - see below
  --  declare recipient_list dynamic scroll cursor for 
  --            select recip.recip_num, recip.recip_char_b
  --              from recipient_temp recip;
  --
  --  declare iRecip_num integer;
  --  declare cRecip_char char(200);
  --  declare cAdd  char(200);
  -- get all master cust_id''s first
  insert into #master_temp(master_num)
    select distinct(cust.cust_id) from
      rds_customer as cust join customer_address_moves as cam on cust.cust_id = cam.cust_id
      join address as addr on addr.adr_id = cam.adr_id where
      addr.contract_no = any(select rds_id from rds_temp) and -- get contract numbers from the temp table
      cam.move_out_date is null and
      cust.master_cust_id is null
  --and cam.adr_id = addr.adr_id
  --and cust.cust_id = cam.cust_id;
  -- don''t do anything if there is no need for recipients
  select @get_recip = sum(rds_code)  
    from rds_temp
  if @get_recip > 0
    begin
      -- get all recipients names       
      insert into #recipient_temp(recip_num,recip_char_b)
        select cust.master_cust_id,', '+
          rd.trim(isnull(cust.cust_surname_company,'')+' '+isnull(cust.cust_initials,'')) from
          rds_customer as cust where
          cust.master_cust_id = any(select tmp.master_num from #master_temp as tmp) and
          (cust.cust_surname_company is not null or cust.cust_initials is not null) and
          (len(cust.cust_surname_company) > 0 or len(cust.cust_initials) > 0)
      -- TJB Sept 2005 
      -- Add recipients to master list
      -- This replaces the cursor and speeds the procedure up considerably!
      update #master_temp set
        #master_temp.recip_char = ISNULL(#master_temp.recip_char,'')+#recipient_temp.recip_char_b from
        #recipient_temp where
        #master_temp.master_num = #recipient_temp.recip_num
    end
  ------------- cursor attempt
  --    set iRecip_num=0;
  --    set cRecip_char='';
  --  
  --    open recipient_list;
  --    CursorLoop: loop
  --      fetch next recipient_list into iRecip_num, cRecip_char;
  --      if sqlstate=err_notfound then
  --        leave CursorLoop
  --      end if;
  --    
  --      set cAdd = '';  
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
  --      set iRecip_num=0;
  --      set cRecip_char='';
  --    
  --    end loop CursorLoop;
  --  close recipient_list;
  -- Get the number of customers at the occupied addresses
  select @cust_count_master = count(*) 
    from #master_temp
  -- ***********************************************
  --        main select for the procedure
  -- ***********************************************
  -- Populate the temp table for occupants
  -- TJB  SR4683  Aug 2006
  -- Changed the category counts to equal the Kiwimail count, instead of 1
  --
  -- TJB Sept 2005
  --     Removed the 'group by' clause. Redundant.
  --     Combined tables in to joins - it improved performance
  --     Added "mast_cust_id is null" - also improved performance
  --
  insert into #occ_temp(contract_no,
    con_title,
    adr_id,sur_comp_name,initials,prop_title,
    road_no,road_alpha,road_name,locality,rd_no,mail_town,
    recipients,categories,
    business,residential,farmer,
    kiwimail_qty,
    cust_counter,cmb_seq)
    select distinct con.contract_no,
      con.con_title,
      addr.adr_id,
      cust.cust_surname_company,
      cust.cust_initials,
      addr.adr_property_identification,
      upper(/*ifnull(addr.adr_unit,'',addr.adr_unit+'/')*/case when isnull(addr.adr_unit,'') = '' then '' else addr.adr_unit+'/' end +rd.trim(addr.adr_no)),
      upper(rd.trim(addr.adr_alpha)),
      rd.road_name+/*ifnull(rt.rt_name,'',' '+rt.rt_name)*/case when isnull(rt.rt_name,'') = '' then '' else ' '+rt.rt_name end +/*ifnull(rs.rs_name,'',' '+rs.rs_name)*/case when isnull(rs.rs_name,'') = '' then '' else ' '+rs.rs_name end ,
      sub.sl_name,
      addr.adr_rd_no,
      tc.tc_name,substring(mast.recip_char,2,len(mast.recip_char)-2),
      (case when cust.cust_business = 'Y' then 'Business' else
        case when cust.cust_rural_farmer = 'Y' then 'Farmer' else
          case when cust.cust_rural_resident = 'Y' then 'Residential'
          end
        end
      end),
    (case when cust.cust_business = 'Y' then isnull(cust.cust_adpost_quantity,0) else 0 end),
     (case when cust.cust_rural_resident = 'Y' then isnull(cust.cust_adpost_quantity,0) else 0 end),
      (case when cust.cust_rural_farmer = 'Y' then isnull(cust.cust_adpost_quantity,0) else 0 end),
      kiwimail_qty=cust.cust_adpost_quantity,
      @cust_count,
      0 from -- cmb_seq
      rds_customer as cust join customer_address_moves as cam on cust.cust_id = cam.cust_id
      join address as addr  on addr.adr_id = cam.adr_id
      left outer join suburblocality as sub on addr.sl_id = sub.sl_id
      join towncity as tc on addr.tc_id = tc.tc_id
      join road as rd on addr.road_id = rd.road_id
      join contract as con on addr.contract_no = con.contract_no
      left outer join road_type as rt on rd.rt_id = rt.rt_id
      left outer join road_suffix as rs on rd.rs_id = rs.rs_id,
      #master_temp as mast
      where
      cust.cust_id = mast.master_num and
      cam.move_out_date is null and
      cust.master_cust_id is null
  --and cust.cust_id = cam.cust_id
  --and addr.adr_id = cam.adr_id 
  --and tc.tc_id = addr.tc_id 
  --and rd.road_id = addr.road_id
  --group by con.contract_no, con.con_title, addr.adr_id, cust.cust_surname_company, cust.cust_initials, 
  --      addr.adr_property_identification, upper(trim(addr.adr_no)), upper(trim(addr.adr_alpha)), 
  --      rd.road_name + ' ' + rt.rt_name , sub.sl_name, addr.adr_rd_no, tc.tc_name, substr(mast.recip_char, 3),
  --      cust.cust_business, cust.cust_rural_resident, cust_rural_farmer, cust.cust_adpost_quantity, cust_count;
  -- Insert the unoccupied entries into the table
  -- TJB Sept 2005
  --     Removed the 'group by' clause. Redundant.
  --     Combined tables into joins - it improved performance
  insert into #occ_temp(adr_id,
    contract_no,con_title,prop_title,
    road_no,road_alpha,road_name,locality,rd_no,mail_town,
    business,residential,farmer,
    cust_counter,cmb_seq)
    select distinct addr.adr_id,
      con.contract_no,
      con.con_title,
      addr.adr_property_identification,
      upper(/*ifnull(addr.adr_unit,'',addr.adr_unit+'/')*/case when isnull(addr.adr_unit,'')= '' then '' else addr.adr_unit+'/' end
      +rd.trim(addr.adr_no)),
      upper(rd.trim(addr.adr_alpha)),
      rd.road_name+/*ifnull(rt.rt_name,'',' '+rt.rt_name)*/case when isnull(rt.rt_name,'') = '' then '' else ' '+rt.rt_name end+/*ifnull(rs.rs_name,'',' '+rs.rs_name)*/
      case when isnull(rs.rs_name,'') = '' then '' else ' '+rs.rs_name end,
      sub.sl_name,
      addr.adr_rd_no,
      tc.tc_name,
      0, -- Business
      0, -- Resident
      0, -- Farmer 
      @cust_count,
      0 from -- cmb_seq
      address as addr left outer join suburblocality as sub on addr.sl_id = sub.sl_id
      join towncity as tc on addr.tc_id = tc.tc_id
      join road as rd on addr.road_id = rd.road_id
      join contract as con on addr.contract_no = con.contract_no
      left outer join road_type as rt on rd.rt_id = rt.rt_id
      left outer join road_suffix as rs on rd.rs_id = rs.rs_id where
      addr.contract_no = any(select rds_id from rds_temp) and
      not addr.adr_id = any(select occ.adr_id from #occ_temp as occ)
  --and addr.road_id = rd.road_id
  --and addr.tc_id   = tc.tc_id
  --group by addr.adr_id, con.contract_no, con.con_title, addr.adr_property_identification, upper(trim(addr.adr_no)),
  --      upper(trim(addr.adr_alpha)), rd.road_name + ' ' + rt.rt_name , sub.sl_name, addr.adr_rd_no, tc.tc_name,
  --      cust_count;
  -- Get the total number of delivery points
  select @del_pt_count = count(distinct(adr_id))
    from #occ_temp
  -- insert the CMB entries into the table
  insert into #occ_temp(sur_comp_name,
    initials,
    road_no,
    rd_no,mail_town,
    categories,
    business,residential,farmer,
    kiwimail_qty,cmb_seq)
    select cmb.cmb_cust_surname,
      cmb.cmb_cust_initials,
      cmb.cmb_box_no,
      cmb.adr_rd_no,
      tc.tc_name,'CMB',
      -- Catagories
      0, -- Business
      0, -- Resident
      0, -- Farmer
      kiwimail_qty=(case when(cmb_cust_surname is null or cmb_cust_surname = '') and
      (cmb_cust_initials is null or cmb_cust_initials = '') then
        null else 1 end),
      row_number() over (order by cmb.cmb_cust_surname asc) from -- cmb_seq
      cmb_address as cmb,
      towncity as tc where
      cmb.contract_no = any(select rds_id from rds_temp) and
      cmb.tc_id = tc.tc_id order by
      tc.tc_name asc,cmb.cmb_box_no asc
  -- Get the number of cmb customers
  select @cust_count_cmb = count(*)
    from #occ_temp where
    cmb_seq > 0 and
    ((sur_comp_name is not null and sur_comp_name != '') or
    (initials is not null and initials != ''))
  -- Calculate the total number of customers
  select @cust_count=isnull(@cust_count_master,0)+isnull(@cust_count_cmb,0)
  -- 20 blank spaces
  select @blank_space=space(20)
  -- Output the result
  select sur_comp_name,
    initials,
    prop_title,
    road_no=substring(@blank_space,1,(20-len(road_no)))+road_no,
    road_alpha=road_alpha,
    road_name,
    locality,
    rd_no,
    mail_town,
    recipients,
    categories,
    kiwimail_qty,
    business,
    residential,
    farmer,
    @cust_count as cust_count ,
    @del_pt_count as del_pt_count,
    contract_no,
    con_title from
    #occ_temp 
    order by
    cmb_seq asc,contract_no asc
end
GO
