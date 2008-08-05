/****** Object:  UserDefinedFunction [rd].[getContractorEnd]    Script Date: 08/05/2008 11:24:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for user-defined function getContractorEnd : 
--

create function [rd].[getContractorEnd](
@con_no int,
@contractor_no int)
returns datetime
AS
BEGIN

  declare @end_date datetime
  declare @curr_effective datetime
  declare @active_seq int
  -- get the effective date of this contractor
  select @curr_effective=max(cr_effective_date)
    from contractor_renewals where
    contract_no = @con_no and
    contractor_supplier_no = @contractor_no
  -- get the min cr_effective date for this contract where they are larger than the curr
  select @end_date=isnull(min(cr_effective_date),dateadd(year,100,convert(datetime,convert(varchar(100),getdate(),101))))
    from contractor_renewals where
    contract_no = @con_no and
    contractor_supplier_no <> @contractor_no and
    cr_effective_date > @curr_effective
  -- modify the date - so take one day off
  select @end_date=dateadd(day,-1,@end_date)
  return @end_date
end
GO
