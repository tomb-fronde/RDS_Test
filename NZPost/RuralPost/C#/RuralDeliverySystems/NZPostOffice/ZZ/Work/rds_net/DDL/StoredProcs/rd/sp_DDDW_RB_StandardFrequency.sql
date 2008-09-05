/****** Object:  StoredProcedure [rd].[sp_DDDW_RB_StandardFrequency]    Script Date: 08/05/2008 10:18:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--
-- Definition for stored procedure sp_DDDW_RB_StandardFrequency : 
--

create procedure [rd].[sp_DDDW_RB_StandardFrequency]
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  select sf_key,sf_description,bull='z' from
    standard_frequency union
  select-1,'<All>','a'   order by
    3 asc,2 asc
end
GO
