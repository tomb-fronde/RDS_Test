
--
-- Definition for stored procedure sp_ContractSummaryList : 
--

create procedure [rd].[sp_ContractSummaryList](@inContract int,@inSequence int,@indate datetime)
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  declare @outdate datetime
  select @outdate=@indate
  select contract_renewals.contract_no,
    contract_renewals.contract_seq_number,@outdate from
    rd.contract_renewals where
    (contract_renewals.contract_no = @incontract) and
    (contract_renewals.contract_seq_number = @insequence)
end