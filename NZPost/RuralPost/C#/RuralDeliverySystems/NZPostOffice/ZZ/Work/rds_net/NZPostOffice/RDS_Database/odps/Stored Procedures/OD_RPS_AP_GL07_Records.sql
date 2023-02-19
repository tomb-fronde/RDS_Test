
CREATE procedure [odps].[OD_RPS_AP_GL07_Records](
	@ProcDate datetime)
AS
-- TJB 23-Oct-2013  AP Export File Reformat: New
BEGIN
  set CONCAT_NULL_YIELDS_NULL off

  select Trans_type='AP'
       , Invoice_no_alpha=odps.OD_MiscF_Get_Invoicenumber(payment.invoice_no,@ProcDate)
       , Invoice_date=convert(varchar,invoice_date, 112)
       , Pay_amount=convert(varchar,abs(convert(int,odps.OD_BLF_Get_NetPay(payment.invoice_id,null,null)*100))*-1)
       , Supplier_no=isnull(convert(varchar,supplier_no),' ')
       , Ac_code='420000'
       , Description=' '
    from
         odps.payment left outer join rd.contractor
                  on contractor.contractor_supplier_no = payment.contractor_supplier_no
   where
         exists(select invoice_id from odps.payment_component 
                 where payment.invoice_id = payment_component.invoice_id) 
     and invoice_date = @procdate 
     and convert(decimal,left(convert(varchar,odps.OD_BLF_Get_NetPay(payment.invoice_id,null,null)),21)) <> 0 
--     and supplier_no is not null
   UNION
  select Trans_type=case when ac.ac_code = 160000
                         then 'TX'
                         else 'GL'
                         end
       , Invoice_no_alpha=odps.OD_MiscF_Get_Invoicenumber(p.invoice_no,@procdate)
       , Invoice_date=convert(varchar,p.invoice_date,112)
       , Pay_amount=convert(varchar,convert(int,odps.OD_RPS_AP_Interface_Footer_Amt(p.invoice_id,ac.ac_id)*100))
       , Supplier_no=isnull(convert(varchar,supplier_no),' ')
       , Ac_code=rtrim(ac.ac_code)
       , Description=ac.ac_description
    from
         odps.payment as p left outer join rd.contractor as con
                 on p.contractor_supplier_no = con.contractor_supplier_no
       , rd.contract as c
       , odps.account_codes as ac 
   where
         p.contract_no = c.contract_no
     and p.invoice_date = @procdate 
     and exists(select payment_component_type.pct_id 
                  from odps.payment_component inner join odps.payment_component_type 
                                    on payment_component_type.pct_id = payment_component.pct_id 
                 where payment_component_type.ac_id = ac.ac_id 
                   and payment_component.invoice_id = p.invoice_id) 
     and odps.OD_BLF_Get_NetPay(p.invoice_id,null,null) <> 0 
--     and supplier_no is not null
   order by
         Invoice_no_alpha, Trans_type
end