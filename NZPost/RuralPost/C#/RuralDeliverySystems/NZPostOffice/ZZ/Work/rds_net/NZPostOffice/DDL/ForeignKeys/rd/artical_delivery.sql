ALTER TABLE [rd].[artical_delivery] WITH CHECK 
  ADD CONSTRAINT [FK_artical_rate] 
  FOREIGN KEY([at_key], [art_effective_date], [contract_no], [contract_seq_number])
    REFERENCES [rd].[artical_rate] ([at_key], [art_effective_date], [contract_no], [contract_seq_number])
GO
ALTER TABLE [rd].[artical_delivery] CHECK CONSTRAINT [FK_artical_rate]
GO
ALTER TABLE [rd].[artical_delivery] WITH CHECK 
  ADD CONSTRAINT [FK_contract_renewals] 
  FOREIGN KEY([contract_no], [contract_seq_number])
    REFERENCES [rd].[contract_renewals] ([contract_no], [contract_seq_number])
GO
ALTER TABLE [rd].[artical_delivery] CHECK CONSTRAINT [FK_contract_renewals]
GO
