CREATE TABLE [rd].[occupation] (
    [occupation_id]          INT           NOT NULL,
    [occupation_description] VARCHAR (100) NULL,
    CONSTRAINT [occupation_cns] PRIMARY KEY CLUSTERED ([occupation_id] ASC)
);

