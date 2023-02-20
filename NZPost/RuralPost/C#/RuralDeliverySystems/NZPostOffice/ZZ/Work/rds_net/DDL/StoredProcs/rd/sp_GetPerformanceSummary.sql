/****** Object:  StoredProcedure [rd].[sp_GetPerformanceSummary]    Script Date: 08/05/2008 10:20:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for stored procedure sp_GetPerformanceSummary : 
--

create procedure [rd].[sp_GetPerformanceSummary](
@inRegion decimal(12,2),
@inMonth datetime)
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  create table #tmp_performance_table(
    detailtype char(2) null,
    datagroup char(2) null,
    sortorder decimal(12,2) null,
    monthact decimal(12,2) null,
    monthbud decimal(12,2) null,
    description char(40) null,
    ytdact decimal(12,2) null,
    ytdbud decimal(12,2) null)
  declare @dMonthStart datetime
  declare @dMonthEnd datetime
  declare @dYearStart datetime
  declare @dYearEnd datetime
  declare @dPrevMonthEnd datetime
  declare @iLettersCount int
  declare @iSmallParcels int
  declare @iLargeParcels int
  declare @iExtnLetters int
  declare @iExtnSmallParcels int
  declare @iExtnLargeParcels int
  declare @decYTDDelHours decimal(12,2)
  declare @decYTDSortHours decimal(12,2)
  declare @decYTDDistance decimal(12,2)
  declare @decMonthDelHours decimal(12,2)
  declare @decMonthSortHours decimal(12,2)
  declare @decMonthDistance decimal(12,2)
  declare @numCustSum int
  declare @decYTDStart int
  declare @decYTDTrans int
  declare @decYTDStop int
  declare @decMonthStart int
  declare @decMonthTrans int
  declare @decMonthStop int
  declare @iYTDRenNo int
  declare @iYTDOutNo int
  declare @decYTDRenVal decimal(12,2)
  declare @decYTDOutVal decimal(12,2)
  declare @iMonRenNo int
  declare @iMonOutNo int
  declare @decMonRenVal decimal(12,2)
  declare @decMonOutVal decimal(12,2)
  declare @iYTDRenTrans int
  declare @iMonthRenTrans int
  declare @iYTDConCancelled int
  declare @iMonthConCancelled int
  select @dMonthStart=rd.ymd(year(@inMonth),month(@inMonth),1)
  select @dMonthEnd=dateadd(day,-1,dateadd(month,1,@dMonthStart))
  select @dPrevMonthEnd=dateadd(day,-1,@dMonthStart)
  if month(@dMonthStart) < 4
    begin
      select @dYearStart=rd.ymd(year(@dMonthStart)-1,4,1)
      select @dYearEnd=rd.ymd(year(@dMonthStart),3,31)
    end
  else
    begin
      select @dYearStart=rd.ymd(year(@dMonthStart),4,1)
      select @dYearEnd=rd.ymd(year(@dMonthStart)+1,3,31)
    end
  insert into #tmp_performance_table(detailtype,
    datagroup,sortorder,monthact,monthbud,description,ytdact,ytdbud) values('D','TR',
    10,0,0,'TOTAL REVENUE',0,0)
  insert into #tmp_performance_table(detailtype,
    datagroup,sortorder,monthact,monthbud,description,ytdact,ytdbud) values('D','TR',
    20,0,0,'OWNER DRIVER EXPENDITURE',0,0)
  insert into #tmp_performance_table(detailtype,
    datagroup,sortorder,monthact,monthbud,description,ytdact,ytdbud) values('D','TR',
    30,0,0,'OTHER EXPENDITURES',0,0)
  insert into #tmp_performance_table(detailtype,
    datagroup,sortorder,monthact,monthbud,description,ytdact,ytdbud) values('D','TR',
    40,0,0,'TOTAL EXPENDITURES',0,0)
  insert into #tmp_performance_table(detailtype,
    datagroup,sortorder,monthact,monthbud,description,ytdact,ytdbud) values('D','TR',
    50,0,0,'PROFIT CONTRIBUTION',0,0)
  insert into #tmp_performance_table(detailtype,
    datagroup,sortorder,monthact,monthbud,description,ytdact,ytdbud) values('S1','MV',
    60,0,0,'MAIL VOLUMES',0,0)
  execute rd.ps_count_articles @inRegion,@dYearStart,@dMonthEnd,@iLettersCount,@iSmallParcels,@iLargeParcels,@iExtnLetters,@iExtnSmallParcels,@iExtnLargeParcels
  execute rd.ps_Renewal_Information @inRegion,@dYearStart,@dMonthEnd,@decYTDDelHours,@decYTDSortHours,@decYTDDistance,@decMonthDelHours,@decMonthSortHours,@decMonthDistance
  execute rd.ps_Customers @inRegion,@dYearStart,@dMonthEnd,@decYTDStart,@decYTDTrans,@decYTDStop,@decMonthStart,@decMonthTrans,@decMonthStop
  execute rd.ps_serviceplan @inRegion,@dYearStart,@dMonthEnd,@iYTDRenNo,@iYTDOutNo,@decYTDRenVal,@decYTDOutVal,@iMonRenNo,@iMonOutNo,decRenVal,@decMonOutVal,@iYTDRenTrans,@iMonthRenTrans,@iYTDConCancelled,iMonConCancelled
  insert into #tmp_performance_table(detailtype,
    datagroup,sortorder,monthact,monthbud,description,ytdact,ytdbud) values('D','MV',
    70,@iExtnLetters,0,'Letters',@iLettersCount,0)
  insert into #tmp_performance_table(detailtype,
    datagroup,sortorder,monthact,monthbud,description,ytdact,ytdbud) values('D','MV',
    80,@iExtnSmallParcels,0,'Small Parcels',@iSmallParcels,0)
  insert into #tmp_performance_table(detailtype,
    datagroup,sortorder,monthact,monthbud,description,ytdact,ytdbud) values('D','MV',
    90,@iExtnLargeParcels,0,'Large Parcels',@iLargeParcels,0)
  insert into #tmp_performance_table(detailtype,
    datagroup,sortorder,monthact,monthbud,description,ytdact,ytdbud) values('D','MV',
    100,rd.GetPRSupplierVolumes(@inRegion,2,@dMonthStart,@dMonthEnd),0,'Courier Post',rd.GetPRSupplierVolumes(@inRegion,2,@dYearStart,@dMonthEnd),0)
  insert into #tmp_performance_table(detailtype,
    datagroup,sortorder,monthact,monthbud,description,ytdact,ytdbud) values('D','MV',
    110,rd.GetPRSupplierVolumes(@inRegion,1,@dMonthStart,@dMonthEnd),0,'Kiwimail',rd.GetPRSupplierVolumes(@inRegion,1,@dYearStart,@dMonthEnd),0)
  insert into #tmp_performance_table(detailtype,
    datagroup,sortorder,monthact,monthbud,description,ytdact,ytdbud) values('S2','OK',
    120,0,0,'OTHER KEY INDICATORS',0,0)
  insert into #tmp_performance_table(detailtype,
    datagroup,sortorder,monthact,monthbud,description,ytdact,ytdbud) values('D','OK',
    130,0,0,'FTEU Level',0,0)
  insert into #tmp_performance_table(detailtype,
    datagroup,sortorder,monthact,monthbud,description,ytdact,ytdbud) values('D','OK',
    140,0,0,'Overtime Hours',0,0)
  insert into #tmp_performance_table(detailtype,
    datagroup,sortorder,monthact,monthbud,description,ytdact,ytdbud) values('D','OK',
    150,@decMonthDelHours,0,'Delivery Hours (p.w.)',@decYTDDelHours,0)
  insert into #tmp_performance_table(detailtype,
    datagroup,sortorder,monthact,monthbud,description,ytdact,ytdbud) values('D','OK',
    160,@decMonthSortHours,0,'Sort Hours (p.w.)',@decYTDSortHours,0)
  insert into #tmp_performance_table(detailtype,
    datagroup,sortorder,monthact,monthbud,description,ytdact,ytdbud) values('D','OK',
    170,@decMonthDistance,0,'KM Travelled (p.a.)',@decYTDDistance,0)
  insert into #tmp_performance_table(detailtype,
    datagroup,sortorder,monthact,monthbud,description,ytdact,ytdbud) values('D','OK',
    179,@decMonthStart,0,'Average Cost per Article ($)',rd.NZPRegion(@inRegion,0,0)/rd.VolRegion(@inRegion,0,0),0)
  execute pGetNumCusts @inRegion,@numCustSum
  insert into #tmp_performance_table(detailtype,
    datagroup,sortorder,monthact,monthbud,description,ytdact,ytdbud) values('D','OK',
    180,@decMonthStart,0,'Number of Customers',@numCustSum,0)
  insert into #tmp_performance_table(detailtype,
    datagroup,sortorder,monthact,monthbud,description,ytdact,ytdbud) values('D','OK',
    181,@decMonthStart,0,'Number of New Customers',@decYTDStart,0)
  insert into #tmp_performance_table(detailtype,
    datagroup,sortorder,monthact,monthbud,description,ytdact,ytdbud) values('D','OK',
    182,@decMonthStart,0,'Average Cost per Customer ($)',rd.NZPRegion(@inRegion,0,0)/@numCustSum,0)
  insert into #tmp_performance_table(detailtype,
    datagroup,sortorder,monthact,monthbud,description,ytdact,ytdbud) values('D','OK',
    190,@decMonthTrans,0,'Number of Transfers',@decYTDTrans,0)
  insert into #tmp_performance_table(detailtype,
    datagroup,sortorder,monthact,monthbud,description,ytdact,ytdbud) values('D','OK',
    200,@decMonthStop,0,'Number of Relinquishments',@decYTDStop,0)
  insert into #tmp_performance_table(detailtype,
    datagroup,sortorder,monthact,monthbud,description,ytdact,ytdbud) values('S3','SP',
    210,0,0,'SERVICE PERFORMANCE',0,0)
  insert into #tmp_performance_table(detailtype,
    datagroup,sortorder,monthact,monthbud,description,ytdact,ytdbud) values('D','SP',
    220,0,0,'Planned Customer Visits',0,0)
  insert into #tmp_performance_table(detailtype,
    datagroup,sortorder,monthact,monthbud,description,ytdact,ytdbud) values('D','SP',
    230,0,0,'Service Failures',0,0)
  insert into #tmp_performance_table(detailtype,
    datagroup,sortorder,monthact,monthbud,description,ytdact,ytdbud) values('D','SP',
    240,0,0,'Owner Driver Visits',0,0)
  insert into #tmp_performance_table(detailtype,
    datagroup,sortorder,monthact,monthbud,description,ytdact,ytdbud) values('D','SP',
    250,@iMonRenNo,0,'SLA Renewals Number',@iYTDRenNo,0)
  insert into #tmp_performance_table(detailtype,
    datagroup,sortorder,monthact,monthbud,description,ytdact,ytdbud) values('D','SP',
    260,@decMonRenVal,0,'SLA Renewals Values ($)',@decYTDRenVal,0)
  insert into #tmp_performance_table(detailtype,
    datagroup,sortorder,monthact,monthbud,description,ytdact,ytdbud) values('D','SP',
    270,@iMonthRenTrans,0,'SLA Transfers/ Assignments',@iYTDRenTrans,0)
  insert into #tmp_performance_table(detailtype,
    datagroup,sortorder,monthact,monthbud,description,ytdact,ytdbud) values('D','SP',
    280,@iMonOutNo,0,'SLA Renewals Outstanding No',@iYTDOutNo,0)
  insert into #tmp_performance_table(detailtype,
    datagroup,sortorder,monthact,monthbud,description,ytdact,ytdbud) values('D','SP',
    290,@decMonOutVal,0,'SLA Renewals Outstanding Value ($)',@decYTDOutVal,0)
  insert into #tmp_performance_table(detailtype,
    datagroup,sortorder,monthact,monthbud,description,ytdact,ytdbud) values('D','SP',
    300,0,0,'Sort Analysis Number Undertaken',0,0)
  insert into #tmp_performance_table(detailtype,
    datagroup,sortorder,monthact,monthbud,description,ytdact,ytdbud) values('D','SP',
    310,0,0,'Sort Analysis Average S.E.',0,0)
  insert into #tmp_performance_table(detailtype,
    datagroup,sortorder,monthact,monthbud,description,ytdact,ytdbud) values('D','SP',
    320,@iMonthConCancelled,0,'SLA Cancelled',@iYTDConCancelled,0)
  select detailtype,datagroup,sortorder,monthact,monthbud,description,ytdact,ytdbud from
    #tmp_performance_table
end
GO
