CREATE TABLE [rd].[standard_frequency] (
    [sf_key]         INT          IDENTITY (1, 1) NOT NULL,
    [sf_description] VARCHAR (35) NULL,
    [sf_days_week]   SMALLINT     NULL,
    CONSTRAINT [standard_frequency_cns] PRIMARY KEY CLUSTERED ([sf_key] ASC)
);

