/****** Object:  StoredProcedure [rd].[update_id_codes]    Script Date: 08/05/2008 10:23:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for stored procedure update_id_codes : 
--

create procedure -- TWC - 13/06/2003
--This script has been written to resolve call 4524
-- This script will bring selected id_codes up to date
[rd].[update_id_codes]
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  declare @max_cust_id int,
  @max_address_id int,
  @max_road_id int,
  @max_user_rights int,
  @max_vehicle_id int,
  @max_contractor_id int,
  @max_rur_id int,
  @li_return int
  select @li_return=1
  select @max_contractor_id = max(contractor_supplier_no) 
    from contractor
  update id_codes set
    next_value = @max_contractor_id+1 where
    sequence_name = 'Contractor'
  if @@ERROR < 0
    select @li_return=-1
  select @max_vehicle_id = max(vehicle_number) 
    from vehicle
  update id_codes set
    next_value = @max_vehicle_id+1 where
    sequence_name = 'vehicles'
  if @@ERROR < 0
    select @li_return=-1
  select @max_user_rights = max(rur_id) 
    from rds_user_rights
  update id_codes set
    next_value = @max_user_rights+1 where
    sequence_name = 'rdsUserRights'
  if @@ERROR < 0
    select @li_return=-1
  select @max_cust_id = max(cust_id) 
    from rds_customer
  update id_codes set
    next_value = @max_cust_id+1 where
    sequence_name = 'customer'
  if @@ERROR < 0
    select @li_return=-1
  select @max_address_id = max(adr_id) 
    from address
  update id_codes set
    next_value = @max_address_id+1 where
    sequence_name = 'address'
  if @@ERROR < 0
    select @li_return=-1
  select @max_road_id = max(road_id) 
    from road
  update id_codes set
    next_value = @max_road_id+1 where
    sequence_name = 'road'
  if @@ERROR < 0
    select @li_return=-1
  select @max_rur_id = max(rur_id) 
    from rds_user_rights
  update id_codes set
    next_value = @max_rur_id+1 where
    sequence_name = 'rdsUserRights'
  if @@ERROR < 0
    select @li_return=-1
  return @li_return
end
GO
