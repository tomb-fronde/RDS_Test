
CREATE procedure [rd].[sp_GetContractorsContracts](@in_Contractor int)
--
-- TJB  RPCR_045  Jan-2013
-- Added con_date_terminated to returned values
AS
BEGIN
  select distinct
         c.contract_no,
         c.con_title, 
         c.con_date_terminated
    from contract as c,
         contractor_renewals as cr,
         contract_renewals as conr 
   where c.contract_no = cr.contract_no and
         cr.contractor_supplier_no = @in_Contractor and
         conr.contract_no = c.contract_no and
         conr.contract_seq_number = cr.contract_seq_number and
         cr.cr_effective_date = (select max(cr_effective_date) 
                                   from contractor_renewals 
                                  where contract_no = c.contract_no 
                                    and contract_seq_number = conr.contract_seq_number) 
   order by
         c.con_title asc
end