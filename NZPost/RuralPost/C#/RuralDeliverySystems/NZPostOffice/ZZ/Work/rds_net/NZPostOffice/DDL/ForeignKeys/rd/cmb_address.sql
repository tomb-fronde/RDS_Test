ALTER TABLE [rd].[cmb_address] WITH CHECK 
  ADD CONSTRAINT [FK_cmb_address_contract] 
  FOREIGN KEY([contract_no])
    REFERENCES [rd].[contract] ([contract_no])
GO
ALTER TABLE [rd].[cmb_address] CHECK CONSTRAINT [FK_cmb_address_contract]
GO
ALTER TABLE [rd].[cmb_address] WITH CHECK 
  ADD CONSTRAINT [FK_CMB_ADDRESS_TOWNCITY] 
  FOREIGN KEY([tc_id])
    REFERENCES [rd].[TownCity] ([tc_id])
GO
ALTER TABLE [rd].[cmb_address] CHECK CONSTRAINT [FK_CMB_ADDRESS_TOWNCITY]
GO
ALTER TABLE [rd].[cmb_address] WITH CHECK 
  ADD CONSTRAINT [FK_CNB_ADDRESS_POST_CODE] 
  FOREIGN KEY([post_code_id])
    REFERENCES [rd].[post_code] ([post_code_id])
GO
ALTER TABLE [rd].[cmb_address] CHECK CONSTRAINT [FK_CNB_ADDRESS_POST_CODE]
GO
