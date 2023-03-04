CREATE TABLE [rd].[piece_rate_delivery] (
    [contract_no]      INT             NOT NULL,
    [prd_date]         DATETIME        NOT NULL,
    [prt_key]          INT             NOT NULL,
    [prd_quantity]     INT             NULL,
    [prd_cost]         NUMERIC (10, 2) NULL,
    [____]             INT             NULL,
    [prd_paid_to_date] DATETIME        NULL,
    CONSTRAINT [piece_rate_delivery_cns] PRIMARY KEY CLUSTERED ([contract_no] ASC, [prd_date] ASC, [prt_key] ASC),
    CONSTRAINT [FK_contract3] FOREIGN KEY ([contract_no]) REFERENCES [rd].[contract] ([contract_no]),
    CONSTRAINT [FK_piece_rate_type1] FOREIGN KEY ([prt_key]) REFERENCES [rd].[piece_rate_type] ([prt_key])
);


GO
CREATE NONCLUSTERED INDEX [pr_prt]
    ON [rd].[piece_rate_delivery]([prt_key] ASC);


GO
CREATE NONCLUSTERED INDEX [pr_prdate]
    ON [rd].[piece_rate_delivery]([prd_date] ASC);


GO
CREATE NONCLUSTERED INDEX [pr_paiddate]
    ON [rd].[piece_rate_delivery]([prd_paid_to_date] ASC);


GO
CREATE NONCLUSTERED INDEX [pr_contract]
    ON [rd].[piece_rate_delivery]([contract_no] ASC);

