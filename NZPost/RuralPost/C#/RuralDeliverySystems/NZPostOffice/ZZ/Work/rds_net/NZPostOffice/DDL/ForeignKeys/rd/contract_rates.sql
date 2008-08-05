ALTER TABLE [rd].[contract_rates] WITH CHECK 
  ADD CONSTRAINT [FK_contract_renewals4] 
  FOREIGN KEY([contract_no], [contract_seq_number])
    REFERENCES [rd].[contract_renewals] ([contract_no], [contract_seq_number])
GO
ALTER TABLE [rd].[contract_rates] CHECK CONSTRAINT [FK_contract_renewals4]
GO
