ALTER TABLE [rd].[artical_rate] WITH CHECK 
  ADD CONSTRAINT [FK_artical_type] 
  FOREIGN KEY([at_key])
    REFERENCES [rd].[artical_type] ([at_key])
GO
ALTER TABLE [rd].[artical_rate] CHECK CONSTRAINT [FK_artical_type]
GO
ALTER TABLE [rd].[artical_rate] WITH CHECK 
  ADD CONSTRAINT [FK_contract_renewals1] 
  FOREIGN KEY([contract_no], [contract_seq_number])
    REFERENCES [rd].[contract_renewals] ([contract_no], [contract_seq_number])
GO
ALTER TABLE [rd].[artical_rate] CHECK CONSTRAINT [FK_contract_renewals1]
GO
