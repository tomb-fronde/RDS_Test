/****** Object:  StoredProcedure [odps].[od_OwnerDriver]    Script Date: 08/05/2008 10:13:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for stored procedure od_OwnerDriver : 
--

create procedure  [odps].[od_OwnerDriver](@inStartDate datetime,@inEndDate datetime,@inOwnerDriver varchar(40))
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  select payment.contract_no,
    contractor.c_first_names from
    rd.contractor,payment where
    contractor.contractor_supplier_no = payment.contractor_supplier_no and
    payment.invoice_date between @inStartDate and @inEndDate and
    contractor.c_first_names like @inOwnerDriver+'%'
end
GO
