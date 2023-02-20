ALTER TABLE [rd].[rds_customer] WITH CHECK 
  ADD CONSTRAINT [FK_RDS_CUST_REFERENCE_RDS_CUST] 
  FOREIGN KEY([master_cust_id])
    REFERENCES [rd].[rds_customer] ([cust_id])
GO
ALTER TABLE [rd].[rds_customer] CHECK CONSTRAINT [FK_RDS_CUST_REFERENCE_RDS_CUST]
GO
