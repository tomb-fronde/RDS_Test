
--
-- Definition for stored procedure sp_GetCustOccupation : 
--

--
-- Definition for stored procedure sp_GetCustOccupation : 
--

create procedure [rd].[sp_GetCustOccupation](@in_Cust_Id int)
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  select cust_id,
    occupation_id from
    customer_occupation where
    cust_id = @in_cust_id
end