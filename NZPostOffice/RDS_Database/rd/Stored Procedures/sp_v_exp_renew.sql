create procedure [rd].[sp_v_exp_renew] @renew_id INT 

AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  
  -- table to hold end results and allow the filtering of results
  -- first create a temporary table for unique contract_vehicle
  -- temp table for max renewals
   declare @month_6 DATETIME
   declare @count_final INT
   --THE EVALUATION VERSION TRIMS COLUMN NAMES AND VARIABLES TO 7 CHARACTERS
--
CREATE TABLE #final_temp
   (
      reg_name CHAR(40)   null,
      expiry DATETIME   null,
      con_num INT   null,
      rego CHAR(8)   null,
      vmake CHAR(20)   null,
      vmodel CHAR(20)   null,
      vyear SMALLINT   null,
      vdesc CHAR(30)   null,
      vfuel CHAR(35)   null
   ) -- temp table for contract numbers
   --THE EVALUATION VERSION TRIMS COLUMN NAMES AND VARIABLES TO 7 CHARACTERS
--
CREATE TABLE #cv_temp
   (
      v_num INT   null,
      c_num INT   null,
      start_num INT   null,
      seq_no INT   null,
      dist_renew NUMERIC(10,2)   null
   ) -- temp table for the first seq number where this vehicle showed up
   --THE EVALUATION VERSION TRIMS COLUMN NAMES AND VARIABLES TO 7 CHARACTERS
--
CREATE TABLE #cr_temp
   (
      c_num INT   null,
      cd_num NUMERIC(10,2)   null
   )
   --THE EVALUATION VERSION TRIMS COLUMN NAMES AND VARIABLES TO 7 CHARACTERS
--
CREATE TABLE #con_temp
   (
      contract_no INT   null,
      active_seq INT   null
   )
   --THE EVALUATION VERSION TRIMS COLUMN NAMES AND VARIABLES TO 7 CHARACTERS
--
CREATE TABLE #veh_min_temp
   (
      contract_no INT   null,
      veh_seq INT   null
   ) -- populate the contract table
   insert into #con_temp(contract_no,active_seq)
   select distinct(con.contract_no),con.con_active_sequence from
   rd.contract_renewals as cr, rd.contract as con, rd.types_for_contract as tfc where(@renew_id is null or @renew_id = 0 or con.rg_code = @renew_id) and
   con.con_base_cont_type = 1 and
   tfc.ct_key = 1 and
   cr.con_expiry_date > GetDate()
   insert into #veh_min_temp(contract_no,veh_seq)
   select cv.contract_no,min(contract_seq_number) from
   rd.contract_vehical as cv,#con_temp as con where
   cv.contract_no = con.contract_no and
   cv.vehicle_number = rd.f_GetLatestConVehicle(cv.contract_no)
   group by cv.contract_no
   insert into #cv_temp(v_num,c_num,start_num,dist_renew)
   select distinct(cv.vehicle_number),cv.contract_no,min(cv.start_kms),max(cr.con_distance_at_renewal) from
   rd.contract_vehical as cv,rd.contract_renewals as cr,#con_temp as con,#veh_min_temp as vmt where
   con.contract_no = vmt.contract_no and
   cv.contract_no = con.contract_no and
   cv.contract_no = cr.contract_no and
   cv.contract_seq_number = vmt.veh_seq and
   cv.vehicle_number = rd.f_GetLatestConVehicle(cv.contract_no) and
   cr.contract_seq_number = vmt.veh_seq
   group by cv.vehicle_number,cv.contract_no,cv.start_kms,cr.con_distance_at_renewal
  -- set any milages over 200000 to limit of 200000
   update #cv_temp set start_num = 200000  where
   start_num > 200000

insert into #final_temp(expiry,con_num,rego,vmake,vmodel,vyear,vdesc,vfuel,reg_name) --values(getdate(),1, 'regon', 'vmake','vmodel',2,'vdesc','vfuel','reg_name')
select distinct(case when cv.start_num > 5000 and cv.start_num is not null then CONVERT(DATETIME,CONVERT(VARCHAR(10),dateadd(day,(((200000 -cv.start_num)/cv.dist_renew)*365),v.v_purchased_date),
      110)) else CONVERT(DATETIME,CONVERT(VARCHAR(10),dateadd(day,((200000/cv.dist_renew)*365),v.v_purchased_date),110))
end) as expiry 
,con.contract_no,v.v_vehicle_registration_number,
      v.v_vehicle_make,v.v_vehicle_model,v.v_vehicle_year
,vs.vs_description,ft.ft_description,reg.rgn_name 
from rd.vehicle as v left outer join rd.fuel_type as ft on v.vs_key=ft.ft_key  ,--join
 #con_temp as con
, --join 
rd.vehicle_style as vs ,--join
#cv_temp as cv  ,--join 
      rd.[contract] as cont join rd.outlet as outl on ( cont.con_base_office = outl.outlet_id ) join rd.region as reg on outl.region_id = reg.region_id
where  -- cr.c_num = con.contract_no   
   cv.c_num = con.contract_no and
   v.vehicle_number = cv.v_num and
   v.v_purchased_date is not null and
   vs.vs_key = v.vs_key and
   v.vs_key not in(3,8,12,16,15) and
   cont.contract_no = con.contract_no 
--order by 1 expiry asc  
order by 1 asc

  -- get the date 6 months ago
   set @month_6 = dateadd(month,6,GetDate())
  -- get rid of entries where the expiry is more than 6 months in the future
   delete from #final_temp where
   expiry > @month_6
  -- get count and put in message if there are no rows
   select   @count_final = count(*) 
   from #final_temp
   if @count_final = 0
   begin
      insert into #final_temp(vmodel)
      select '0 Vehicles'
   end

   select   max(expiry) AS expiry,con_num AS con_num,rego AS rego,vmake AS vmake,vmodel AS vmodel,
   vyear AS vyear,vdesc AS vdesc,vfuel AS vfuel,reg_name AS reg_name,
   @month_6 AS month_6 from -- dateformat(month_6, 'dd/mm/yyyy')
   #final_temp
   group by reg_name,con_num,rego,vmake,vmodel,vyear,vdesc,vfuel,expiry order by
   max(expiry) asc,con_num asc,rego asc
end






SET ANSI_NULLS ON