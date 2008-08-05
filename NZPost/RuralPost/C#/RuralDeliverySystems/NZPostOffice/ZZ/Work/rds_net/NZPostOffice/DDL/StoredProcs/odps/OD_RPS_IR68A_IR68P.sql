/****** Object:  StoredProcedure [odps].[OD_RPS_IR68A_IR68P]    Script Date: 08/05/2008 10:14:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for stored procedure OD_RPS_IR68A_IR68P : 
--

create procedure [odps].[OD_RPS_IR68A_IR68P](@sdate datetime,@edate datetime)
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  select distinct a=contractor_renewals.contract_no,
    b=contractor.c_surname_company,
    c=contractor.c_first_names,
    d=contractor.c_initials,
    GPTaxable=odps.OD_RPF_PCYearlyEarnings(contractor.contractor_supplier_no,contract_renewals.contract_no,contract_renewals.contract_seq_number,@sdate,@edate,'GP','Y')+
    odps.OD_RPF_PCYearlyEarnings(contractor.contractor_supplier_no,contract_renewals.contract_no,contract_renewals.contract_seq_number,@sdate,@edate,'OGP','Y'),
    GPNonTaxable=odps.OD_RPF_PCYearlyEarnings(contractor.contractor_supplier_no,contract_renewals.contract_no,contract_renewals.contract_seq_number,@sdate,@edate,'GP','N')+
    odps.OD_RPF_PCYearlyEarnings(contractor_renewals.contractor_supplier_no,contractor_renewals.contract_no,contractor_renewals.contract_seq_number,@sdate,@edate,'OGP','N'),
    Paye=abs(odps.OD_RPF_PCGetSumYear_spec(contractor.contractor_supplier_no,contract_renewals.contract_no,contract_renewals.contract_seq_number,@sdate,@edate,'TAX',null)),  --!added a 'null' to the default parameter
    ACC=(select((nat_acc_percentage/100)) from [national] where nat_id = odps.OD_BLF_GetWhichNational(@edate)) from
    rd.contractor,rd.contractor_renewals,rd.contract_renewals where
    contractor.contractor_supplier_no = contractor_renewals.contractor_supplier_no and
    contract_renewals.contract_no = contractor_renewals.contract_no and
    (contract_renewals.con_expiry_date is null or contract_renewals.con_expiry_date > @sdate) and
    contract_renewals.contract_seq_number = contractor_renewals.contract_seq_number order by
    contractor_renewals.contract_no asc
end
GO
