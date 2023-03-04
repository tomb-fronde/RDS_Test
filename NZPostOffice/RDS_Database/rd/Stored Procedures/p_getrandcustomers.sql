
--
-- Definition for stored procedure p_getrandcustomers : 
--

create procedure [rd].[p_getrandcustomers](@xrequired int)
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  -- PBY 25-11-2002 SR#4427
  -- Used a temporary table instead of the permenant temp_mine table.
  -- Also modified the query to use rds_customer table instead of the legacy customer table.
  --
  -- PBY Modified 27-Feb-2002
  -- Added a Post Code onto the label
  --
  -- TJB 30-Sep-2004 SR4637
  -- Include postcode to town name so it needn''t print on a separate line.
  --
  -- TJB  Sept 2005  NPAD2 Address schema changes
  -- Added adr_unit and road_suffix to addresses
  declare @xrand int,
  @xcount int,
  @xnum int,
  @xtmp int
 create table #tmp_rand_labels(
    cust_title varchar(10) null,
    cust_surname_company varchar(45) null,
    cust_initials varchar(30) null,
    cust_mailing_address_no varchar(9) null,
    cust_mailing_address_road varchar(45) null,
    cust_mailing_address_locality varchar(45) null,
    cust_mail_town varchar(45) null,
    cust_rd_number varchar(40) null,
    con_rd_ref_text varchar(35) null,
    uzed integer null,
    cust_post_code varchar(10) null)

  delete from #tmp_rand_labels
  --commit work;
  update tmp_rand_cust_list set uzed = null
  select @xnum = Count(*) 
    from tmp_rand_cust_list
  if @xnum = 0
    begin
      select cust_title,
        cust_surname_company,
        cust_initials,
        cust_mailing_address_no,
        cust_mailing_address_road,
        cust_mailing_address_locality,
        cust_mail_town,
        cust_rd_number,
        con_rd_ref_text,
        cust_post_code from
        #tmp_rand_labels
      return
    end
  select @xCount=0
  /* Watcom only
  CursorLoop:
  */while 1=1 
    begin
      select @xrand=round((rand()*@xnum),0)
      select @xTmp = Count(*) 
        from tmp_rand_cust_list where
        sequence = @xrand and
        uzed is null
      if @xTmp > 0
        begin
          update tmp_rand_cust_list set
            uzed = cust_id where
            sequence = @xrand
          select @xCount=@xCount+1
        end
      if @xcount >= @xrequired or @xCount >= @xNum
        break
        /* Watcom only
        CursorLoop
        */
    end
  insert into #tmp_rand_labels
    select distinct
      rds_customer.cust_title,
      rds_customer.cust_surname_company,
      rds_customer.cust_initials,
      case when address.adr_unit is null then '' else address.adr_unit+'/' end +
      IsNull(address.adr_no,'')+
      IsNull(address.adr_alpha,''),
      IsNull(road.road_name,'')+
      case when road_type.rt_name is null then '' else ' '+road_type.rt_name end +
      case when road_suffix.rs_name is null then '' else ' '+road_suffix.rs_name end ,
      suburblocality.sl_name,
      towncity.tc_name,
      address.adr_rd_no,'',
      rds_customer.cust_id,
      post_code.post_code from
      address left outer join road on address.road_id = road.road_id left outer join
      road_type on road.rt_id = road_type.rt_id left outer join
      road_suffix on road.rs_id = road_suffix.rs_id left outer join suburblocality on
      address.sl_id = suburblocality.sl_id left outer join towncity on
      address.tc_id = towncity.tc_id left outer join post_code on address.post_code_id = post_code.post_code_id,
      tmp_rand_cust_list,
      rds_customer where
      tmp_rand_cust_list.adr_id = address.adr_id and
      rds_customer.cust_id = tmp_rand_cust_list.cust_id and
      tmp_rand_cust_list.uzed is not null
  --commit work;
  select cust_title,
    cust_surname_company,
    cust_initials,
    cust_mailing_address_no,
    cust_mailing_address_road,
    cust_mailing_address_locality,
    -- TJB SR4637
    -- Include postcode with town name so it needn''t print on a separate line
    -- (similar to normal customer list)
    -- cust_mail_town,
    cust_mail_town+'   '+cust_post_code,
    cust_rd_number,
    con_rd_ref_text,
    cust_post_code from
    --    post_code.post_code from
    #tmp_rand_labels
--       post_code 
-- where tmp_mine.cust_mail_town *= post_code.post_mail_town
end