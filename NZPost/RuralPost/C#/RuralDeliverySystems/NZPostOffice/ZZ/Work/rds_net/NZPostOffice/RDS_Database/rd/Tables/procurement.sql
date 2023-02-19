CREATE TABLE [rd].[procurement] (
    [proc_id]   INT          NOT NULL,
    [proc_name] VARCHAR (40) NULL,
    CONSTRAINT [procurement_cns] PRIMARY KEY CLUSTERED ([proc_id] ASC)
);

