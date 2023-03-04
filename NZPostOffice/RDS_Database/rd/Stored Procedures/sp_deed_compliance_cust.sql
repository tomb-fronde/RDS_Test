
--
-- Definition for stored procedure sp_deed_compliance_cust : 
--

create procedure [rd].[sp_deed_compliance_cust]
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  -- the table to hold address id''s and their standard frequencies
create table #cust_freq(
    cust_id integer null,
    sf_days_week integer null,
    region_id integer null,
    )
  declare
  @reg_id integer,
  -- private bag counts
  @pvt_one integer,
  @pvt_two integer,
  @pvt_three integer,
  @pvt_four integer,
  @pvt_five integer,
  @pvt_six integer,
  -- count figures national
  @one_nat integer,
  @two_nat integer,
  @three_nat integer,
  @four_nat integer,
  @five_nat integer,
  @six_nat integer,
  @total_nat integer,
  -- Christchurch
  @one_ch integer,
  @two_ch integer,
  @three_ch integer,
  @four_ch integer,
  @five_ch integer,
  @six_ch integer,
  @total_ch integer,
  -- Dunedin
  @one_dun integer,
  @two_dun integer,
  @three_dun integer,
  @four_dun integer,
  @five_dun integer,
  @six_dun integer,
  @total_dun integer,
  -- Hamilton
  @one_ham integer,
  @two_ham integer,
  @three_ham integer,
  @four_ham integer,
  @five_ham integer,
  @six_ham integer,
  @total_ham integer,
  -- Palmerston North
  @one_p integer,
  @two_p integer,
  @three_p integer,
  @four_p integer,
  @five_p integer,
  @six_p integer,
  @total_p integer,
  -- Rotorua
  @one_rot integer,
  @two_rot integer,
  @three_rot integer,
  @four_rot integer,
  @five_rot integer,
  @six_rot integer,
  @total_rot integer,
  -- Whangarei
  @one_w integer,
  @two_w integer,
  @three_w integer,
  @four_w integer,
  @five_w integer,
  @six_w integer,
  @total_w integer
  ------------------------------------------------------------------------
  insert into #cust_freq(sf_days_week,
    cust_id,region_id)
    select sum(sf.sf_days_week),cust.cust_id,tc.region_id from
      rds_customer as cust join customer_address_moves as cam on cust.cust_id = cam.cust_id 
      join address as addr on addr.adr_id = cam.adr_id
      join address_frequency_sequence on address_frequency_sequence.adr_id = addr.adr_id 
      join route_frequency on route_frequency.contract_no = addr.contract_no  
      join standard_frequency as sf on sf.sf_key =route_frequency.sf_key  ,towncity as tc
      where
      cust.master_cust_id is null and
      cam.move_out_date is null and
      addr.tc_id = tc.tc_id
      group by cust.cust_id,tc.region_id
  -- change so that max is 6
  update #cust_freq set
    sf_days_week = 6 where
    sf_days_week > 6
  ------------------------------------------------------------------------
  -----------------------------------------------------------------
  -- Christchurch
  select @reg_id=6
  select @one_ch = count(*)
    from #cust_freq where
    sf_days_week = 1 and
    region_id = @reg_id
  select @two_ch = count(*)
    from #cust_freq where
    sf_days_week = 2 and
    region_id = @reg_id
  select @three_ch = count(*)
    from #cust_freq where
    sf_days_week = 3 and
    region_id = @reg_id
  select @four_ch = count(*)
    from #cust_freq where
    sf_days_week = 4 and
    region_id = @reg_id
  select @five_ch = count(*)
    from #cust_freq where
    sf_days_week = 5 and
    region_id = @reg_id
  select @six_ch = count(*)
    from #cust_freq where
    sf_days_week = 6 and
    region_id = @reg_id
  select @total_ch = count(*)
    from #cust_freq where
    region_id = @reg_id
  ----------------------------------------------------------------
  -- Dunedin
  select @reg_id=7
  select @one_dun = count(*) 
    from #cust_freq where
    sf_days_week = 1 and
    region_id = @reg_id
  select @two_dun = count(*)
    from #cust_freq where
    sf_days_week = 2 and
    region_id = @reg_id
  select @three_dun = count(*)
    from #cust_freq where
    sf_days_week = 3 and
    region_id = @reg_id
  select @four_dun = count(*)
    from #cust_freq where
    sf_days_week = 4 and
    region_id = @reg_id
  select @five_dun = count(*)
    from #cust_freq where
    sf_days_week = 5 and
    region_id = @reg_id
  select @six_dun = count(*)
    from #cust_freq where
    sf_days_week = 6 and
    region_id = @reg_id
  select @total_dun = count(*)
    from #cust_freq where
    region_id = @reg_id
  ----------------------------------------------------------------
  -- Hamilton
  select @reg_id=2
  select @one_ham = count(*)
    from #cust_freq where
    sf_days_week = 1 and
    region_id = @reg_id
  select @two_ham = count(*)
    from #cust_freq where
    sf_days_week = 2 and
    region_id = @reg_id
  select @three_ham = count(*)
    from #cust_freq where
    sf_days_week = 3 and
    region_id = @reg_id
  select @four_ham = count(*)
    from #cust_freq where
    sf_days_week = 4 and
    region_id = @reg_id
  select @five_ham = count(*)
    from #cust_freq where
    sf_days_week = 5 and
    region_id = @reg_id
  select @six_ham = count(*) 
    from #cust_freq where
    sf_days_week = 6 and
    region_id = @reg_id
  select @total_ham = count(*) 
    from #cust_freq where
    region_id = @reg_id
  ----------------------------------------------------------------
  -- Palmerston North
  select @reg_id=4
  select @one_p = count(*) 
    from #cust_freq where
    sf_days_week = 1 and
    region_id = @reg_id
  select @two_p = count(*) 
    from #cust_freq where
    sf_days_week = 2 and
    region_id = @reg_id
  select @three_p = count(*) 
    from #cust_freq where
    sf_days_week = 3 and
    region_id = @reg_id
  select @four_p = count(*) 
    from #cust_freq where
    sf_days_week = 4 and
    region_id = @reg_id
  select @five_p = count(*) 
    from #cust_freq where
    sf_days_week = 5 and
    region_id = @reg_id
  select @six_p = count(*) 
    from #cust_freq where
    sf_days_week = 6 and
    region_id = @reg_id
  select @total_p = count(*) 
    from #cust_freq where
    region_id = @reg_id
  ----------------------------------------------------------------
  -- Rotorua
  select @reg_id=3
  select @one_rot = count(*) 
    from #cust_freq where
    sf_days_week = 1 and
    region_id = @reg_id
  select @two_rot = count(*)
    from #cust_freq where
    sf_days_week = 2 and
    region_id = @reg_id
  select @three_rot = count(*) 
    from #cust_freq where
    sf_days_week = 3 and
    region_id = @reg_id
  select @four_rot = count(*) 
    from #cust_freq where
    sf_days_week = 4 and
    region_id = @reg_id
  select @five_rot = count(*) 
    from #cust_freq where
    sf_days_week = 5 and
    region_id = @reg_id
  select @six_rot = count(*) 
    from #cust_freq where
    sf_days_week = 6 and
    region_id = @reg_id
  select @total_rot = count(*) 
    from #cust_freq where
    region_id = @reg_id
  ----------------------------------------------------------------
  -- Whangarei
  select @reg_id=1
  select @one_w = count(*) 
    from #cust_freq where
    sf_days_week = 1 and
    region_id = @reg_id
  select @two_w = count(*) 
    from #cust_freq where
    sf_days_week = 2 and
    region_id = @reg_id
  select @three_w = count(*) 
    from #cust_freq where
    sf_days_week = 3 and
    region_id = @reg_id
  select @four_w = count(*) 
    from #cust_freq where
    sf_days_week = 4 and
    region_id = @reg_id
  select @five_w = count(*) 
    from #cust_freq where
    sf_days_week = 5 and
    region_id = @reg_id
  select @six_w = count(*) 
    from #cust_freq where
    sf_days_week = 6 and
    region_id = @reg_id
  select @total_w = count(*) 
    from #cust_freq where
    region_id = @reg_id
  ----------------------------------------------------------------
  -- national
  -- do the same for the national
  select @one_nat = count(*) 
    from #cust_freq where
    sf_days_week = 1
  select @two_nat = count(*) 
    from #cust_freq where
    sf_days_week = 2
  select @three_nat = count(*) 
    from #cust_freq where
    sf_days_week = 3
  select @four_nat = count(*) 
    from #cust_freq where
    sf_days_week = 4
  select @five_nat = count(*) 
    from #cust_freq where
    sf_days_week = 5
  select @six_nat = count(*) 
    from #cust_freq where
    sf_days_week = 6
  select @total_nat = count(*) 
    from #cust_freq
  ----------------------------------------------------------------
  -- get latest private bag counts
  -- TJB SR4601 - Add region condition to date selection to get all
  --              Pvt Bags accross all regions.
  select @pvt_one = sum(pvt_bag_count) 
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
  select @pvt_two = sum(pvt_bag_count) 
    from private_bags as pb1 where
    pvt_frequency = 2 and
    pvt_date = (select max(pvt_date) from private_bags as pb2 where
      pb2.pvt_frequency = pb1.pvt_frequency and
      pb2.region_id = pb1.region_id)
  select @pvt_three = sum(pvt_bag_count) 
    from private_bags as pb1 where
    pvt_frequency = 3 and
    pvt_date = (select max(pvt_date) from private_bags as pb2 where
      pb2.pvt_frequency = pb1.pvt_frequency and
      pb2.region_id = pb1.region_id)
  select @pvt_four = sum(pvt_bag_count) 
    from private_bags as pb1 where
    pvt_frequency = 4 and
    pvt_date = (select max(pvt_date) from private_bags as pb2 where
      pb2.pvt_frequency = pb1.pvt_frequency and
      pb2.region_id = pb1.region_id)
  select @pvt_five = sum(pvt_bag_count) 
    from private_bags as pb1 where
    pvt_frequency = 5 and
    pvt_date = (select max(pvt_date) from private_bags as pb2 where
      pb2.pvt_frequency = pb1.pvt_frequency and
      pb2.region_id = pb1.region_id)
  select @pvt_six = sum(pvt_bag_count) 
    from private_bags as pb1 where
    pvt_frequency = 6 and
    pvt_date = (select max(pvt_date) from private_bags as pb2 where
      pb2.pvt_frequency = pb1.pvt_frequency and
      pb2.region_id = pb1.region_id)
  -- return all the individual results
  select @one_nat,@two_nat,@three_nat,@four_nat,@five_nat,@six_nat,@total_nat,@one_ch,@two_ch,@three_ch,@four_ch,@five_ch,@six_ch,@total_ch,
    @one_dun,@two_dun,@three_dun,@four_dun,@five_dun,@six_dun,@total_dun,@one_ham,@two_ham,@three_ham,@four_ham,@five_ham,@six_ham,@total_ham,
    @one_p,@two_p,@three_p,@four_p,@five_p,@six_p,@total_p,@one_rot,@two_rot,@three_rot,@four_rot,@five_rot,@six_rot,@total_rot,
    @one_w,@two_w,@three_w,@four_w,@five_w,@six_w,@total_w,@pvt_one,@pvt_two,@pvt_three,@pvt_four,@pvt_five,@pvt_six
end