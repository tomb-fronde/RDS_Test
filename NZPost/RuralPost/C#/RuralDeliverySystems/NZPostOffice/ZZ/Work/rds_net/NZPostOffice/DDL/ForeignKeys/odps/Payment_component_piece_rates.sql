ALTER TABLE [odps].[Payment_component_piece_rates] WITH CHECK 
  ADD CONSTRAINT [fk_payment__ref_16341_payment_] 
  FOREIGN KEY([pc_id])
    REFERENCES [odps].[Payment_Component] ([pc_id])
  ON UPDATE CASCADE
  ON DELETE CASCADE
GO
ALTER TABLE [odps].[Payment_component_piece_rates] CHECK CONSTRAINT [fk_payment__ref_16341_payment_]
GO
ALTER TABLE [odps].[Payment_component_piece_rates] WITH CHECK 
  ADD CONSTRAINT [FK_PAYMENT__REF_16363_PIECE_RA] 
  FOREIGN KEY([prt_key])
    REFERENCES [rd].[piece_rate_type] ([prt_key])
GO
ALTER TABLE [odps].[Payment_component_piece_rates] CHECK CONSTRAINT [FK_PAYMENT__REF_16363_PIECE_RA]
GO
