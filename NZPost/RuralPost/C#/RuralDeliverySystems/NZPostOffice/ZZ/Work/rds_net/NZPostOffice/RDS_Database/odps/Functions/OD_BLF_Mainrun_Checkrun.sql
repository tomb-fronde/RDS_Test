




--
-- Definition for user-defined function OD_BLF_Mainrun_Checkrun : 
--

create function  [odps].[OD_BLF_Mainrun_Checkrun](@inContract_No int,@inContractor_no int,@inPayPeriod_Start datetime,@inPayPeriod_End datetime)
returns int
AS
BEGIN

 
  declare @v_temp_int int
  declare @v_temp_int2 int
  if @inContract_no > 0
    select @v_temp_int = count(*) 
    from odps.payment where
      (invoice_date between @inPayPeriod_Start and @inPayPeriod_End) and
      (contract_no = @inContract_no) and
      (contractor_supplier_no = @inContractor_no) and
      POTS = 'N'
  else
    select @v_temp_int = count(payment_runs.pr_id) 
    from odps.payment_runs where
      (cast((cast(payment_runs.pr_date as varchar)) as datetime) between @inPayPeriod_Start and @inPayPeriod_End ) and
      (payment_runs.pr_contract_no = @inContract_no) and
      POTS = 'N'
  return(@v_temp_int)
end