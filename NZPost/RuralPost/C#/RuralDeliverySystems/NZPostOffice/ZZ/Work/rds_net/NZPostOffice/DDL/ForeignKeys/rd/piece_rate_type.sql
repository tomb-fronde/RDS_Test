ALTER TABLE [rd].[piece_rate_type] WITH CHECK 
  ADD CONSTRAINT [fky_piece_rate_supplier] 
  FOREIGN KEY([prs_key])
    REFERENCES [rd].[piece_rate_supplier] ([prs_key])
GO
ALTER TABLE [rd].[piece_rate_type] CHECK CONSTRAINT [fky_piece_rate_supplier]
GO
