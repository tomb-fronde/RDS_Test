
create function [rd].[f_GetCustomerAddresses](@ai_cust_id int)
-- Get formatted customer address
-- TJB  SR4599    Add adr_alpha to adr_no.
-- TJB  SR4624a   Added move_out_date condition (current customer)
-- TJB  Sept 2005  NPAD2 Address schema changes
-- Added adr_unit and road_suffix to addresses
-- Returns address in this format
--   <Property ID>
--   <unit>/<number><alpha> <road name> <road type> <road suffix>
--   <suburb>
--   RD <RD number>
returns char(1000)
as --   <town>  <post code>
begin

  declare @sret varchar(100)
  declare @stemp1 varchar(100)
  declare @stemp2a varchar(50)
  declare @stemp2b varchar(50)
  declare @stemp2 varchar(100)
  declare @stemp3 varchar(100)
  declare @stemp4 varchar(100)
  declare @stemp5 varchar(100)
  declare @stemp6 varchar(100)
  declare @stemp7 varchar(100)
  declare @stemp8 varchar(50)
  declare @scrlf varchar(100)
  -- Note re this cursor: some customers have more than one address.  This use of a
  --      cursor avoids multiple result set errors.  The cursor shouldn''t be removed 
  --      unless you're SURE the data is clean, no matter how tempting!  - TJB Sept'05
  -- Note on the joins: The 'on' clauses appear to be redundant, and some probably are, 
  --      but removing them results in lots of extra rows, so its better to leave them.
  --      - TJB  Sept''05
  -- TJB SR4663 Add RD number
  declare Customer_Address  cursor for select address.adr_property_identification,
      case when isnull(address.adr_unit,'')='' then '' else address.adr_unit+'/' end +address.adr_no,
      address.adr_alpha,
      road.road_name,
      road_type.rt_name+case when isnull(road_suffix.rs_name,'')= '' then '' else ' '+road_suffix.rs_name end ,
      suburblocality.sl_name,
      towncity.tc_name,
      post_code.post_code,
      address.adr_rd_no from
      address left outer join road on
      address.road_id = road.road_id
		left outer join suburblocality on
      address.sl_id = suburblocality.sl_id
		left outer join towncity on
      address.tc_id = towncity.tc_id
		left outer join road_type on
      road.rt_id = road_type.rt_id
		left outer join rd.road_suffix on
      road.rs_id = road_suffix.rs_id
		 left outer join post_code on
      address.post_code_id = post_code.post_code_id,
      customer_address_moves,
      rds_customer where
      customer_address_moves.adr_id = address.adr_id and
      rds_customer.cust_id = customer_address_moves.cust_id and
      rds_customer.master_cust_id is null and
      customer_address_moves.move_out_date is null and
      rds_customer.cust_id = @ai_cust_id
  --      ((rds_customer.master_cust_id is null) and
  --      (rds_customer.cust_id = ai_cust_id));
  -- TJB (SR4624a) 26 May 2004
  -- Changed where conditions above: added move_out_date condition, split compound condition,
  -- and reformatted
  open Customer_Address
  fetch next from  Customer_Address into @stemp1,@stemp2a,@stemp2b,@stemp3,@stemp4,@stemp5,@stemp6,@stemp7,@stemp8
  -- PBY SR#4373,4368 Commented out char(13) so only a newline is used. (char13 is carriage return)
  select @scrlf=char(10) -- || "char"(13);
  -- TJB SR4599 Adjust to remove leading spaces when columns empty (change isnull(stemp3 to ifnull...)
  -- TJB SR4663 Move post code to Town line and add RD number after suburb
  -- NOTE:  It appears the output is to leave blank lines where there is no data
  --        (eg leave a blank line for the property name if there isn''t one)!
  select @sret=isnull(@stemp1,'')+@scrlf+ -- Property ID
    case when (@stemp2a is null) and (@stemp2b is null) then '' else isnull(@stemp2a,'')+isnull(@stemp2b,'')+' ' end+ -- Street number, unit, and alpha
    case when @stemp3 is null then '' else @stemp3+' ' end + isnull(@stemp4,'')+@scrlf+ -- Streen name, type, and suffix
    isnull(@stemp5,'')+@scrlf+ -- Suburb
    case when @stemp8 is null then '' else 'RD '+@stemp8 end +@scrlf+ -- RD number
    case when @stemp6 is null then '' else @stemp6+'    ' end +isnull(@stemp7,'')+@scrlf -- Town & Postcode

  close Customer_Address
  return(@sret)
end