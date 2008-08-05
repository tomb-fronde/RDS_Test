/****** Object:  StoredProcedure [rd].[sp_SearchForContract]    Script Date: 08/05/2008 10:22:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for stored procedure sp_SearchForContract : 
--

create procedure [rd].[sp_SearchForContract](@in_Region int,@in_Contract int,@in_ContractTitle char(60),@in_ConMSN char(6),@in_LastServiceStart datetime,@in_LastServiceEnd datetime,@in_LastDelStart datetime,@in_LastDelEnd datetime,@in_LastWorkStart datetime,@in_LastWorkEnd datetime)
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  select distinct contract_no,
    con_title from
    contract where
    (contract_no = @in_Contract or @in_Contract = 0) and
    (con_old_mail_service_no like @in_ConMSN + '%' or
    @in_ConMSN = '') and
    (con_title like @in_ContractTitle + '%') and
    (con_last_service_review between @in_LastServiceStart and @in_LastServiceEnd or
    (@in_LastServiceStart = '1900-01-01' and con_last_service_review is null)) and
    (con_last_delivery_check between @in_LastDelStart and @in_LastDelEnd or
    (@in_LastDelStart = '1900-01-01' and con_last_delivery_check is null)) and
    (con_last_work_msrmnt_check between @in_LastWorkStart and @in_LastWorkEnd or
    (@in_LastWorkStart = '1900-01-01' and con_last_work_msrmnt_check is null)) and
    (@in_Region = 0 or con_base_office = any(select outlet_id from outlet where region_id = @in_Region)) order by
    con_title asc
end
GO
