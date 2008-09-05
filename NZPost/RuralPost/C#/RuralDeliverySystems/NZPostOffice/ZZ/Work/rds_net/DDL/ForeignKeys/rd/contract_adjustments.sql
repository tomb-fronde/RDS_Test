ALTER TABLE [rd].[contract_adjustments] WITH CHECK 
  ADD CONSTRAINT [FK_contract_renewals3] 
  FOREIGN KEY([contract_no], [contract_seq_number])
    REFERENCES [rd].[contract_renewals] ([contract_no], [contract_seq_number])
GO
ALTER TABLE [rd].[contract_adjustments] CHECK CONSTRAINT [FK_contract_renewals3]
GO
