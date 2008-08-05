ALTER TABLE [odps].[post_tax_deductions] WITH CHECK 
  ADD CONSTRAINT [fk_balance_contractor] 
  FOREIGN KEY([contractor_supplier_no])
    REFERENCES [rd].[contractor] ([contractor_supplier_no])
GO
ALTER TABLE [odps].[post_tax_deductions] CHECK CONSTRAINT [fk_balance_contractor]
GO
ALTER TABLE [odps].[post_tax_deductions] WITH CHECK 
  ADD CONSTRAINT [FK_POST_TAX_REF_13920_PAYMENT_] 
  FOREIGN KEY([pct_id])
    REFERENCES [odps].[Payment_Component_Type] ([pct_id])
GO
ALTER TABLE [odps].[post_tax_deductions] CHECK CONSTRAINT [FK_POST_TAX_REF_13920_PAYMENT_]
GO
