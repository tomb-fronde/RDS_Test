ALTER TABLE [rd].[contract_vehical] WITH CHECK 
  ADD CONSTRAINT [FK_contract_renewals5] 
  FOREIGN KEY([contract_no], [contract_seq_number])
    REFERENCES [rd].[contract_renewals] ([contract_no], [contract_seq_number])
  ON UPDATE CASCADE
  ON DELETE CASCADE
GO
ALTER TABLE [rd].[contract_vehical] CHECK CONSTRAINT [FK_contract_renewals5]
GO
ALTER TABLE [rd].[contract_vehical] WITH CHECK 
  ADD CONSTRAINT [FK_vehicle] 
  FOREIGN KEY([vehicle_number])
    REFERENCES [rd].[vehicle] ([vehicle_number])
GO
ALTER TABLE [rd].[contract_vehical] CHECK CONSTRAINT [FK_vehicle]
GO
