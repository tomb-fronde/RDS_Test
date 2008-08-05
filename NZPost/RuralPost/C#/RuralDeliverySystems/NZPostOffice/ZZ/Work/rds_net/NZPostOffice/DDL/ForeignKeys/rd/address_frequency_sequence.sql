ALTER TABLE [rd].[address_frequency_sequence] WITH CHECK 
  ADD CONSTRAINT [FK_ADDRESS__REF_591_ADDRESS] 
  FOREIGN KEY([adr_id])
    REFERENCES [rd].[address] ([adr_id])
ON DELETE CASCADE
GO
ALTER TABLE [rd].[address_frequency_sequence] CHECK CONSTRAINT [FK_ADDRESS__REF_591_ADDRESS]
GO
ALTER TABLE [rd].[address_frequency_sequence] WITH CHECK 
  ADD CONSTRAINT [FK_ADDRESS__REFERENCE_ROUTE_FR] 
  FOREIGN KEY([contract_no], [sf_key], [rf_delivery_days])
    REFERENCES [rd].[route_frequency] ([contract_no], [sf_key], [rf_delivery_days])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [rd].[address_frequency_sequence] CHECK CONSTRAINT [FK_ADDRESS__REFERENCE_ROUTE_FR]
GO
