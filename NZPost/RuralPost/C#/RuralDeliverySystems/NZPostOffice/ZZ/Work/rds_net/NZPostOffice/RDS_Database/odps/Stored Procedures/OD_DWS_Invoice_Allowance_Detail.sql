
CREATE PROCEDURE  odps.OD_DWS_Invoice_Allowance_Detail(
	@inContractorNo int,
	@inContractNo int,
	@inEdate datetime,
	@inRegion int,
	@inCtKey int)
as
begin
-- TJB RPCR056, Aug 2013: Bug fix
-- Added 'Arrear' condition to allowance breakdown selection
-- Any allowance arrears show up in the Taxable allowances details
--
-- TJB RPCR056, June 2013
-- This code populates the t_invoice_allowances table from the odps.payment_component table
-- Called from the WInvoiceSearch.cs when preparing invoices
-- Adapted from OD_DWS_OwnerDriver_Search_Region_v2

  create table #con_temp (
      contract_no int null
    , invoice_id  int null
    ) 

  -- Find contracts matching input selection criteria
  -- Insert these contract numbers into the temp table along with their associated invoice ID's
  insert into #con_temp(
           contract_no 
         , invoice_id
         )
    select distinct 
           contract.contract_no
         , payment.invoice_id
      from rd.contract,
           rd.contract_renewals,
           rd.contractor,
           rd.contractor_renewals,
           rd.outlet,
           rd.types_for_contract ,
           odps.payment
     where
           contractor_renewals.contractor_supplier_no = contractor.contractor_supplier_no
       and contractor_renewals.contract_no = contract_renewals.contract_no 
       and contractor_renewals.contract_seq_number = contract_renewals.contract_seq_number 
       and contract.contract_no = contract_renewals.contract_no
       and (@inContractorNo is null or @inContractorNo = 0 
            or (@inContractorNo <> 0 and contractor.contractor_supplier_no = @inContractorNo))
       and (@inContractNo is null or @inContractNo = 0 
            or (@inContractNo <> 0 and contract.contract_no = @inContractNo))
       and (@inCtKey is null or @inCtKey = 0 
            or (@inCtKey <> 0 and types_for_contract.ct_key = @inCtKey)) 
       and types_for_contract.contract_no = contract.contract_no 
       and con_base_office = outlet_id 
       and ((region_id = @inRegion and @inRegion <> 0) 
             or @inRegion is null or @inRegion = 0)
       and payment.contract_no = contractor_renewals.contract_no
       and payment.invoice_date = @inEdate 
     order by invoice_id
       
  -- Prepare t_invoice_allowances
  truncate table odps.t_invoice_allowances

  -- Summarise the allowances by contract/invoice and allowance type using the contracts 
  -- identified above as the selection criteria.
  insert into odps.t_invoice_allowances
     (contract_no, invoice_id, alt_key, alt_description, amount)
  select ct.contract_no, pc.invoice_id, pc.alt_key, alt.alt_description, sum(pc.pc_amount) as allowance
    from odps.payment_component pc
       , rd.allowance_type alt
       , #con_temp ct
   where pc.invoice_id = ct.invoice_id
     and left(pc.comments,6) <> 'Arrear'
     and pc.alt_key is not null
     and alt.alt_key = pc.alt_key
   group by ct.contract_no, pc.invoice_id, pc.alt_key, alt.alt_description
   order by invoice_id, pc.alt_key

  -- Remove any entries where the allowance is 0 (or close to it).
  delete from odps.t_invoice_allowances
   where abs(amount) < 0.10

  -- Drop the temp table
  drop table #con_temp

  -- Return the number of allowances found
  select count(*) from odps.t_invoice_allowances
  
end