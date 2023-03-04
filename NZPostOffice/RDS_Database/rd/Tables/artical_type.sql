CREATE TABLE [rd].[artical_type] (
    [at_key]         INT          IDENTITY (1, 1) NOT NULL,
    [at_description] VARCHAR (40) NULL,
    CONSTRAINT [artical_type_cns] PRIMARY KEY CLUSTERED ([at_key] ASC)
);

