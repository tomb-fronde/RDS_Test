
--
-- Definition for stored procedure v_expPercent : 
--
create function  [rd].[v_expPercent](@inRegion int,@inOutlet int,@inRenGroup int,@inContractType int)
returns real
as -- TJB  SR4658  9-Apr-2005 Bug fix
begin 

  declare @i_exp_num real,
  @i_total real,
  @d_percentage real,
  @month_6 datetime,
  @count_final int
  -- table to hold end results and allow the filtering of results
  declare  @final_temp table(
    reg_name char(40) null,
    expiry datetime null,
    con_num int null,
    rego char(8) null,
    vmake char(20) null,
    vmodel char(20) null,
    vyear smallint null
    ) 
declare  @cv_temp table(
    v_num int null,
    c_num int null,
    start_num int null,
    seq_no int null,
    dist_renew numeric(10,2) null
    ) 
declare  @cr_temp table(
    c_num int null,
    cd_num numeric(10,2) null
    ) 
declare  @con_temp table(
    contract_no int null,
    active_seq int null
    )
-- MRB 12/3/2007 - added in active_seq to returned list
  insert into @con_temp(contract_no,active_seq)
    select distinct(con.contract_no),con.con_active_sequence from
      towncity as tc join address as addr on tc.tc_id = addr.tc_id join contract as con on addr.contract_no = con.contract_no join contract_renewals as cr on con.contract_no = cr.contract_no where
      (@inRegion = 0 or @inRegion is null or tc.region_id = @inRegion) and
      (@inOutlet = 0 or @inOutlet is null or con.con_lodgement_office = @inOutlet) and
      (@inContractType = 0 or @inContractType is null or con.con_base_cont_type = @inContractType) and
      (@inRenGroup = 0 or @inRenGroup is null or con.rg_code = @inRenGroup) and
      cr.con_expiry_date > rd.today()
  -- populate the contract_vehicle temp with the lastest vehicles 
  -- where vehicle newer than contract start date
  insert into @cv_temp(v_num,c_num,start_num,seq_no,dist_renew)
    select distinct(cv.vehicle_number),
      cv.contract_no,
      max(cv.start_kms),
      max(cv.contract_seq_number),
      max(cr.con_distance_at_renewal) from
      contract_vehical as cv join vehicle as veh on cv.vehicle_number = veh.vehicle_number,
      @con_temp as temp,
      contract_renewals as cr where
      cv.contract_no = temp.contract_no and
      -- TJB  SR4658  9-Apr-2005
      -- Bug fix: removed following line.
      -- con_temp.active_seq is never populated so this condition is never true!
      -- MRB 12/3/2007 - added line back in as list was not returning the correct vehicle details
      -- and commented out filter for null start_kms as this was excluding valid vehicles.
      cv.contract_seq_number = temp.active_seq and
      --       and cv.start_kms is not null
      cr.contract_no = cv.contract_no and
      cr.contract_seq_number = cv.contract_seq_number and
      cr.con_distance_at_renewal is not null and
      veh.v_purchased_date >= cr.con_start_date and
      veh.v_purchased_date = (select max(veh1.v_purchased_date) from
        contract_vehical as cv2 join vehicle as veh1 on cv2.vehicle_number = veh1.vehicle_number where
        cv2.contract_no = cv.contract_no
        group by cv2.contract_no)
      group by cv.contract_no,cv.vehicle_number,cv.start_kms,cv.contract_seq_number,cr.con_distance_at_renewal
  -- populate the contract_vehicle temp with latest vehicles - where vehicles older than contract start
  insert into @cv_temp(v_num,c_num,start_num,seq_no,dist_renew)
    select distinct(cv.vehicle_number),
      cv.contract_no,
      cv.start_kms,
      cv.contract_seq_number,
      cr.con_distance_at_renewal from
      contract_vehical as cv join vehicle as veh on cv.vehicle_number = veh.vehicle_number,
      @con_temp as temp,
      contract_renewals as cr where
      cv.contract_no = temp.contract_no and
      not cv.contract_no = any(select c_num from @cv_temp) and
      not cv.vehicle_number = any(select v_num from @cv_temp) and
/*!      cv.start_kms is not null and
      cv.start_kms = (select min(cv1.start_kms) from
        contract_vehical as cv1 where
        cv1.contract_no = cv.contract_no) and  */
      --MRB 12/3/2007 - remove start_kms filters as these were excluding valid vehicles
      --       and cv.start_kms is not null
      --       and cv.start_kms = (select min(cv1.start_kms) 
      --                             from contract_vehical cv1 
      --                            where cv1.contract_no = cv.contract_no)

      cr.contract_seq_number = cv.contract_seq_number and
      cv.contract_seq_number = temp.active_seq and
      cr.contract_no = cv.contract_no and
      cr.con_distance_at_renewal is not null and
      veh.v_purchased_date < cr.con_start_date and
      veh.v_purchased_date = (select max(veh1.v_purchased_date) from
        contract_vehical as cv2 join vehicle as veh1 on cv2.vehicle_number = veh1.vehicle_number where
        cv2.contract_no = cv.contract_no
        group by cv2.contract_no)
      group by cv.contract_no,cv.vehicle_number,cv.start_kms,cv.contract_seq_number,cr.con_distance_at_renewal
  -- set any milages over 200000 to limit of 200000
  update @cv_temp set
    start_num = 200000 where
    start_num > 200000
  -- set any null mileages to 0
  update @cv_temp set
    start_num = 0 where
    start_num is null;

  insert into @final_temp(expiry,con_num,rego,vmake,vmodel,vyear)
    select distinct expiry=(case when cv.start_num > 5000 and cv.start_num is not null then
        rd.date(dateadd(day,(((200000-cv.start_num)/cv.dist_renew)*365),v.v_purchased_date))
      else rd.date(dateadd(day,((200000/cv.dist_renew)*365),v.v_purchased_date))
      end),
      con.contract_no,
      v.v_vehicle_registration_number,
      v.v_vehicle_make,
      v.v_vehicle_model,
      v.v_vehicle_year from
      vehicle as v,
      @con_temp as con,
      @cv_temp as cv where
      -- cr.c_num = con.contract_no   
      cv.c_num = con.contract_no and
      v.vehicle_number = cv.v_num and
      v.v_purchased_date is not null and
      -- exclude styles : boat, bus, minibus, motorcycle, trucks
      v.vs_key not in(3,8,12,16,15)
  -- see how many are to expire before today
  select @i_exp_num = count(*) 
    from @final_temp as ft where
    ft.expiry > rd.today()
  -- get the total
  select @i_total = count(*)
    from @final_temp
  if @i_total <> 0
    begin
      select @d_percentage=(@i_exp_num/@i_total)*100
      select @d_percentage=round(@d_percentage,2)
    end
  else
    select @d_percentage=0
  return @d_percentage
end