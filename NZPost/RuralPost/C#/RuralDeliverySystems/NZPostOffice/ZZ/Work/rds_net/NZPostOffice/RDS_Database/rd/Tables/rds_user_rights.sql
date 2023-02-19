CREATE TABLE [rd].[rds_user_rights] (
    [rur_id]     INT         NOT NULL,
    [rur_create] VARCHAR (1) NULL,
    [region_id]  INT         NULL,
    [ug_id]      INT         NULL,
    [rc_id]      INT         NULL,
    [rur_read]   VARCHAR (1) NULL,
    [rur_modify] VARCHAR (1) NULL,
    [rur_delete] VARCHAR (1) NULL,
    CONSTRAINT [rds_user_rights_cns] PRIMARY KEY CLUSTERED ([rur_id] ASC),
    CONSTRAINT [FK_RDS_USER_REFERENCE_RDS_COMP] FOREIGN KEY ([rc_id]) REFERENCES [rd].[rds_component] ([rc_id]) ON DELETE CASCADE,
    CONSTRAINT [FK_RDS_USER_REFERENCE_RDS_USER2] FOREIGN KEY ([ug_id]) REFERENCES [rd].[rds_user_group] ([ug_id])
);


GO
CREATE NONCLUSTERED INDEX [idx_rdu_rc_id]
    ON [rd].[rds_user_rights]([rc_id] ASC);

