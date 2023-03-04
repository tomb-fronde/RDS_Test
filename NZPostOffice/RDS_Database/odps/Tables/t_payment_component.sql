CREATE TABLE [odps].[t_payment_component] (
    [pc_id]        INT              IDENTITY (1, 1) NOT NULL,
    [pct_id]       INT              NOT NULL,
    [invoice_id]   INT              NOT NULL,
    [pc_amount]    NUMERIC (12, 2)  CONSTRAINT [DF__t_payment__pc_am__47FBA9D6] DEFAULT ((0)) NOT NULL,
    [comments]     VARCHAR (400)    NULL,
    [misc_date]    DATETIME         NULL,
    [misc_string]  VARCHAR (200)    NULL,
    [misc_decimal] NUMERIC (20, 12) NULL,
    [alt_key]      INT              NULL,
    CONSTRAINT [t_payment_component_cns] PRIMARY KEY CLUSTERED ([pc_id] ASC),
    CONSTRAINT [FK_payment_component_type1] FOREIGN KEY ([pct_id]) REFERENCES [odps].[Payment_Component_Type] ([pct_id]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_t_payment] FOREIGN KEY ([invoice_id]) REFERENCES [odps].[t_payment] ([invoice_id]) ON DELETE CASCADE ON UPDATE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [tpci1]
    ON [odps].[t_payment_component]([invoice_id] ASC);


GO
CREATE NONCLUSTERED INDEX [tpc_pct]
    ON [odps].[t_payment_component]([pct_id] ASC);

