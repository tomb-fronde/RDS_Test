
CREATE PROCEDURE [rd].[sp_updateAdrDeliveryDays](@adr_id int)
AS
BEGIN
  -- ====================================================
  -- = TJB 23-Apr-2012  RPCR_036    New                 =
  -- = Updates the adr_delivery_days column in address  =
  -- ====================================================

update address
   set adr_delivery_days = rd.f_getAdrDeliveryDays(adr_id)
 where adr_id = @adr_id
 
END