ALTER TABLE [rd].[route_description] WITH CHECK 
  ADD CONSTRAINT [FK_RDESC_ADR] 
  FOREIGN KEY([adr_id])
    REFERENCES [rd].[address] ([adr_id])
ON DELETE CASCADE
GO
ALTER TABLE [rd].[route_description] CHECK CONSTRAINT [FK_RDESC_ADR]
GO
ALTER TABLE [rd].[route_description] WITH CHECK 
  ADD CONSTRAINT [FK_ROUTE_DE_REFERENCE_RDS_CUST] 
  FOREIGN KEY([cust_id])
    REFERENCES [rd].[rds_customer] ([cust_id])
  ON DELETE SET NULL
GO
ALTER TABLE [rd].[route_description] CHECK CONSTRAINT [FK_ROUTE_DE_REFERENCE_RDS_CUST]
GO
ALTER TABLE [rd].[route_description] WITH CHECK 
  ADD CONSTRAINT [FK_route_frequency1] 
  FOREIGN KEY([contract_no], [sf_key], [rf_delivery_days])
    REFERENCES [rd].[route_frequency] ([contract_no], [sf_key], [rf_delivery_days])
GO
ALTER TABLE [rd].[route_description] CHECK CONSTRAINT [FK_route_frequency1]
GO
ALTER TABLE [rd].[route_description] WITH CHECK 
  ADD CONSTRAINT [fky_route_freq_verb] 
  FOREIGN KEY([rfv_id])
    REFERENCES [rd].[route_freq_verbs] ([rfv_id])
GO
ALTER TABLE [rd].[route_description] CHECK CONSTRAINT [fky_route_freq_verb]
GO
ALTER TABLE [rd].[route_description] WITH CHECK 
  ADD CONSTRAINT [fky_route_pt_type] 
  FOREIGN KEY([rfpd_id])
    REFERENCES [rd].[route_freq_point_type] ([rfpt_id])
GO
ALTER TABLE [rd].[route_description] CHECK CONSTRAINT [fky_route_pt_type]
GO
