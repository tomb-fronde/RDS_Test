

--
-- Definition for stored procedure OD_RPS_IR13_Interface_Header : 
--

create procedure [odps].[OD_RPS_IR13_Interface_Header](@Procdate datetime)
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  select Name_of_Organisation='Rural Post',Trading_name='',Type_of_Service='Mail Contract Delivery',GST='N',
    Rural_Post_GST_Number=(select nat_rural_post_gst_no from [national] where [national].nat_id = (select odps.od_blf_getwhichnational(@procdate) /*!from dummy*/)),
    Rural_Post_Address=(select nat_rural_post_address from [national] where [national].nat_id = (select odps.od_blf_getwhichnational(@procdate) /*!from dummy*/)),
    Name_of_Payer=(select nat_rural_post_payer_name from [national] where [national].nat_id = (select odps.od_blf_getwhichnational(@procdate) /*!from dummy*/)),
    Date_Of_printing=getdate()--!today(*) from
    --!sys.dummy
end