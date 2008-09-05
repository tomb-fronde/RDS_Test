/****** Object:  StoredProcedure [rd].[sp_GetContAdjustments]    Script Date: 08/05/2008 10:19:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for stored procedure sp_GetContAdjustments : 
--

--
-- Definition for stored procedure sp_GetContAdjustments : 
--

create procedure [rd].[sp_GetContAdjustments](@in_Contract int,@in_Sequence int)
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  select ca_key,
    contract_no,
    contract_seq_number,
    ca_date_occured,
    ca_reason,
    ca_date_paid,
    ca_amount,
    ca_confirmed,pct_id from
    contract_adjustments where
    contract_no = @in_Contract and
    contract_seq_number = @in_Sequence order by ca_date_occured desc
end
GO
