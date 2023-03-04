
CREATE PROCEDURE [odps].[OD_RPS_Invoice_Headerv5](
      @contractor int
    , @contract int
    , @start_date datetime
    , @end_date datetime
    , @region int
    , @ctKey int
    , @cname varchar(40))
AS
    -- TJB  RPCR_054 July-2013: NEW
    -- Created from ODPS.Entity.OdpsInvoice.InvoiceHeaderv5
    -- Need @CName to be varchar
    -- (also easier to maintain)
BEGIN
    set CONCAT_NULL_YIELDS_NULL off

	SELECT @start_date as start_date,
	       [contract].contract_no,   
	       contractor.c_gst_number,   
	       [contract].con_title,   
	       contractor.c_surname_company,   
	       contractor.c_first_names,   
	       contractor.c_address,   
	       odps.OD_MiscF_Get_Invoicenumber(invoice_no,@end_date) as invoice_no,   
	       payment.invoice_id,   
	       contractor.contractor_supplier_no,  
	       (isnull(message_for_invoice, (select nat_message_for_invoice from odps.[national] 
					      where nat_id=odps.od_blf_getwhichnational(@end_date))
					    )),   
	       (select count(*) from odps.payment_component_piece_rates, odps.payment_component 
		 where payment_component.pc_id=payment_component_piece_rates.pc_id 
		   and payment_component.invoice_id=payment.invoice_id),   
	       isnull((SELECT max(case when cd_old_ds_no = NULL 
				  then 'RD0'+convert(varchar(20),contractor_ds.contractor_supplier_no) 
				  else cd_old_ds_no end ) 
			 FROM rd.contractor_ds  
			WHERE contractor_ds.contractor_supplier_no = contractor.contractor_supplier_no )
		     ,'RD0'+convert(varchar(20),contractor.contractor_supplier_no)
		     ) as DS_NO,   
	       isnull(message_for_invoice, (select nat_message_for_invoice from odps.[national] 
					     where nat_id=odps.od_blf_getwhichnational(@end_date))
		     ) as invmessage,   
	       (select count(*) from odps.payment_component_piece_rates, odps.payment_component, odps.payment_component_type  
		 where payment_component_type.pct_id= payment_component.pct_id 
		   and pct_description like 'XP%' 
		   and payment_component.pc_id=payment_component_piece_rates.pc_id 
		   and payment_component.invoice_id=payment.invoice_id) xpc
	  FROM odps.payment,   
	       rd.[contract],   
	       rd.contractor,   
	       rd.outlet,
	       rd.types_for_contract
	 WHERE payment.contract_no = [contract].contract_no 
	   AND payment.contractor_supplier_no = contractor.contractor_supplier_no 
	   AND [contract].con_base_office = outlet.outlet_id 
	   AND payment.invoice_date = @end_date 
	   AND types_for_contract.contract_no = [contract].contract_no
	   AND (  (@contractor > 0 AND @contract > 0 
		    AND payment.contractor_supplier_no = @contractor
		    AND payment.contract_no = @contract)
	       OR (@contractor > 0 AND @contract = 0 
		    AND payment.contractor_supplier_no = @contractor) 
	       OR (@contractor = 0 AND @contract > 0
		    AND payment.contract_no = @contract)
	       OR (@contractor = 0 AND @contract = 0) ) 
	   AND ( (outlet.region_id = @region AND @region <> 0) OR @region = 0 ) 
	   AND ( (contractor.c_surname_company like '' + @cname + '%' AND len(@cname) > 0) 
	       OR len(@cname) = 0 )
	   AND ( (types_for_contract.ct_key = @ctKey AND @ctKey <> 0) OR @ctKey = 0 ) 
	 ORDER BY [contract].contract_no ASC

END