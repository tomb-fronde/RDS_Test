
--
-- Definition for stored procedure sp_GetCustInterest : 
--

--
-- Definition for stored procedure sp_GetCustInterest : 
--

create procedure [rd].[sp_GetCustInterest](@in_Cust_Id int)
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  select cust_id,
    interest_id from
    rd.customer_interest where
    cust_id = @in_cust_id
end