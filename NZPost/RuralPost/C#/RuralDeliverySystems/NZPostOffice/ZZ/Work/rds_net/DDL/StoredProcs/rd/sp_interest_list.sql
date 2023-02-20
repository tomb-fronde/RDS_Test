/****** Object:  StoredProcedure [rd].[sp_interest_list]    Script Date: 08/05/2008 10:21:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for stored procedure sp_interest_list : 
--

create procedure -- Tim Chan 24/03/2003
-- This is a new procedure written as part of the resolution to service request 4474_01
-- 
[rd].[sp_interest_list]
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  select interest.interest_description,interest.interest_id from
    interest order by
    interest.interest_description asc
end
GO
