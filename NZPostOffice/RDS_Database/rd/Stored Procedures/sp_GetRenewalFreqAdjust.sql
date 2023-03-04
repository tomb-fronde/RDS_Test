
--
-- Definition for stored procedure sp_GetRenewalFreqAdjust : 
--

create procedure [rd].[sp_GetRenewalFreqAdjust](
@in_Contract int,
@in_Sequence int)
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  select frequency_adjustments.contract_no,
    frequency_adjustments.contract_seq_number,
    frequency_adjustments.fd_unique_seq_number,
    frequency_adjustments.fd_adjustment_amount,
    frequency_adjustments.fd_paid_to_date,
    frequency_adjustments.fd_bm_after_extn,
    frequency_adjustments.fd_confirmed,line_type='D',
    frequency_adjustments.fd_amount_to_pay from
    frequency_adjustments where
    frequency_adjustments.contract_no = @in_Contract and
    frequency_adjustments.contract_seq_number =@in_Sequence --modify inSequence to @in_sequency by jlwang_msd 
union all
  select frequency_adjustments.contract_no,
    frequency_adjustments.contract_seq_number,
    null,
    sum(frequency_adjustments.fd_adjustment_amount),
    null,
    null,'T','S',
    sum(frequency_adjustments.fd_amount_to_pay) from
    frequency_adjustments where
    frequency_adjustments.contract_no = @in_Contract and
    frequency_adjustments.contract_seq_number = @in_Sequence --modify inSequence to @in_sequency by jlwang_msd 

    group by frequency_adjustments.contract_no,frequency_adjustments.contract_seq_number order by
    1 desc,2 desc,8 asc
end