
--
-- Definition for user-defined function OD_RPF_PCGetSumYear_spec : 
--

create function [odps].[OD_RPF_PCGetSumYear_spec](@con_supplier int,@contract int,@con_seq_no int,@sdate datetime,@edate datetime,@ShortCode char(5),@NZPostEmp char(1)= null)
returns numeric(12,2)AS
BEGIN

  declare @amt numeric(12,2)
  if @NZPostEmp is null
    select @amt = sum(payment_component.pc_amount)  
      from payment,payment_component,payment_component_type,payment_component_group where
      payment.contractor_supplier_no = @con_supplier and
      payment.contract_no = @contract and
      --Removed for net pay variance report testing 19/7/2000
      -- |note by JJG - including the next line screws up the net pay variance report
      -- |excluding the next line screws up the yearly earnings report
      payment.contract_seq_number = @con_seq_no and
      payment.invoice_id = payment_component.invoice_id and
      payment_component.pct_id = payment_component_type.pct_id and
      --Added 16/09/1999,this stops it from adding Kiwimail ,Courierpost and XP.
      --So that the extension ,Standard and allowance are the only values that are 
      --calculated.  
      payment_component_type.pct_id <> 7 and
      payment_component_type.pct_id <> 9 and
      payment_component_type.pct_id <> 13 and
      payment_component_type.pcg_id = payment_component_group.pcg_id and
      payment_component_group.pcg_short_code = @ShortCode and
      payment.invoice_date between @sdate and @edate
  else
    if upper(@NZPostEmp) = 'Y'
      select @amt = sum(payment_component.pc_amount) 
        from payment,rd.contractor,payment_component,payment_component_type,payment_component_group where
        payment.contractor_supplier_no = @con_supplier and
        payment.contract_no = @contract and
        payment.contract_seq_number = @con_seq_no and
        payment.contractor_supplier_no = contractor.contractor_supplier_no and
        payment.invoice_id = payment_component.invoice_id and
        payment_component.pct_id = payment_component_type.pct_id and
        --Added 16/09/1999,this stops it from adding Kiwimail ,Courierpost and XP.
        --So that the extension ,Standard and allowance are the only values that are 
        --calculated.  
        payment_component_type.pct_id <> 7 and
        payment_component_type.pct_id <> 9 and
        payment_component_type.pct_id <> 13 and
        payment_component_type.pcg_id = payment_component_group.pcg_id and
        payment_component_group.pcg_short_code = @ShortCode and
        contractor.nz_post_employee = 'Y' and
        payment.invoice_date between @sdate and @edate
    else
      select @amt = sum(payment_component.pc_amount) 
        from payment,rd.contractor,payment_component,payment_component_type,payment_component_group where
        payment.contractor_supplier_no = @con_supplier and
        payment.contract_no = @contract and
        payment.contract_seq_number = @con_seq_no and
        payment.contractor_supplier_no = contractor.contractor_supplier_no and
        payment.invoice_id = payment_component.invoice_id and
        payment_component.pct_id = payment_component_type.pct_id and
        --Added 16/09/1999,this stops it from adding Kiwimail ,Courierpost and XP.
        --So that the extension ,Standard and allowance are the only values that are 
        --calculated.  
        payment_component_type.pct_id <> 7 and
        payment_component_type.pct_id <> 9 and
        payment_component_type.pct_id <> 13 and
        payment_component_type.pcg_id = payment_component_group.pcg_id and
        payment_component_group.pcg_short_code = @ShortCode and
        (contractor.nz_post_employee = 'N' or contractor.nz_post_employee is null) and
        payment.invoice_date between @sdate and @edate
  if @amt is null
    return 0
  else
    return @amt
return -1
end