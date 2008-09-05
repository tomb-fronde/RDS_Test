ALTER TABLE [odps].[t_payment_component] WITH CHECK 
  ADD CONSTRAINT [FK_payment_component_type1] 
  FOREIGN KEY([pct_id])
    REFERENCES [odps].[Payment_Component_Type] ([pct_id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [odps].[t_payment_component] CHECK CONSTRAINT [FK_payment_component_type1]
GO
ALTER TABLE [odps].[t_payment_component] WITH CHECK 
  ADD CONSTRAINT [FK_t_payment] 
  FOREIGN KEY([invoice_id])
    REFERENCES [odps].[t_payment] ([invoice_id])
  ON UPDATE CASCADE
  ON DELETE CASCADE
GO
ALTER TABLE [odps].[t_payment_component] CHECK CONSTRAINT [FK_t_payment]
GO
