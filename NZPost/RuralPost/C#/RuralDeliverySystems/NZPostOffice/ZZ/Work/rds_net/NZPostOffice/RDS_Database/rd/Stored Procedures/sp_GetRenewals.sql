
CREATE procedure [rd].[sp_GetRenewals](
	@in_Contract int)
	
-- TJB RPCR_152 June_2020
--    Added column 'renewal_type to rd.contract_renewals
--    and added it to select list
AS
BEGIN
  set NOCOUNT on
  set CONCAT_NULL_YIELDS_NULL off

  select c.contract_no
       , c.contract_seq_number
       , c.con_start_date
       , c.con_expiry_date
       , c.con_acceptance_flag
       , (select cntr.c_surname_company 
                 + (case when isnull(cntr.c_first_names,'')='' then '' else ', ' end )
                 + isnull(cntr.c_first_names,'')
            from contractor as cntr 
                       join contractor_renewals as cr 
                         on cntr.contractor_supplier_no=cr.contractor_supplier_no
           where cr.contract_no = c.contract_no 
             and cr.contract_seq_number = c.contract_seq_number 
             and cr.cr_effective_date = (select max(cr2.cr_effective_date) 
                                           from contractor_renewals as cr2 
                                          where cr.contract_no = cr2.contract_no 
                                            and cr.contract_seq_number = cr2.contract_seq_number)
         ) as surname_company
       , (case when c.renewal_type is null then 'Renewal' else c.renewal_type end) as renewal_type 
    from contract_renewals as c 
   where c.contract_no = @in_Contract 
   order by c.contract_seq_number desc
   
END