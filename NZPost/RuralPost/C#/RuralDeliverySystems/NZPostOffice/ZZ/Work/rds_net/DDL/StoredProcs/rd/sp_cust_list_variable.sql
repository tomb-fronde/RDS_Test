/****** Object:  StoredProcedure [rd].[sp_cust_list_variable]    Script Date: 08/05/2008 10:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



 

--
-- Definition for stored procedure sp_cust_list_variable : 
--
 
create procedure [rd].[sp_cust_list_variable](
@inPost varchar(5000),
@inOcc varchar(200),
@inInterest varchar(200),
@inDate1 datetime,
@inDate2 datetime,
@in_orFlag  int)
--
-- TJB  Sept 2005  NPAD2 address schema changes
-- Added adr_unit number and road_suffix to relevant parts of addresses returned
--
-- TJB  Apr 2006  NPAD2 bug fixes
-- New post codes mean the inPost string may be much longer that previously.
-- Increased its length (was 1200).
--
-- TJB  SR4701  May 2007
-- Added in_orFlag to parameter list, and dp_id to results.  If in_orFlag = 1, 
-- the occupations and interests criteria are 'or'ed, otherwise 'and'ed.
-- Sundry refinements to selected results made (see SR).
-- Added indexes to temp tables to try to improve performance.
--
-- Added execute immediate section.  Uses execute immediate if the constructed
-- command will be short enough (< 4000 characters), otherwise the original
-- selects with temporary tables.  The command string length can be very long 
-- if the user has selected many (but not all) post codes.
-- - the execute immediate runs considerably faster than the original scheme.
as -- Increased its length (was 1200).
begin
set CONCAT_NULL_YIELDS_NULL off
  declare @li_post int,
  @li_occ int,
  @li_int int,
  @movein1 datetime,
  @movein2 datetime,
  @rd_contract integer,
  @len         integer,
  @cmd         varchar(5000),
  @postSelect  varchar(3000),
  @occSelect   varchar(200),
  @intSelect   varchar(200),
  @andor       char(3),
	
  @movein1s varchar(20),
  @movein2s varchar(20)

  -- create temp for post_codes
  CREATE  table #post_temp(
    post_id integer null,
    ) 
--on commit delete rows;
  -- create temp for  occupations :
  CREATE  table #occ_temp(
    occ_id integer null,
    )
-- on commit delete rows;
  -- create temp for interests
  CREATE  table #interest_temp(
    int_id integer null,
    ) 
--on commit delete rows;

 -- create a temporary table for result set when using execute immediate form
  CREATE  table #result_set (
	    	Customer_id   integer,
	    	Title         char(10),
	    	Initials      char(30),
	    	Last_name     char(45),
	    	Road_no       char(20),
	    	Road_name     char(100),
	    	Locality      char(50),
	    	RD_no         char(40),
	    	Town_Postcode char(45), 
	    	Post_town     char(40),
	    	Postcode      char(4),
	    	Dp_id         integer
	        );
 
  -- get timestamps
  if @inDate1 is not null
    select @movein1 = CAST(@inDate1 AS datetime )
  else
    select @movein1=null
  if @inDate1 is not null
    select @movein2 = CAST(@inDate2 AS datetime )
  else
    select @movein2=null


 -- get timestamps
    if @inDate1 is not null
        select @movein1 = @inDate1
    else
        set @movein1 = null

	if @inDate1 is not null
        select @movein2 = @inDate2
    else
        set @movein2 = null

    -- Get ct_key for Rural Delivery contracts
    select @rd_contract = ct_key
      from contract_type
     where contract_type = 'Rural Delivery Contracts'
	
   set @len = (case when isnull(@inPost, ' ') = ' ' then 0 else len(@inPost) end)
              + (case when isnull(@inOcc, ' ') = ' ' then 0 else len(@inOcc) end)
              + (case when isnull(@inInterest, ' ') = ' ' then 0 else len(@inInterest) end)

   -- If the length of the strings for the post codes, occupations and interests is
        -- short enough (as it is when only a few post codes have been selected) we''ll
        -- construct a select command as a string and use execute immediate.
        -- If the length of the strings is too long, we''ll use the slower, original
        -- selects (but indexes have been added to speed things up a bit).

if @len > 1250
BEGIN
  -- populate temp tables : 
  if(@inPost is not null) and(LEN(@inPost) > 1)
  begin
		execute('insert into #post_temp(post_id) '+'select distinct(post_code_id) '+'  from post_code where post_code.post_code_id in '+
			@inPost+' ; ')
		CREATE INDEX idx_post_temp ON #post_temp ( post_id ASC )
  end 
  if(@inOcc is not null) and(LEN(@inOcc) > 1)
  begin
		execute('insert into #occ_temp(occ_id) '+'select distinct(occupation_id) '+'  from occupation where occupation.occupation_id in '+
		@inOcc+' ; ')
  		CREATE INDEX idx_occ_temp ON #occ_temp ( occ_id ASC )
  end 
  if(@inInterest is not null) and(LEN(@inInterest) > 1)
  begin
		execute('insert into #interest_temp(int_id) '+'select distinct(interest_id) '+'  from interest where interest.interest_id in '+
		@inInterest+' ; ')
  		CREATE INDEX idx_interest_temp ON #interest_temp ( int_id ASC )
  end 
  -- get counts of temp tables
  select @li_post = count(*) from #post_temp
  select @li_occ = count(*) from #occ_temp
  select @li_int = count(*) from #interest_temp

  -- if the "or" flag == 0, we "AND" the occupations and interests selections  

  if @in_orFlag = 0
	  select cust.cust_id               as Customer_id, 
	               cust.cust_title            as Title, 
	               cust.cust_initials         as Initials, 
	               cust.cust_surname_company  as Last_name, 
	               upper(isnull(addr.adr_unit,'')+'/')+rtrim(ltrim(addr.adr_no)) + upper(rtrim(ltrim(addr.adr_alpha)))  as Road_no, 
	               rd.road_name + isnull(rt.rt_name,'') + isnull(rs.rs_name,'')         as Road_name, 
	               sub.sl_name                as Locality, 
	               'RD ' + addr.adr_rd_no     as RD_no, 
	               pc.post_mail_town + '  ' + pc.post_code  as Town_postcode, 
	               pc.post_mail_town          as Post_town, 
	               pc.post_code               as Postcode,
	               addr.dp_id                 as Dpid
		from
			rds_customer as cust join customer_address_moves as cam on cust.cust_id = cam.cust_id
			join address as addr on addr.adr_id = cam.adr_id
			left outer join suburblocality as sub on addr.sl_id = sub.sl_id
			left outer join post_code as pc on addr.post_code_id = pc.post_code_id
			join road as rd on addr.road_id = rd.road_id
			join types_for_contract as tfc on addr.contract_no = tfc.contract_no
			left outer join road_type as rt on rd.rt_id = rt.rt_id
			left outer join road_suffix as rs on rd.rs_id = rs.rs_id 
		where
			(@li_post = 0 or addr.post_code_id = any(select post_id from #post_temp)) and
			(@li_occ = 0 or cust.cust_id = 
			any(select co.cust_id from customer_occupation as co,#occ_temp as ot where co.occupation_id = ot.occ_id)) and
			(@li_int = 0 or cust.cust_id = 
			any(select ci.cust_id from customer_interest as ci,#interest_temp as it where ci.interest_id = it.int_id)) and
			cam.move_out_date is null and
			cust.master_cust_id is null and
			(@movein1 is null or cam.move_in_date > @movein1) and
			(@movein2 is null or cam.move_in_date < @movein2) and
			cust.cust_surname_company not like '%&%' and
			-- and cust.cust_title not like '%&%'
			-- and cust.cust_initials not like '%&%'
			cust.cust_title is not null and
			cust.cust_dir_listing_ind = 'Y'
		   and addr.dp_id is not null
		   and addr.adr_rd_no is not null
		   and tfc.ct_key = @rd_contract
  else            -- if the "or" flag == 1 (actually any non-0), we "OR" the occupations and interests selections
		select cust.cust_id               as Customer_id, 
	               cust.cust_title            as Title, 
	               cust.cust_initials         as Initials, 
	               cust.cust_surname_company  as Last_name, 
	              upper(isnull(addr.adr_unit,'')+'/')+rtrim(ltrim(addr.adr_no)) + upper(rtrim(ltrim(addr.adr_alpha)))  as Road_no, 
	               rd.road_name + isnull(rt.rt_name,'') + isnull(rs.rs_name,'')         as Road_name, 
	               sub.sl_name                as Locality, 
	               'RD ' + addr.adr_rd_no     as RD_no, 
	               pc.post_mail_town + '  ' + pc.post_code  as Town_postcode, 
	               pc.post_mail_town          as Post_town, 
	               pc.post_code               as Postcode,
	               addr.dp_id                 as Dpid
	        from
			rds_customer as cust join customer_address_moves as cam on cust.cust_id = cam.cust_id
			join address as addr on addr.adr_id = cam.adr_id
			left outer join suburblocality as sub on addr.sl_id = sub.sl_id
			left outer join post_code as pc on addr.post_code_id = pc.post_code_id
			join road as rd on addr.road_id = rd.road_id
			join types_for_contract as tfc on addr.contract_no = tfc.contract_no
			left outer join road_type as rt on rd.rt_id = rt.rt_id
			left outer join road_suffix as rs on rd.rs_id = rs.rs_id 
		where
			(@li_post = 0 or addr.post_code_id = any(select post_id from #post_temp)) and
			(
				(@li_occ = 0 or cust.cust_id = 
				any(select co.cust_id from customer_occupation as co,#occ_temp as ot where co.occupation_id = ot.occ_id))
				or
				(@li_int = 0 or cust.cust_id = 
				any(select ci.cust_id from customer_interest as ci,#interest_temp as it where ci.interest_id = it.int_id)))
			and
			cam.move_out_date is null and
			cust.master_cust_id is null and
			(@movein1 is null or cam.move_in_date > @movein1) and
			(@movein2 is null or cam.move_in_date < @movein2) and
			cust.cust_surname_company not like '%&%' and
			-- and cust.cust_title not like '%&%'
			-- and cust.cust_initials not like '%&%'
			cust.cust_title is not null and
			cust.cust_dir_listing_ind = 'Y'
		   and addr.dp_id is not null
		   and addr.adr_rd_no is not null
		   and tfc.ct_key = @rd_contract
  END
  ELSE        -- We''ve estimated that the command string will be short enough 
                -- for the 'execute immediate' (approx < 4000), so we''ll create 
                -- a select string and execute it.
        BEGIN
	    -- Construct the where clauses for postcode, occupation and interests
        -- Note: a null value represents 'any'
        -- The actual clauses are constructed as part of the select command below
	    if (@inPost is null) or (len(@inPost) <= 1)
	        set @postSelect = '0 = 0'
	    else
	        set @postSelect = 'addr.post_code_id in ' + @inPost

	    if (@inOcc is null) or (len(@inOcc) <= 1) 
	        set @occSelect = '0 = 0'
	    else
	        set @occSelect = 'exists (select 1 from customer_occupation co'
	                              +' where co.cust_id = cust.cust_id and co.occupation_id in ' + @inOcc +')'

	    if (@inInterest is null) or (len(@inInterest) <= 1) 
	        set @intSelect = '0 = 0'
	    else
	        set @intSelect = 'exists (select 1 from customer_interest ci'
	                              +' where ci.cust_id = cust.cust_id and ci.interest_id in ' + @inInterest +')'

	    -- Translate inOrFlag into 'and' or 'or'
	    if @in_orFlag = 0 
	        set @andor = 'and'
	    else
	        set @andor = 'or'

	    -- Create the command to execute

		if @movein1 is null
			select @movein1s = null
		else
			select @movein1s = convert(varchar, @movein1, 101)


		if @movein2 is null
			select @movein2s = null
		else
			select @movein2s = convert(varchar, @movein2, 101)

	    set @cmd = 'select cust.cust_id, '
	            +'cust.cust_title, '
	            +'cust.cust_initials, '
	            +'cust.cust_surname_company, ' 
--	            +'upper(isnull(addr.adr_unit,'''')+''/'')+rtrim(ltrim(addr.adr_no)) + upper(rtrim(ltrim(addr.adr_alpha))) as addr_no, '
	            +'upper(case when addr.adr_unit is null then '''' else addr.adr_unit + ''/'' end)+isnull(rtrim(ltrim(addr.adr_no)),'''') + isnull(upper(rtrim(ltrim(addr.adr_alpha))),'''') as addr_no, '
--	            +'rd.road_name + isnull(rt.rt_name,'''') + isnull(rs.rs_name,'''') as addr_street, '
				+'rd.road_name + case when rt.rt_name is null then '''' else '' ''+ rt.rt_name end + case when rs.rs_name is null then '''' else '' ''+ rs.rs_name end as addr_street, '
	            +'sub.sl_name, '
	            +'''RD '' + addr.adr_rd_no  as rd_no, '
	            +'pc.post_mail_town + ''  '' + pc.post_code  as town, '
	            +'pc.post_mail_town, '
	            +'pc.post_code, '
	            +'addr.dp_id '
				+'from rds_customer as cust join customer_address_moves as cam on cust.cust_id = cam.cust_id '
	            +'join address as addr on addr.adr_id = cam.adr_id '
	             +'left outer join suburblocality as sub on addr.sl_id = sub.sl_id '
				 +'left outer join post_code as pc on addr.post_code_id = pc.post_code_id '
				 +'join road as rd on addr.road_id = rd.road_id '
				 +'join types_for_contract as tfc on addr.contract_no = tfc.contract_no '
				 +'left outer join road_type as rt on rd.rt_id = rt.rt_id '
				+'left outer join road_suffix as rs on rd.rs_id = rs.rs_id '
	      +'where ' + LTRIM(@postSelect) + ' '
	        +'and ( ' + @occSelect + ' ' 
                      + @andor + ' ' + @intSelect + ' ) '
	        +'and cam.move_out_date   is null '
	        +'and cust.master_cust_id is null '
	        +'and (' + @movein1s + ' is null or cam.move_in_date > convert(datetime, ''' + @movein1s + ''', 101) ) '
	        +'and (' + @movein2s + ' is null or cam.move_in_date < convert(datetime, ''' + @movein2s + ''', 101) ) '
	        +'and cust.cust_surname_company not like ''%&%'' '
	        +'and cust.cust_title is not null '
	        +'and cust.cust_dir_listing_ind = ''Y'''
	        +'and addr.dp_id is not null '
	        +'and addr.adr_rd_no is not null '
	        +'and tfc.ct_key = ' + convert(varchar, @rd_contract) + ';';

            -- Now do it.  The execute immediate cannot generate a result set, so we 
            -- put the results in a temporary table.
	    execute ('insert into #result_set ' + @cmd);

print @cmd
            -- Select the results from the temporary table to return then to the caller.
	    select * from #result_set;
	    END
end
GO
