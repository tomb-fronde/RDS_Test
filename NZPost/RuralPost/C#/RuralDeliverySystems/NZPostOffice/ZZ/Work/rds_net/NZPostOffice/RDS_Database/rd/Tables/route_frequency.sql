CREATE TABLE [rd].[route_frequency] (
    [contract_no]         INT             NOT NULL,
    [sf_key]              INT             NOT NULL,
    [rf_delivery_days]    VARCHAR (7)     NOT NULL,
    [rf_active]           VARCHAR (1)     NULL,
    [rf_distance]         NUMERIC (10, 2) NULL,
    [rf_annotation]       VARCHAR (500)   NULL,
    [rf_annotation_print] VARCHAR (1)     NULL,
    [rf_valid_ind]        INT             NULL,
    [rf_valid_date]       DATETIME        NULL,
    [rf_valid_user]       VARCHAR (20)    NULL,
    [rf_frozen]           INT             NULL,
    [rf_nms]              VARCHAR (10)    NULL,
    [rf_dpcount]          INT             NULL,
    [vehicle_number]      INT             NULL,
    CONSTRAINT [route_frequency_cns] PRIMARY KEY CLUSTERED ([contract_no] ASC, [sf_key] ASC, [rf_delivery_days] ASC),
    CONSTRAINT [FK_contract4] FOREIGN KEY ([contract_no]) REFERENCES [rd].[contract] ([contract_no]),
    CONSTRAINT [FK_standard_frequency1] FOREIGN KEY ([sf_key]) REFERENCES [rd].[standard_frequency] ([sf_key])
);


GO


CREATE TRIGGER [rd].[trig_modfreq1] ON [rd].[route_frequency]
WITH EXECUTE AS CALLER
FOR UPDATE
AS
begin
  declare @nContract int,
  @nSequence int,
  @nCount int
  select @nCount = count(*)
    from contract join
    contract_renewals on
    contract.contract_no = contract_renewals.contract_no and
    (contract.con_active_sequence is null or
    contract.con_active_sequence < contract_renewals.contract_seq_number) where
    contract.contract_no = (select contract_no from inserted)
  if @nCount > 0
    update contract_renewals set
      con_distance_at_renewal = rd.getcontractdistance(contract_no,contract_seq_number) where
      contract_no = (select contract_no from inserted) and
      contract_seq_number = (select max(contract_seq_number) from
        contract_renewals where
        contract_no = (select contract_no from inserted))
end
GO


CREATE TRIGGER [rd].[trig_insfreq1] ON [rd].[route_frequency]
WITH EXECUTE AS CALLER
FOR INSERT
AS
begin
  declare @nContract int,
  @nSequence int,
  @nCount int
  select @nCount = count(*)
    from contract join contract_renewals on
    contract.contract_no = contract_renewals.contract_no and
    (contract.con_active_sequence is null or
    contract.con_active_sequence < contract_renewals.contract_seq_number),inserted as i
 where
    contract.contract_no = i.contract_no
  if @nCount > 0
    update contract_renewals set
      con_distance_at_renewal = rd.getcontractdistance(contract_no,contract_seq_number) where
      contract_no = (select contract_no from inserted) and
      contract_seq_number = (select max(contract_seq_number) from
        contract_renewals where
        contract_no = (select contract_no from inserted))
end
GO


CREATE TRIGGER [rd].[trig_delfreq1] ON [rd].[route_frequency]
WITH EXECUTE AS CALLER
FOR DELETE
AS
begin
  declare @nContract int,
  @nSequence int,
  @nCount int
  select @nCount = count(*)
    from contract join
    contract_renewals on
    contract.contract_no = contract_renewals.contract_no and
    (contract.con_active_sequence is null or
    contract.con_active_sequence < contract_renewals.contract_seq_number) where
    contract.contract_no = (select contract_no from inserted)
  if @nCount > 0
    update contract_renewals set
      con_distance_at_renewal = rd.getcontractdistance(contract_no,contract_seq_number) where
      contract_no = (select contract_no from inserted) and
      contract_seq_number = (select max(contract_seq_number) from
        contract_renewals where
        contract_no = (select contract_no from inserted))
end