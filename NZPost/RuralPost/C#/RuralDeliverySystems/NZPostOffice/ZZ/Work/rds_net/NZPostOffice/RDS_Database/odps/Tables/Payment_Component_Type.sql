CREATE TABLE [odps].[Payment_Component_Type] (
    [pct_id]                    INT           IDENTITY (1, 1) NOT NULL,
    [ac_id]                     INT           NULL,
    [pct_description]           VARCHAR (100) NOT NULL,
    [pct_witholding_tax_status] VARCHAR (1)   NULL,
    [pcg_id]                    INT           NULL,
    [prs_key]                   INT           NULL,
    CONSTRAINT [Payment_Component_Type_cns] PRIMARY KEY CLUSTERED ([pct_id] ASC),
    CONSTRAINT [pct_pcg_fk] FOREIGN KEY ([pcg_id]) REFERENCES [odps].[payment_component_group] ([pcg_id]),
    CONSTRAINT [piece_rate_supplier] FOREIGN KEY ([prs_key]) REFERENCES [rd].[piece_rate_supplier] ([prs_key]) ON DELETE SET NULL ON UPDATE SET NULL
);


GO
CREATE NONCLUSTERED INDEX [pc_acid]
    ON [odps].[Payment_Component_Type]([ac_id] ASC);


GO
CREATE NONCLUSTERED INDEX [i_pctdesc]
    ON [odps].[Payment_Component_Type]([pct_description] ASC);

