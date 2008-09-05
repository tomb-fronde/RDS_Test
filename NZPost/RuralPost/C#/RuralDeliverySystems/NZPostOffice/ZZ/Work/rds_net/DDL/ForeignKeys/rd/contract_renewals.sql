ALTER TABLE [rd].[contract_renewals] WITH CHECK 
  ADD CONSTRAINT [FK_contract2] 
  FOREIGN KEY([contract_no])
    REFERENCES [rd].[contract] ([contract_no])
GO
ALTER TABLE [rd].[contract_renewals] CHECK CONSTRAINT [FK_contract2]
GO
