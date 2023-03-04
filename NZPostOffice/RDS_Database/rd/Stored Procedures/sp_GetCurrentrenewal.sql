
--
-- Definition for stored procedure sp_GetCurrentrenewal : 
--

--
-- Definition for stored procedure sp_GetCurrentrenewal : 
--

create procedure [rd].[sp_GetCurrentrenewal](@inContract int)
AS
BEGIN
  -- PBY 24/06/2002 SR#4411
  -- changed con_active_sequence > (select max... to 
  -- con_active_sequence < (select max...
  select cnt=count(*) from
    contract where
    contract.contract_no = @inContract and
    (contract.con_active_sequence is null or
    contract.con_active_sequence < (select max(contract_seq_number) from
      contract_renewals where
      contract_renewals.contract_no = contract.contract_no))
end