/****** Object:  StoredProcedure [odps].[OD_RPS_IR66ES_old]    Script Date: 08/05/2008 10:14:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for stored procedure OD_RPS_IR66ES_old : 
--

create procedure [odps].[OD_RPS_IR66ES_old](@sdate datetime,@edate datetime)
as
select contractor.c_surname_company,
  contractor.c_first_names,
  contractor.c_initials,
  StartDate=case when contractor_renewals.cr_effective_date >= @sdate and contractor_renewals.cr_effective_date <= @edate then
    contractor_renewals.cr_effective_date
  else
    null
  end,
  EndDate=(select dateadd(day,-1,min(cr.cr_effective_date)) from
    rd.contractor_renewals as cr where
    cr.contract_no = contractor_renewals.contract_no and
    cr.contract_seq_number = contractor_renewals.contract_seq_number and
    cr.cr_effective_date > contractor_renewals.cr_effective_date),
  TaxCategory=case when contractor.c_witholding_tax_certificate is null or contractor.c_witholding_tax_certificate = 'N' then 'W' else 'N' end,
  c_ird_no from
  rd.contractor_renewals,
  rd.contractor where
  contractor_renewals.contractor_supplier_no = contractor.contractor_supplier_no and
  contractor_renewals.cr_effective_date between @sdate and @edate











GO
