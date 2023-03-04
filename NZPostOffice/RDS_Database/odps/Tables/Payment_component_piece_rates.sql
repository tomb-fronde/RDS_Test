CREATE TABLE [odps].[Payment_component_piece_rates] (
    [pcpr_id]     INT             IDENTITY (1, 1) NOT NULL,
    [prt_key]     INT             NOT NULL,
    [pc_id]       INT             NOT NULL,
    [pcpr_volume] INT             NOT NULL,
    [pcpr_value]  NUMERIC (12, 2) NOT NULL,
    CONSTRAINT [Payment_component_piece_rates_cns] PRIMARY KEY CLUSTERED ([pcpr_id] ASC),
    CONSTRAINT [fk_payment__ref_16341_payment_] FOREIGN KEY ([pc_id]) REFERENCES [odps].[Payment_Component] ([pc_id]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_PAYMENT__REF_16363_PIECE_RA] FOREIGN KEY ([prt_key]) REFERENCES [rd].[piece_rate_type] ([prt_key])
);


GO
CREATE NONCLUSTERED INDEX [pcpr_pc]
    ON [odps].[Payment_component_piece_rates]([pc_id] ASC);

