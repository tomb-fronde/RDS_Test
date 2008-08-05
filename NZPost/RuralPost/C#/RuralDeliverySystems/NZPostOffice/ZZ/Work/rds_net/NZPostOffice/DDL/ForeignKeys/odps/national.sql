ALTER TABLE [odps].[national] WITH CHECK 
  ADD CONSTRAINT [FK_Payment_Component_Type] 
  FOREIGN KEY([nat_AdPost_DefaultComptype])
    REFERENCES [odps].[Payment_Component_Type] ([pct_id])
GO
ALTER TABLE [odps].[national] CHECK CONSTRAINT [FK_Payment_Component_Type]
GO
ALTER TABLE [odps].[national] WITH CHECK 
  ADD CONSTRAINT [fk_xp_pct] 
  FOREIGN KEY([nat_xp_defaultcomptype])
    REFERENCES [odps].[Payment_Component_Type] ([pct_id])
GO
ALTER TABLE [odps].[national] CHECK CONSTRAINT [fk_xp_pct]
GO
ALTER TABLE [odps].[national] WITH CHECK 
  ADD CONSTRAINT [Payment_Component_Type2] 
  FOREIGN KEY([nat_ContAdj_DefaultCompType])
    REFERENCES [odps].[Payment_Component_Type] ([pct_id])
GO
ALTER TABLE [odps].[national] CHECK CONSTRAINT [Payment_Component_Type2]
GO
ALTER TABLE [odps].[national] WITH CHECK 
  ADD CONSTRAINT [Payment_Component_Type3] 
  FOREIGN KEY([nat_ContAllow_DefaultComptype])
    REFERENCES [odps].[Payment_Component_Type] ([pct_id])
GO
ALTER TABLE [odps].[national] CHECK CONSTRAINT [Payment_Component_Type3]
GO
ALTER TABLE [odps].[national] WITH CHECK 
  ADD CONSTRAINT [Payment_Component_Type4] 
  FOREIGN KEY([nat_CourierPost_DefaultComptype])
    REFERENCES [odps].[Payment_Component_Type] ([pct_id])
GO
ALTER TABLE [odps].[national] CHECK CONSTRAINT [Payment_Component_Type4]
GO
ALTER TABLE [odps].[national] WITH CHECK 
  ADD CONSTRAINT [Payment_Component_Type5] 
  FOREIGN KEY([nat_Deductions_DefaultComptype])
    REFERENCES [odps].[Payment_Component_Type] ([pct_id])
GO
ALTER TABLE [odps].[national] CHECK CONSTRAINT [Payment_Component_Type5]
GO
ALTER TABLE [odps].[national] WITH CHECK 
  ADD CONSTRAINT [Payment_Component_Type6] 
  FOREIGN KEY([nat_FreqAdj_DefaultCompType])
    REFERENCES [odps].[Payment_Component_Type] ([pct_id])
GO
ALTER TABLE [odps].[national] CHECK CONSTRAINT [Payment_Component_Type6]
GO
