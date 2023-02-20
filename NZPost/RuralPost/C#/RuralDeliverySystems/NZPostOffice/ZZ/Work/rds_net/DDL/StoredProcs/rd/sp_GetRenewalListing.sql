/****** Object:  StoredProcedure [rd].[sp_GetRenewalListing]    Script Date: 08/05/2008 10:20:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for stored procedure sp_GetRenewalListing : 
--

create procedure [rd].[sp_GetRenewalListing](@in_Contract int)
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  select contract_seq_number from
    contract_renewals where
    contract_no = @in_Contract order by contract_seq_number desc
end
GO
