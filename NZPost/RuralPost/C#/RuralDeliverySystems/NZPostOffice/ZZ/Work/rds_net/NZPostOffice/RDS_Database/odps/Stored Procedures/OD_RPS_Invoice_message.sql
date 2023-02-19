
--
-- Definition for stored procedure OD_RPS_Invoice_message : 
--

create procedure [odps].[OD_RPS_Invoice_message](@in_message char(1000))
AS
BEGIN
  select out_message=@in_message
end