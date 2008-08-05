ALTER TABLE [rd].[customer_address_moves] WITH CHECK 
  ADD CONSTRAINT [FK_CUSTOMER_REF_582_RDS_CUST] 
  FOREIGN KEY([cust_id])
    REFERENCES [rd].[rds_customer] ([cust_id])
ON DELETE CASCADE
GO
ALTER TABLE [rd].[customer_address_moves] CHECK CONSTRAINT [FK_CUSTOMER_REF_582_RDS_CUST]
GO
ALTER TABLE [rd].[customer_address_moves] WITH CHECK 
  ADD CONSTRAINT [FK_CUSTOMER_REF_588_ADDRESS] 
  FOREIGN KEY([adr_id])
    REFERENCES [rd].[address] ([adr_id])
ON DELETE CASCADE
GO
ALTER TABLE [rd].[customer_address_moves] CHECK CONSTRAINT [FK_CUSTOMER_REF_588_ADDRESS]
GO
