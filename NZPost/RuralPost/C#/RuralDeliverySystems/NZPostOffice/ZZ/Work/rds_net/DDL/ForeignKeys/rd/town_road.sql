ALTER TABLE [rd].[town_road] WITH CHECK 
  ADD CONSTRAINT [FK_TOWN_ROA_REFERENCE_ROAD] 
  FOREIGN KEY([road_id])
    REFERENCES [rd].[Road] ([road_id])
GO
ALTER TABLE [rd].[town_road] CHECK CONSTRAINT [FK_TOWN_ROA_REFERENCE_ROAD]
GO
ALTER TABLE [rd].[town_road] WITH CHECK 
  ADD CONSTRAINT [FK_TOWN_ROA_REFERENCE_TOWNCITY] 
  FOREIGN KEY([tc_id])
    REFERENCES [rd].[TownCity] ([tc_id])
GO
ALTER TABLE [rd].[town_road] CHECK CONSTRAINT [FK_TOWN_ROA_REFERENCE_TOWNCITY]
GO
