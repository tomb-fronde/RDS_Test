CREATE TABLE [rd].[piece_rate_supplier] (
    [prs_key]         INT          IDENTITY (1, 1) NOT NULL,
    [prs_description] VARCHAR (40) NULL,
    [pct_id]          INT          NULL,
    CONSTRAINT [piece_rate_supplier_cns] PRIMARY KEY CLUSTERED ([prs_key] ASC),
    CONSTRAINT [FK_Payment_Component_Type1] FOREIGN KEY ([pct_id]) REFERENCES [odps].[Payment_Component_Type] ([pct_id])
);

