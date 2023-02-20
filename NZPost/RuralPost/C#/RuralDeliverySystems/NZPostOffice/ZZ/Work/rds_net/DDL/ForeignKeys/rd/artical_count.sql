ALTER TABLE [rd].[artical_count] WITH CHECK 
  ADD CONSTRAINT [FK_contract_renewals7] 
  FOREIGN KEY([contract_no], [contract_seq_number])
    REFERENCES [rd].[contract_renewals] ([contract_no], [contract_seq_number])
GO
ALTER TABLE [rd].[artical_count] CHECK CONSTRAINT [FK_contract_renewals7]
GO
ALTER TABLE [rd].[artical_count] WITH CHECK 
  ADD CONSTRAINT [FK_contract7] 
  FOREIGN KEY([contract_no])
    REFERENCES [rd].[contract] ([contract_no])
GO
ALTER TABLE [rd].[artical_count] CHECK CONSTRAINT [FK_contract7]
GO
