ALTER TABLE [rd].[budget] WITH CHECK 
  ADD CONSTRAINT [FK_region1] 
  FOREIGN KEY([region_id])
    REFERENCES [rd].[region] ([region_id])
GO
ALTER TABLE [rd].[budget] CHECK CONSTRAINT [FK_region1]
GO
