/****** Object:  StoredProcedure [rd].[sp_CreateTFC]    Script Date: 08/05/2008 10:18:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for stored procedure sp_CreateTFC : 
--

create procedure [rd].[sp_CreateTFC] AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  insert into types_for_contract(contract_no,
    ct_key)
    select contract.contract_no,
      isnull(contract.con_base_cont_type,0) from
      rd.contract where
      0 = (select count(*) from
        rd.types_for_contract as tfc where
        (tfc.ct_key = contract.con_base_cont_type) and
        (tfc.contract_no = contract.contract_no))
end
GO
