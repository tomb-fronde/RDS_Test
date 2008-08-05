/****** Object:  StoredProcedure [rd].[insert_PTDs]    Script Date: 08/05/2008 10:16:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for stored procedure insert_PTDs : 
--

create procedure [rd].[insert_PTDs](@con_no int,@amount numeric(6,2),@in_description varchar(200)= 'Other - Uniform deduction Dec 03',@in_reference varchar(200))
-- TJB 5-Aug-2004
-- Added in_description and in_reference as optional parameters.  
as -- Default values are as originally hard-coded.
begin
set CONCAT_NULL_YIELDS_NULL off
  declare @max_ded_id int,
  @contractor_id int,
  @pct int
if @in_reference is null select @in_reference =convert(varchar(200),@con_no)
  -- always use the pct_id 6
  select @pct=6
  select @max_ded_id = max(ded_id)+1 
    from odps.post_tax_deductions
  -- get the contractor id
  select @contractor_id = cr.contractor_supplier_no 
    from contractor_renewals as cr where
    cr.contract_no = @con_no and
    cr.contract_seq_number = (select max(cr1.contract_seq_number) from
      contractor_renewals as cr1 where
      cr1.contract_no = @con_no) and
    cr.cr_effective_date = (select max(cr2.cr_effective_date) from
      contractor_renewals as cr2 where
      cr2.contract_no = @con_no)
  insert into odps.post_tax_deductions( --ded_id,
    pct_id,ded_description,ded_reference,ded_type_period,ded_default_minimum,ded_start_balance,contractor_supplier_no) values(
    --@max_ded_id,
@pct,@in_description,@in_reference,'M',@amount,@amount,@contractor_id)
  if @@error <> 0 /* <> was < */
    return-1
  return 1
end
GO
