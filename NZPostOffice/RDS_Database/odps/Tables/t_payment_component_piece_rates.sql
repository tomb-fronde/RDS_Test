CREATE TABLE [odps].[t_payment_component_piece_rates] (
    [pcpr_id]     INT             IDENTITY (1, 1) NOT NULL,
    [prt_key]     INT             NOT NULL,
    [pc_id]       INT             NOT NULL,
    [pcpr_volume] INT             NOT NULL,
    [pcpr_value]  NUMERIC (12, 2) NOT NULL,
    CONSTRAINT [t_payment_component_piece_rates_cns] PRIMARY KEY CLUSTERED ([pcpr_id] ASC),
    CONSTRAINT [FK_t_payment_component] FOREIGN KEY ([pc_id]) REFERENCES [odps].[t_payment_component] ([pc_id]) ON DELETE CASCADE ON UPDATE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [tpcpr1]
    ON [odps].[t_payment_component_piece_rates]([pc_id] ASC);


GO
CREATE NONCLUSTERED INDEX [tpc_prt]
    ON [odps].[t_payment_component_piece_rates]([prt_key] ASC);

