ALTER TABLE [rd].[contractor_ds] WITH CHECK 
  ADD CONSTRAINT [FK_contractor3] 
  FOREIGN KEY([contractor_supplier_no])
    REFERENCES [rd].[contractor] ([contractor_supplier_no])
GO
ALTER TABLE [rd].[contractor_ds] CHECK CONSTRAINT [FK_contractor3]
GO
