CREATE TABLE [odps].[sync] (
    [sync_no]    INT          NOT NULL,
    [sync_name]  VARCHAR (30) NOT NULL,
    [sync_value] NUMERIC (5)  NOT NULL,
    CONSTRAINT [sync_cns] PRIMARY KEY CLUSTERED ([sync_no] ASC)
);

