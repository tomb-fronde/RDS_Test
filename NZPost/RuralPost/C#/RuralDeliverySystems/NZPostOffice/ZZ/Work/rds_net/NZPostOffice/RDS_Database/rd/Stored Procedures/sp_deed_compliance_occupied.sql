create procedure [rd].[sp_deed_compliance_occupied]
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  -- TJB  SR4676  Feb 2006    - New
  -- Collect address statistics similar to sp_deed_compliance_addr
  -- but filtered by whether the address is occupied or not.
  declare @reg_id integer
  -- private bag counts
  declare @pvt_one integer
  declare @pvt_two integer
  declare @pvt_three integer
  declare @pvt_four integer
  declare @pvt_five integer
  declare @pvt_six integer
  -- count figures national
  declare @one_nat integer
  declare @two_nat integer
  declare @three_nat integer
  declare @four_nat integer
  declare @five_nat integer
  declare @six_nat integer
  declare @total_nat integer
  -- Christchurch
  declare @one_ch integer
  declare @two_ch integer
  declare @three_ch integer
  declare @four_ch integer
  declare @five_ch integer
  declare @six_ch integer
  declare @total_ch integer
  -- Dunedin
  declare @one_dun integer
  declare @two_dun integer
  declare @three_dun integer
  declare @four_dun integer
  declare @five_dun integer
  declare @six_dun integer
  declare @total_dun integer
  -- Hamilton
  declare @one_ham integer
  declare @two_ham integer
  declare @three_ham integer
  declare @four_ham integer
  declare @five_ham integer
  declare @six_ham integer
  declare @total_ham integer
  -- Palmerston North
  declare @one_p integer
  declare @two_p integer
  declare @three_p integer
  declare @four_p integer
  declare @five_p integer
  declare @six_p integer
  declare @total_p integer
  -- Rotorua
  declare @one_rot integer
  declare @two_rot integer
  declare @three_rot integer
  declare @four_rot integer
  declare @five_rot integer
  declare @six_rot integer
  declare @total_rot integer
  -- Whangarei
  declare @one_w integer
  declare @two_w integer
  declare @three_w integer
  declare @four_w integer
  declare @five_w integer
  declare @six_w integer
  declare @total_w integer
  -- the table to hold address id''s and their standard frequencies
 
    create table #addr_occ_freq(
    adr_id integer null,
    sf_days_week integer null,
    region_id integer null,
    occupied char(1) null default 'N',
    )
	insert into #addr_occ_freq (sf_days_week,
    adr_id,region_id) select sum(sf.sf_days_week),addr.adr_id,tc.region_id from
      towncity as tc join address as addr on tc.tc_id=addr.tc_id join
      address_frequency_sequence on address_frequency_sequence.adr_id=addr.adr_id join
      route_frequency on route_frequency.sf_key=address_frequency_sequence.sf_key and route_frequency.rf_delivery_days=address_frequency_sequence.rf_delivery_days and route_frequency.contract_no=address_frequency_sequence.contract_no join
      standard_frequency as sf on route_frequency.sf_key=sf.sf_key  group by addr.adr_id,tc.region_id
  -- change so that max is 6
  update #addr_occ_freq set
    sf_days_week = 6 where
    sf_days_week > 6
  -- Flag the occupied addresses
  update #addr_occ_freq  set
    occupied = 'Y' from
    #addr_occ_freq as af,customer_address_moves as cam where
    af.adr_id = cam.adr_id and
    move_out_date is null
  -----------------------------------------------------------------
  -- Christchurch
  select @reg_id=6
  select @one_ch=count(*) 
    from #addr_occ_freq where
    sf_days_week = 1 and
    region_id = @reg_id and
    occupied = 'Y'
  select @two_ch=count(*) 
    from #addr_occ_freq where
    sf_days_week = 2 and
    region_id = @reg_id and
    occupied = 'Y'
  select @three_ch=count(*) 
    from #addr_occ_freq where
    sf_days_week = 3 and
    region_id = @reg_id and
    occupied = 'Y'
  select @four_ch=count(*) 
    from #addr_occ_freq where
    sf_days_week = 4 and
    region_id = @reg_id and
    occupied = 'Y'
  select @five_ch=count(*) 
    from #addr_occ_freq where
    sf_days_week = 5 and
    region_id = @reg_id and
    occupied = 'Y'
  select @six_ch=count(*) 
    from #addr_occ_freq where
    sf_days_week = 6 and
    region_id = @reg_id and
    occupied = 'Y'
  select @total_ch=count(*) 
    from #addr_occ_freq where
    region_id = @reg_id and
    occupied = 'Y'
  ----------------------------------------------------------------
  -- Dunedin
  select @reg_id=7
  select @one_dun=count(*) 
    from #addr_occ_freq where
    sf_days_week = 1 and
    region_id = @reg_id and
    occupied = 'Y'
  select @two_dun=count(*) 
    from #addr_occ_freq where
    sf_days_week = 2 and
    region_id = @reg_id and
    occupied = 'Y'
  select @three_dun=count(*) 
    from #addr_occ_freq where
    sf_days_week = 3 and
    region_id = @reg_id and
    occupied = 'Y'
  select @four_dun=count(*) 
    from #addr_occ_freq where
    sf_days_week = 4 and
    region_id = @reg_id and
    occupied = 'Y'
  select @five_dun=count(*) 
    from #addr_occ_freq where
    sf_days_week = 5 and
    region_id = @reg_id and
    occupied = 'Y'
  select @six_dun=count(*) 
    from #addr_occ_freq where
    sf_days_week = 6 and
    region_id = @reg_id and
    occupied = 'Y'
  select @total_dun=count(*) 
    from #addr_occ_freq where
    region_id = @reg_id and
    occupied = 'Y'
  ----------------------------------------------------------------
  -- Hamilton
  select @reg_id=2
  select @one_ham=count(*) 
    from #addr_occ_freq where
    sf_days_week = 1 and
    region_id = @reg_id and
    occupied = 'Y'
  select @two_ham=count(*) 
    from #addr_occ_freq where
    sf_days_week = 2 and
    region_id = @reg_id and
    occupied = 'Y'
  select @three_ham=count(*) 
    from #addr_occ_freq where
    sf_days_week = 3 and
    region_id = @reg_id and
    occupied = 'Y'
  select @four_ham=count(*)
    from #addr_occ_freq where
    sf_days_week = 4 and
    region_id = @reg_id and
    occupied = 'Y'
  select @five_ham=count(*)
    from #addr_occ_freq where
    sf_days_week = 5 and
    region_id = @reg_id and
    occupied = 'Y'
  select @six_ham=count(*)
    from #addr_occ_freq where
    sf_days_week = 6 and
    region_id = @reg_id and
    occupied = 'Y'
  select @total_ham=count(*)
    from #addr_occ_freq where
    region_id = @reg_id and
    occupied = 'Y'
  ----------------------------------------------------------------
  -- Palmerston North
  select @reg_id=4
  select @one_p=count(*)
    from #addr_occ_freq where
    sf_days_week = 1 and
    region_id = @reg_id and
    occupied = 'Y'
  select @two_p=count(*)
    from #addr_occ_freq where
    sf_days_week = 2 and
    region_id = @reg_id and
    occupied = 'Y'
  select @three_p=count(*)
    from #addr_occ_freq where
    sf_days_week = 3 and
    region_id = @reg_id and
    occupied = 'Y'
  select @four_p=count(*)
    from #addr_occ_freq where
    sf_days_week = 4 and
    region_id = @reg_id and
    occupied = 'Y'
  select @five_p=count(*)
    from #addr_occ_freq where
    sf_days_week = 5 and
    region_id = @reg_id and
    occupied = 'Y'
  select @six_p=count(*)
    from #addr_occ_freq where
    sf_days_week = 6 and
    region_id = @reg_id and
    occupied = 'Y'
  select @total_p=count(*)
    from #addr_occ_freq where
    region_id = @reg_id and
    occupied = 'Y'
  ----------------------------------------------------------------
  -- Rotorua
  select @reg_id=3
  select @one_rot=count(*)
    from #addr_occ_freq where
    sf_days_week = 1 and
    region_id = @reg_id and
    occupied = 'Y'
  select @two_rot=count(*)
    from #addr_occ_freq where
    sf_days_week = 2 and
    region_id = @reg_id and
    occupied = 'Y'
  select @three_rot=count(*)
    from #addr_occ_freq where
    sf_days_week = 3 and
    region_id = @reg_id and
    occupied = 'Y'
  select @four_rot=count(*)
    from #addr_occ_freq where
    sf_days_week = 4 and
    region_id = @reg_id and
    occupied = 'Y'
  select @five_rot=count(*)
    from #addr_occ_freq where
    sf_days_week = 5 and
    region_id = @reg_id and
    occupied = 'Y'
  select @six_rot=count(*)
    from #addr_occ_freq where
    sf_days_week = 6 and
    region_id = @reg_id and
    occupied = 'Y'
  select @total_rot=count(*)
    from #addr_occ_freq where
    region_id = @reg_id and
    occupied = 'Y'
  ----------------------------------------------------------------
  -- Whangarei
  select @reg_id=1
  select @one_w=count(*)
    from #addr_occ_freq where
    sf_days_week = 1 and
    region_id = @reg_id and
    occupied = 'Y'
  select @two_w=count(*)
    from #addr_occ_freq where
    sf_days_week = 2 and
    region_id = @reg_id and
    occupied = 'Y'
  select @three_w=count(*)
    from #addr_occ_freq where
    sf_days_week = 3 and
    region_id = @reg_id and
    occupied = 'Y'
  select @four_w=count(*)
    from #addr_occ_freq where
    sf_days_week = 4 and
    region_id = @reg_id and
    occupied = 'Y'
  select @five_w=count(*)
    from #addr_occ_freq where
    sf_days_week = 5 and
    region_id = @reg_id and
    occupied = 'Y'
  select @six_w=count(*)
    from #addr_occ_freq where
    sf_days_week = 6 and
    region_id = @reg_id and
    occupied = 'Y'
  select @total_w=count(*)
    from #addr_occ_freq where
    region_id = @reg_id and
    occupied = 'Y'
  ----------------------------------------------------------------
  -- national
  -- do the same for the national
  select @one_nat=count(*)
    from #addr_occ_freq where
    sf_days_week = 1 and
    occupied = 'Y'
  select @two_nat=count(*)
    from #addr_occ_freq where
    sf_days_week = 2 and
    occupied = 'Y'
  select @three_nat=count(*)
    from #addr_occ_freq where
    sf_days_week = 3 and
    occupied = 'Y'
  select @four_nat=count(*)
    from #addr_occ_freq where
    sf_days_week = 4 and
    occupied = 'Y'
  select @five_nat=count(*)
    from #addr_occ_freq where
    sf_days_week = 5 and
    occupied = 'Y'
  select @six_nat=count(*)
    from #addr_occ_freq where
    sf_days_week = 6 and
    occupied = 'Y'
  select @total_nat=count(*)
    from #addr_occ_freq where
    occupied = 'Y'
  ----------------------------------------------------------------
  -- get latest private bag counts
  -- TJB SR4601 - Add region condition to date selection to get all Pvt Bags
  --              accross all regions.
  select @pvt_one=sum(pvt_bag_count)
    from private_bags as pb1 where
    pvt_frequency = 1 and
    pvt_date = (select max(pvt_date) from private_bags as pb2 where
      pb2.pvt_frequency = pb1.pvt_frequency and
      pb2.region_id = pb1.region_id)
  -- select max(pvt_bag_count)
  -- into pvt_one
  -- from private_bags
  -- where pvt_frequency = 1
  -- and pvt_date = (select max(pvt_date) from private_bags
  --                  where pvt_frequency = 1);
  select @pvt_two=sum(pvt_bag_count)
    from private_bags as pb1 where
    pvt_frequency = 2 and
    pvt_date = (select max(pvt_date) from private_bags as pb2 where
      pb2.pvt_frequency = pb1.pvt_frequency and
      pb2.region_id = pb1.region_id)
  select @pvt_three=sum(pvt_bag_count)
    from private_bags as pb1 where
    pvt_frequency = 3 and
    pvt_date = (select max(pvt_date) from private_bags as pb2 where
      pb2.pvt_frequency = pb1.pvt_frequency and
      pb2.region_id = pb1.region_id)
  select @pvt_four=sum(pvt_bag_count)
    from private_bags as pb1 where
    pvt_frequency = 4 and
    pvt_date = (select max(pvt_date) from private_bags as pb2 where
      pb2.pvt_frequency = pb1.pvt_frequency and
      pb2.region_id = pb1.region_id)
  select @pvt_five=sum(pvt_bag_count)
    from private_bags as pb1 where
    pvt_frequency = 5 and
    pvt_date = (select max(pvt_date) from private_bags as pb2 where
      pb2.pvt_frequency = pb1.pvt_frequency and
      pb2.region_id = pb1.region_id)
  select @pvt_six=sum(pvt_bag_count)
    from private_bags as pb1 where
    pvt_frequency = 6 and
    pvt_date = (select max(pvt_date) from private_bags as pb2 where
      pb2.pvt_frequency = pb1.pvt_frequency and
      pb2.region_id = pb1.region_id)
  -- return all the individual results
  select @one_nat,@two_nat,@three_nat,@four_nat,@five_nat,@six_nat,@total_nat,
    @one_ch,@two_ch,@three_ch,@four_ch,@five_ch,@six_ch,@total_ch,
    @one_dun,@two_dun,@three_dun,@four_dun,@five_dun,@six_dun,@total_dun,
    @one_ham,@two_ham,@three_ham,@four_ham,@five_ham,@six_ham,@total_ham,
    @one_p,@two_p,@three_p,@four_p,@five_p,@six_p,@total_p,
    @one_rot,@two_rot,@three_rot,@four_rot,@five_rot,@six_rot,@total_rot,
    @one_w,@two_w,@three_w,@four_w,@five_w,@six_w,@total_w,
    @pvt_one,@pvt_two,@pvt_three,@pvt_four,@pvt_five,@pvt_six
end