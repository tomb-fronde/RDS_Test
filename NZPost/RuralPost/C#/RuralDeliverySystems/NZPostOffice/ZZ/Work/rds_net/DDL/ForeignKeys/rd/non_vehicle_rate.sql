ALTER TABLE [rd].[non_vehicle_rate] WITH CHECK 
  ADD CONSTRAINT [FK_NON_VEHI_REF_784_RENEWAL_] 
  FOREIGN KEY([rg_code])
    REFERENCES [rd].[renewal_group] ([rg_code])
GO
ALTER TABLE [rd].[non_vehicle_rate] CHECK CONSTRAINT [FK_NON_VEHI_REF_784_RENEWAL_]
GO
ALTER TABLE [rd].[non_vehicle_rate] WITH CHECK 
  ADD CONSTRAINT [FK_NON_VEHI_REF_784_RENEWAL_1] 
  FOREIGN KEY([rg_code])
    REFERENCES [rd].[renewal_group] ([rg_code])
GO
ALTER TABLE [rd].[non_vehicle_rate] CHECK CONSTRAINT [FK_NON_VEHI_REF_784_RENEWAL_1]
GO
