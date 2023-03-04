
--
-- Definition for stored procedure sp_v_exp_region : 
--

create procedure [rd].[sp_v_exp_region](@reg_id int)
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  declare @month_6 datetime,
  @count_final int
  -- table to hold end results and allow the filtering of results
  -- first create a temporary table for unique contract_vehicle
  -- temp table for max renewals
  create table #final_temp(
    reg_name char(40) null,
    expiry datetime null,
    con_num integer null,
    rego char(8) null,
    vmake char(20) null,
    vmodel char(20) null,
    vyear smallint null,
    vdesc char(30) null,
    vfuel char(35) null,
    ) 
create table #cv_temp(
    v_num integer null,
    c_num integer null,
    start_num integer null,
    seq_no integer null,
    dist_renew numeric(10,2) null,
    ) 
create table #cr_temp(
    c_num integer null,
    cd_num numeric(10,2) null,
    ) 
create table #con_temp(
    contract_no integer null,
    active_seq integer null,
    ) 
create table #veh_min_temp(
    contract_no integer null,
    veh_seq integer null,
    )
insert into #con_temp(contract_no,active_seq)
select distinct(con.contract_no),con.con_active_sequence 
from
  contract_renewals as cr join contract as con
on cr.contract_no = con.contract_no
join outlet as outl
on(con.con_lodgement_office = outl.outlet_id),
types_for_contract as tfc
 where
      (@reg_id is null or @reg_id = 0 or outl.region_id = @reg_id) and
      con.contract_no = tfc.contract_no and
      con.con_base_cont_type = 1 and
      tfc.ct_key = 1 and
      cr.con_expiry_date > rd.today()
  insert into #veh_min_temp(contract_no,
    veh_seq)
    select cv.contract_no,min(contract_seq_number) from
      contract_vehical as cv,#con_temp as con where
      cv.contract_no = con.contract_no and
      cv.vehicle_number = rd.f_GetLatestConVehicle(cv.contract_no)
      group by cv.contract_no
  insert into #cv_temp(v_num,
    c_num,start_num,dist_renew)
    select distinct(cv.vehicle_number),cv.contract_no,min(cv.start_kms),max(cr.con_distance_at_renewal) from
      contract_vehical as cv,contract_renewals as cr,#con_temp as con,#veh_min_temp as vmt where
      con.contract_no = vmt.contract_no and
      cv.contract_no = con.contract_no and
      cv.contract_no = cr.contract_no and
      cv.contract_seq_number = vmt.veh_seq and
      cv.vehicle_number = rd.f_GetLatestConVehicle(cv.contract_no) and
      cr.contract_seq_number = vmt.veh_seq
      group by cv.vehicle_number,cv.contract_no,cv.start_kms,cr.con_distance_at_renewal
  -- set any milages over 200000 to limit of 200000
  update #cv_temp set
    start_num = 200000 where
    start_num > 200000
  insert into #final_temp(expiry,
    con_num,rego,vmake,vmodel,vyear,vdesc,vfuel,reg_name)
    select distinct  expiry=(
case when cv.start_num > 5000 and cv.start_num is not null then
 rd.date(dateadd(day,(((200000-cv.start_num)/cv.dist_renew)*365),v.v_purchased_date))
else 
rd.date(dateadd(day,((200000/cv.dist_renew)*365),v.v_purchased_date))end),
      con.contract_no,v.v_vehicle_registration_number,
      v.v_vehicle_make,v.v_vehicle_model,v.v_vehicle_year,vs.vs_description,ft.ft_description,reg.rgn_name 
from
      vehicle as v left outer join fuel_type as ft on v.ft_key = ft.ft_key,
      #con_temp as con,vehicle_style as vs,#cv_temp as cv,
      contract as cont join outlet as outl on cont.con_base_office = outl.outlet_id
      join region as reg  on outl.region_id = reg.region_id
where
      cv.c_num = con.contract_no and
      v.vehicle_number = cv.v_num and
      v.v_purchased_date is not null and
      vs.vs_key = v.vs_key and
      v.vs_key not in(3,8,12,16,15) and
      cont.contract_no = con.contract_no order by
      expiry asc
  -- get the date 6 months ago
  select @month_6=dateadd(month,6,rd.today())
  -- get rid of entries where the expiry is more than 6 months in the future
  delete from #final_temp where
    expiry > @month_6
  -- get count of final_temp
  select @count_final=count(*) 
    from #final_temp
  if @count_final = 0
    insert into #final_temp(reg_name,
      vmodel)
      select rgn_name,'0 Vehicles' from
        region where
        region_id = @reg_id
  select max(expiry),con_num,rego,vmake,vmodel,vyear,vdesc,vfuel,reg_name,@month_6 from
    #final_temp
    group by reg_name,con_num,rego,vmake,vmodel,vyear,vdesc,vfuel order by
    reg_name asc,max(expiry) asc,con_num asc,rego asc
end