ALTER TABLE [rd].[contract_allowance] WITH CHECK 
ADD CONSTRAINT [FK_allowance_type] 
FOREIGN KEY([alt_key])
REFERENCES [rd].[allowance_type] ([alt_key])
GO
ALTER TABLE [rd].[contract_allowance] CHECK CONSTRAINT [FK_allowance_type]
GO
ALTER TABLE [rd].[contract_allowance] WITH CHECK 
ADD CONSTRAINT [FK_contract] 
FOREIGN KEY([contract_no])
REFERENCES [rd].[contract] ([contract_no])
GO
ALTER TABLE [rd].[contract_allowance] CHECK CONSTRAINT [FK_contract]
GO
ALTER TABLE [rd].[contract_allowance] WITH CHECK 
ADD CONSTRAINT [FK_payment_component_type] 
FOREIGN KEY([pct_id])
REFERENCES [odps].[Payment_Component_Type] ([pct_id])
GO
ALTER TABLE [rd].[contract_allowance] CHECK CONSTRAINT [FK_payment_component_type]
GO
