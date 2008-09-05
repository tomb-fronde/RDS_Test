ALTER TABLE [odps].[t_payment_component_piece_rates] WITH NOCHECK 
  ADD CONSTRAINT [FK_t_payment_component] 
  FOREIGN KEY([pc_id])
    REFERENCES [odps].[t_payment_component] ([pc_id])
  ON UPDATE CASCADE
  ON DELETE CASCADE
GO
ALTER TABLE [odps].[t_payment_component_piece_rates] CHECK CONSTRAINT [FK_t_payment_component]
GO
