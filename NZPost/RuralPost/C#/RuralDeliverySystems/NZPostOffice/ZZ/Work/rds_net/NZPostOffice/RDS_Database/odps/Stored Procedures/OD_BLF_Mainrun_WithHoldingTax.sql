create procedure [odps].[OD_BLF_Mainrun_WithHoldingTax]
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  declare @v_pcfaker integer,
  @v_ctr integer,
  @v_invoiceid integer,
  @v_taxrate decimal(12,4),
  @v_gross decimal(12,2)
  declare vc_invoice_list cursor for select invoice_id,(witholding_tax_rate_applied/100.0)*-1.0 from t_payment
  select @v_pcfaker = count(*) from t_payment_component
  if @v_pcfaker is null		--2008
		set @v_pcfaker= 0	--2008
  DBCC CHECKIDENT ('odps.t_payment_component', RESEED, @v_pcfaker)  --2008
  select @v_ctr=0

  open vc_invoice_list
  /* Watcom only
  iloop:
  */while 1=1 
    begin
      fetch next from vc_invoice_list into @v_invoiceid,@v_taxrate
      if @@error <> 0
        begin
          rollback transaction
          return(-808)
        end
      if @v_taxrate is null
        select @v_taxrate=0
      if @@FETCH_STATUS <0
        break
        /* Watcom only
        iloop
        */
      select @v_ctr=@v_ctr+1
      select @v_gross = sum(tpc.pc_amount) from t_payment_component as tpc where tpc.invoice_id = @v_invoiceid
      insert into t_payment_component(/*pc_id,*/ --Cannot insert explicit value for identity column in table 't_payment_component' when IDENTITY_INSERT is set to OFF.
        pct_id,
        invoice_id,
        pc_amount,comments,misc_string,misc_decimal)
        select /*@v_pcfaker+@v_ctr,*/ 
          (select pct_id from payment_component_type where pct_description like 'Withholding Tax%'),
          t_payment.invoice_id,
          (@v_gross)*@v_taxrate,'Withholding Tax - ' + 
          convert(varchar,t_payment.witholding_tax_rate_applied) + '%','Tax rate applied',@v_taxrate from
          t_payment where
          t_payment.invoice_id = @v_invoiceid and
          exists(select tc.pc_amount from t_payment_component as tc,payment_component_type as pctt where
            tc.pct_id = pctt.pct_id and pctt.pct_description not like 'Post-Tax%' and tc.invoice_id = @v_invoiceid and tc.pc_amount > 0)
      if @@error <> 0
		begin
		rollback transaction
        return(@@error)
		end
    end
  close vc_invoice_list
deallocate vc_invoice_list
  if @@error <> 0
    begin
      rollback transaction
      return(-101)
    end
--!commit transaction
  return(0)
/* Watcom only
exception
  when others then
    rollback transaction
    resignal
    return(-1)
*/
end