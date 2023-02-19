
--
-- Definition for stored procedure temp_AddressMerge : 
--

create procedure [rd].[temp_AddressMerge] AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
   /*declare
  Watcom only
  err_notfound exception for sqlstate value '02000'
  */
  declare cur_dupAddress cursor for select Id=adr1.adr_id,
      SortField=convert(varchar,adr1.contract_no)+'@'+convert(varchar,adr1.tc_id)+'@'+convert(varchar,adr1.adr_rd_no)+'@'+convert(varchar,adr1.road_id)+'@'+rd.trim(IsNULL(adr1.adr_no,''))+rd.trim(IsNULL(adr1.adr_alpha,'')) from
      address as adr1 where
      0 < (select COUNT(adr2.adr_id) from
        address as adr2 where
        adr1.adr_id <> adr2.adr_id and
        adr1.tc_id = adr2.tc_id and
        adr1.adr_rd_no = adr2.adr_rd_no and
        adr1.road_id = adr2.road_id and
        (rd.trim(IsNULL(adr1.adr_no,''))+rd.trim(IsNULL(adr1.adr_alpha,''))) = (rd.trim(IsNULL(adr2.adr_no,''))+rd.trim(IsNULL(adr2.adr_alpha,''))) and
        rd.trim(IsNULL(adr1.adr_no,''))+rd.trim(IsNULL(adr1.adr_alpha,'')) <> '' and
        adr1.contract_no = adr2.contract_no) order by
      SortField asc,
      Id asc
  declare @primaryAdrId integer,
  @currentAdrId integer,
  @primaryDupTag varchar(255),
  @currentDupTag varchar(255)
  select @primaryAdrId=0
  select @currentAdrId=0
  select @primaryDupTag=''
  select @currentDupTag=''
  open cur_dupAddress
  /* Watcom only
  DupLoop:
  */while 1=1 
    begin
      fetch next from cur_dupAddress into @currentAdrId,@currentDupTag
      if @@fetch_status <0
        break
        /* Watcom only
        DupLoop
        */
      if @primaryDupTag <> @currentDupTag
        begin
          -- this is a different set of addresses
          select @primaryAdrId=@currentAdrId
          select @primaryDupTag=@currentDupTag
        end
      else
        begin
          -- this is a duplicated address
          -- move the customers into the primary address
          insert into customer_address_moves(adr_id,
            cust_id,
            move_in_date)
            select @primaryAdrId,
              cust_id,
              getdate() from
              customer_address_moves where
              adr_id = @currentAdrId and
              move_out_date is null
          -- delete the duplicated address
          delete from address where
            adr_id = @currentAdrId
        end
    end
  close cur_dupAddress
  commit transaction
end
--EXEC temp_AddressMerge