
--
-- Definition for user-defined function f_GetCustomerCountCount : 
--

create function [rd].[f_GetCustomerCountCount](@in_Contract int,@in_Type char(1))
returns int
AS
BEGIN

  declare @iCount int
  select @iCount=sum(cust_adpost_quantity) 
    from customer where
    customer.contract_no = @in_Contract and
    cust_category = 'RR' and
    @in_Type = 'R'
  if @iCount > 0
    return @iCount
  select @iCount=sum(cust_adpost_quantity) 
    from customer where
    customer.contract_no = @in_Contract and
    cust_category = 'BS' and
    @in_Type = 'B'
  if @iCount > 0
    return @iCount
  select @iCount=sum(cust_adpost_quantity) 
    from customer where
    customer.contract_no = @in_Contract and
    cust_category = 'RF' and
    @in_Type = 'F'
  if @iCount > 0
    return @iCount
  select @iCount=count(cust_id) 
    from customer where
    customer.contract_no = @in_Contract and
    (cust_adpost_quantity is null or cust_adpost_quantity = 0) and
    @in_Type = 'X'
  if @iCount > 0
    return @iCount
return @iCount
end