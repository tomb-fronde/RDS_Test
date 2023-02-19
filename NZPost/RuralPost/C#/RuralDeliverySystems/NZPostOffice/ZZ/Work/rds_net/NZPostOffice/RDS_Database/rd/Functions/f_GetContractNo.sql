

--
-- Definition for user-defined function f_GetContractNo : 
--

create function [rd].[f_GetContractNo](@ai_cust_id int)
returns char(300)
AS
BEGIN

  declare @sret varchar(100),
  @stemp1 varchar(100),
  @stemp2 varchar(100)
  declare contract_no cursor for select contract.contract_no,
      contract.con_title from
      rds_customer,
      customer_address_moves,
      address,
      contract where
      (customer_address_moves.cust_id = rds_customer.cust_id) and
      (customer_address_moves.move_out_date is null) and
      (address.adr_id = customer_address_moves.adr_id) and
      (contract.contract_no = address.contract_no) and
      ((rds_customer.master_cust_id is null) and
      (rds_customer.cust_id = @ai_cust_id))
  open contract_no
  fetch next from contract_no into @stemp1,@stemp2
  select @sret='('+@stemp1+')'+' '+@stemp2
  close contract_no
  return(@sret)
end