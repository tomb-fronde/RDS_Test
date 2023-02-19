
--
-- Definition for stored procedure sp_DDDW_StandardFrequency : 
--

create procedure [rd].[sp_DDDW_StandardFrequency]
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  select sf_key,
    sf_description,
    sf_days_week from
    standard_frequency order by
    sf_description asc
end