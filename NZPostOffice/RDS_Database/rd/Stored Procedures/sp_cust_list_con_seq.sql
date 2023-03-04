

--
-- Definition for stored procedure sp_cust_list_con_seq : 
--

CREATE procedure [rd].[sp_cust_list_con_seq](
   @con_id int)
-- TJB  SR4683  Aug 2006
-- Original script

-- K. Beach, inhouse Ltd.
-- added additional fields as per request P5-1860116.
--
as
begin
  declare
  /* Watcom only
  err_notfound exception for sqlstate value '02000'
  ,*/
  @rec_tmp char(200),
  @cust_tmp int,
  @master_tmp char(200),
  @cust_count_master int,
  @cust_count_recip int,
  @cust_count_cmb int,
  @cust_count int,
  @del_pt_count int

  -- temp table for the all occupied addresses
  create table #occ_temp(
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
        road_unit char(10) null,
        seq_num integer null, 
        case_slots integer null
    )

  -- create temporary tables for master customers 
  -- and recipients at an address
  create table #master_temp(
        master_num integer null,
        recip_char varchar(200) null,
    ) 
  create table #recipient_temp(
        recip_num integer null,
        recip_char_b varchar(200) null,
    ) 


  declare recipient_list cursor local for 
            select recip.recip_num, recip.recip_char_b
              from #recipient_temp recip

  declare @iRecip_num  integer
  declare @cRecip_char varchar(200)
  declare @cAdd        varchar(200)

  -- get all master cust_id''s first
  insert into #master_temp(master_num)
    select distinct(cust.cust_id) 
      from rds_customer as cust join customer_address_moves as cam on cust.cust_id = cam.cust_id
                                join address as addr on addr.adr_id = cam.adr_id 
     where addr.contract_no = @con_id and
           cam.move_out_date is null and
           cust.master_cust_id is null
           --and cam.adr_id = addr.adr_id
           --and cust.cust_id = cam.cust_id

  -- get all recipient names
  insert into #recipient_temp(recip_num,recip_char_b)
    select cust.master_cust_id,
           ', '+rd.trim(isnull(cust.cust_surname_company,'')+' '+isnull(cust.cust_initials,'')) 
      from rds_customer as cust 
     where cust.master_cust_id = any(select tmp.master_num from #master_temp as tmp) and
           (cust.cust_surname_company is not null or cust.cust_initials is not null) and
           (len(cust.cust_surname_company) > 0 or len(cust.cust_initials) > 0)


  open recipient_list
  -- CursorLoop: loop
  while 1=1
  begin
    set @iRecip_num=0
    set @cRecip_char=''
    set @cAdd = '' 

    -- get next recipient name and customer number
    fetch next from recipient_list into @iRecip_num, @cRecip_char
    --    if sqlstate=err_notfound then
    --      leave CursorLoop
    --    end if;

    if @@error <> 0 
    begin
       select 'Error fetching; error = '+convert(varchar(8),@@error)
       break
    end
    if @@fetch_status < 0    -- No more records
       break

    -- get customer's current recipient list
    select @cAdd = recip_char 
      from #master_temp
     where master_num = @iRecip_num

    -- Append recipient to recipient list
    set @cAdd = isnull(@cAdd,'') + isnull(@cRecip_char,'')

    -- update #master_temp recipient list
    update #master_temp
       set recip_char = @cAdd 
     where master_num = @iRecip_num

  end          -- loop CursorLoop;
  close recipient_list
  deallocate  recipient_list

  select @cust_count_master = count(*)
    from #master_temp
    
    

  /******************************************************
  *          main select for the procedure             *
  ******************************************************/

  insert into #occ_temp(
        adr_id,
        sur_comp_name,
        initials,
        prop_title,
        road_no,
        road_alpha,
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
        cust_counter,
        cmb_seq,
        road_unit,
        seq_num, 
        case_slots
		)  
    select distinct 
		addr.adr_id,  -- Adr_Id
        cust.cust_surname_company, --sur_comp_name
        cust.cust_initials, --initials
        addr.adr_property_identification, --prop_title
        rd.trim(addr.adr_no), --road_no
        upper(rd.trim(addr.adr_alpha)), --road_alpha 
        rd.road_name + case when isnull(rt.rt_name,'') = '' then '' else ' '+ rt.rt_name end 
                     + case when isnull(rs.rs_name,'') = '' then '' else ' '+ rs.rs_name end, -- road_name
        sub.sl_name, --locality
        addr.adr_rd_no, --rd_no
        tc.tc_name, --mail_town
        substring(mast.recip_char,3,len(mast.recip_char)-2),
        case when cust.cust_business = 'Y' then 'Business' else  
            case when cust.cust_rural_farmer = 'Y' then 'Farmer' else 
				case when cust.cust_rural_resident = 'Y' then 'Residential'
                end
            end
        end, --recipients
        --null, --categories
        cust.cust_adpost_quantity,--kiwimail_qty
        case when cust.cust_business = 'Y' then isnull(cust.cust_adpost_quantity,0) else 0 end, --business
        case when cust.cust_rural_resident = 'Y' then isnull(cust.cust_adpost_quantity,0) else 0 end, --residential
        case when cust.cust_rural_farmer = 'Y' then isnull(cust.cust_adpost_quantity,0) else 0 end, --farmer
        cust.cust_adpost_quantity, --cust_counter
        0, -- cmb_seq
        addr.adr_unit, -- road_unit
        addr.seq_num, --seq_num
        cust.cust_slot_allocation --case_slots
        
      from rds_customer as cust join customer_address_moves as cam on cust.cust_id = cam.cust_id
                                join address as addr on addr.adr_id = cam.adr_id
                                left outer join suburblocality as sub on addr.sl_id = sub.sl_id
                                join towncity as tc on addr.tc_id = tc.tc_id
                                join road as rd  on addr.road_id =rd.road_id
                                left outer join road_type as rt on rd.rt_id = rt.rt_id
                                left outer join road_suffix as rs on rd.rs_id = rs.rs_id,
           #master_temp as mast --????????????????????????????????
     where cust.cust_id = mast.master_num and
           cam.move_out_date is null and
           cust.master_cust_id is null


  -- insert the unoccupied entries into the table
  /*
  Edited 24/07/2013
  changed order of 2nd, 3rd and 4th select fields so that
  property identification value is in the correct field.
  Kevin Beach, Inhouse
  */

  insert into #occ_temp(
        adr_id,
        sur_comp_name,
        initials,
        prop_title,
        road_no,
        road_alpha,
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
        cust_counter,
        cmb_seq,
        road_unit,
        seq_num, 
        case_slots
		) 
         
    select distinct
		addr.adr_id,
		null, --sur_comp_name
		null, --initials
        addr.adr_property_identification,   
        rd.trim(addr.adr_no),
        upper(rd.trim(addr.adr_alpha)),
        rd.road_name + case when isnull(rt.rt_name,'') = '' then '' else ' '+rt.rt_name end
                     + case when isnull(rs.rs_name,'') = '' then '' else ' '+rs.rs_name end,
        sub.sl_name,
        addr.adr_rd_no,
        tc.tc_name,
        null, --recipients
        null, --categories
        null, --kiwimail_qty
        0, -- Business
        0, -- Resident
        0, -- Farmer 
        null, --cust_counter
        0, -- cmb_seq
        addr.adr_unit, -- road_unit
        addr.seq_num,
        null --Case_slots
      from address as addr left outer join suburblocality as sub on addr.sl_id = sub.sl_id
                           join towncity as tc on addr.tc_id = tc.tc_id
                           join road as rd on addr.road_id = rd.road_id
                           left outer join road_type as rt on rd.rt_id = rt.rt_id
                           left outer join road_suffix as rs on rd.rs_id = rs.rs_id 
     where addr.contract_no = @con_id and
           not addr.adr_id = any(select occ.adr_id from #occ_temp as occ)


  -- Get the total number of delivery points (excluding the CMBs)
  select @del_pt_count = count(distinct(adr_id))
    from #occ_temp

  -- insert the CMB entries into the table
  insert into #occ_temp(
        adr_id,
        sur_comp_name,
        initials,
        prop_title,
        road_no,
        road_alpha,
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
        cust_counter,
        cmb_seq,
        road_unit,
        seq_num, 
        case_slots
		)
    select 
		null, --adr_id
		cmb.cmb_cust_surname,
        cmb.cmb_cust_initials,
        null, --prop_title
        cmb.cmb_box_no, 
        null, --road_alpha
        null, --road_name
        null, --locality
        cmb.adr_rd_no,
        tc.tc_name,
        null, --recipients
        'CMB', --categories
        case when(cmb_cust_surname is null or cmb_cust_surname = '') and(cmb_cust_initials is null or cmb_cust_initials = '') then
                  null else 1 end,
        0, -- Business
        0, -- Resident
        0, -- Farmer
        0, --cust_counter
        row_number() over (order by cmb.adr_rd_no asc), -- cmb_seq
        null, --road_unit
        null, --seq_num
        null --case_slots 
           
	from cmb_address as cmb,
           towncity as tc 
	where cmb.contract_no = @con_id and
           cmb.tc_id = tc.tc_id 
    order by tc.tc_name asc,cmb.cmb_box_no asc

  -- Count the CMB customers
  select @cust_count_cmb = count(*)
    from cmb_address 
   where contract_no = @con_id and
         ((cmb_cust_surname is not null and cmb_cust_surname <> '') 
          or (cmb_cust_initials is not null and cmb_cust_initials <> ''))

  -- Calculate the total customer count
  select @cust_count=isnull(@cust_count_master,0)+isnull(@cust_count_cmb,0)

  select sur_comp_name,
         initials,
         prop_title,
         road_no=right(space(20)+road_no,20),
         road_alpha,
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
         @cust_count as cust_counter,
         @del_pt_count as del_counter,
         cmb_seq,
         road_unit=right(space(10)+road_unit,10),
         seq_num, 
         case_slots
    from #occ_temp

end