/****** Object:  StoredProcedure [odps].[OD_RPS_AuditContractsOwnerDriver]    Script Date: 08/05/2008 10:13:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for stored procedure OD_RPS_AuditContractsOwnerDriver : 
--

create procedure [odps].[OD_RPS_AuditContractsOwnerDriver](@sdate datetime,@edate datetime)
as
select contractor_renewals.contract_no,
  contractor.c_surname_company,
  contractor.c_first_names,
  contractor.c_initials,'New Contractor',
  contract_renewals.con_start_date,
  contract_renewals.con_expiry_date from
  rd.contractor_renewals,rd.contract_renewals,rd.contractor where
  contractor_renewals.contract_no = contract_renewals.contract_no and
  contractor_renewals.contract_seq_number = contract_renewals.contract_seq_number and
  contractor_renewals.contractor_supplier_no = contractor.contractor_supplier_no and
  contractor_renewals.cr_effective_date between @sdate and @edate union
select contractor_renewals.contract_no,
  contractor.c_surname_company,
  contractor.c_first_names,
  contractor.c_initials,Status='New Contract',
  contract_renewals.con_start_date,
  contract_renewals.con_expiry_date from
  rd.contractor_renewals,rd.contract_renewals,rd.contractor where
  contractor_renewals.contract_no = contract_renewals.contract_no and
  contractor_renewals.contract_seq_number = contract_renewals.contract_seq_number and
  contractor_renewals.contractor_supplier_no = contractor.contractor_supplier_no and
  contract_renewals.con_start_date between @sdate and @edate union
select contractor_renewals.contract_no,
  contractor.c_surname_company,
  contractor.c_first_names,
  contractor.c_initials,Status='Contract Terminated',
  contract_renewals.con_start_date,
  contract_renewals.con_expiry_date from
  rd.contractor_renewals,rd.contract_renewals,rd.contract,rd.contractor where
  contractor_renewals.contract_no = contract_renewals.contract_no and
  contractor_renewals.contract_seq_number = contract_renewals.contract_seq_number and
  contract_renewals.contract_no = contract.contract_no and
  contractor_renewals.contractor_supplier_no = contractor.contractor_supplier_no and
  contract.con_date_terminated between @sdate and @edate











GO
