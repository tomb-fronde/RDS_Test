/****** Object:  StoredProcedure [rd].[sp_getConNumbers]    Script Date: 08/05/2008 10:19:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for stored procedure sp_getConNumbers : 
--

--
-- Definition for stored procedure sp_getConNumbers : 
--

create procedure -- TWC -- 15/08/2003
-- This procedure will return all contract numbers of contracts that have not expired.
[rd].[sp_getConNumbers]
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  select distinct contract_no,con_title from
    contract as con where
    con.con_date_terminated is null and
    contract_no > 0 order by
    contract_no asc,con_title asc
end
GO
