CREATE TABLE [odps].[t_payment] (
    [contractor_supplier_no]      INT            NOT NULL,
    [contract_no]                 INT            NOT NULL,
    [contract_seq_number]         INT            NOT NULL,
    [invoice_id]                  INT            IDENTITY (1, 1) NOT NULL,
    [pr_id]                       INT            NOT NULL,
    [invoice_date]                DATETIME       NOT NULL,
    [witholding_tax_rate_applied] NUMERIC (5, 2) NULL,
    [invoice_no]                  INT            NULL,
    [case_no]                     INT            NULL,
    [POTS]                        VARCHAR (50)   CONSTRAINT [DF__t_payment__POTS__4336F4B9] DEFAULT ('N') NULL,
    CONSTRAINT [t_payment_cns] PRIMARY KEY CLUSTERED ([invoice_id] ASC),
    CONSTRAINT [FK_contract_renewals2] FOREIGN KEY ([contract_no], [contract_seq_number]) REFERENCES [rd].[contract_renewals] ([contract_no], [contract_seq_number]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_t_payment_runs] FOREIGN KEY ([pr_id]) REFERENCES [odps].[t_payment_runs] ([pr_id]) ON DELETE CASCADE ON UPDATE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [tpi2]
    ON [odps].[t_payment]([contract_no] ASC);


GO
CREATE NONCLUSTERED INDEX [tpi1]
    ON [odps].[t_payment]([contractor_supplier_no] ASC);

