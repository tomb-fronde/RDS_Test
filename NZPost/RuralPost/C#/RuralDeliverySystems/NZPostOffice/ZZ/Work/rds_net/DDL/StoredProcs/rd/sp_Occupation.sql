/****** Object:  StoredProcedure [rd].[sp_Occupation]    Script Date: 08/05/2008 10:21:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for stored procedure sp_Occupation : 
--

create procedure [rd].[sp_Occupation]
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  select occupation.occupation_id,
    occupation.occupation_description from
    occupation order by
    occupation.occupation_description asc
end
GO
