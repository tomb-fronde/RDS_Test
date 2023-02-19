
--
-- Definition for stored procedure sp_rd_auditlog_addresschange : 
--

create procedure [rd].[sp_rd_auditlog_addresschange](@fromdate datetime,@todate datetime)
AS
BEGIN
    declare @sfromdate char(20),
  @stodate char(20)
  select @sfromdate=convert(datetime,rd.Date(@fromdate),120)
  select @stodate=convert(datetime,@todate,120)
  select a_key,
    a_datetime,
    a_userid,
    rds_audit.a_contract,
    a_contractor,
    rds_audit.a_comment,
    a_oldvalue,
    a_newvalue,
    ddate=rd.date(a_datetime) from
    rd.rds_audit where
    a_datetime between cast(@sfromdate as datetime) and cast(@stodate as datetime) and
    a_userid <> 'DB Trigger' and
    left(a_newvalue,8) = 'Address:' order by
    ddate desc,
    a_contract asc,
    a_contractor asc
end