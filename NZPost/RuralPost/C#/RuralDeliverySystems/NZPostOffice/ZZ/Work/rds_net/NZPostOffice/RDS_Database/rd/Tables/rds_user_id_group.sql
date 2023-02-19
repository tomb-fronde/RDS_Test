CREATE TABLE [rd].[rds_user_id_group] (
    [ug_id] INT NULL,
    [ui_id] INT NULL,
    CONSTRAINT [FK_RDS_USER_REFERENCE_RDS_USER_ID] FOREIGN KEY ([ui_id]) REFERENCES [rd].[rds_user_id] ([ui_id]),
    CONSTRAINT [FK_RDS_USER_REFERENCE_RDS_USER1] FOREIGN KEY ([ug_id]) REFERENCES [rd].[rds_user_group] ([ug_id])
);

