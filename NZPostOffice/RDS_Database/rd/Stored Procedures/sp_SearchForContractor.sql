
CREATE procedure [rd].[sp_SearchForContractor](
	 @in_ContractorSupplierNo int
	,@in_ContractNo int
	,@in_ct_key int
	,@in_region_id int
	,@in_c_surname_company varchar(40)
	,@in_c_first_names varchar(40)
	,@in_c_phone_day varchar(11))
AS
BEGIN
  -- TJB  RPCR_140  June-2019
  -- If both a contract number and contract type have been specified, 
  -- set the contract type to 0 (any)
  
  set nocount on
  set CONCAT_NULL_YIELDS_NULL off

  declare @nCtKey int;
  
  if (@in_ct_key > 0 and @in_ContractNo > 0)
      select @in_ct_key = 0
  
  select c.contractor_supplier_no,
         contractor_name=c.c_surname_company 
                         + case when c.c_first_names is null 
                                then case when c.c_initials is null 
                                          then '' 
                                          else ', ' + c.c_initials 
                                          end 
                                else ', ' + c.c_first_names 
                                end,
         (select top 1 cr_effective_date 
            from contractor_renewals 
           where contractor_supplier_no = c.contractor_supplier_no) 
    from contractor as c 
   where (@in_ContractorSupplierNo = 0 or c.contractor_supplier_no = @in_ContractorSupplierNo) 
     and (@in_ContractNo = 0 
           or (select count(*) from contractor_renewals 
               where contract_no = @in_ContractNo 
                 and contractor_supplier_no = c.contractor_supplier_no) 
               > 0) 
     and (@in_ct_key = 0 
          or (select count(*) from types_for_contractor 
               where ct_key = @in_ct_key 
                 and contractor_supplier_no = c.contractor_supplier_no) 
              > 0) 
     and (@in_region_id = 0 
          or (select count(*) from contractor_renewals as cr, contract as con, outlet as o 
               where c.contractor_supplier_no = cr.contractor_supplier_no 
                 and cr.contract_no = con.contract_no 
                 and con.con_base_office = o.outlet_id 
                 and o.region_id = @in_region_id) 
              > 0) 
     and (@in_c_surname_company = '' 
          or c_surname_company like @in_c_surname_company + '%') 
     and (@in_c_first_names = '' 
          or c_first_names like @in_c_first_names + '%') 
     and (@in_c_phone_day = '' 
          or c_phone_day like @in_c_phone_day + '%') 
   order by contractor_name asc

end