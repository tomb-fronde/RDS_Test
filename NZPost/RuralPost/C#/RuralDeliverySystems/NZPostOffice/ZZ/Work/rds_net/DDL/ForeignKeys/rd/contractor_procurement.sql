ALTER TABLE [rd].[contractor_procurement] WITH CHECK 
  ADD CONSTRAINT [FK_contractor] 
  FOREIGN KEY([contractor_supplier_no])
    REFERENCES [rd].[contractor] ([contractor_supplier_no])
GO
ALTER TABLE [rd].[contractor_procurement] CHECK CONSTRAINT [FK_contractor]
GO
ALTER TABLE [rd].[contractor_procurement] WITH CHECK 
  ADD CONSTRAINT [FK_procurement] 
  FOREIGN KEY([proc_id])
    REFERENCES [rd].[procurement] ([proc_id])
GO
ALTER TABLE [rd].[contractor_procurement] CHECK CONSTRAINT [FK_procurement]
GO
