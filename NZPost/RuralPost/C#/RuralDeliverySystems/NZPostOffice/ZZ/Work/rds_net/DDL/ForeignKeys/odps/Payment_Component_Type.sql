ALTER TABLE [odps].[Payment_Component_Type] WITH CHECK 
  ADD CONSTRAINT [pct_pcg_fk] 
  FOREIGN KEY([pcg_id])
    REFERENCES [odps].[payment_component_group] ([pcg_id])
GO
ALTER TABLE [odps].[Payment_Component_Type] CHECK CONSTRAINT [pct_pcg_fk]
GO
ALTER TABLE [odps].[Payment_Component_Type] WITH CHECK 
  ADD CONSTRAINT [piece_rate_supplier] 
  FOREIGN KEY([prs_key])
    REFERENCES [rd].[piece_rate_supplier] ([prs_key])
  ON UPDATE SET NULL
  ON DELETE SET NULL
GO
ALTER TABLE [odps].[Payment_Component_Type] CHECK CONSTRAINT [piece_rate_supplier]
GO
