/****** Object:  StoredProcedure [rd].[sp_DDDW_AllowanceType]    Script Date: 08/05/2008 10:18:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for stored procedure sp_DDDW_AllowanceType : 
--

create procedure [rd].[sp_DDDW_AllowanceType]
AS
BEGIN
  select alt_key,
    alt_description from
    allowance_type
end
GO
