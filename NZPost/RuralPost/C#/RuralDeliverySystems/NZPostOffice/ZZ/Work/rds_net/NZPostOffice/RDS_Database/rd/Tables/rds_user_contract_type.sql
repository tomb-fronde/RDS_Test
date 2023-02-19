CREATE TABLE [rd].[rds_user_contract_type] (
    [ct_key] INT NULL,
    [ui_id]  INT NULL,
    CONSTRAINT [FK_RDS_CT_REFERENCE_RDS_CT] FOREIGN KEY ([ct_key]) REFERENCES [rd].[contract_type] ([ct_key]) ON DELETE CASCADE,
    CONSTRAINT [FK_RDS_CT_REFERENCE_RDS_UID] FOREIGN KEY ([ui_id]) REFERENCES [rd].[rds_user_id] ([ui_id])
);

