
--
-- Definition for stored procedure sp_GetRCMStatReport : 
--

create procedure [rd].[sp_GetRCMStatReport](
@inRegion int,
@inOutlet int,
@inRenGroup int,
@inContractType int)
-- TJB  SR4684  June-2006
-- Reformatted for legibility
-- Moved 'Delete from RCM...' and commit to beginning
as --    so commit didn''t happen in the middle.
begin
SET IMPLICIT_TRANSACTIONS On

  declare @sRegion char(40)
  declare @AVol int
  declare @CVol int
  declare @ACost numeric(12,2)
  declare @CCost numeric(12,2)
  declare @test1 int
  declare @test2 int
  delete from rcm_stat_report -- Collects report data
  delete from RCMStatPR1 -- Collects KiwiMail report data
  delete from RCMStatPR2 -- Collects CourierPost report data
  commit transaction
  insert into rcm_stat_report(region,
    description,sumamount,sort_order,column_order,showdecimals,variablename)
    select rgn_name,'Number of Runs',
      rd.RDRunsRegionV2(region_id,@inOutlet,@inRenGroup,@inContractType),
      10,
      1,'N','NORDRUN' from
      region where
      (region_id = @inRegion or @inRegion = 0)
  insert into rcm_stat_report(region,
    description,sumamount,sort_order,column_order,showdecimals,variablename)
    select 'National','Number of Runs',
      rd.RDRunsRegionV2(0,0,@inRenGroup,@inContractType),
      10,
      2,'N','NORDRUN'
insert into rcm_stat_report(region,
    description,sumamount,sort_order,column_order,showdecimals,variablename)
    select rgn_name,'Number of Owner Drivers',
      rd.OwnDrvRegionV2(region_id,@inOutlet,@inRenGroup,@inContractType),
      20,
      1,'N','NOOWNDRV' from
      region where
      (region_id = @inRegion or @inRegion = 0)
insert into rcm_stat_report(region,
    description,sumamount,sort_order,column_order,showdecimals,variablename)
    select 'National','Number of Owner Drivers',
      rd.OwnDrvRegionV2(0,0,@inRenGroup,@inContractType),
      20,
      2,'N','NOOWNDRV'
insert into rcm_stat_report(region,
    description,sumamount,sort_order,column_order,showdecimals,variablename)
    select rgn_name,'Number of Customers',
      rd.CustsRegionV2(region_id,@inOutlet,@inRenGroup,@inContractType),
      30,
      1,'N','NOCUSTS' from
      region where
      (region_id = @inRegion or @inRegion = 0)
insert into rcm_stat_report(region,
    description,sumamount,sort_order,column_order,showdecimals,variablename)
    select 'National','Number of Customers',
      rd.CustsRegionV2(0,0,@inRenGroup,@inContractType),
      30,
      2,'N','NOCUSTS'
insert into rcm_stat_report(region,
    description,sumamount,sort_order,column_order,showdecimals,variablename)
    select rgn_name,'Total Articles Delivered',
      rd.AnnualVolume(region_id,@inOutlet,@inRenGroup,@inContractType),
      40,
      1,'N','NOARTDEL' from
      region where
      (region_id = @inRegion or @inRegion = 0)
insert into rcm_stat_report(region,
    description,sumamount,sort_order,column_order,showdecimals,variablename)
    select 'National','Total Articles Delivered',
      rd.AnnualVolume(0,0,@inRenGroup,@inContractType),
      40,
      2,'N','NOARTDEL'
insert into rcm_stat_report(region,
    description,sumamount,sort_order,column_order,showdecimals,variablename)
    select rgn_name,'Total NZP Payments($)',
      rd.CoreCOntract(region_id,@inOutlet,@inRenGroup,@inContractType),
      50,
      1,'N','NONZP' from
      region where
      (region_id = @inRegion or @inRegion = 0)
insert into rcm_stat_report(region,
    description,sumamount,sort_order,column_order,showdecimals,variablename)
    select 'National','Total NZP Payments($)',
      rd.CoreCOntract(0,0,@inRenGroup,@inContractType),
      50,
      2,'N','NONZP'
insert into rcm_stat_report(region,
    description,sumamount,sort_order,column_order,showdecimals,variablename)
    select rgn_name,'Total Daily Distance',
      rd.DayDistRegionV2(region_id,@inOutlet,@inRenGroup,@inContractType),
      60,
      1,'N','DAYDIST' from
      region where
      (region_id = @inRegion or @inRegion = 0)
insert into rcm_stat_report(region,
    description,sumamount,sort_order,column_order,showdecimals,variablename)
    select 'National','Total Daily Distance',
      rd.DayDistRegionV2(0,0,@inRenGroup,@inContractType),
      60,
      2,'N','DAYDIST'
insert into rcm_stat_report(region,
    description,sumamount,sort_order,column_order,showdecimals,variablename)
    select tab1.region,'Ave. Boxes per Run',
      (case when  tab2.sumamount > 0 then tab1.sumamount/tab2.sumamount else 0 end),
      70,
      tab1.column_order,'N','AVEBOXRUN' from
      rcm_stat_report as tab1,
      rcm_stat_report as tab2 where
      tab1.region = tab2.region and
      tab1.variablename = 'NOCUSTS' and
      tab2.variablename = 'NORDRUN'
insert into rcm_stat_report(region,
    description,sumamount,sort_order,column_order,showdecimals,variablename)
    select tab1.region,'Ave. Articles per Run',
      (case when tab2.sumamount > 0 then tab1.sumamount/tab2.sumamount else 0 end),
      80,
      tab1.column_order,'N','AVEARTRUN' from
      rcm_stat_report as tab1,
      rcm_stat_report as tab2 where
      tab1.region = tab2.region and
      tab1.variablename = 'NOARTDEL' and
      tab2.variablename = 'NORDRUN'
insert into rcm_stat_report(region,
    description,sumamount,sort_order,column_order,showdecimals,variablename)
    select tab1.region,'Ave. Articles per Box',
      (case when tab2.sumamount > 0 then tab1.sumamount/tab2.sumamount else 0 end),
      90,
      tab1.column_order,'N','AVEARTBOX' from
      rcm_stat_report as tab1,
      rcm_stat_report as tab2 where
      tab1.region = tab2.region and
      tab1.variablename = 'NOARTDEL' and
      tab2.variablename = 'NOCUSTS'
insert into rcm_stat_report(region,
    description,sumamount,sort_order,column_order,showdecimals,variablename)
    select tab1.region,'Ave. Distance per Run',
      (case when tab2.sumamount > 0 then tab1.sumamount/tab2.sumamount else 0 end),
      100,
      tab1.column_order,'N','AVEKMRUN' from
      rcm_stat_report as tab1,
      rcm_stat_report as tab2 where
      tab1.region = tab2.region and
      tab1.variablename = 'DAYDIST' and
      tab2.variablename = 'NORDRUN'
insert into rcm_stat_report(region,
    description,sumamount,sort_order,column_order,showdecimals,variablename)
    select tab1.region,'Ave. Density (Boxes/ KM)',
      (case when tab2.sumamount > 0 then tab1.sumamount/tab2.sumamount else 0 end),
      110,
      tab1.column_order,'Y','CUSTDENSE' from
      rcm_stat_report as tab1,
      rcm_stat_report as tab2 where
      tab1.region = tab2.region and
      tab1.variablename = 'NOCUSTS' and
      tab2.variablename = 'DAYDIST'
insert into rcm_stat_report(region,
    description,sumamount,sort_order,column_order,showdecimals,variablename)
    select rgn_name,'Annual Distance',
      rd.AnnualDistance(region_id,@inOutlet,@inRenGroup,@inContractType),
      210,
      1,'Y','COREDIST' from
      region where
      (region_id = @inRegion or @inRegion = 0)
insert into rcm_stat_report(region,
    description,sumamount,sort_order,column_order,showdecimals,variablename)
    select 'National','Annual Distance',
      rd.AnnualDistance(0,0,@inRenGroup,@inContractType),
      210,
      1,'Y','COREDIST'
insert into rcm_stat_report(region,
    description,sumamount,sort_order,column_order,showdecimals,variablename)
    select rgn_name,'Total Allowances per Year($)',
      rd.NZPAllowance(region_id,@inOutlet,@inRenGroup,@inContractType),
      55,
      1,'N','ALLOW' from
      region where
      (region_id = @inRegion or @inRegion = 0)
insert into rcm_stat_report(region,
    description,sumamount,sort_order,column_order,showdecimals,variablename)
    select 'National','Total Allowances per Year($)',
      rd.NZPAllowance(0,0,@inRenGroup,@inContractType),
      55,
      2,'N','ALLOW'
  /*
  *  SR#4392 PBY 22/05/2002 Commented out Unit Cost related rows
  *
  *   insert into rcm_stat_report
  *      (region,description,sumamount,sort_order,column_order,showdecimals,variablename)
  *  select tab1.region,
  *         'Unit Cost($)',
  *         (if tab2.sumamount>0 then tab1.sumamount/tab2.sumamount else 0 endif),
  *         210,
  *         1,
  *         'Y',
  *         'UNITCOST'
  *    from rcm_stat_report as tab1
  *       , rcm_stat_report as tab2
  *   where tab1.region=tab2.region
  *     and tab1.variablename='NONZP'
  *     and tab2.variablename='NOARTDEL'
  *     and tab1.region<>'National';
  *
  *  insert into rcm_stat_report
  *      (region,description,sumamount,sort_order,column_order,showdecimals,variablename)
  *  select 'National',
  *         'Unit Cost($)',
  *         (if tab2.sumamount > 0 then tab1.sumamount/tab2.sumamount else 0 endif),
  *         210,
  *         2,
  *         'Y',
  *         'UNITCOST'
  *    from rcm_stat_report as tab1,
  *         rcm_stat_report as tab2 
  *   where tab1.region = 'National' 
  *     and tab2.region = 'National' 
  *     and tab1.variablename = 'NONZP' 
  *     and tab2.variablename = 'NOARTDEL';
  */

insert into rcm_stat_report(region,
    description,sumamount,sort_order,column_order,showdecimals,variablename)
    select tab1.region,'Cost per Customer($)',
      (case when tab2.sumamount > 0 then tab1.sumamount/tab2.sumamount else 0 end),
      220,
      1,'Y','COSTCUST' from
      rcm_stat_report as tab1,
      rcm_stat_report as tab2 where
      tab1.region = tab2.region and
      tab1.variablename = 'NONZP' and
      tab2.variablename = 'NOCUSTS' and
      tab1.region <> 'National'
insert into rcm_stat_report(region,
    description,sumamount,sort_order,column_order,showdecimals,variablename)
    select 'National','Cost per Customer($)',
      (case when tab2.sumamount > 0 then tab1.sumamount/tab2.sumamount else 0 end),
      220,
      2,'Y','COSTCUST' from
      rcm_stat_report as tab1,
      rcm_stat_report as tab2 where
      tab1.region = 'National' and
      tab2.region = 'National' and
      tab1.variablename = 'NONZP' and
      tab2.variablename = 'NOCUSTS'
insert into rcm_stat_report(region,
    description,sumamount,sort_order,column_order,showdecimals,variablename)
    select tab1.region,'Cost per Km($)',
      (case when tab2.sumamount > 0 then tab1.sumamount/tab2.sumamount else 0 end),
      220,
      1,'Y','COSTKM' from
      rcm_stat_report as tab1,
      rcm_stat_report as tab2 where
      tab1.region = tab2.region and
      tab1.variablename = 'NONZP' and
      tab2.variablename = 'COREDIST' and
      tab1.region <> 'National'
insert into rcm_stat_report(region,
    description,sumamount,sort_order,column_order,showdecimals,variablename)
    select 'National','Cost per Km($)',
      (case when tab2.sumamount > 0 then tab1.sumamount/tab2.sumamount else 0 end),
      220,
      2,'Y','COSTKM' from
      rcm_stat_report as tab1,
      rcm_stat_report as tab2 where
      tab1.region = 'National' and
      tab2.region = 'National' and
      tab1.variablename = 'NONZP' and
      tab2.variablename = 'COREDIST'
insert into rcm_stat_report(region,
    description,sumamount,sort_order,column_order,showdecimals,variablename)
    select rgn_name,'Inward Mail',
      rd.PickupVolumes(region_id,@inOutlet,@inRenGroup,@inContractType),
      45,
      1,'n','PICKUP' from
      region where
      (region_id = @inRegion or @inRegion = 0)
insert into rcm_stat_report(region,
    description,sumamount,sort_order,column_order,showdecimals,variablename)
    select 'National','Inward Mail',
      rd.PickupVolumes(0,0,@inRenGroup,@inContractType),
      45,
      2,'N','PICKUP'
  ----------------------------------------------------------------------------------------------      
  execute rd.EstAdPost @inRegion,@inOutlet,@inRenGroup,@inContractType
  execute rd.EstCourPost @inRegion,@inOutlet,@inRenGroup,@inContractType
insert into rcm_stat_report(region,
    description,sumamount,sort_order,column_order,showdecimals,variablename)
    select rgn_name,'Est. Courier Post Volumes',
      CourpostVol,
      120,
      1,'N','ESTCPV' from
      region,
      RCMStatPR2 where
      RCMStatPR2.region_id = region.region_id
insert into rcm_stat_report(region,
    description,sumamount,sort_order,column_order,showdecimals,variablename)
    select rgn_name,'Est. Courier Post Expenditures',
      CourpostCost,
      130,
      1,'Y','ESTCPE' from
      region,
      RCMStatPR2 where
      RCMStatPR2.region_id = region.region_id
insert into rcm_stat_report(region,
    description,sumamount,sort_order,column_order,showdecimals,variablename)
    select rgn_name,'Est. Kiwimail Volumes',
      AdpostVol,
      140,
      1,'N','ESTAPV' from
      region,
      RCMStatPR1 where
      RCMStatPR1.region_id = region.region_id
insert into rcm_stat_report(region,
    description,sumamount,sort_order,column_order,showdecimals,variablename)
    select rgn_name,'Est. Kiwimail Expenditures',
      AdpostCost,
      150,
      1,'Y','ESTAPE' from
      region,
      RCMStatPR1 where
      RCMStatPR1.region_id = region.region_id
  ------------------------------------------------------------------------------------  
  if @inRegion = 0 and @inOutlet = 0
    begin
      execute @test1=rd.EstCourPostAll 1,@inRegion,@inRenGroup,@inContractType
        
      execute @test2=rd.EstAdPostAll 1,@inRegion,@inRenGroup,@inContractType
        
    end
  else
    begin
      execute @test1=rd.EstCourPostAll 0,@inRegion,@inRenGroup,@inContractType
        
      execute @test2=rd.EstAdPostAll 0,@inRegion,@inRenGroup,@inContractType 
       
    end
  select @ACost=AdpostCost,@AVol=AdpostVol from RCMStatPR1 where region_id = 0
  select @CCost=CourpostCost,@CVol=CourpostVol from RCMStatPR2 where region_id = 0
insert into rcm_stat_report(region,
    description,sumamount,sort_order,column_order,showdecimals,variablename)
    select 'National','Est. Courier Post Volumes',
      @CVol,
      120,
      2,'N','ESTCPV'
insert into rcm_stat_report(region,
    description,sumamount,sort_order,column_order,showdecimals,variablename)
    select 'National','Est. Courier Post Expenditures',
      @CCost,
      130,
      2,'Y','ESTCPE'
insert into rcm_stat_report(region,
    description,sumamount,sort_order,column_order,showdecimals,variablename)
    select 'National','Est. Kiwimail Volumes',
      @AVol,
      140,
      2,'N','ESTAPV' 
insert into rcm_stat_report(region,
    description,sumamount,sort_order,column_order,showdecimals,variablename)
    select 'National','Est. Kiwimail Expenditures',
      @ACost,
      150,
      2,'Y','ESTAPE'
  ------------------------------------------------------------------------------------------
insert into rcm_stat_report(region,
    description,sumamount,sort_order,column_order,showdecimals,variablename)
    select tab1.region,'Ave. Courier Post Articles per Run',
      (case when isnull(tab2.sumamount,0) > 0 then isnull(tab1.sumamount,0)/tab2.sumamount else 0 end),    --
      160,
      tab1.column_order,'N','AVECPRUN' from
      rcm_stat_report as tab1,
      rcm_stat_report as tab2 where
      tab1.region = tab2.region and
      tab1.variablename = 'ESTCPV' and
      tab2.variablename = 'NORDRUN'
insert into rcm_stat_report(region,
    description,sumamount,sort_order,column_order,showdecimals,variablename)
    select tab1.region,'Ave. Courier Post Articles per Box',
      (case when isnull(tab2.sumamount,0) > 0 then isnull(tab1.sumamount,0)/tab2.sumamount else 0 end),		--
      170,
      tab1.column_order,'N','AVECPRUN' from
      rcm_stat_report as tab1,
      rcm_stat_report as tab2 where
      tab1.region = tab2.region and
      tab1.variablename = 'ESTCPV' and
      tab2.variablename = 'NOCUSTS'
  --------------------------------------------------------------------------------------------           
insert into rcm_stat_report(region,
    description,sumamount,sort_order,column_order,showdecimals,variablename)
    select tab1.region,'Ave. Kiwimail Articles per Run',
      (case when isnull(tab2.sumamount,0) > 0 then isnull(tab1.sumamount,0)/tab2.sumamount else 0 end),  --
      180,
      tab1.column_order,'N','AVECPRUN' from
      rcm_stat_report as tab1,
      rcm_stat_report as tab2 where
      tab1.region = tab2.region and
      tab1.variablename = 'ESTAPV' and
      tab2.variablename = 'NORDRUN'
insert into rcm_stat_report(region,
    description,sumamount,sort_order,column_order,showdecimals,variablename)
    select tab1.region,'Ave. Kiwimail Articles per Box',
      (case when isnull(tab2.sumamount,0) > 0 then isnull(tab1.sumamount,0)/tab2.sumamount else 0 end),		--
      190,
      tab1.column_order,'N','AVECPRUN' from
      rcm_stat_report as tab1,
      rcm_stat_report as tab2 where
      tab1.region = tab2.region and
      tab1.variablename = 'ESTAPV' and
      tab2.variablename = 'NOCUSTS'
  --------------------------------------------------------------------------------------------------------
  -- working area TWC : 
insert into rcm_stat_report(region,
    description,sumamount,sort_order,column_order,showdecimals,variablename)
    select 'National','Geocoded Delivery Points %',
      rd.RDGeoPercent(0,0,@inRenGroup,@inContractType),
      250,
      2,'N','PERGEO' 
insert into rcm_stat_report(region,
    description,sumamount,sort_order,column_order,showdecimals,variablename)
    select rgn_name,'Geocoded Delivery Points %',
      rd.RDGeoPercent(region_id,@inOutlet,@inRenGroup,@inContractType),
      250,
      1,'N','PERGEO' from
      region where
      (region_id = @inRegion or @inRegion = 0)
  --------------------------------------------------------------------------------------------------------------------------------------------------------   
insert into rcm_stat_report(region,
    description,sumamount,sort_order,column_order,showdecimals,variablename)
    select 'National','Drivers with Cell Phones %',
      rd.ownerwithcellPercent(0,0,@inRenGroup,@inContractType),
      260,
      2,'N','PERCELL'
--select convert(char, getdate(),9)+ 'w'
insert into rcm_stat_report(region,
    description,sumamount,sort_order,column_order,showdecimals,variablename)
    select rgn_name,'Drivers with Cell Phones %',
      rd.ownerwithcellPercent(region_id,@inOutlet,@inRenGroup,@inContractType),
      260,
      1,'N','PERCELL' from
      region where
      (region_id = @inRegion or @inRegion = 0)
--select convert(char, getdate(),9)+ 'w1'
  --------------------------------------------------------------------------------------------------------------------------------------------------------   
declare @exppercent1 real
execute @exppercent1 = rd.v_expPercent 0,0,@inRenGroup,@inContractType
insert into rcm_stat_report(region,
    description,sumamount,sort_order,column_order,showdecimals,variablename)
    select 'National','Vehicles meeting replacement %',
      @exppercent1,
      270,
      2,'Y','PEREXP' 
--select convert(char, getdate(),9)+ 'w2'
/*
  insert into rcm_stat_report(region,
    description,sumamount,sort_order,column_order,showdecimals,variablename)
    select rgn_name,'Vehicles meeting replacement %',
      rd.v_expPercent(region_id,@inOutlet,@inRenGroup,@inContractType),
      270,
      1,'Y','PEREXP' from
      region where
      (region_id = @inRegion or @inRegion = 0)
*/
-- temp table for setting column value by a procedure
create table #region_temp(
    region_id int not null,
    rgn_name varchar(40) null,
    expPercent real
    ) 
declare @l_region_id int
begin transaction
delete  #region_temp
insert #region_temp(region_id,rgn_name) 
select region_id,rgn_name from rd.region 
	where region_id = @inRegion or @inRegion = 0
declare c_region_temp  cursor for select region_id from #region_temp
open c_region_temp
while 1=1 
    begin
      fetch next from c_region_temp into @l_region_id
		if @@error <>0
        begin
          rollback transaction
          return(-1)
        end
		if @@FETCH_STATUS < 0
		  break
		select @exppercent1 = rd.v_expPercent(@l_region_id,@inOutlet,@inRenGroup,@inContractType)
		update #region_temp set expPercent = @exppercent1 where region_id=@l_region_id
	end
--select convert(char, getdate(),9)+ 'w3'
insert into rcm_stat_report(region,
    description,sumamount,sort_order,column_order,showdecimals,variablename)
    select rgn_name,'Vehicles meeting replacement %',
      expPercent,
      270,
      1,'Y','PEREXP' from
      #region_temp
commit transaction

--select cast(getdate() as char)+ 'x'
  --------------------------------------------------------------------------------------------------------------------------------------------------------      
  insert into rcm_stat_report(region,
    description,sumamount,sort_order,column_order,showdecimals,variablename)
    select 'National','Vehicles meeting Specs / livery %',
      0,
      280,
      2,'N','PERSPEC'
  insert into rcm_stat_report(region,
    description,sumamount,sort_order,column_order,showdecimals,variablename)
    select rgn_name,'Vehicles meeting Specs / livery %',
      0,
      280,
      1,'N','PERSPEC' from
      region where
      (region_id = @inRegion or @inRegion = 0)
  --------------------------------------------------------------------------------------------------------------------------------------------------------            
  insert into rcm_stat_report(region,
    description,sumamount,sort_order,column_order,showdecimals,variablename)
    select 'National','Privacy Opt out %',
      rd.privacyPercent(0,0,@inRenGroup,@inContractType),
      290,
      2,'Y','PERPRIV' 
  insert into rcm_stat_report(region,
    description,sumamount,sort_order,column_order,showdecimals,variablename)
    select rgn_name,'Privacy Opt out %',
      rd.privacyPercent(region_id,@inOutlet,@inRenGroup,@inContractType),
      290,
      1,'Y','PERPRIV' from
      region where
      (region_id = @inRegion or @inRegion = 0)
  --------------------------------------------------------------------------------------------------------------------------------------------------------               
  insert into rcm_stat_report(region,
    description,sumamount,sort_order,column_order,showdecimals,variablename)
    select 'National','No Road Number %',
      rd.noroadnumPercent(0,0,@inRenGroup,@inContractType),
      300,
      2,'Y','PERNRN'
--select cast(getdate() as char)+ 'y'
  insert into rcm_stat_report(region,
    description,sumamount,sort_order,column_order,showdecimals,variablename)
    select rgn_name,'No Road Number %',
      rd.noroadnumPercent(region_id,@inOutlet,@inRenGroup,@inContractType),
      300,
      1,'Y','PERNRN' from
      region where
      (region_id = @inRegion or @inRegion = 0)
--select cast(getdate() as char)+ 'z'
  -----------------------------------------------------------------------------------------------------------------------
  commit transaction
SET IMPLICIT_TRANSACTIONS OFF
  select region,
    description,
    sumamount,
    sort_order,
    column_order,
    showdecimals from
    rcm_stat_report where
   left(description,3) <> 'Est' and
   left(variablename,3) <> 'COR'
--commit transaction

end