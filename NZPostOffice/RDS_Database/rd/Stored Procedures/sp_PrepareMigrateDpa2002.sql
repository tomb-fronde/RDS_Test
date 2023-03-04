create procedure [rd].[sp_PrepareMigrateDpa2002]
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  --Temp variables
  declare @v_iTemp integer
  --Generate road types
  delete from address_frequency_sequence
  --Check @@error
  if @@error <> 0 /* <> was < */
    begin
      rollback transaction
      return(-1)
    end
  delete from customer_address_moves
  --Check @@error
  if @@error <> 0 /* <> was < */
    begin
      rollback transaction
      return(-2)
    end
  delete from rds_customer
  --Check @@error
  if @@error <> 0 /* <> was < */
    begin
      rollback transaction
      return(-3)
    end
  delete from road_suburb
  --Check @@error
  if @@error <> 0 /* <> was < */
    begin
      rollback transaction
      return(-4)
    end
  delete from town_suburb
  --Check @@error
  if @@error <> 0 /* <> was < */
    begin
      rollback transaction
      return(-5)
    end
  delete from town_road
  --Check @@error
  if @@error <> 0 /* <> was < */
    begin
      rollback transaction
      return(-6)
    end
  delete from address
  --Check @@error
  if @@error <> 0 /* <> was < */
    begin
      rollback transaction
      return(-7)
    end
  delete from road
  --Check @@error
  if @@error <> 0 /* <> was < */
    begin
      rollback transaction
      return(-8)
    end
  delete from TownCity
  --Check @@error
  if @@error <> 0 /* <> was < */
    begin
      rollback transaction
      return(-9)
    end
  delete from SuburbLocality
  --Check @@error
  if @@error <> 0 /* <> was < */
    begin
      rollback transaction
      return(-10)
    end
  delete from road_type
  --Check @@error
  if @@error <> 0 /* <> was < */
    begin
      rollback transaction
      return(-11)
    end
  commit transaction
  
  DBCC CHECKIDENT ('rd.TownCity', RESEED, 0)
  DBCC CHECKIDENT ('rd.road_type', RESEED, 0)
  DBCC CHECKIDENT ('rd.SuburbLocality', RESEED, 0)  
  
  insert into road_type(rt_id,rt_name,rt_abbrev) values(1,'Avenue','Ave')
  insert into road_type(rt_id,rt_name,rt_abbrev) values(2,'Grove','Gve')
  insert into road_type(rt_id,rt_name,rt_abbrev) values(3,'Street','St')
  insert into road_type(rt_id,rt_name,rt_abbrev) values(4,'Highway','Hwy')
  insert into road_type(rt_id,rt_name,rt_abbrev) values(5,'Motorway','Motorway')
  insert into road_type(rt_id,rt_name,rt_abbrev) values(6,'Terrace','Tce')
  insert into road_type(rt_id,rt_name,rt_abbrev) values(7,'Road','Rd')
  insert into road_type(rt_id,rt_name,rt_abbrev) values(8,'Boulevard','Blvd')
  insert into road_type(rt_id,rt_name,rt_abbrev) values(9,'Lane','Ln')
  insert into road_type(rt_id,rt_name,rt_abbrev) values(10,'Crescent','Cres')
  insert into road_type(rt_id,rt_name,rt_abbrev) values(11,'Way','Way')
  insert into road_type(rt_id,rt_name,rt_abbrev) values(12,'Close','Close')
  insert into road_type(rt_id,rt_name,rt_abbrev) values(13,'Court','Ct')
  insert into road_type(rt_id,rt_name,rt_abbrev) values(14,'Drive','Dve')
  insert into road_type(rt_id,rt_name,rt_abbrev) values(15,'Esplanade','Espl')
  insert into road_type(rt_id,rt_name,rt_abbrev) values(16,'Junction','Junction')
  insert into road_type(rt_id,rt_name,rt_abbrev) values(17,'Line','Line')
  insert into road_type(rt_id,rt_name,rt_abbrev) values(18,'Park','Park')
  insert into road_type(rt_id,rt_name,rt_abbrev) values(19,'Parade','Pde')
  insert into road_type(rt_id,rt_name,rt_abbrev) values(20,'Point','Point')
  insert into road_type(rt_id,rt_name,rt_abbrev) values(21,'Place','Pl')
  insert into road_type(rt_id,rt_name,rt_abbrev) values(22,'Rise','Rise')
  insert into road_type(rt_id,rt_name,rt_abbrev) values(23,'Straight','Straight')
  insert into road_type(rt_id,rt_name,rt_abbrev) values(24,'Track','Track')
  insert into road_type(rt_id,rt_name,rt_abbrev) values(25,'Village','Village')
  insert into road_type(rt_id,rt_name,rt_abbrev) values(26,'Bend','Bend')
  insert into road_type(rt_id,rt_name,rt_abbrev) values(27,'Creek','Creek')
  insert into road_type(rt_id,rt_name,rt_abbrev) values(28,'Pass','Pass')
  commit transaction
  --Check @@error
  if @@error <> 0 /* <> was < */
    begin
      rollback transaction
      return(-30)
    end
  select 1 
end