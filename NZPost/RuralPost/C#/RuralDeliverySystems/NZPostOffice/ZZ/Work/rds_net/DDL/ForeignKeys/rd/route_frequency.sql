ALTER TABLE [rd].[route_frequency] WITH CHECK 
  ADD CONSTRAINT [FK_contract4] 
  FOREIGN KEY([contract_no])
    REFERENCES [rd].[contract] ([contract_no])
GO
ALTER TABLE [rd].[route_frequency] CHECK CONSTRAINT [FK_contract4]
GO
ALTER TABLE [rd].[route_frequency] WITH CHECK 
  ADD CONSTRAINT [FK_standard_frequency1] 
  FOREIGN KEY([sf_key])
    REFERENCES [rd].[standard_frequency] ([sf_key])
GO
ALTER TABLE [rd].[route_frequency] CHECK CONSTRAINT [FK_standard_frequency1]
GO
