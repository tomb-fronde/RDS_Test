ALTER TABLE [rd].[address] WITH CHECK 
  ADD CONSTRAINT [FK_ADDRESS_REF_576_CONTRACT] 
  FOREIGN KEY([contract_no])
    REFERENCES [rd].[contract] ([contract_no])
GO
ALTER TABLE [rd].[address] CHECK CONSTRAINT [FK_ADDRESS_REF_576_CONTRACT]
GO
ALTER TABLE [rd].[address] WITH CHECK 
  ADD CONSTRAINT [FK_ADDRESS_REF_594_TOWNCITY] 
  FOREIGN KEY([tc_id])
    REFERENCES [rd].[TownCity] ([tc_id])
GO
ALTER TABLE [rd].[address] CHECK CONSTRAINT [FK_ADDRESS_REF_594_TOWNCITY]
GO
ALTER TABLE [rd].[address] WITH CHECK 
  ADD CONSTRAINT [FK_ADDRESS_REF_597_SUBURBLO] 
  FOREIGN KEY([sl_id])
    REFERENCES [rd].[SuburbLocality] ([sl_id])
GO
ALTER TABLE [rd].[address] CHECK CONSTRAINT [FK_ADDRESS_REF_597_SUBURBLO]
GO
ALTER TABLE [rd].[address] WITH CHECK 
  ADD CONSTRAINT [FK_ADDRESS_REF_603_ROAD] 
  FOREIGN KEY([road_id])
    REFERENCES [rd].[Road] ([road_id])
GO
ALTER TABLE [rd].[address] CHECK CONSTRAINT [FK_ADDRESS_REF_603_ROAD]
GO
ALTER TABLE [rd].[address] WITH CHECK 
  ADD CONSTRAINT [FK_ADDRESS_REFERENCE_POST_COD] 
  FOREIGN KEY([post_code_id])
    REFERENCES [rd].[post_code] ([post_code_id])
GO
ALTER TABLE [rd].[address] CHECK CONSTRAINT [FK_ADDRESS_REFERENCE_POST_COD]
GO