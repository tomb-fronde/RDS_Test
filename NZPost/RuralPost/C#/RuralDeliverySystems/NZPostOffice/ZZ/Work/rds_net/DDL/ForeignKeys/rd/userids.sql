ALTER TABLE [rd].[userids] WITH CHECK 
ADD CONSTRAINT [fk_region] 
FOREIGN KEY([region_id])
REFERENCES [rd].[region] ([region_id])
ON DELETE SET NULL
GO
ALTER TABLE [rd].[userids] CHECK CONSTRAINT [fk_region]
GO
ALTER TABLE [rd].[userids] WITH CHECK 
ADD CONSTRAINT [FK_user_groups] 
FOREIGN KEY([gp_code])
REFERENCES [rd].[user_groups] ([gp_code])
GO
ALTER TABLE [rd].[userids] CHECK CONSTRAINT [FK_user_groups]
GO
