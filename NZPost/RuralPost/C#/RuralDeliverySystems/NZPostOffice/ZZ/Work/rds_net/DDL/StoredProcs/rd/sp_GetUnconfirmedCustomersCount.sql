/****** Object:  StoredProcedure [rd].[sp_GetUnconfirmedCustomersCount]    Script Date: 08/05/2008 10:21:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for stored procedure sp_GetUnconfirmedCustomersCount : 
--

create procedure [rd].[sp_GetUnconfirmedCustomersCount](@inContract int,@indate datetime)
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  select count(*) from
    customer where
    contract_no = @incontract and
    ((cust_date_commenced is null) or(cust_date_commenced < @indate and @indate is not null))
end
GO
