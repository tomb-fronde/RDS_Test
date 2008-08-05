ALTER TABLE [odps].[Payment] WITH CHECK 
  ADD CONSTRAINT [fk_payment_ref_13929_payment_] 
  FOREIGN KEY([pr_id])
    REFERENCES [odps].[payment_runs] ([pr_id])
  ON UPDATE CASCADE
  ON DELETE CASCADE
GO
ALTER TABLE [odps].[Payment] CHECK CONSTRAINT [fk_payment_ref_13929_payment_]
GO
ALTER TABLE [odps].[Payment] WITH CHECK 
  ADD CONSTRAINT [FK_PAYMENT_REF_5177_CONTRACT] 
  FOREIGN KEY([contractor_supplier_no], [contract_no], [contract_seq_number])
    REFERENCES [rd].[contractor_renewals] ([contractor_supplier_no], [contract_no], [contract_seq_number])
GO
ALTER TABLE [odps].[Payment] CHECK CONSTRAINT [FK_PAYMENT_REF_5177_CONTRACT]
GO
