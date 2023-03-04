
CREATE procedure [rd].[sp_GetContractDailyArticalCounts](
    @in_Contract int,
    @in_Period datetime)
AS
BEGIN
  -- TJB  RPCR_093  May-2015
  -- Bug fix: Change returned values from null to 0
  --
  -- TJB  RPCR_093  Feb-2015: New
  -- Get daily article counts for a specific contract for data entry
  -- Returns dummy, empty records where no data is held
  -- See sp_GetRegionArticalCounts and WAddArticalCounts

  set CONCAT_NULL_YIELDS_NULL off
  select acd.contract_no,
         acd.ac_start_week_period,
         acd.acd_week_no,
         acd.act_key,
         act.act_description,
         acd_mon_count,
         acd_tue_count,
         acd_wed_count,
         acd_thu_count,
         acd_fri_count,
         acd_sat_count,
         'U'
    from contract c
                left outer join artical_count_daily acd 
                     on acd.contract_no=c.contract_no 
                left outer join artical_count_type act
                     on acd.act_key = act.act_key
   where c.contract_no = @in_Contract 
     and (c.con_date_terminated is null or c.con_date_terminated > @in_Period) 
     and acd.ac_start_week_period = @in_Period 
     and acd.acd_week_no = 1
 union 
  select c.contract_no,
         @in_Period as ac_start_week_period,
         1 as acd_week_no,
         act.act_key,
         act.act_description,
         0 as acd_mon_count,
         0 as acd_tue_count,
         0 as acd_wed_count,
         0 as acd_thu_count,
         0 as acd_fri_count,
         0 as acd_sat_count,
         'A' 
    from contract c 
       , artical_count_type act
   where c.contract_no = @in_Contract 
     and (c.con_date_terminated is null or c.con_date_terminated > @in_Period) 
     and act.act_key not in 
	          (select act2.act_key
			     from artical_count_type act2
			                  left outer join artical_count_daily acd2  
			                       on act2.act_key = acd2.act_key
               where acd2.contract_no = c.contract_no
                 and acd2.ac_start_week_period = @in_period
                 and acd2.acd_week_no = 1)
union
  select acd.contract_no,
         acd.ac_start_week_period,
         acd.acd_week_no,
         acd.act_key,
         act.act_description,
         acd_mon_count,
         acd_tue_count,
         acd_wed_count,
         acd_thu_count,
         acd_fri_count,
         acd_sat_count,
         'U'
    from contract c
                left outer join artical_count_daily acd 
                     on acd.contract_no=c.contract_no 
                left outer join artical_count_type act
                     on acd.act_key = act.act_key
   where c.contract_no = @in_Contract 
     and (c.con_date_terminated is null or c.con_date_terminated > @in_Period) 
     and acd.ac_start_week_period = @in_Period 
     and acd.acd_week_no = 2
 union 
  select c.contract_no,
         @in_Period as ac_start_week_period,
         2 as acd_week_no,
         act.act_key,
         act.act_description,
         0 as acd_mon_count,
         0 as acd_tue_count,
         0 as acd_wed_count,
         0 as acd_thu_count,
         0 as acd_fri_count,
         0 as acd_sat_count,
         'A' 
    from contract c 
       , artical_count_type act
   where c.contract_no = @in_Contract 
     and (c.con_date_terminated is null or c.con_date_terminated > @in_Period) 
     and act.act_key not in 
	          (select act2.act_key
			     from artical_count_type act2
			                  left outer join artical_count_daily acd2  
			                       on act2.act_key = acd2.act_key
               where acd2.contract_no = c.contract_no
                 and acd2.ac_start_week_period = @in_period
                 and acd2.acd_week_no = 2)
end