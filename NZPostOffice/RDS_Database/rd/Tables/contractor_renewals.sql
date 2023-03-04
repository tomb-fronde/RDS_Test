CREATE TABLE [rd].[contractor_renewals] (
    [contractor_supplier_no] INT      NOT NULL,
    [contract_no]            INT      NOT NULL,
    [contract_seq_number]    INT      NOT NULL,
    [cr_effective_date]      DATETIME NULL,
    CONSTRAINT [contractor_renewals_cns] PRIMARY KEY CLUSTERED ([contractor_supplier_no] ASC, [contract_no] ASC, [contract_seq_number] ASC),
    CONSTRAINT [FK_contract_renewals2] FOREIGN KEY ([contract_no], [contract_seq_number]) REFERENCES [rd].[contract_renewals] ([contract_no], [contract_seq_number]),
    CONSTRAINT [FK_contractor1] FOREIGN KEY ([contractor_supplier_no]) REFERENCES [rd].[contractor] ([contractor_supplier_no])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [crr]
    ON [rd].[contractor_renewals]([contract_no] ASC, [contract_seq_number] ASC, [contractor_supplier_no] ASC, [cr_effective_date] ASC);


GO




CREATE TRIGGER [rd].[trig_UpdContractorRen1] ON [rd].[contractor_renewals]
WITH EXECUTE AS CALLER
FOR UPDATE
AS
if update(cr_effective_date) begin
  begin
    declare @dDate datetime
    select @dDate = max(cr_effective_date) 
      from contractor_renewals where
      contract_no = (select contract_no from inserted) and
      contract_seq_number = (select contract_seq_number from inserted)
    update contract_renewals set
      con_date_last_assigned = @dDate where
      contract_no = (select contract_no from inserted) and
      contract_seq_number = (select contract_seq_number from inserted)
  end
end
GO




CREATE TRIGGER [rd].[trig_ModContractorRen1] ON [rd].[contractor_renewals]
WITH EXECUTE AS CALLER
FOR INSERT
AS
begin
  declare @dDate datetime
  select @dDate = max(cr_effective_date)
    from contractor_renewals where
    contract_no = (select contract_no from inserted) and
    contract_seq_number = (select contract_seq_number from inserted)
  update contract_renewals set
    con_date_last_assigned = @dDate where
    contract_no = (select contract_no from inserted)  and
    contract_seq_number = (select contract_seq_number from inserted)
end
GO




CREATE TRIGGER [rd].[trig_DelContractorRen1] ON [rd].[contractor_renewals]
WITH EXECUTE AS CALLER
FOR DELETE
AS
begin
  declare @dDate datetime
  select @dDate = max(cr_effective_date) 
    from contractor_renewals where
    contract_no = (select contract_no from deleted) and
    contract_seq_number = (select contract_seq_number from deleted)
  update contract_renewals set
    con_date_last_assigned = @dDate where
    contract_no = (select contract_no from deleted) and
    contract_seq_number = (select contract_seq_number from deleted)
end