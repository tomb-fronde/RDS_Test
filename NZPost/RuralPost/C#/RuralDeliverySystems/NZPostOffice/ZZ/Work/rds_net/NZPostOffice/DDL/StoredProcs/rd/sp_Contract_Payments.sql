/****** Object:  StoredProcedure [rd].[sp_Contract_Payments]    Script Date: 08/05/2008 10:17:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for stored procedure sp_Contract_Payments : 
--

create procedure [rd].[sp_Contract_Payments](@inContract int,@inRenewal int)
AS
BEGIN
  select contract_renewals.con_renewal_payment_value,'Renewal Price',
    1 from
    contract_renewals where
    contract_renewals.contract_no = @inContract and
    contract_renewals.contract_seq_number = @inRenewal union
  select sum(contract_allowance.ca_annual_amount),
    allowance_type.alt_description,
    2 from
    contract_allowance join
    allowance_type on
    contract_allowance.alt_key = allowance_type.alt_key where
    contract_allowance.contract_no = @inContract
    group by allowance_type.alt_description union
  select sum(contract_adjustments.ca_amount),'Contract Adjustments',
    3 from
    contract_renewals join
    contract on
    contract_renewals.contract_no = contract.contract_no join
    contract_adjustments on
    contract_renewals.contract_no = contract_adjustments.contract_no and
    contract_renewals.contract_seq_number = contract_adjustments.contract_seq_number where
    contract_adjustments.ca_confirmed = 'Y' and
    contract_renewals.contract_no = @inContract and
    contract_renewals.contract_seq_number = @inRenewal union
  select sum(frequency_adjustments.fd_adjustment_amount),'Extensions',
    4 from
    contract_renewals join
    contract on
    contract_renewals.contract_no = contract.contract_no join
    frequency_adjustments on
    contract_renewals.contract_no = frequency_adjustments.contract_no and
    contract_renewals.contract_seq_number = frequency_adjustments.contract_seq_number where
    frequency_adjustments.fd_confirmed = 'Y' and
    contract_renewals.contract_no = @inContract and
    contract_renewals.contract_seq_number = @inRenewal
end
GO
