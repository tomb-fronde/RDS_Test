ALTER TABLE [rd].[contract] WITH CHECK 
  ADD CONSTRAINT [fk_base_office] 
  FOREIGN KEY([con_base_office])
    REFERENCES [rd].[outlet] ([outlet_id])
GO
ALTER TABLE [rd].[contract] CHECK CONSTRAINT [fk_base_office]
GO
ALTER TABLE [rd].[contract] WITH CHECK 
  ADD CONSTRAINT [fk_base_office1] 
  FOREIGN KEY([con_base_office])
    REFERENCES [rd].[outlet] ([outlet_id])
GO
ALTER TABLE [rd].[contract] CHECK CONSTRAINT [fk_base_office1]
GO
ALTER TABLE [rd].[contract] WITH CHECK 
  ADD CONSTRAINT [FK_outlet] 
  FOREIGN KEY([con_lodgement_office])
    REFERENCES [rd].[outlet] ([outlet_id])
GO
ALTER TABLE [rd].[contract] CHECK CONSTRAINT [FK_outlet]
GO
ALTER TABLE [rd].[contract]  ITH CHECK 
  ADD CONSTRAINT [FK_renewal_group] 
  FOREIGN KEY([rg_code])
    REFERENCES [rd].[renewal_group] ([rg_code])
GO
ALTER TABLE [rd].[contract] CHECK CONSTRAINT [FK_renewal_group]
GO
