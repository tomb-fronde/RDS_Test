/****** Object:  StoredProcedure [rd].[sp_Get_other_override_rates]    Script Date: 08/05/2008 10:19:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for stored procedure sp_Get_other_override_rates : 
--

create procedure [rd].[sp_Get_other_override_rates](@incontract_no int,@incontract_seq_no int)
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  select misc_override_rate.contract_no,
    misc_override_rate.contract_seq_number,
    misc_override_rate.mor_name,
    misc_override_rate.mor_value,
    misc_override_rate.mor_km_flag,
    misc_override_rate.mor_annual_flag from
    misc_override_rate where
    (misc_override_rate.contract_no = @incontract_no) and
    (misc_override_rate.contract_seq_number = @incontract_seq_no)
end
GO
