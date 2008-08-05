ALTER TABLE [rd].[piece_rate_delivery] WITH CHECK 
  ADD CONSTRAINT [FK_contract3] 
  FOREIGN KEY([contract_no])
    REFERENCES [rd].[contract] ([contract_no])
GO
ALTER TABLE [rd].[piece_rate_delivery] CHECK CONSTRAINT [FK_contract3]
GO
ALTER TABLE [rd].[piece_rate_delivery] WITH CHECK 
  ADD CONSTRAINT [FK_piece_rate_type1] 
  FOREIGN KEY([prt_key])
    REFERENCES [rd].[piece_rate_type] ([prt_key])
GO
ALTER TABLE [rd].[piece_rate_delivery] CHECK CONSTRAINT [FK_piece_rate_type1]
GO
