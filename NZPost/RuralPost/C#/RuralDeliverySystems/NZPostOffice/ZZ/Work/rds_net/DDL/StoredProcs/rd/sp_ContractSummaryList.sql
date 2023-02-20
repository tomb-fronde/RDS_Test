/****** Object:  StoredProcedure [rd].[sp_ContractSummaryList]    Script Date: 08/05/2008 10:18:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

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
GO
