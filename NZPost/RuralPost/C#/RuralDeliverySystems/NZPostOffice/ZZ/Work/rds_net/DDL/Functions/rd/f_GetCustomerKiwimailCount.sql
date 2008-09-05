/****** Object:  UserDefinedFunction [rd].[f_GetCustomerKiwimailCount]    Script Date: 08/05/2008 11:23:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--THE EVALUATION VERSION TRIMS COLUMN NAMES AND VARIABLES TO 7 CHARACTERS
--
create function [rd].[f_GetCustomerKiwimailCount](@in_Con INT ,@in_typ CHAR(1))
RETURNS INT
-- TJB  SR4659  July 2005
-- Add count for CMB customers.  Count 1 Kiwimail for each
-- customer (surname and/or initials not null or empty).
   AS
BEGIN

   declare @iCount INT
   if @in_typ = 'R'
   begin
      select   @iCount = sum(rd.rds_customer.cust_adpost_quantity) 
      from rd.address,
      rd.customer_address_moves,
      rd.rds_customer where(rd.customer_address_moves.adr_id = rd.address.adr_id) and(rd.rds_customer.cust_id = rd.customer_address_moves.cust_id) and
      rd.rds_customer.master_cust_id is null and
      rd.customer_address_moves.move_out_date is null and((rd.address.contract_no = @in_Con) and(rd.rds_customer.cust_rural_resident = 'Y'))
   end
   else
   begin
      if @in_typ = 'B'
      begin
         select   @iCount = sum(rd.rds_customer.cust_adpost_quantity) 
         from rd.address,
      rd.customer_address_moves,
      rd.rds_customer where(rd.customer_address_moves.adr_id = rd.address.adr_id) and(rd.rds_customer.cust_id = rd.customer_address_moves.cust_id) and
         rd.rds_customer.master_cust_id is null and
         rd.customer_address_moves.move_out_date is null and((rd.address.contract_no = @in_Con) and(rd.rds_customer.cust_business = 'Y'))
      end
      else
      begin
         if @in_typ = 'F'
         begin
            select   @iCount = sum(rd.rds_customer.cust_adpost_quantity) 
            from rd.address,
      rd.customer_address_moves,
      rd.rds_customer where(rd.customer_address_moves.adr_id = rd.address.adr_id) and(rd.rds_customer.cust_id = rd.customer_address_moves.cust_id) and
            rd.rds_customer.master_cust_id is null and
            rd.customer_address_moves.move_out_date is null and((rd.address.contract_no = @in_Con) and(rd.rds_customer.cust_rural_farmer = 'Y'))
         end
         else
         begin
            if @in_typ = 'X'
            begin
               select   @iCount = Count(rd.rds_customer.cust_id) 
               from rd.address,
      rd.customer_address_moves,
      rd.rds_customer where(rd.customer_address_moves.adr_id = rd.address.adr_id) and(rd.rds_customer.cust_id = rd.customer_address_moves.cust_id) and(rd.rds_customer.master_cust_id is null) and
               rd.rds_customer.master_cust_id is null and
               rd.customer_address_moves.move_out_date is null and((rd.address.contract_no = @in_Con) and(cust_adpost_quantity is null or cust_adpost_quantity = 0))
            end
            else
            begin
               if @in_typ = 'C'
               begin
                  select   @iCount = Count(cmb_id) 
                  from rd.cmb_address where
                  contract_no = @in_Con and((cmb_cust_surname is not null and cmb_cust_surname <> '') or(cmb_cust_initials is not null and cmb_cust_initials <> ''))
               end
               else
               begin
                  set @iCount = 0
               end
            end
         end
      end
   end
   return @iCount
end
GO
