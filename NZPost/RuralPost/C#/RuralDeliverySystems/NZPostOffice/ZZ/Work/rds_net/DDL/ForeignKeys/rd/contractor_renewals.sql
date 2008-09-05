ALTER TABLE [rd].[contractor_renewals] WITH CHECK 
  ADD CONSTRAINT [FK_contract_renewals2] 
  FOREIGN KEY([contract_no], [contract_seq_number])
    REFERENCES [rd].[contract_renewals] ([contract_no], [contract_seq_number])
  ON UPDATE CASCADE
  ON DELETE CASCADE
GO
ALTER TABLE [rd].[contractor_renewals] CHECK CONSTRAINT [FK_contract_renewals2]
GO
ALTER TABLE [rd].[contractor_renewals] WITH CHECK 
  ADD CONSTRAINT [FK_contractor1] 
  FOREIGN KEY([contractor_supplier_no])
    REFERENCES [rd].[contractor] ([contractor_supplier_no])
GO
ALTER TABLE [rd].[contractor_renewals] CHECK CONSTRAINT [FK_contractor1]
GO
