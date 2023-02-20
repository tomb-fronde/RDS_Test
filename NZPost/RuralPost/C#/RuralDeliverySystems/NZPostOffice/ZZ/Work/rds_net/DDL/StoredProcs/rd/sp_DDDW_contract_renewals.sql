/****** Object:  StoredProcedure [rd].[sp_DDDW_contract_renewals]    Script Date: 08/05/2008 10:18:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for stored procedure sp_DDDW_contract_renewals : 
--

create procedure [rd].[sp_DDDW_contract_renewals](@contractno int)
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
 select contract_seq_number,sdate='Renewal '+convert(varchar(20),contract_seq_number),con_start_date from contract_renewals where((contract_no = @contractno and @contractno is not null and @contractno <> -1)) order by 2 asc end













GO
