/****** Object:  StoredProcedure [odps].[sp_rd_auditlog]    Script Date: 08/05/2008 10:14:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for stored procedure sp_rd_auditlog : 
--

create procedure [odps].[sp_rd_auditlog](@fromdate datetime,@todate datetime)
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  declare @sfromdate char(20),
  @stodate char(20)
  select @sfromdate=convert(datetime,rd.Date(@fromdate),120)
  select @stodate=convert(datetime,@todate,120)
  select a_key,
    a_datetime,
    a_userid,rds_audit.a_contract,
    a_contractor,rds_audit.a_comment,
    a_oldvalue,
    a_newvalue,
ddate=CONVERT(varchar(12),a_datetime,111)  from  
    rd.rds_audit where
    a_datetime between cast(@sfromdate as datetime) and cast (@stodate as datetime) and
    a_userid <> 'DB Trigger' order by ddate desc,
    a_contract asc,a_contractor asc
end
GO
