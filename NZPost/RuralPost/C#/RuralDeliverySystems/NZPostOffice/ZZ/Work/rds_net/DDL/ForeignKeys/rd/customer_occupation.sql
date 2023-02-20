ALTER TABLE [rd].[customer_occupation] WITH CHECK 
  ADD CONSTRAINT [cust_occupation2] 
  FOREIGN KEY([occupation_id])
    REFERENCES [rd].[occupation] ([occupation_id])
GO
ALTER TABLE [rd].[customer_occupation] CHECK CONSTRAINT [cust_occupation2]
GO
ALTER TABLE [rd].[customer_occupation] WITH CHECK 
  ADD CONSTRAINT [FK_CUSTOMER_REFERENCE_RDS_CUST1] 
  FOREIGN KEY([cust_id])
    REFERENCES [rd].[rds_customer] ([cust_id])
GO
ALTER TABLE [rd].[customer_occupation] CHECK CONSTRAINT [FK_CUSTOMER_REFERENCE_RDS_CUST1]
GO
