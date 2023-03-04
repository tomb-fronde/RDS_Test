CREATE TABLE [rd].[SuburbLocality] (
    [sl_id]   INT          IDENTITY (1, 1) NOT NULL,
    [sl_name] VARCHAR (50) NULL,
    CONSTRAINT [SuburbLocality_cns] PRIMARY KEY CLUSTERED ([sl_id] ASC)
);

