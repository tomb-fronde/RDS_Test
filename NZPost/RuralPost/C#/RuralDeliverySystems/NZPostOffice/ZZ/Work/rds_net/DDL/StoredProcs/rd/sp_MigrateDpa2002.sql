/****** Object:  StoredProcedure [rd].[sp_MigrateDpa2002]    Script Date: 08/05/2008 10:21:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



--
-- Definition for stored procedure sp_MigrateDpa2002 : 
--

create procedure [rd].[sp_MigrateDpa2002] AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  --Temp variables
  declare @v_iTemp integer
  declare @v_Loops integer
  declare @v_sTemp char(255)
  --Misc variables
  declare @v_Ctr integer
  declare @v_MaxTownCityId integer
  declare @v_MaxSuburbLocalityId integer
  declare @v_MaxRoadId integer
  declare @v_MaxRecipientId integer
  declare @v_TownCityId integer
  declare @v_SuburbLocalityId integer
  declare @v_RoadId integer
  declare @v_RoadTypeId integer
  declare @v_RoadName char(45)
  declare @v_PostCodeId integer
  --Customer/address fetch variables
  declare @v_region_id integer
  declare @v_cust_id integer
  declare @v_contract_no integer
  declare @v_cust_title char(10)
  declare @v_cust_surname_company char(45)
  declare @v_cust_initials char(30)
  declare @v_cust_rd_number char(40)
  declare @v_cust_mailing_address_no char(9)
  declare @v_cust_mailing_address_road char(45)
  declare @v_cust_mailing_address_locality char(45)
  declare @v_cust_mail_town char(40)
  declare @v_cust_nad_reference char(12)
  declare @v_cust_prior_customer integer
  declare @v_cust_phone_day char(14)
  declare @v_cust_phone_night char(14)
  declare @v_cust_dir_listing_ind char(1)
  declare @v_cust_dir_listing_text char(60)
  declare @v_cust_delivery_frequency tinyint
  declare @v_cust_delivery_days char(7)
  declare @v_cust_business char(1)
  declare @v_cust_rural_resident char(1)
  declare @v_cust_rural_farmer char(1)
  declare @v_cust_old_delivery_days char(1)
  declare @v_cust_adpost_quantity tinyint
  declare @v_cust_date_first_loaded datetime
  declare @v_cust_date_last_transfered datetime
  declare @v_cust_date_left datetime
  declare @v_printedon datetime
  declare @v_cust_date_commenced datetime
  declare @v_cust_property_identification char(100)
  declare @v_cust_post_code char(6)
  declare @v_cust_survey98_timestamp datetime
  declare @v_cust_phone_mobile char(14)
  declare @v_cust_category char(2)
  declare @v_sf_key1 integer
  declare @v_sf_key2 integer
  declare @v_sf_key3 integer
  declare @v_sf_key4 integer
  declare @v_sf_key5 integer
  declare @v_sf_key6 integer
  declare @v_sf_key7 integer
  declare @v_sf_key8 integer
  declare @v_sf_key9 integer
  declare vc_ContractCustomers cursor for select region.region_id,
      customer.cust_id,
      customer.contract_no,
      customer.cust_title,
      customer.cust_surname_company,
      customer.cust_initials,
      customer.cust_rd_number,
      customer.cust_mailing_address_no,
      customer.cust_mailing_address_road,
      customer.cust_mailing_address_locality,
      customer.cust_mail_town,
      customer.cust_nad_reference,
      customer.cust_prior_customer,
      customer.cust_phone_day,
      customer.cust_phone_night,
      customer.cust_dir_listing_ind,
      customer.cust_dir_listing_text,
      customer.cust_delivery_frequency,
      customer.cust_delivery_days,
      customer.cust_business,
      customer.cust_rural_resident,
      customer.cust_rural_farmer,
      customer.cust_old_delivery_days,
      customer.cust_adpost_quantity,
      customer.cust_date_first_loaded,
      customer.cust_date_last_transfered,
      customer.cust_date_left,
      customer.printedon,
      customer.cust_date_commenced,
      customer.cust_property_identification,
      customer.cust_post_code,
      customer.cust_survey98_timestamp,
      customer.cust_phone_mobile,
      customer.cust_category,
      customer.sf_key1,
      customer.sf_key2,
      customer.sf_key3,
      customer.sf_key4,
      customer.sf_key5,
      customer.sf_key6,
      customer.sf_key7,
      customer.sf_key8,
      customer.sf_key9 from
      contract,
      customer,
      outlet,
      region where
      customer.contract_no = contract.contract_no and
      outlet.outlet_id = contract.con_base_office and
      region.region_id = outlet.region_id
  --and   customer.contract_no between 5000 and 5010;
  --****Preliminary Processing*****
  --Check @@error
  if @@error <> 0 /* <> was < */
    begin
      rollback transaction
      return(-30)
    end
  --Get max town/city id
  select @v_MaxTownCityId=Max(tc_id)
    from TownCity
  --Check @@error
  if @@error <> 0 /* <> was < */
    begin
      rollback transaction
      return(-40)
    end
  --Get max Suburb/Locality id
  select @v_MaxSuburbLocalityId=Max(sl_id) 
    from SuburbLocality
  --Check @@error
  if @@error <> 0 /* <> was < */
    begin
      rollback transaction
      return(-50)
    end
  --Get max road Id
  select @v_MaxRoadId=max(road_id) 
    from road
  --Check @@error
  if @@error <> 0 /* <> was < */
    begin
      rollback transaction
      return(-60)
    end
  open vc_ContractCustomers
  --Check @@error
  if @@error <> 0 /* <> was < */
    begin
      rollback transaction
      return(-65)
    end
  select @v_Loops=0
  --********Main processing********
  /* Watcom only
  MAINLOOP:
  */while 1=1 
    begin
      select @v_Loops=@v_Loops+1
      select @v_TownCityId=null
      select @v_SuburbLocalityId=null
      select @v_RoadId=null
      select @v_RoadTypeId=null
      select @v_RoadName=null
      select @v_iTemp=null
      select @v_sTemp=null
      select @v_PostCodeId=null
      --Fetch customers into vars
      fetch next from vc_ContractCustomers into @v_region_id,
        @v_cust_id,
        @v_contract_no,@v_cust_title,@v_cust_surname_company,
        @v_cust_initials,@v_cust_rd_number,@v_cust_mailing_address_no,
        @v_cust_mailing_address_road,@v_cust_mailing_address_locality,@v_cust_mail_town,
        @v_cust_nad_reference,@v_cust_prior_customer,@v_cust_phone_day,
        @v_cust_phone_night,@v_cust_dir_listing_ind,@v_cust_dir_listing_text,
        @v_cust_delivery_frequency,@v_cust_delivery_days,@v_cust_business,
        @v_cust_rural_resident,@v_cust_rural_farmer,@v_cust_old_delivery_days,
        @v_cust_adpost_quantity,@v_cust_date_first_loaded,@v_cust_date_last_transfered,
        @v_cust_date_left,@v_printedon,@v_cust_date_commenced,
        @v_cust_property_identification,@v_cust_post_code,@v_cust_survey98_timestamp,
        @v_cust_phone_mobile,@v_cust_category,@v_sf_key1,
        @v_sf_key2,@v_sf_key3,@v_sf_key4,
        @v_sf_key5,@v_sf_key6,@v_sf_key7,
        @v_sf_key8,@v_sf_key9
      --Check SQLSTATE
      if @@fetch_status <0
        break
        /* Watcom only
        MAINLOOP
        */
      if charindex(rd.Trim('private bag'),rd.trim(upper(@v_cust_mailing_address_road))) > 0
        begin
          select @v_cust_property_identification=@v_cust_mailing_address_road
          select @v_cust_mailing_address_road=null
        end
      /******Migrate address******/
      --Generate Town/City
      if len(@v_cust_mail_town) > 0
        begin
          select @v_Ctr=count(*)
            from TownCity where
            region_id = @v_region_id and
            Upper(rd.Trim(tc_name)) = Upper(rd.Trim(@v_cust_mail_town))
          --Check @@error
          if @@error <> 0 /* <> was < */
            begin
              rollback transaction
              return(-70)
            end
          --Does it exist"?"
          if @v_Ctr = 0
            begin
              --No: Add town/city
              if @v_MaxTownCityId is null
                select @v_MaxTownCityId=0
              select @v_MaxTownCityId=@v_MaxTownCityId+1
              select @v_TownCityId=@v_MaxTownCityId
              insert into TownCity(tc_id,region_id,tc_name) values(
                @v_MaxTownCityId,@v_Region_Id,@v_cust_mail_town)
              --Check @@error
              if @@error <> 0 /* <> was < */
                begin
                  rollback transaction
                  return(-80)
                end
            end
          else
            begin
              --Yes: Get the Town/City ID for future use
              select top 1  @v_TownCityId=tc_Id
                from TownCity where
                region_id = @v_region_id and
                Upper(rd.Trim(tc_name)) = Upper(rd.Trim(@v_cust_mail_town))
              --Check @@error
              if @@error <> 0 /* <> was < */
                begin
                  rollback transaction
                  return(-90)
                end
            end
        end
      --Generate Suburbs/Locality
      if len(@v_cust_mailing_address_locality) > 0
        begin
          select @v_Ctr = count(*) 
            from SuburbLocality where
            Upper(rd.Trim(sl_name)) = Upper(rd.Trim(@v_cust_mailing_address_locality))
          --Check @@error
          if @@error <> 0 /* <> was < */
            begin
              rollback transaction
              return(-100)
            end
          --Does it exist"?"
          if @v_Ctr = 0
            begin
              --No: Add suburbs/locality
              if @v_MaxSuburbLocalityId is null
                select @v_MaxSuburbLocalityId=0
              select @v_MaxSuburbLocalityId=@v_MaxSuburbLocalityId+1
              select @v_SuburbLocalityId=@v_MaxSuburbLocalityId
              insert into SuburbLocality(sl_id,sl_name) values(
                @v_MaxSuburbLocalityId,@v_cust_mailing_address_locality)
              --Check @@error
              if @@error <> 0 /* <> was < */
                begin
                  rollback transaction
                  return(-110)
                end
            end
          else
            begin
              --Yes: Get suburb/locality ID for future use 
              select top 1 @v_SuburbLocalityId=sl_id 
                from SuburbLocality where
                Upper(rd.Trim(sl_name)) = Upper(rd.Trim(@v_cust_mailing_address_locality))
              --Check @@error
              if @@error <> 0 /* <> was < */
                begin
                  rollback transaction
                  return(-120)
                end
            end
        end
      --Generate town_suburb
      if @v_TownCityId > 0 and @v_SuburbLocalityId > 0 and len(@v_cust_mailing_address_locality) > 0 and len(@v_cust_mail_town) > 0
        begin
          select @v_iTemp=count(*) 
            from town_suburb where
            town_suburb.tc_id = @v_TownCityId and
            town_suburb.sl_id = @v_SuburbLocalityId
          --Check @@error
          if @@error <> 0 /* <> was < */
            begin
              rollback transaction
              return(-130)
            end
          if @v_iTemp = 0 or @v_iTemp is null
            begin
              insert into town_suburb(tc_id,sl_id) values(
                @v_TownCityId,@v_SuburbLocalityId)
              --Check @@error
              if @@error <> 0 /* <> was < */
                begin
                  rollback transaction
                  return(-140)
                end
            end
        end
      --Generate Roads
      if len(@v_cust_mailing_address_road) > 0
        begin
          --Generate Roads: Try to separate the road name and the type
          select top 1 @v_RoadName=case when len(rd.Trim(LEFT(customer.cust_mailing_Address_road,charindex(' ' + road_type.rt_abbrev,lower(cust_mailing_address_road))))) = 0 then cust_mailing_Address_road else rd.Trim(LEFT(customer.cust_mailing_Address_road,charindex(' ' + road_type.rt_abbrev,lower(cust_mailing_address_road)))) end,
            @v_RoadTypeId=rt_id  
             from customer,
            road_type where
            RIGHT(lower(cust_mailing_address_road),len(road_type.rt_abbrev)) = lower(road_type.rt_abbrev) and
            customer.cust_id = @v_cust_id
          --Check @@error
          if @@error <> 0 /* <> was < */
            begin
              rollback transaction
              return(-150)
            end
          if @v_RoadName is null
            select @v_RoadName=@v_cust_mailing_address_road
          --Search for road using extracted values
          select top 1 @v_RoadId=road.road_id,
            @v_sTemp=road.road_name  
             from road where
            Lower(rd.Trim(road.road_name)) = Lower(rd.Trim(@v_RoadName)) and
            ((road.rt_id = @v_RoadTypeId) or(road.rt_id is null and @v_RoadTypeId is null))
          --insert into fuck_t values (v_RoadId, v_sTemp,v_RoadTypeId, v_RoadName);
          --Check @@error
          if @@error <> 0 /* <> was < */
            begin
              rollback transaction
              return(-160)
            end
          --Add road (for the suburb) IF not found. Dupes allowed accross suburbs
          if @v_RoadId > 0
            select @v_MaxRoadId=@v_MaxRoadId --DO NOTHING
          else
            begin
              if len(@v_RoadName) = 0 or @v_RoadName is null
                begin
                  select @v_RoadName=@v_cust_mailing_address_road
                  select @v_RoadTypeId=null
                end
              if @v_MaxRoadId is null
                select @v_MaxRoadId=0
              select @v_MaxRoadId=@v_MaxRoadId+1
              select @v_RoadId=@v_MaxRoadId
              --Create road
              insert into road(road_id,road_name,rt_id) values(
                @v_MaxRoadId,@v_RoadName,@v_RoadTypeId)
              --Check @@error
              if @@error <> 0 /* <> was < */
                begin
                  rollback transaction
                  return(-170)
                end
            end
        end
      --road
      --Create road/suburb  
      if @v_SuburbLocalityId > 0 and @v_RoadId > 0
        begin
          select @v_iTemp=Count(*) 
            from road_suburb where
            sl_id = @v_SuburbLocalityId and
            road_id = @v_RoadId
          if @v_iTemp = 0
            begin
              insert into road_suburb(sl_id,road_id) values(
                @v_SuburbLocalityId,@v_RoadId)
              --Check @@error
              if @@error <> 0 /* <> was < */
                begin
                  rollback transaction
                  return(-185)
                end
            end
        end
      --Create town/road 
      if @v_RoadId > 0 and @v_TownCityId > 0
        begin
          select @v_iTemp=Count(*) 
            from town_road where
            tc_id = @v_TownCityId and
            road_id = @v_RoadId
          if @v_iTemp = 0
            begin
              insert into town_road(tc_id,road_id) values(
                @v_TownCityId,@v_RoadId)
              --Check @@error
              if @@error <> 0 /* <> was < */
                begin
                  rollback transaction
                  return(-195)
                end
            end
        end
      select top 1 @v_PostCodeId=post_code.post_code_id 
        from post_code where
        rd.Trim(Lower(post_code.post_code)) = rd.Trim(Lower(@v_cust_post_code)) and
        rd.Trim(Lower(post_mail_town)) = rd.Trim(Lower(@v_cust_mail_town))
      --Migrate the address: main address record
      insert into address(adr_id,tc_id,road_id,
        sl_id,contract_no,post_code_id,
        adr_rd_no,adr_no,/*adr_nad_reference,*/
        adr_old_delivery_days,adr_property_identification,adr_date_loaded) values(
        @v_cust_id,@v_TownCityId,@v_RoadId,
        @v_SuburbLocalityId,@v_contract_no,@v_PostCodeId,
        @v_cust_rd_number,@v_cust_mailing_address_no,/*@v_cust_nad_reference,*/
        @v_cust_old_delivery_days,@v_cust_property_identification,@v_cust_date_first_loaded)
      --Check @@error
      if @@error <> 0 /* <> was < */
        begin
          rollback transaction
          return(-200)
        end
      /*Migrate customer*/
      insert into rds_customer(cust_id,
        cust_title,cust_surname_company,
        cust_initials,cust_phone_day,cust_phone_night,
        cust_dir_listing_ind,cust_dir_listing_text,cust_business,
        cust_rural_resident,cust_rural_farmer,printedon,
        cust_date_commenced,
        cust_phone_mobile,master_cust_id,
        cust_care_of,cust_adpost_quantity) values(
        @v_cust_id,@v_cust_title,isNull(@v_cust_surname_company,''),
        @v_cust_initials,@v_cust_phone_day,@v_cust_phone_night,
        isNull(@v_cust_dir_listing_ind,'N'),@v_cust_dir_listing_text,@v_cust_business,
        @v_cust_rural_resident,@v_cust_rural_farmer,@v_printedon,
        (case when @v_cust_date_commenced > @v_cust_date_last_transfered or @v_cust_date_last_transfered is null then @v_cust_date_commenced else @v_cust_date_last_transfered end),
        @v_cust_phone_mobile,null,
        null,@v_cust_adpost_quantity)
      --Check @@error
      if @@error <> 0 /* <> was < */
        begin
          rollback transaction
          return(-210)
        end
      select @v_MaxRecipientId=Max(cust_id) 
        from rds_customer where
        cust_id > 500000
      if @v_MaxRecipientId is null
        select @v_MaxRecipientId=500000
      /*Migrate recipients*/
      insert into rds_customer(cust_id,
        cust_title,cust_surname_company,
        cust_initials,cust_phone_day,cust_phone_night,
        cust_dir_listing_ind,cust_dir_listing_text,cust_business,
        cust_rural_resident,cust_rural_farmer,printedon,
        cust_date_commenced,cust_phone_mobile,master_cust_id,
        cust_care_of,cust_adpost_quantity)
        select row_number() over (order by master_cust_id asc) +@v_MaxRecipientId,null,isNull(rc_surname_company,''),
          isNull(rc_first_names,''),null,null,'N',
          null,null,
          null,null,null,
          null,null,@v_cust_id,
          null,null from
          recipient where
          cust_id = @v_cust_id
      --Check @@error
      if @@error <> 0 /* <> was < */
        begin
          rollback transaction
          return(-220)
        end
      --Migrate Address Frequency Sequence
      insert into address_frequency_sequence(adr_id,
        sf_key,rf_delivery_days,contract_no,seq_num)
        select @v_cust_id,sf_key,rf_delivery_days,@v_contract_no,cfo_sequence from
          cust_frequency_order where
          contract_no = @v_contract_no and
          cust_id = @v_cust_id
      --Check @@error
      if @@error <> 0 /* <> was < */
        begin
          rollback transaction
          return(-230)
        end
      --Generate Customer moves 
      insert into customer_address_moves(adr_id,
        cust_id,move_in_date,move_out_date) values(
        @v_cust_id,@v_cust_id,isNull(@v_cust_date_commenced,getdate()),null)
      --Check @@error
      if @@error <> 0 /* <> was < */
        begin
          rollback transaction
          return(-240)
        end
      --Generate Customer moves for recipients
      insert into customer_address_moves(adr_id,
        cust_id,move_in_date,move_out_date)
        select @v_cust_id,cust_id,isNull(@v_cust_date_commenced,getdate()),null from
          rds_customer where
          master_cust_id = @v_cust_id
      --Check @@error
      if @@error <> 0 /* <> was < */
        begin
          rollback transaction
          return(-250)
        end
    end
  --Migrate Route Description - No need (just drop the foreign key to customer)
  --************************
  --Close the cursor
  close vc_ContractCustomers
  --Check @@error
  if @@error <> 0 /* <> was < */
    begin
      rollback transaction
      return(-270)
    end
  --Commit changes
  commit transaction
  --Check @@error
  if @@error <> 0 /* <> was < */
    begin
      rollback transaction
      return(-290)
    end
  select @v_Loops 
end
GO
