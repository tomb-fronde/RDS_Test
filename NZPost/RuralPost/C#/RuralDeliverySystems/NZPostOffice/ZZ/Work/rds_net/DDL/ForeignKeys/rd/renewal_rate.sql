ALTER TABLE [rd].[renewal_rate] WITH CHECK 
ADD CONSTRAINT [FK_renewal_group1] 
FOREIGN KEY([rg_code])
REFERENCES [rd].[renewal_group] ([rg_code])
GO
ALTER TABLE [rd].[renewal_rate] CHECK CONSTRAINT [FK_renewal_group1]
GO
