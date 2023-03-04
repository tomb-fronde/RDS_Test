create procedure [rd].[sp_Contractor](@inContract int,@inRenewal int)
AS
BEGIN
  select contractor.c_surname_company,
    contractor.c_first_names,
    contractor.c_address,
    contractor.c_phone_night 
    from
/*    contractor as con join contractor_renewals as corr on con.contractor_supplier_no = corr.contractor_supplier_no,
    corr join contract_renewals as cotr on  */
    contractor  join contractor_renewals  on contractor.contractor_supplier_no = contractor_renewals.contractor_supplier_no
	 join contract_renewals on 
    contractor_renewals.contract_no = contract_renewals.contract_no and
    contractor_renewals.contract_seq_number = contract_renewals.contract_seq_number and
    contractor_renewals.cr_effective_date = contract_renewals.con_date_last_assigned and
    contract_renewals.contract_no = @inContract and
    contract_renewals.contract_seq_number = @inRenewal
end