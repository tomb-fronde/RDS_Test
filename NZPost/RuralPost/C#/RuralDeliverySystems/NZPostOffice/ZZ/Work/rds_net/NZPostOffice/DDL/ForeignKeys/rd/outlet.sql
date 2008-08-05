ALTER TABLE [rd].[outlet] WITH CHECK 
  ADD CONSTRAINT [FK_outlet_type] 
  FOREIGN KEY([ot_code])
    REFERENCES [rd].[outlet_type] ([ot_code])
GO
ALTER TABLE [rd].[outlet] CHECK CONSTRAINT [FK_outlet_type]
GO
ALTER TABLE [rd].[outlet] WITH CHECK 
  ADD CONSTRAINT [FK_region2] 
  FOREIGN KEY([region_id])
    REFERENCES [rd].[region] ([region_id])
GO
ALTER TABLE [rd].[outlet] CHECK CONSTRAINT [FK_region2]
GO
