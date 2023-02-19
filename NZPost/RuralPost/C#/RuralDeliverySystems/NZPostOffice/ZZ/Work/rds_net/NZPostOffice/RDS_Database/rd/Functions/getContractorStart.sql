
--
-- Definition for user-defined function getContractorStart : 
--

create function [rd].[getContractorStart](@con_no int,@contractor_no int)
returns datetime
AS
BEGIN

  declare @start_date datetime
  -- TJB SR4623 29 June 2004
  -- 'max' returns the most recent contract establishment date, for those cases
  -- where a contractor gives up a contract then takes it up again.
  select @start_date = max(cr_effective_date) 
    from contractor_renewals where
    contract_no = @con_no and
    contractor_supplier_no = @contractor_no
  return @start_date
end