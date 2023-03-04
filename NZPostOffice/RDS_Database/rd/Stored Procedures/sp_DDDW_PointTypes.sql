
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