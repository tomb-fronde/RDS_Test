CREATE TABLE [rd].[piece_rate_type] (
    [prt_key]               INT          IDENTITY (1, 1) NOT NULL,
    [prt_description]       VARCHAR (40) NULL,
    [prt_code]              VARCHAR (4)  NULL,
    [prt_print_on_schedule] VARCHAR (1)  NULL,
    [prs_key]               INT          NULL,
    [prs_true_value]        VARCHAR (1)  NULL,
    CONSTRAINT [piece_rate_type_cns] PRIMARY KEY CLUSTERED ([prt_key] ASC),
    CONSTRAINT [fky_piece_rate_supplier] FOREIGN KEY ([prs_key]) REFERENCES [rd].[piece_rate_supplier] ([prs_key])
);


GO
CREATE NONCLUSTERED INDEX [prs_prsk]
    ON [rd].[piece_rate_type]([prs_key] ASC);

