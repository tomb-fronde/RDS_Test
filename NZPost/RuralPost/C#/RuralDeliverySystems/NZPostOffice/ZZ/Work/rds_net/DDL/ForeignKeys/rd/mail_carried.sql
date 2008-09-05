ALTER TABLE [rd].[mail_carried] WITH CHECK 
  ADD CONSTRAINT [FK_outlet1] 
  FOREIGN KEY([mc_uplift_outlet])
    REFERENCES [rd].[outlet] ([outlet_id])
GO
ALTER TABLE [rd].[mail_carried] CHECK CONSTRAINT [FK_outlet1]
GO
ALTER TABLE [rd].[mail_carried] WITH CHECK 
  ADD CONSTRAINT [FK_route_frequency] 
  FOREIGN KEY([contract_no], [sf_key], [rf_delivery_days])
    REFERENCES [rd].[route_frequency] ([contract_no], [sf_key], [rf_delivery_days])
GO
ALTER TABLE [rd].[mail_carried] CHECK CONSTRAINT [FK_route_frequency]
GO
ALTER TABLE [rd].[mail_carried] WITH CHECK 
  ADD CONSTRAINT [fk_set_down] 
  FOREIGN KEY([mc_set_down_outlet])
    REFERENCES [rd].[outlet] ([outlet_id])
GO
ALTER TABLE [rd].[mail_carried] CHECK CONSTRAINT [fk_set_down]
GO
