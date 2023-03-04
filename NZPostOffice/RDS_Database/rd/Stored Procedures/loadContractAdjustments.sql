
--
-- Definition for stored procedure loadContractAdjustments : 
--

create procedure [rd].[loadContractAdjustments] AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  declare @ll_NextKey int,
  @li_keyseq int,
  @li_contract_no int,
  @ld_date_occured datetime,
  @ln_amount numeric(10,2),
  @ls_reason char(40),
  @li_seq_number int,
  @li_inserts int,
  @li_skipped int,
  @li_errors int,
  @ln_amount_inserted numeric(10,2)
  declare tempCA_crsr cursor for select contract_no,
      ca_date_occured,
      ca_amount,
      ca_reason,
      contract_seq_number from
      rd.temp_Contract_Adjustments for read only
  select @li_keyseq=0
  select @li_inserts=0
  select @li_skipped=0
  select @li_errors=0
  select @ln_amount_inserted=0.0
  begin transaction
  update temp_Contract_Adjustments set
    contract_seq_number = (select con_active_sequence from
      rd.contract as c where
      c.contract_no = temp_Contract_Adjustments.contract_no)
  commit transaction
  begin transaction
  select @ll_NextKey = next_value 
    from rd.Id_Codes where
    sequence_name = 'ContractAdjust'
  commit transaction
  open tempCA_crsr
  /* Watcom only
  copyloop:
  */
  begin transaction
    while 1=1 
    begin
      fetch next from tempCA_crsr into @li_contract_no,@ld_date_occured,@ln_amount,@ls_reason,@li_seq_number
      if @@fetch_status <> 0
        break
        /* Watcom only
        copyloop
        */
      if exists(select 1 from rd.contract_adjustments where
          contract_no = @li_contract_no and
          ca_date_occured = @ld_date_occured and
          ca_reason = @ls_reason and
          ca_amount = @ln_amount)
        select @li_skipped=@li_skipped+1
      else
        begin
          select @li_keyseq=@li_inserts+@ll_NextKey+1
          insert into rd.contract_adjustments(ca_key,
            contract_no,contract_seq_number,ca_date_occured,ca_reason,ca_amount,ca_confirmed) values(
            @li_keyseq,@li_contract_no,@li_seq_number,@ld_date_occured,@ls_reason,@ln_amount,'Y')
          if @@error <> 0
            select @li_errors=@li_errors+1
          else
            begin
              select @li_inserts=@li_inserts+1
              select @ln_amount_inserted=@ln_amount_inserted+@ln_amount
            end
        end
    end
  commit transaction
  begin transaction
  update rd.id_codes set
    next_value = (select max(ca_key)+1 from
      rd.contract_adjustments) where
    sequence_name = 'ContractAdjust'
  commit transaction
  begin transaction
  update rd.ca_load_results set
    rows_inserted = @li_inserts,
    rows_skipped = @li_skipped,
    row_errors = @li_errors,
    amount_inserted = @ln_amount_inserted,
    load_date = getdate() where
    load_name = 'ContractAdjust'
  commit transaction
end