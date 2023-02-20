ALTER TABLE [rd].[piece_rate] WITH CHECK 
  ADD CONSTRAINT [FK_piece_rate_type] 
  FOREIGN KEY([prt_key])
    REFERENCES [rd].[piece_rate_type] ([prt_key])
GO
ALTER TABLE [rd].[piece_rate] CHECK CONSTRAINT [FK_piece_rate_type]
GO
