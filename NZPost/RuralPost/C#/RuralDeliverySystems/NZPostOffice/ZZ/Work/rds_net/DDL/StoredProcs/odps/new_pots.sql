/****** Object:  StoredProcedure [odps].[new_pots]    Script Date: 08/05/2008 10:13:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--
-- Definition for stored procedure new_pots : 
--

create procedure -- Tim Chan 26/05/2003
-- Initial version - will insert new payment, payment_component entries and rur
[odps].[new_pots](@name char(40),@ird_no char(10),@con_no int,@vendor_id char(10),@supplier_no int,@gross numeric(10,2),@tax numeric(10,2),@gst numeric(10,2),@net numeric(10,2),@invoice_number int,@input_date datetime)
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  declare @li_return_value int,
  @cont_seq int, -- the contract sequence number
  @invoice_id_ int, -- the new invoice number for the payment
  -- declare invoice_no_ int; -- no idea what this is at the moment
  @tax_rate numeric(4,2),
  @invoice_date_ datetime,
  @pr_id_ int,
  @pr_date_ int,
  @contractor_check int,
  @pc_comment char(400),
  @pc_id_ int,
  @tax_ numeric(10,2),
  @gst_ numeric(10,2)
  -- start with a positive return on the return value
  select @li_return_value=1
  -------------------------------------------------------------------------------
  -- insert entry into payment_runs
  -- get new pr_id value
  select @pr_id_ = max(pr.pr_id)+1 from payment_runs as pr
  -- get the next invoice date (the 20th of the month)
  if day(@input_date) <= 20
    -- set the invoice_date to the 20th of this month
    select @invoice_date_=rd.ymd(year(@input_date),month(@input_date),20)
  else
    -- set the invoice_date to the 20th of next month
    select @invoice_date_=rd.ymd(year(@input_date),month(@input_date)+1,20)
  -- put together the pr_date from the invoice_date
  select @pr_date_=convert(int,@invoice_date_)
  insert into payment_runs(pr_id,
    pr_date,gl_posted,pr_ap_posted,pr_contract_no,POTS) values(
    @pr_id_,@pr_date_,'N','N',@con_no,'Y')
  if @@error <> 0 /* <> was < */
    select @li_return_value=-1
  -------------------------------------------------------------------------------
  -- insert entry into payment
  -- get the contract sequenc number from the contractor_renewals table 
  -- max for contractor and contract_no
  select @cont_seq=max(contract_seq_number) 
    from rd.contractor_renewals as con where
    con.contract_no = @con_no and
    con.contractor_supplier_no = @supplier_no
  -- if couldn''t validate a contract sequence number then return failure
  if @cont_seq is null or @cont_seq < 1
    begin
      select @li_return_value=-1
      return @li_return_value
    end
  -- make sure the contract_no and the supplier number match
  select @contractor_check=count(*) 
    from rd.contractor_renewals as cr where
    cr.contractor_supplier_no = @supplier_no and
    cr.contract_no = @con_no
  -- if the count was not higher than  0 - return failure
  if @contractor_check < 1
    select @li_return_value=-1
  -- get the tax rate
  select @tax_rate = cont.c_tax_rate 
    from rd.contractor as cont where
    cont.contractor_supplier_no = @supplier_no
  -- if no tax rate - then set to 0
  if @tax_rate is null
    select @tax_rate=0
  -- get the new payment invoice number
  select @invoice_id_ = max(pay.invoice_id)+1 
    from payment as pay
  -- do insert into payment table
  insert into payment(contractor_supplier_no,
    contract_no,contract_seq_number,invoice_id,pr_id,invoice_date,
    witholding_tax_rate_applied,invoice_no,POTS) values(
    @supplier_no,@con_no,@cont_seq,@invoice_id_,@pr_id_,@invoice_date_,@tax_rate,@invoice_number,'Y')
  -- check for error
  if @@error <> 0 /* <> was < */
    select @li_return_value=-1
  -----------------------------------------------------------------------------------
  -- do inserts into payment_component
  select @pc_id_ = max(pc_id)+1 
    from payment_component
  --** insert the gross **--
  insert into payment_component(pc_id,
    pct_id,invoice_id,pc_amount,comments) values(
    @pc_id_,2,@invoice_id_,@gross,'Payment val(prorata=1.0000000')
  -- check for error
  if @@error <> 0 /* <> was < */
    select @li_return_value=-1
  --** insert the tax **--
  select @pc_id_=@pc_id_+1
  -- will reverse gst regardless
  select @tax_=@tax*-1
  insert into payment_component(pc_id,
    pct_id,invoice_id,pc_amount,comments,misc_string,misc_decimal) values(
    @pc_id_,8,@invoice_id_,@tax_,'Withholding tax - '+convert(varchar,@tax_rate)+'%','Tax rate applied',(@tax_rate/100)*-1)
  -- check for error
  if @@error <> 0 /* <> was < */
    select @li_return_value=-1
  --** insert the gst **--
  select @pc_id_=@pc_id_+1
  -- will reverse gst regardless
  select @gst_=@gst*-1
  insert into payment_component(pc_id,
    pct_id,invoice_id,pc_amount,comments,misc_string,misc_decimal) values(
    @pc_id_,10,@invoice_id_,@gst_,'GST - 12.50% which is standard','GST rate applied',.125)
  -- check for error
  if @@error <> 0 /* <> was < */
    select @li_return_value=-1
  if @li_return_value = -1
    rollback transaction
  return @li_return_value
end
GO
