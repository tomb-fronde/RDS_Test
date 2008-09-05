/****** Object:  StoredProcedure [rd].[temp_LoadContractAdjustments]    Script Date: 08/05/2008 10:23:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [rd].[temp_LoadContractAdjustments] AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  declare @ll_NextKey integer
  update temp_Contract_Adjustments set
    contract_seq_number = (select con_active_sequence from contract as c where c.contract_no = temp_Contract_Adjustments.contract_no)
  select @ll_NextKey = next_value 
    from Id_Codes where
    sequence_name = 'ContractAdjust'
  insert into contract_adjustments(ca_key,
    contract_no,
    contract_seq_number,
    ca_date_occured,
    ca_reason,
    ca_amount,
    ca_confirmed)
    select ROW_NUMBER() OVER (ORDER BY contract_no ASC) + @ll_NextKey,  --! was number(*)+ @ll_NextKey in ASA
      contract_no,
      contract_seq_number,
      ca_date_occured,
      ca_reason,
      ca_amount,'Y' from
      temp_Contract_Adjustments
  update id_codes set
    next_value = (select max(ca_key)+1 from contract_adjustments) where
    sequence_name = 'ContractAdjust'
end
GO
