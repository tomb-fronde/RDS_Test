CREATE TABLE [rd].[contract_adjustments] (
    [ca_key]              INT             NOT NULL,
    [contract_no]         INT             NOT NULL,
    [contract_seq_number] INT             NOT NULL,
    [ca_date_occured]     DATETIME        NULL,
    [ca_reason]           VARCHAR (40)    NULL,
    [ca_date_paid]        DATETIME        NULL,
    [ca_amount]           NUMERIC (10, 2) NULL,
    [ca_confirmed]        VARCHAR (1)     NULL,
    [pct_id]              INT             NULL,
    CONSTRAINT [contract_adjustments_cns] PRIMARY KEY CLUSTERED ([ca_key] ASC, [contract_no] ASC, [contract_seq_number] ASC),
    CONSTRAINT [FK_contract_renewals3] FOREIGN KEY ([contract_no], [contract_seq_number]) REFERENCES [rd].[contract_renewals] ([contract_no], [contract_seq_number])
);


GO
CREATE NONCLUSTERED INDEX [icontractseq_no]
    ON [rd].[contract_adjustments]([contract_no] ASC, [contract_seq_number] ASC);


GO
CREATE NONCLUSTERED INDEX [ica_key]
    ON [rd].[contract_adjustments]([ca_key] ASC);


GO
CREATE NONCLUSTERED INDEX [i_cadate]
    ON [rd].[contract_adjustments]([ca_date_occured] DESC);


GO
CREATE NONCLUSTERED INDEX [ca_datepaid]
    ON [rd].[contract_adjustments]([ca_date_paid] ASC);

