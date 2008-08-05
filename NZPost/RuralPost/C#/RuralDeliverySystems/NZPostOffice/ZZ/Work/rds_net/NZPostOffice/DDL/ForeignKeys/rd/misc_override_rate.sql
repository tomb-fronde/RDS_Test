ALTER TABLE [rd].[misc_override_rate] WITH CHECK 
  ADD CONSTRAINT [FK_MISC_OVE_REF_1026_CONTRACT] 
  FOREIGN KEY([contract_no], [contract_seq_number])
    REFERENCES [rd].[contract_renewals] ([contract_no], [contract_seq_number])
GO
ALTER TABLE [rd].[misc_override_rate] CHECK CONSTRAINT [FK_MISC_OVE_REF_1026_CONTRACT]
GO
