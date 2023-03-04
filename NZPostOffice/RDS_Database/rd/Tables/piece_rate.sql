CREATE TABLE [rd].[piece_rate] (
    [prt_key]           INT             NOT NULL,
    [pr_effective_date] DATETIME        NOT NULL,
    [rg_code]           INT             NOT NULL,
    [pr_active_status]  VARCHAR (1)     NULL,
    [pr_rate]           NUMERIC (10, 5) NULL,
    CONSTRAINT [piece_rate_cns] PRIMARY KEY CLUSTERED ([prt_key] ASC, [pr_effective_date] ASC, [rg_code] ASC),
    CONSTRAINT [FK_piece_rate_type] FOREIGN KEY ([prt_key]) REFERENCES [rd].[piece_rate_type] ([prt_key])
);


GO
CREATE NONCLUSTERED INDEX [pr_prtkey]
    ON [rd].[piece_rate]([prt_key] ASC);


GO
CREATE NONCLUSTERED INDEX [pr_prgcode]
    ON [rd].[piece_rate]([rg_code] ASC);


GO
CREATE NONCLUSTERED INDEX [pr_preffdate]
    ON [rd].[piece_rate]([pr_effective_date] ASC);

