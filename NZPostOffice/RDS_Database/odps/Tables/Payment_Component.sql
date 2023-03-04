CREATE TABLE [odps].[Payment_Component] (
    [pc_id]        INT              NOT NULL,
    [pct_id]       INT              NOT NULL,
    [Invoice_ID]   INT              NOT NULL,
    [pc_amount]    NUMERIC (12, 2)  NOT NULL,
    [comments]     VARCHAR (400)    NULL,
    [misc_date]    DATETIME         NULL,
    [misc_string]  VARCHAR (200)    NULL,
    [misc_decimal] NUMERIC (20, 12) NULL,
    [alt_key]      INT              NULL,
    CONSTRAINT [Payment_Component_cns] PRIMARY KEY CLUSTERED ([pc_id] ASC),
    CONSTRAINT [fk_payment__ref_5187_payment] FOREIGN KEY ([Invoice_ID]) REFERENCES [odps].[Payment] ([Invoice_ID]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_PAYMENT__REF_5195_PAYMENT_] FOREIGN KEY ([pct_id]) REFERENCES [odps].[Payment_Component_Type] ([pct_id])
);


GO
CREATE NONCLUSTERED INDEX [pct_inv]
    ON [odps].[Payment_Component]([Invoice_ID] ASC);

