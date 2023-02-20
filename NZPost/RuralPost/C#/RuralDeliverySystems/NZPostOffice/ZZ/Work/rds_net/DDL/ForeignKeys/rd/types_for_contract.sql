ALTER TABLE [rd].[types_for_contract] WITH CHECK 
ADD CONSTRAINT [FK_contract_type] 
FOREIGN KEY([ct_key])
REFERENCES [rd].[contract_type] ([ct_key])
GO
ALTER TABLE [rd].[types_for_contract] CHECK CONSTRAINT [FK_contract_type]
GO
ALTER TABLE [rd].[types_for_contract] WITH CHECK 
ADD CONSTRAINT [FK_contract5] 
FOREIGN KEY([contract_no])
REFERENCES [rd].[contract] ([contract_no])
GO
ALTER TABLE [rd].[types_for_contract] CHECK CONSTRAINT [FK_contract5]
GO
