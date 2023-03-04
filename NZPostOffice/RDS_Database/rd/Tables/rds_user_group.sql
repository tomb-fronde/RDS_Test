CREATE TABLE [rd].[rds_user_group] (
    [ug_id]               INT           NOT NULL,
    [ug_name]             VARCHAR (50)  NULL,
    [ug_description]      VARCHAR (255) NULL,
    [ug_created_date]     DATETIME      NULL,
    [ug_created_by]       VARCHAR (20)  NULL,
    [ug_modified_date]    DATETIME      NULL,
    [ug_modified_by]      VARCHAR (20)  NULL,
    [ug_privacy_override] VARCHAR (1)   NULL,
    CONSTRAINT [rds_user_group_cns] PRIMARY KEY CLUSTERED ([ug_id] ASC)
);

