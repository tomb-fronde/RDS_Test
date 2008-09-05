ALTER TABLE [rd].[vehicle] WITH CHECK 
  ADD CONSTRAINT [FK_fuel_type1] 
  FOREIGN KEY([ft_key])
    REFERENCES [rd].[fuel_type] ([ft_key])
GO
ALTER TABLE [rd].[vehicle] CHECK CONSTRAINT [FK_fuel_type1]
GO
ALTER TABLE [rd].[vehicle] WITH CHECK 
  ADD CONSTRAINT [FK_VEHICLE_REF_1997_VEHICLE_] 
  FOREIGN KEY([vs_key])
    REFERENCES [rd].[vehicle_style] ([vs_key])
GO
ALTER TABLE [rd].[vehicle] CHECK CONSTRAINT [FK_VEHICLE_REF_1997_VEHICLE_]
GO
ALTER TABLE [rd].[vehicle] WITH CHECK 
  ADD CONSTRAINT [FK_vehicle_type] 
  FOREIGN KEY([vt_key])
    REFERENCES [rd].[vehicle_type] ([vt_key])
GO
ALTER TABLE [rd].[vehicle] CHECK CONSTRAINT [FK_vehicle_type]
GO
