ALTER TABLE [rd].[rds_user_contract_type] WITH CHECK 
  ADD CONSTRAINT [FK_RDS_CT_REFERENCE_RDS_CT] 
  FOREIGN KEY([ct_key])
    REFERENCES [rd].[contract_type] ([ct_key])
  ON DELETE CASCADE
GO
ALTER TABLE [rd].[rds_user_contract_type] CHECK CONSTRAINT [FK_RDS_CT_REFERENCE_RDS_CT]
GO
ALTER TABLE [rd].[rds_user_contract_type] WITH CHECK 
  ADD CONSTRAINT [FK_RDS_CT_REFERENCE_RDS_UID] 
  FOREIGN KEY([ui_id])
    REFERENCES [rd].[rds_user_id] ([ui_id])
GO
ALTER TABLE [rd].[rds_user_contract_type] CHECK CONSTRAINT [FK_RDS_CT_REFERENCE_RDS_UID]
GO
