/****** Object:  StoredProcedure [rd].[ps_Customers]    Script Date: 08/05/2008 10:17:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for stored procedure ps_Customers : 
--

create procedure [rd].[ps_Customers](@inRegion int,@inYearStart datetime,@inMonthEnd datetime,@outYTDStart int output,@outYTDTransfer int output,@outYTDStopped int output,@outMonthStart int output,@outMonthTransfer int output,@outMonthStopped int output)
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  declare @dMonthStart datetime
  select @dMonthStart=rd.ymd(year(@inMonthEnd),month(@inMonthEnd),1)
  select @outYTDStart = sum(case when cust_date_first_loaded > @inYearStart and cust_date_first_loaded < @inMonthEnd then 1 else 0 end),
    @outYTDTransfer = sum(case when cust_date_last_transfered > @inYearStart and cust_date_last_transfered < @inMonthEnd then 1 else 0 end),
    @outYTDStopped = sum(case when cust_date_left > @inYearStart and cust_date_left < @inMonthEnd then 1 else 0 end),
    @outMonthStart = sum(case when cust_date_first_loaded > @dMonthStart and cust_date_first_loaded < @inMonthEnd then 1 else 0 end),
    @outMonthTransfer = sum(case when cust_date_last_transfered > @dMonthStart and cust_date_last_transfered < @inMonthEnd then 1 else 0 end),
    @outMonthStopped = sum(case when cust_date_left > @dMonthStart and cust_date_left < @inMonthEnd then 1 else 0 end) 
    from customer join
    contract on
    customer.contract_no = contract.contract_no,
    contract join
    outlet on
    contract.con_base_office = outlet.outlet_id and
    (outlet.region_id = @inRegion or @inRegion = 0) where
    (contract.con_date_terminated is null or
    contract.con_date_terminated > @inYearStart)
end
GO
