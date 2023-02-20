ALTER TABLE [rd].[contract_fixed_assets] WITH CHECK 
ADD CONSTRAINT [FK_contract1] 
FOREIGN KEY([contract_no])
REFERENCES [rd].[contract] ([contract_no])
GO
ALTER TABLE [rd].[contract_fixed_assets] CHECK CONSTRAINT [FK_contract1]
GO
ALTER TABLE [rd].[contract_fixed_assets] WITH CHECK 
ADD CONSTRAINT [FK_fixed_asset_register] 
FOREIGN KEY([fa_fixed_asset_no])
REFERENCES [rd].[fixed_asset_register] ([fa_fixed_asset_no])
GO
ALTER TABLE [rd].[contract_fixed_assets] CHECK CONSTRAINT [FK_fixed_asset_register]
GO
