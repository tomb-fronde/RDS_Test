CREATE TABLE [rd].[artical_delivery] (
    [contract_no]         INT             NOT NULL,
    [ad_date]             DATETIME        NOT NULL,
    [at_key]              INT             NOT NULL,
    [art_effective_date]  DATETIME        NOT NULL,
    [contract_seq_number] INT             NOT NULL,
    [ad_quantity]         INT             NULL,
    [ad_value_paid]       NUMERIC (10, 2) NULL,
    CONSTRAINT [artical_delivery_cns] PRIMARY KEY CLUSTERED ([contract_no] ASC, [ad_date] ASC, [at_key] ASC, [art_effective_date] ASC, [contract_seq_number] ASC),
    CONSTRAINT [FK_artical_rate] FOREIGN KEY ([at_key], [art_effective_date], [contract_no], [contract_seq_number]) REFERENCES [rd].[artical_rate] ([at_key], [art_effective_date], [contract_no], [contract_seq_number]),
    CONSTRAINT [FK_contract_renewals] FOREIGN KEY ([contract_no], [contract_seq_number]) REFERENCES [rd].[contract_renewals] ([contract_no], [contract_seq_number])
);

