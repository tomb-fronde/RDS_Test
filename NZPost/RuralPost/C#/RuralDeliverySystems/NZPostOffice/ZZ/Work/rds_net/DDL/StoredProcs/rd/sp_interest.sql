/****** Object:  StoredProcedure [rd].[sp_interest]    Script Date: 08/05/2008 10:21:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for stored procedure sp_interest : 
--

create procedure [rd].[sp_interest]
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  select interest.interest_id,
    interest.interest_description from
    interest order by
    interest.interest_description asc
end
GO
