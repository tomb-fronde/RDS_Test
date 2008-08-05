/****** Object:  StoredProcedure [rd].[sp_DDDW_PointTypes]    Script Date: 08/05/2008 10:18:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for stored procedure sp_DDDW_PointTypes : 
--

create procedure -- TJB 16 Mar 04 SR4607
-- Update database tables used to populate dropdown lists in 
--     dw_frequency_description window
-- Update stored procedures  used for retrieval to put blank
--     entries first
[rd].[sp_DDDW_PointTypes]
AS
BEGIN
  select rfpt_id,rfpt_description from
    route_freq_point_type order by
    rfpt_id asc
end
GO
