CREATE TABLE [odps].[Payment] (
    [contractor_supplier_no]      INT            NOT NULL,
    [contract_no]                 INT            NOT NULL,
    [contract_seq_number]         INT            NOT NULL,
    [Invoice_ID]                  INT            NOT NULL,
    [pr_id]                       INT            NOT NULL,
    [Invoice_date]                DATETIME       NOT NULL,
    [Witholding_tax_rate_applied] NUMERIC (5, 2) NULL,
    [invoice_no]                  INT            NULL,
    [case_no]                     INT            NULL,
    [POTS]                        VARCHAR (50)   CONSTRAINT [DF__Payment__POTS__1C1D2798] DEFAULT ('N') NULL,
    [batch_no]                    INT            NULL,
    CONSTRAINT [Payment_cns] PRIMARY KEY CLUSTERED ([Invoice_ID] ASC),
    CONSTRAINT [fk_payment_ref_13929_payment_] FOREIGN KEY ([pr_id]) REFERENCES [odps].[payment_runs] ([pr_id]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_PAYMENT_REF_5177_CONTRACT] FOREIGN KEY ([contractor_supplier_no], [contract_no], [contract_seq_number]) REFERENCES [rd].[contractor_renewals] ([contractor_supplier_no], [contract_no], [contract_seq_number])
);


GO
CREATE NONCLUSTERED INDEX [p3]
    ON [odps].[Payment]([Invoice_date] ASC);


GO
CREATE NONCLUSTERED INDEX [p2]
    ON [odps].[Payment]([Invoice_ID] ASC, [Invoice_date] ASC);


GO
CREATE NONCLUSTERED INDEX [p1]
    ON [odps].[Payment]([contract_no] ASC, [contractor_supplier_no] ASC, [contract_seq_number] ASC);

