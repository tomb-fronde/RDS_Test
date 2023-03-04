
CREATE FUNCTION [rd].[f_GetAddress](@p_adr_id int)
returns varchar(255)
as
begin

  declare @sret varchar(255)
  
  select @sret = (case when address.adr_unit is null then '' else address.adr_unit+'/' end) 
                   + (case when address.adr_no is null then '' else address.adr_no end) 
                   + (case when address.adr_alpha is null then '' else address.adr_alpha end)
                   + (case when address.road_id is null then '' else ' ' + road1.road_name
                      + (case when road1.rt_id is null then '' else ' ' + road_type.rt_abbrev end)
                      + (case when road1.rs_id is null then '' else ' ' + road_suffix.rs_abbrev end) 
                      end)
                   + (case when address.sl_id is null then '' else ', ' + SuburbLocality.sl_name end)
                   + (case when address.tc_id is null then '' else ', ' + TownCity.tc_name end)
    from address left outer join road road1
                   on road1.road_id = address.road_id
                 left outer join SuburbLocality 
                   on SuburbLocality.sl_id = address.sl_id
                 left outer join TownCity 
                   on TownCity.tc_id = address.tc_id,
         road road2 left outer join road_type
                   on road_type.rt_id = road2.rt_id
              left outer join road_suffix
                   on road_suffix.rs_id = road2.rs_id
   where address.adr_id = @p_adr_id
     and road2.road_id = road1.road_id

  return(@sret)
end