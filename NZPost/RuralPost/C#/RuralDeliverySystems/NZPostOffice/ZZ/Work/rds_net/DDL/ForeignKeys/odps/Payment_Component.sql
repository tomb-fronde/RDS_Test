ALTER TABLE [odps].[Payment_Component] WITH CHECK 
  ADD CONSTRAINT [fk_payment__ref_5187_payment] 
  FOREIGN KEY([Invoice_ID])
    REFERENCES [odps].[Payment] ([Invoice_ID])
  ON UPDATE CASCADE
  ON DELETE CASCADE
GO
ALTER TABLE [odps].[Payment_Component] CHECK CONSTRAINT [fk_payment__ref_5187_payment]
GO
ALTER TABLE [odps].[Payment_Component] WITH CHECK 
  ADD CONSTRAINT [FK_PAYMENT__REF_5195_PAYMENT_] 
  FOREIGN KEY([pct_id])
    REFERENCES [odps].[Payment_Component_Type] ([pct_id])
GO
ALTER TABLE [odps].[Payment_Component] CHECK CONSTRAINT [FK_PAYMENT__REF_5195_PAYMENT_]
GO
