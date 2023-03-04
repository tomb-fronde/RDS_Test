
create procedure [rd].[sp_GetRegionalDailyArticalCounts](
	@in_Region int,
	@in_RenewalGroup int,
	@in_Period datetime)
AS
BEGIN
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
    from artical_count_daily acd 
                join contract c
                     on acd.contract_no=c.contract_no 
                join outlet o
                     on c.con_lodgement_office=o.outlet_id   
                left outer join artical_count_type act
                     on acd.act_key = act.act_key
  where	o.region_id = @in_Region and
        c.rg_code   = @in_RenewalGroup and
        (c.con_date_terminated is null or c.con_date_terminated > @in_Period) and
        acd.ac_start_week_period = @in_Period 
  union
  select c.contract_no,
         @in_Period,
         1,
         act.act_key,
         act.act_description,
         0,
         0,
         0,
         0,
         0,
         0,
         'A' 
    from contract c 
             join outlet as o 
                  on c.con_lodgement_office=o.outlet_id,
         artical_count_type act 
         --artical_count_daily acd 
         --    left outer join artical_count_type act
         --         on acd.act_key = act.act_key
   where o.region_id = @in_Region and
         c.rg_code = @in_RenewalGroup and
         (c.con_date_terminated is null or c.con_date_terminated > @in_Period) and
         0 = (select count(*) from artical_count_daily acd2
               where acd2.contract_no = c.contract_no and
                     (c.con_date_terminated is null or c.con_date_terminated > @in_Period) and
                     acd2.ac_start_week_period = @in_Period)
  union
  select c.contract_no,
         @in_Period,
         2,
         act.act_key,
         act.act_description,
         0,
         0,
         0,
         0,
         0,
         0,
         'A' 
    from contract c 
             join outlet as o 
                  on c.con_lodgement_office=o.outlet_id,
         artical_count_type act 
         --artical_count_daily acd 
         --    left outer join artical_count_type act
         --         on acd.act_key = act.act_key
   where o.region_id = @in_Region and
         c.rg_code   = @in_RenewalGroup and
         (c.con_date_terminated is null or c.con_date_terminated > @in_Period) and
         0 = (select count(*) from artical_count_daily acd2
               where acd2.contract_no = c.contract_no and
                     (c.con_date_terminated is null or c.con_date_terminated > @in_Period) and
                     acd2.ac_start_week_period = @in_Period)
  order by
        contract_no asc,
        ac_start_week_period desc,
        acd_week_no asc,
        act_key asc

end