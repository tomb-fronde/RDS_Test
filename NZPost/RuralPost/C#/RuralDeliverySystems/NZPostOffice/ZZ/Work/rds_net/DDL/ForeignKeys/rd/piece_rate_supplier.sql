ALTER TABLE [rd].[piece_rate_supplier] WITH CHECK 
  ADD CONSTRAINT [FK_Payment_Component_Type1] 
  FOREIGN KEY([pct_id])
    REFERENCES [odps].[Payment_Component_Type] ([pct_id])
GO
ALTER TABLE [rd].[piece_rate_supplier] CHECK CONSTRAINT [FK_Payment_Component_Type1]
GO
