CREATE procedure [rd].[sp_remove_driver](
	  @inContractorNo int
	, @inDriverNo int)
AS
-- TJB  RPCR_060  Apr-2014: Created
-- Remove a driver from the contractor's list of drivers
BEGIN
  set CONCAT_NULL_YIELDS_NULL OFF
  declare @n int
  
  delete from contractor_driver
   where contractor_supplier_no = @inContractorNo
     and driver_no = @inDriverNo
     
  select @n = count(*) from contractor_driver
   where driver_no = @inDriverNo
   
  if (@n is null or @n < 1)
  begin
      delete from driver_hs_info
       where driver_no = @inDriverNo
       
      delete from driver
       where driver_no = @inDriverNo
  end
END