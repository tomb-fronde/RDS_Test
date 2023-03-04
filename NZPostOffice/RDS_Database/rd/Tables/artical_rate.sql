CREATE TABLE [rd].[artical_rate] (
    [at_key]              INT            NOT NULL,
    [art_effective_date]  DATETIME       NOT NULL,
    [contract_no]         INT            NOT NULL,
    [contract_seq_number] INT            NOT NULL,
    [art_rate]            NUMERIC (8, 2) NULL,
    CONSTRAINT [artical_rate_cns] PRIMARY KEY CLUSTERED ([at_key] ASC, [art_effective_date] ASC, [contract_no] ASC, [contract_seq_number] ASC),
    CONSTRAINT [FK_artical_type] FOREIGN KEY ([at_key]) REFERENCES [rd].[artical_type] ([at_key]),
    CONSTRAINT [FK_contract_renewals1] FOREIGN KEY ([contract_no], [contract_seq_number]) REFERENCES [rd].[contract_renewals] ([contract_no], [contract_seq_number])
);

