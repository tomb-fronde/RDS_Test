/****** Object:  StoredProcedure [odps].[OD_DWS_OwnerDriver_Search]    Script Date: 08/05/2008 10:13:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



--
-- Definition for stored procedure OD_DWS_OwnerDriver_Search : 
--

create procedure
-- TWC - 11/08/2003 -- changing this procedure to handle contractor / renewal changes
[odps].[OD_DWS_OwnerDriver_Search](@inOwnerDriver varchar(40),@sdate datetime,@edate datetime)
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  select top 1 0,0,odcontracts='<All Contractors/Contracts>',enddate=rd.date(rd.today())  union
  select distinct contract.contract_no,
    contractor.contractor_supplier_no,
    c_surname_company + (case when len(c_first_names) > 0 then ',' + c_first_names else '' end),contractor_end_date=(select dateadd(day,-1,min(crx.cr_effective_date)) from
      rd.contractor_renewals as crx where
      crx.contract_no = contract_renewals.contract_no and
      crx.contract_seq_number = contract_renewals.contract_seq_number and
      crx.cr_effective_date > contractor_renewals.cr_effective_date) from
    rd.contract,
    rd.contract_renewals,
    rd.contractor,
    rd.contractor_renewals where
    (contractor_renewals.contractor_supplier_no = contractor.contractor_supplier_no) and
    (contractor_renewals.contract_no = contract_renewals.contract_no) and
    (contractor_renewals.contract_seq_number = contract_renewals.contract_seq_number) and
    -- TWC - if a renewal has gone through - old renewal may be part of this period
    -- (contract.con_active_sequence = contract_renewals.contract_seq_number) and
    (contract_renewals.contract_seq_number = rd.maxSeqContractor(contractor_renewals.contract_no,contractor_renewals.contractor_supplier_no)) and
    (contract.contract_no = contract_renewals.contract_no) and
    (contractor.c_surname_company like ISNULL(@inOwnerDriver,'') + '%') and
    (contract.con_date_terminated is null or contract.con_date_terminated > @edate or datediff(day,con_date_terminated,@sdate) < 63) and
    (contractor_renewals.cr_effective_date <= @edate) and
    -- check that the end date of the contract is smaller than the end date
    (rd.getContractorEnd(contract.contract_no,contractor.contractor_supplier_no) >= dateadd(month,-2,@sdate)) and
    (/*contractor_end_date*/(select dateadd(day,-1,min(crx.cr_effective_date)) from
      rd.contractor_renewals as crx where
      crx.contract_no = contract_renewals.contract_no and
      crx.contract_seq_number = contract_renewals.contract_seq_number and
      crx.cr_effective_date > contractor_renewals.cr_effective_date) > @edate or /*contractor_end_date*/(select dateadd(day,-1,min(crx.cr_effective_date)) from
      rd.contractor_renewals as crx where
      crx.contract_no = contract_renewals.contract_no and
      crx.contract_seq_number = contract_renewals.contract_seq_number and
      crx.cr_effective_date > contractor_renewals.cr_effective_date) is null or datediff(day,/*contractor_end_date*/(select dateadd(day,-1,min(crx.cr_effective_date)) from
      rd.contractor_renewals as crx where
      crx.contract_no = contract_renewals.contract_no and
      crx.contract_seq_number = contract_renewals.contract_seq_number and
      crx.cr_effective_date > contractor_renewals.cr_effective_date),@sdate) < 63)
end
GO
