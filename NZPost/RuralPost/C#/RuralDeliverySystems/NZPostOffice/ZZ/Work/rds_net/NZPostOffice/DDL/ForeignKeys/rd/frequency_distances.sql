ALTER TABLE [rd].[frequency_distances] WITH CHECK 
  ADD CONSTRAINT [FK_route_frequency2] 
  FOREIGN KEY([contract_no], [sf_key], [rf_delivery_days])
    REFERENCES [rd].[route_frequency] ([contract_no], [sf_key], [rf_delivery_days])
GO
ALTER TABLE [rd].[frequency_distances] CHECK CONSTRAINT [FK_route_frequency2]
GO
