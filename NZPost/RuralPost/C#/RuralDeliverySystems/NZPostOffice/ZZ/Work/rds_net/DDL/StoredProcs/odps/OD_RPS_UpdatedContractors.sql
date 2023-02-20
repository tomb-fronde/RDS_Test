/****** Object:  StoredProcedure [odps].[OD_RPS_UpdatedContractors]    Script Date: 08/05/2008 10:14:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for stored procedure OD_RPS_UpdatedContractors : 
--

create procedure [odps].[OD_RPS_UpdatedContractors](@FromDate datetime,@ToDate datetime)
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
select DS_No=(select max(cd_old_ds_no) from rd.contractor_ds where contractor_ds.contractor_supplier_no = contractor.contractor_supplier_no),
    title=c_title,
    initials=c_initials,
    surname_company=c_surname_company,
    address1=c_address,
    bank_account_no=c_bank_account_no,bank=space(40),
    branch=space(40),changetype=' New Vendor' from
    rd.rds_audit,
    rd.contractor where
    contractor.contractor_supplier_no = a_contractor and
    rds_audit.a_comment = 'New Contractor' and
    rd.date(rds_audit.a_datetime) between rd.date(@FromDate) and rd.date(@ToDate) 

union all
  select DS_No=(select max(cd_old_ds_no) from rd.contractor_ds where contractor_ds.contractor_supplier_no = contractor.contractor_supplier_no),
    title=(case when a_newvalue like '%Title:%' then
      c_title
    else
      space(10)
    end),
    initials=(case when a_newvalue like '%Initials:%' then
      c_initials
    else
      space(10)
    end),
    surname_company=(case when a_newvalue like '%Surname or company name:%' then
      c_surname_company
    else
      space(40)
    end),
    address1=(case when a_newvalue like '%Address:%' then
      c_address
    else
      space(200)
    end),
    bank_account_no=(case when a_newvalue like '%Bank account number:%' then
      c_bank_account_no
    else
      space(18)
    end),
    bank=space(40),
    branch=space(40),
    changetype=(case when (case when a_newvalue like '%Title:%' then c_title else space(10) end) <> space(10) then 'Title'  --!changed title to its origine 
    else
      case when (case when a_newvalue like '%Initials:%' then c_initials else space(10) end) <> space(10) then 'Initials'  --!changed initials to its origine 
      else
        case when (case when a_newvalue like '%Surname or company name:%' then c_surname_company else space(40) end) <> space(40) then 'Name'  --!changed surname_company to its origine 
        else
          case when (case when a_newvalue like '%Address:%' then c_address else space(200) end) <> space(200) then 'Address'  --!changed address1 to its origine 
          else
            case when (case when a_newvalue like '%Bank account number:%' then c_bank_account_no else space(18) end) <> space(18) then 'Bank account no'  --!changed bank_account_no to its origine 
            end
          end
        end
      end
    end) from
    rd.rds_audit,
    rd.contractor where
    contractor.contractor_supplier_no = a_contractor and
    rds_audit.a_comment = 'Updated Contractor' and
    rd.date(rds_audit.a_datetime) between rd.date(@FromDate) and rd.date(@ToDate) and
    (a_newvalue like '%Title:%' or
    a_newvalue like '%Initials:%' or
    a_newvalue like '%Surname or company name:%' or
    a_newvalue like '%Address:%' or
    a_newvalue like '%Bank account number:%' or
    a_newvalue like '%Branch:%' or
    a_newvalue like '%Bank:%') order by
    1 asc,3 asc

end
GO
