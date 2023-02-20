/****** Object:  StoredProcedure [rd].[anzac_fix]    Script Date: 08/05/2008 10:16:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



--
-- Definition for view v_Customers : 
--

--
-- Definition for stored procedure anzac_fix : 
--

create procedure -- Tim Chan
-- Initial version : 21/11/2003
-- This function update the rate_days of contracts and create the corresponding frequency adjustment
-- according to the benchmark change amount
[rd].[anzac_fix](@days_to_makeup real,@in_rg_code int)

AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  declare @return_val integer
  declare @latest_rate_date datetime
  declare @effective_date datetime
  declare @sf_key1 int
  declare @sf_key2 int
  declare @old_rate_days real
  declare @multiplier real
  -- temp table for holding contract numbers seq and distances etc before any changes
  -- temp table for holding max unique seq numbers for entry into the frequency_adjustments table
  create table #con_temp (
    contract_no int null,
    contract_seq int null,
    old_benchmark int null,
    new_benchmark int null,
    "difference" int null,
    )

    create table #uniq_temp(
    contract_no int null,
    max_unique_seq int null,
    )
  -- kill this function if the date is not within 2003 (this function expires at the end of 2003)
  if datepart(year,getdate()) <> 2003
    return-1
  -- set the effective_date
  if @in_rg_code = 2
    select @effective_date='2003-08-01' else
  if @in_rg_code = 3
    select @effective_date='2003-11-01'
  select @sf_key1=1
  select @sf_key2=8
  insert into #con_temp 
    select con.contract_no,con.con_active_sequence,rd.BenchmarkCalc2001(con.contract_no,con.con_active_sequence),0,0 from 
      "contract" as con join route_frequency as rf on con.contract_no=rf.contract_no where
      con.con_date_terminated is null and
      con.rg_code = @in_rg_code and
      rf.rf_active = 'Y' and
      rf.rf_distance > 0 and
      rf.sf_key in(1,8)
      group by con.contract_no,con.con_active_sequence
  insert into uniq_temp
    select fa.contract_no,max(fd_unique_seq_number)+1 from
      con_temp as ct,frequency_adjustments as fa where
      ct.contract_no = fa.contract_no and
      ct.contract_seq = fa.contract_seq_number
      group by fa.contract_no
  -- set the unique seq as 1 if was not in uniq_temp already
  insert into uniq_temp
    select ct.contract_no,1 from
      con_temp as ct where
      not ct.contract_no = any(select contract_no from uniq_temp)
  select @latest_rate_date=max(rr_rates_effective_date) 
    from rate_days where
    rg_code = @in_rg_code and
    sf_key = @sf_key1
  -- save the old rate days count
  select @old_rate_days=max(rtd_days_per_annum) 
    from rate_days where
    rg_code = @in_rg_code and
    sf_key = @sf_key1 and
    rr_rates_effective_date = @latest_rate_date
  -- do update of rate_days
  update rate_days set
    rtd_days_per_annum = rtd_days_per_annum+@days_to_makeup where
    rg_code = @in_rg_code and
    sf_key = @sf_key1 and
    rr_rates_effective_date = @latest_rate_date
  -- do it all again if sf_key2 is non - zero
  if @sf_key2 > 0
    begin
      select @latest_rate_date=max(rr_rates_effective_date) 
        from rate_days where
        rg_code = @in_rg_code and
        sf_key = @sf_key2
      -- do update of rate_days
      update rate_days set
        rtd_days_per_annum = rtd_days_per_annum+@days_to_makeup where
        rg_code = @in_rg_code and
        sf_key = @sf_key2 and
        rr_rates_effective_date = @latest_rate_date
    end
  select @multiplier=(@days_to_makeup+@old_rate_days)/@old_rate_days
  -- update the contract renewals - renewal distances
  update contract_renewals set
    con_distance_at_renewal = round((con_distance_at_renewal*@multiplier)+.49,0) where
    contract_no = any(select con_temp.contract_no from con_temp) and
    contract_seq_number = any(select contract.con_active_sequence from contract where contract.contract_no = contract_renewals.contract_no)
  -- figure out benchmark change
  update con_temp set
    new_benchmark = rd.BenchmarkCalc2001(contract_no,contract_seq)
  update con_temp set
    difference = new_benchmark-old_benchmark
  -- for each row where there is a difference - create an adjustment
  insert into frequency_adjustments
    --(contract_no, contract_seq_number, fd_unique_seq_number, fd_adjustment_amount, fd_paid_to_date, fd_bm_after_extn,
    --fd_confirmed, fd_amount_to_pay, fd_effective_date)
    --values
    select ct.contract_no,ct.contract_seq,ut.max_unique_seq,ct.difference,null,ct.new_benchmark,'Y',
      ct.difference,@effective_date,null from
      con_temp as ct,uniq_temp as ut where
      ct.difference <> 0 and
      ct.contract_no = ut.contract_no
  return 1
end
GO
