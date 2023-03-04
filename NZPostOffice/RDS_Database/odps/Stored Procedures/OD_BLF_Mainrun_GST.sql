
--
-- Definition for stored procedure OD_BLF_Mainrun_GST : 
--

CREATE procedure  [odps].[OD_BLF_Mainrun_GST]
-- 
-- TJB RD7_0016  Jan 2009
-- Status returned to C# app via result set (not return code!).  Return codes as varchar.
-- Create temporary table to get error message from PostTaxAdj and return in result set.
-- Note change: only OD_BLF_MainRun begins and commits/rollsback transaction(s).
-- 
AS
BEGIN
  set CONCAT_NULL_YIELDS_NULL off
  
  declare @v_pcfaker int,
          @v_ctr int,
          @v_invoiceid int,
          @v_taxrate numeric(12,2),
          @v_pct int
          
  -- begin transaction
  
  declare vc_invoice_list2 cursor for 
      select invoice_id from t_payment
      
  select @v_pct = pct_id from payment_component_type 
   where pct_description like 'GST%' 
      or pct_description like 'Goods and Services Tax%'
      
  select @v_pcfaker = max(pc_id) from t_payment_component
  
  if @v_pcfaker is null         --2008
      set @v_pcfaker = 0
      
  DBCC CHECKIDENT ('odps.t_payment_component', RESEED, @v_pcfaker)  --2008

  select @v_ctr=0
  select @v_taxrate=0.0

  open vc_invoice_list2
  
  /* Watcom only iloop2: */
  while 1=1 
  begin
      fetch next from vc_invoice_list2 into @v_invoiceid

      if @@error <> 0
      begin
          deallocate vc_invoice_list2
          -- rollback transaction
          return (-909)
      end
      
      /* Watcom only iloop2 */
      if @@FETCH_STATUS < 0
          break

      select @v_ctr=@v_ctr+1
  
      insert into t_payment_component
         (/*pc_id,*/    -- Cannot insert explicit value for identity column in table 
                        -- 't_payment_component' when IDENTITY_INSERT is set to OFF.
              pct_id, invoice_id, pc_amount, comments, misc_string, misc_decimal)
         select /*@v_pcfaker+@v_ctr,*/
                @v_pct,
                @v_invoiceid,
                (select sum(pc_amount) from t_payment_component as tpc, payment_component_type 
                  where tpc.invoice_id = @v_invoiceid and
                        tpc.pct_id = payment_component_type.pct_id and
                        (pct_description not like 'Withholding%' and pct_description not like 'Post-Tax%'))*
                                    (select isnull(nat_od_standard_gst_rate,12.5)/100 
                                       from odps."national" 
                                      where nat_id = odps.od_blf_getwhichnational(t_payment.invoice_date)),
                'GST - ' + (select case when nat_od_standard_gst_rate is not null 
                                        then convert(varchar(40),nat_od_standard_gst_rate) 
                                                          + '% which is the standard rate in the national table'
                                        else 'set to 12.50% because the standard rate in the national table is null' 
                                   end 
                              from odps."national" 
                             where nat_id = odps.od_blf_getwhichnational(t_payment.invoice_date)),
                'GST rate applied',
                (select isnull(nat_od_standard_gst_rate,12.5)/100 
                   from odps."national" 
                  where nat_id = odps.od_blf_getwhichnational(t_payment.invoice_date)) 
           from t_payment, rd.contractor 
          where t_payment.invoice_id = @v_invoiceid and
                contractor.contractor_supplier_no = t_payment.contractor_supplier_no and
                len(rtrim(ltrim(c_gst_number))) > 0 and
                exists( select pc_amount from t_payment_component as tc 
                         where tc.invoice_id = @v_invoiceid)
      if @@ERROR <> 0
      begin
          deallocate vc_invoice_list2
          -- rollback transaction
          return (@@ERROR)
      end
  end

  close vc_invoice_list2

  if @@ERROR <> 0
  begin
      deallocate vc_invoice_list2
      -- rollback transaction
      return (-101)
  end

  deallocate vc_invoice_list2
  -- commit transaction
  return (0)

  /* Watcom only
  -- exception
  --     when others then
  --         rollback transaction
  --         resignal
  --         return(-1)
  */
END