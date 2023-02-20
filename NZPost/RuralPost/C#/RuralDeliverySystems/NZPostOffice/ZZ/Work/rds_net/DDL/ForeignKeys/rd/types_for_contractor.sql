ALTER TABLE [rd].[types_for_contractor] WITH CHECK 
ADD CONSTRAINT [FK_contract_type2] 
FOREIGN KEY([ct_key])
REFERENCES [rd].[contract_type] ([ct_key])
GO
ALTER TABLE [rd].[types_for_contractor] CHECK CONSTRAINT [FK_contract_type2]
GO
ALTER TABLE [rd].[types_for_contractor] WITH CHECK 
ADD CONSTRAINT [FK_contractor2] 
FOREIGN KEY([contractor_supplier_no])
REFERENCES [rd].[contractor] ([contractor_supplier_no])
GO
ALTER TABLE [rd].[types_for_contractor] CHECK CONSTRAINT [FK_contractor2]
GO
