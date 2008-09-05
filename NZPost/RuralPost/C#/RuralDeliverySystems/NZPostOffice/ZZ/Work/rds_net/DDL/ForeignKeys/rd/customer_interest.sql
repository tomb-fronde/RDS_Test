ALTER TABLE [rd].[customer_interest] WITH CHECK 
  ADD CONSTRAINT [cust_interest2] 
  FOREIGN KEY([interest_id])
    REFERENCES [rd].[interest] ([interest_id])
GO
ALTER TABLE [rd].[customer_interest] CHECK CONSTRAINT [cust_interest2]
GO
ALTER TABLE [rd].[customer_interest] WITH CHECK 
  ADD CONSTRAINT [FK_CUSTOMER_REFERENCE_RDS_CUST] 
  FOREIGN KEY([cust_id])
    REFERENCES [rd].[rds_customer] ([cust_id])
ON DELETE CASCADE
GO
ALTER TABLE [rd].[customer_interest] CHECK CONSTRAINT [FK_CUSTOMER_REFERENCE_RDS_CUST]
GO
