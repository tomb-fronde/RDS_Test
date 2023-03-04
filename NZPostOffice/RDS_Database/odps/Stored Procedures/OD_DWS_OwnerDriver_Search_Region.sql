

--
-- Definition for stored procedure OD_DWS_OwnerDriver_Search_Region : 
--

create procedure [odps].[OD_DWS_OwnerDriver_Search_Region](@inOwnerDriver varchar(40),@inRegion int,@sdate datetime,@edate datetime)
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  -- insert into temporary table
  create table #con_temp(
    con_no int null,
    supply int null,
    detail char(100) null,
    ) 
  insert into #con_temp(con_no,
    supply,detail)
    select 0,0,odcontracts='<All Contractors/Contracts>'
  insert into #con_temp(con_no,
    supply,detail)
    select contract.contract_no,
      contractor.contractor_supplier_no,
      c_surname_company + ISNULL(case when len(c_first_names) > 0 then ',' + c_first_names
      end,'') from rd.contract,
      rd.contract_renewals,
      rd.contractor,
      rd.contractor_renewals,
      rd.outlet where
      (contractor_renewals.contractor_supplier_no = contractor.contractor_supplier_no) and
      (contractor_renewals.contract_no = contract_renewals.contract_no) and
      (contractor_renewals.contract_seq_number = contract_renewals.contract_seq_number) and
      --Commented out 8/11/00, this stops the previous contract holder from being retrieved    
      --and(contract.con_active_sequence=contract_renewals.contract_seq_number)
      (contract.contract_no = contract_renewals.contract_no) and
      (contractor.c_surname_company like @inOwnerDriver + '%') and
      (con_base_office = outlet_id) and
      -- SR#4478 PBY 18/01/03 Also testing for NULL
      -- and((region_id=inRegion and inRegion<>0) or(inRegion=0))
      ((region_id = @inRegion and @inRegion <> 0) or @inRegion is null or @inRegion = 0) and
      exists(select 1 from odps.payment  where payment.contract_no = contract.contract_no and invoice_date = @edate and
        payment.contractor_supplier_no = contractor.contractor_supplier_no)
  select distinct con_no,supply,detail from
    #con_temp order by
    con_no asc
end