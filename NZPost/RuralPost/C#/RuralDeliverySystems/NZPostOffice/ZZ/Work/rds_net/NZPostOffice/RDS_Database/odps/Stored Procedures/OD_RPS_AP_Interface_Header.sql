
CREATE PROCEDURE [odps].[OD_RPS_AP_Interface_Header](
	@ProcDate datetime)
AS
-- TJB 23-Oct-2013  AP Export File Reformat
-- Add supplier_no to returned values
BEGIN
  set CONCAT_NULL_YIELDS_NULL off

  select transaction_id_1='PRQT'
       , vendor_2=left(isnull((select max(cd_old_ds_no) 
                                 from rd.contractor left outer join rd.contractor_ds 
                                         on contractor.contractor_supplier_no = contractor_ds.contractor_supplier_no 
                                where contractor.contractor_supplier_no = contractor_ds.contractor_supplier_no 
                                  and contractor.contractor_supplier_no = payment.contractor_supplier_no)
                             , 'RD0' + convert(varchar,payment.contractor_supplier_no)),11)
       , vendor_location_3=' '
       , Invoice_no_4=odps.OD_MiscF_Get_Invoicenumber(payment.invoice_no,@ProcDate)
       , invoice_date_5=convert(varchar,invoice_date, 112)
       , payment_number_6=0
       , column_7='BAT'
       , column_8=' '
       , column_9=' ', column_10=' '
       , column_11=' '
       , invoice_date_12=convert(varchar,invoice_date,112)
       , column_13=' '
       , column_14=' ', column_15=' ', column_16=' '
       , column_17=' '
       , NetPay_18=left(convert(varchar,odps.OD_BLF_Get_NetPay(payment.invoice_id,null,null)),21)
       , LastDayofMonth_19=convert(varchar,odps.OD_MiscF_GetLastDayofMonth(@Procdate),112)
       , column_20=' '
       , column_21=' ', column_22=' ', column_23=' '
       , column_24=' '
       , column_25='MAILC'
       , invoice_date_26=convert(varchar,invoice_date,112)
       , column_27=' '
       , column_28=' '
       , supplier_no_29=isnull(convert(varchar,supplier_no),' ')
       , column_30=' '
       , column_31=' ', column_32=' ', column_33=' '
       , column_34=' ', column_35=' ', column_36=' ', column_37=' ', column_38=' ', column_39=' '
       , column_40=' ', column_41=' ', column_42=' ', column_43=' ', column_44=' ', column_45=' '
       , column_46=' ', column_47=' ', column_48=' ', column_49=' ', column_50=' ', column_51=' '
       , column_52=' ', column_53=' ', column_54=' ', column_55=' ', column_56=' ', column_57=' '
       , column_58=' ' 
    from
         odps.payment left outer join rd.contractor
                  on contractor.contractor_supplier_no = payment.contractor_supplier_no
   where
         exists(select invoice_id from odps.payment_component 
                 where payment.invoice_id = payment_component.invoice_id) 
     and invoice_date = @procdate 
     and convert(decimal,left(convert(varchar,odps.OD_BLF_Get_NetPay(payment.invoice_id,null,null)),21)) <> 0 
   order by
         invoice_id asc
end