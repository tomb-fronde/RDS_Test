CREATE TABLE [rd].[used_password] (
    [up_id]       INT          IDENTITY (1, 1) NOT NULL,
    [up_password] VARCHAR (20) NULL,
    [ui_id]       INT          NULL,
    CONSTRAINT [used_password_cns] PRIMARY KEY CLUSTERED ([up_id] ASC),
    CONSTRAINT [used_password UNIQUE (up_id)] UNIQUE NONCLUSTERED ([up_id] ASC)
);

