ALTER TABLE [rd].[fuel_rates] WITH CHECK 
  ADD CONSTRAINT [FK_fuel_type] 
  FOREIGN KEY([ft_key])
    REFERENCES [rd].[fuel_type] ([ft_key])
GO
ALTER TABLE [rd].[fuel_rates] CHECK CONSTRAINT [FK_fuel_type]
GO
