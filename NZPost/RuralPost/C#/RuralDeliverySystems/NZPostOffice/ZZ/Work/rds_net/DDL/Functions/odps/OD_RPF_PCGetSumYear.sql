/****** Object:  UserDefinedFunction [odps].[OD_RPF_PCGetSumYear]    Script Date: 08/05/2008 11:22:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for user-defined function OD_RPF_PCGetSumYear : 
--

create function [odps].[OD_RPF_PCGetSumYear](@con_supplier int,@contract int,@con_seq_no int,@sdate datetime,@edate datetime,@ShortCode char(5),@NZPostEmp char(1)=
null)
returns numeric(12,2)
AS
BEGIN

  -- TJB SR4611 2 Aug 2004
  -- Add clauses to calculate taxable allowances sttributed to NZH (NZ Herald)
  -- and Guardian (amt2), then deduct this from the gross pay calculated (amt1).
  -- Note: if the '... not like ...' clauses are included in the gross pay
  -- statement, rows with NULL values in the misc_string column are also excluded.
  declare @amt1 numeric(12,2),
  @amt2 numeric(12,2)
  if @NZPostEmp is null
    begin
      select @amt1 = sum(payment_component.pc_amount) 
        from payment,payment_component,payment_component_type,
        payment_component_group where
        payment.contractor_supplier_no = @con_supplier and
        payment.contract_no = @contract and
        --Removed for net pay variance report testing 19/7/2000
        -- |note by JJG - including the next line screws up the net pay variance report
        -- |excluding the next line screws up the yearly earnings report
        payment.contract_seq_number = @con_seq_no and
        payment.invoice_id = payment_component.invoice_id and
        payment_component.pct_id = payment_component_type.pct_id and
        --Added 16/09/1999
        -- This stops it from adding Kiwimail, Courierpost and XP, so that the extension,
        -- Standard and allowance are the only values that are calculated.  
        -- TJB 2-Aug-2004 - changed to 'not in ...' syntax
        payment_component_type.pct_id not in(7,9,13) and
        payment_component_type.pcg_id = payment_component_group.pcg_id and
        payment_component_group.pcg_short_code = @ShortCode and
        payment.invoice_date between @sdate and @edate
      -- TJB SR4611 2 Aug 2004
      select @amt2 = sum(payment_component.pc_amount) 
        from payment,payment_component,payment_component_type,
        payment_component_group where
        payment.contractor_supplier_no = @con_supplier and
        payment.contract_no = @contract and
        payment.contract_seq_number = @con_seq_no and
        payment.invoice_id = payment_component.invoice_id and
        payment_component.pct_id = payment_component_type.pct_id and
        payment_component_type.pcg_id = payment_component_group.pcg_id and
        payment_component_group.pcg_short_code = @ShortCode and
        payment.invoice_date between @sdate and @edate and
        payment_component.pct_id not in(7,9,13) and
        (payment_component.misc_string like '%NZH%' or
        payment_component.misc_string like '%Guardian%')
      select @amt1=iSnull(@amt1,0) - iSnull(@amt2,0)
    end
  else
    if upper(@NZPostEmp) = 'Y'
      begin
        select @amt1 = sum(payment_component.pc_amount) 
          from payment,rd.contractor,payment_component,payment_component_type,
          payment_component_group where
          payment.contractor_supplier_no = @con_supplier and
          payment.contract_no = @contract and
          payment.contract_seq_number = @con_seq_no and
          payment.contractor_supplier_no = contractor.contractor_supplier_no and
          payment.invoice_id = payment_component.invoice_id and
          payment_component.pct_id = payment_component_type.pct_id and
          --Added 16/09/1999
          -- This stops it from adding Kiwimail, Courierpost and XP, so that the extension,
          -- Standard and allowance are the only values that are calculated.  
          -- TJB 2-Aug-2004 - changed to 'not in ...' syntax
          payment_component_type.pct_id not in(7,9,13) and
          payment_component_type.pcg_id = payment_component_group.pcg_id and
          payment_component_group.pcg_short_code = @ShortCode and
          contractor.nz_post_employee = 'Y' and
          payment.invoice_date between @sdate and @edate
        -- TJB SR4611 2 Aug 2004
        select @amt2 = sum(payment_component.pc_amount) 
          from payment,rd.contractor,payment_component,
          payment_component_type,payment_component_group where
          payment.contractor_supplier_no = @con_supplier and
          payment.contract_no = @contract and
          payment.contract_seq_number = @con_seq_no and
          payment.contractor_supplier_no = contractor.contractor_supplier_no and
          payment.invoice_id = payment_component.invoice_id and
          payment_component.pct_id = payment_component_type.pct_id and
          payment_component.pct_id not in(7,9,13) and
          payment_component_type.pcg_id = payment_component_group.pcg_id and
          payment_component_group.pcg_short_code = @ShortCode and
          contractor.nz_post_employee = 'Y' and
          payment.invoice_date between @sdate and @edate and
          (payment_component.misc_string like '%NZH%' or
          payment_component.misc_string like '%Guardian%')
        select @amt1=isnull(@amt1,0) - isnull(@amt2,0)
      end
    else
      begin
        select @amt1 = sum(payment_component.pc_amount) 
          from payment,rd.contractor,payment_component,payment_component_type,
          payment_component_group where
          payment.contractor_supplier_no = @con_supplier and
          payment.contract_no = @contract and
          payment.contract_seq_number = @con_seq_no and
          payment.contractor_supplier_no = contractor.contractor_supplier_no and
          payment.invoice_id = payment_component.invoice_id and
          payment_component.pct_id = payment_component_type.pct_id and
          --Added 16/09/1999
          -- This stops it from adding Kiwimail, Courierpost and XP, so that the extension,
          -- Standard and allowance are the only values that are calculated.  
          -- TJB 2-Aug-2004 - changed to 'not in ...' syntax
          payment_component_type.pct_id not in(7,9,13) and
          payment_component_type.pcg_id = payment_component_group.pcg_id and
          payment_component_group.pcg_short_code = @ShortCode and
          (contractor.nz_post_employee = 'N' or contractor.nz_post_employee is null) and
          payment.invoice_date between @sdate and @edate
        -- TJB SR4611 2 Aug 2004
        select @amt2 = sum(payment_component.pc_amount) 
          from payment,rd.contractor,payment_component,
          payment_component_type,payment_component_group where
          payment.contractor_supplier_no = @con_supplier and
          payment.contract_no = @contract and
          payment.contract_seq_number = @con_seq_no and
          payment.contractor_supplier_no = contractor.contractor_supplier_no and
          payment.invoice_id = payment_component.invoice_id and
          payment_component.pct_id = payment_component_type.pct_id and
          payment_component.pct_id not in(7,9,13) and
          payment_component_type.pcg_id = payment_component_group.pcg_id and
          payment_component_group.pcg_short_code = @ShortCode and
          (contractor.nz_post_employee = 'N' or
          contractor.nz_post_employee is null) and
          payment.invoice_date between @sdate and @edate and
          (payment_component.misc_string like '%NZH%' or
          payment_component.misc_string like '%Guardian%')
        select @amt1=isnull(@amt1,0)-isnull(@amt2,0)
      end
  return @amt1
end
GO
