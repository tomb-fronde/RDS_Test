ALTER TABLE [odps].[t_payment] WITH CHECK 
  ADD CONSTRAINT [FK_contract_renewals2] 
  FOREIGN KEY([contract_no], [contract_seq_number])
    REFERENCES [rd].[contract_renewals] ([contract_no], [contract_seq_number])
  ON UPDATE CASCADE
  ON DELETE CASCADE
GO
ALTER TABLE [odps].[t_payment] CHECK CONSTRAINT [FK_contract_renewals2]
GO
ALTER TABLE [odps].[t_payment] WITH NOCHECK 
  ADD CONSTRAINT [FK_t_payment_runs] 
  FOREIGN KEY([pr_id])
    REFERENCES [odps].[t_payment_runs] ([pr_id])
  ON UPDATE CASCADE
  ON DELETE CASCADE
GO
ALTER TABLE [odps].[t_payment] CHECK CONSTRAINT [FK_t_payment_runs]
GO
