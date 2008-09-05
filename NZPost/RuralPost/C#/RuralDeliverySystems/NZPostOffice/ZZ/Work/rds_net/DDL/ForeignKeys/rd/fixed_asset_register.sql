ALTER TABLE [rd].[fixed_asset_register] WITH CHECK 
  ADD CONSTRAINT [FK_fixed_asset_type] 
  FOREIGN KEY([fat_id])
    REFERENCES [rd].[fixed_asset_type] ([fat_id])
GO
ALTER TABLE [rd].[fixed_asset_register] CHECK CONSTRAINT [FK_fixed_asset_type]
GO
