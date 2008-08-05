/****** Object:  StoredProcedure [rd].[sp_deed_compliance_addr]    Script Date: 08/05/2008 10:18:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [rd].[sp_deed_compliance_addr]
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  -- the table to hold address id''s and their standard frequencies
create table #addr_freq(
    adr_id integer null,
    sf_days_week integer null,
    region_id integer null,
    ) 
  declare
  @reg_id int,
  -- private bag counts
  @pvt_one int,
  @pvt_two int,
  @pvt_three int,
  @pvt_four int,
  @pvt_five int,
  @pvt_six int,
  -- count figures national
  @one_nat int,
  @two_nat int,
  @three_nat int,
  @four_nat int,
  @five_nat int,
  @six_nat int,
  @total_nat int,
  -- Christchurch
  @one_ch int,
  @two_ch int,
  @three_ch int,
  @four_ch int,
  @five_ch int,
  @six_ch int,
  @total_ch int,
  -- Dunedin
  @one_dun int,
  @two_dun int,
  @three_dun int,
  @four_dun int,
  @five_dun int,
  @six_dun int,
  @total_dun int,
  -- Hamilton
  @one_ham int,
  @two_ham int,
  @three_ham int,
  @four_ham int,
  @five_ham int,
  @six_ham int,
  @total_ham int,
  -- Palmerston North
  @one_p int,
  @two_p int,
  @three_p int,
  @four_p int,
  @five_p int,
  @six_p int,
  @total_p int,
  -- Rotorua
  @one_rot int,
  @two_rot int,
  @three_rot int,
  @four_rot int,
  @five_rot int,
  @six_rot int,
  @total_rot int,
  -- Whangarei
  @one_w int,
  @two_w int,
  @three_w int,
  @four_w int,
  @five_w int,
  @six_w int,
  @total_w int
  insert into #addr_freq(sf_days_week,
    adr_id,region_id)
    select sum(sf.sf_days_week),addr.adr_id,tc.region_id from
      towncity as tc join address as addr on tc.tc_id = addr.tc_id 
      join address_frequency_sequence on addr.adr_id =address_frequency_sequence.adr_id  
      join route_frequency on addr.contract_no = route_frequency.contract_no 
      join standard_frequency as sf on sf.sf_key = route_frequency.sf_key
      group by addr.adr_id, tc.region_id
  -- change so that max is 6
  update #addr_freq set
    sf_days_week = 6 where
    sf_days_week > 6
  -----------------------------------------------------------------
  -- Christchurch
  select @reg_id=6
  select @one_ch = count(*) 
    from #addr_freq where
    sf_days_week = 1 and
    region_id = @reg_id
  select @two_ch = count(*)
    from #addr_freq where
    sf_days_week = 2 and
    region_id = @reg_id
  select @three_ch = count(*)
    from #addr_freq where
    sf_days_week = 3 and
    region_id = @reg_id
  select @four_ch = count(*)
    from #addr_freq where
    sf_days_week = 4 and
    region_id = @reg_id
  select @five_ch = count(*) 
    from #addr_freq where
    sf_days_week = 5 and
    region_id = @reg_id
  select @six_ch = count(*)
    from #addr_freq where
    sf_days_week = 6 and
    region_id = @reg_id
  select @total_ch = count(*)
    from #addr_freq where
    region_id = @reg_id
  ----------------------------------------------------------------
  -- Dunedin
  select @reg_id=7
  select @one_dun = count(*)
    from #addr_freq where
    sf_days_week = 1 and
    region_id = @reg_id
  select @two_dun = count(*)
    from #addr_freq where
    sf_days_week = 2 and
    region_id = @reg_id
  select @three_dun = count(*)
    from #addr_freq where
    sf_days_week = 3 and
    region_id = @reg_id
  select @four_dun = count(*)
    from #addr_freq where
    sf_days_week = 4 and
    region_id = @reg_id
  select @five_dun = count(*)
    from #addr_freq where
    sf_days_week = 5 and
    region_id = @reg_id
  select @six_dun = count(*) 
    from #addr_freq where
    sf_days_week = 6 and
    region_id = @reg_id
  select @total_dun = count(*)
    from #addr_freq where
    region_id = @reg_id
  ----------------------------------------------------------------
  -- Hamilton
  select @reg_id=2
  select @one_ham = count(*)
    from #addr_freq where
    sf_days_week = 1 and
    region_id = @reg_id
  select @two_ham = count(*) 
    from #addr_freq where
    sf_days_week = 2 and
    region_id = @reg_id
  select @three_ham = count(*)
    from #addr_freq where
    sf_days_week = 3 and
    region_id = @reg_id
  select @four_ham = count(*)
    from #addr_freq where
    sf_days_week = 4 and
    region_id = @reg_id
  select @five_ham = count(*)
    from #addr_freq where
    sf_days_week = 5 and
    region_id = @reg_id
  select @six_ham = count(*)
    from #addr_freq where
    sf_days_week = 6 and
    region_id = @reg_id
  select @total_ham = count(*)
    from #addr_freq where
    region_id = @reg_id
  ----------------------------------------------------------------
  -- Palmerston North
  select @reg_id=4
  select @one_p = count(*)
    from #addr_freq where
    sf_days_week = 1 and
    region_id = @reg_id
  select @two_p = count(*)
    from #addr_freq where
    sf_days_week = 2 and
    region_id = @reg_id
  select @three_p = count(*)
    from #addr_freq where
    sf_days_week = 3 and
    region_id = @reg_id
  select @four_p = count(*)
    from #addr_freq where
    sf_days_week = 4 and
    region_id = @reg_id
  select @five_p = count(*)
    from #addr_freq where
    sf_days_week = 5 and
    region_id = @reg_id
  select @six_p = count(*)
    from #addr_freq where
    sf_days_week = 6 and
    region_id = @reg_id
  select @total_p = count(*)
    from #addr_freq where
    region_id = @reg_id
  ----------------------------------------------------------------
  -- Rotorua
  select @reg_id=3
  select @one_rot = count(*)
    from #addr_freq where
    sf_days_week = 1 and
    region_id = @reg_id
  select @two_rot = count(*)
    from #addr_freq where
    sf_days_week = 2 and
    region_id = @reg_id
  select @three_rot = count(*) 
    from #addr_freq where
    sf_days_week = 3 and
    region_id = @reg_id
  select @four_rot = count(*)
    from #addr_freq where
    sf_days_week = 4 and
    region_id = @reg_id
  select @five_rot = count(*) 
    from #addr_freq where
    sf_days_week = 5 and
    region_id = @reg_id
  select @six_rot = count(*)
    from #addr_freq where
    sf_days_week = 6 and
    region_id = @reg_id
  select @total_rot = count(*) 
    from #addr_freq where
    region_id = @reg_id
  ----------------------------------------------------------------
  -- Whangarei
  select @reg_id=1
  select @one_w = count(*)
    from #addr_freq where
    sf_days_week = 1 and
    region_id = @reg_id
  select @two_w = count(*)
    from #addr_freq where
    sf_days_week = 2 and
    region_id = @reg_id
  select @three_w = count(*) 
    from #addr_freq where
    sf_days_week = 3 and
    region_id = @reg_id
  select @four_w = count(*)
    from #addr_freq where
    sf_days_week = 4 and
    region_id = @reg_id
  select @five_w = count(*)
    from #addr_freq where
    sf_days_week = 5 and
    region_id = @reg_id
  select @six_w = count(*)
    from #addr_freq where
    sf_days_week = 6 and
    region_id = @reg_id
  select @total_w = count(*)
    from #addr_freq where
    region_id = @reg_id
  ----------------------------------------------------------------
  -- national
  -- do the same for the national
  select @one_nat = count(*) 
    from #addr_freq where
    sf_days_week = 1
  select @two_nat = count(*) 
    from #addr_freq where
    sf_days_week = 2
  select @three_nat = count(*) 
    from #addr_freq where
    sf_days_week = 3
  select @four_nat = count(*)
    from #addr_freq where
    sf_days_week = 4
  select @five_nat = count(*) 
    from #addr_freq where
    sf_days_week = 5
  select @six_nat = count(*)
    from #addr_freq where
    sf_days_week = 6
  select @total_nat = count(*)
    from #addr_freq
  ----------------------------------------------------------------
  -- get latest private bag counts
  -- TJB SR4601 - Add region condition to date selection to get all Pvt Bags
  --              accross all regions.
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
GO
