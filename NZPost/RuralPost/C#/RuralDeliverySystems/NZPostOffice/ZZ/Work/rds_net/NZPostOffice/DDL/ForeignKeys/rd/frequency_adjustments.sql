ALTER TABLE [rd].[frequency_adjustments] WITH CHECK 
  ADD CONSTRAINT [FK_contract_renewals6] 
  FOREIGN KEY([contract_no], [contract_seq_number])
    REFERENCES [rd].[contract_renewals] ([contract_no], [contract_seq_number])
GO
ALTER TABLE [rd].[frequency_adjustments] CHECK CONSTRAINT [FK_contract_renewals6]
GO
ALTER TABLE [rd].[frequency_adjustments] WITH CHECK 
  ADD CONSTRAINT [FK_contract6] 
  FOREIGN KEY([contract_no])
    REFERENCES [rd].[contract] ([contract_no])
GO
ALTER TABLE [rd].[frequency_adjustments] CHECK CONSTRAINT [FK_contract6]
GO
ALTER TABLE [rd].[frequency_adjustments] WITH CHECK 
  ADD CONSTRAINT [FK_FREQUENC_REF_6264_PAYMENT_] 
  FOREIGN KEY([pct_id])
    REFERENCES [odps].[Payment_Component_Type] ([pct_id])
GO
ALTER TABLE [rd].[frequency_adjustments] CHECK CONSTRAINT [FK_FREQUENC_REF_6264_PAYMENT_]
GO
