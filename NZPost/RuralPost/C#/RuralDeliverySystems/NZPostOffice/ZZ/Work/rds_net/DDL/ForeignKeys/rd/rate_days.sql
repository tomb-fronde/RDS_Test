ALTER TABLE [rd].[rate_days] WITH CHECK 
  ADD CONSTRAINT [FK_standard_frequency] 
  FOREIGN KEY([sf_key])
    REFERENCES [rd].[standard_frequency] ([sf_key])
GO
ALTER TABLE [rd].[rate_days] CHECK CONSTRAINT [FK_standard_frequency]
GO
