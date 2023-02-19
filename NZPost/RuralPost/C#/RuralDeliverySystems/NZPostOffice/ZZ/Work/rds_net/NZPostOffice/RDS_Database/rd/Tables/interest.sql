CREATE TABLE [rd].[interest] (
    [interest_id]          INT           NOT NULL,
    [interest_description] VARCHAR (100) NULL,
    CONSTRAINT [interest_cns] PRIMARY KEY CLUSTERED ([interest_id] ASC)
);

