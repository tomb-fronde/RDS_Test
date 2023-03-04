CREATE TABLE [rd].[frequency_adjustments] (
    [contract_no]          INT             NOT NULL,
    [contract_seq_number]  INT             NOT NULL,
    [fd_unique_seq_number] INT             NOT NULL,
    [fd_adjustment_amount] NUMERIC (10, 2) NULL,
    [fd_paid_to_date]      DATETIME        NULL,
    [fd_bm_after_extn]     NUMERIC (10, 2) NULL,
    [fd_confirmed]         VARCHAR (1)     NULL,
    [fd_amount_to_pay]     NUMERIC (10, 2) NULL,
    [fd_effective_date]    DATETIME        NULL,
    [pct_id]               INT             NULL,
    [sf_key]               INT             NULL,
    [rf_delivery_days]     VARCHAR (7)     NULL,
    CONSTRAINT [frequency_adjustments_cns] PRIMARY KEY CLUSTERED ([contract_no] ASC, [contract_seq_number] ASC, [fd_unique_seq_number] ASC),
    CONSTRAINT [FK_contract_renewals6] FOREIGN KEY ([contract_no], [contract_seq_number]) REFERENCES [rd].[contract_renewals] ([contract_no], [contract_seq_number]),
    CONSTRAINT [FK_contract6] FOREIGN KEY ([contract_no]) REFERENCES [rd].[contract] ([contract_no]),
    CONSTRAINT [FK_FREQUENC_REF_6264_PAYMENT_] FOREIGN KEY ([pct_id]) REFERENCES [odps].[Payment_Component_Type] ([pct_id])
);


GO
CREATE NONCLUSTERED INDEX [fd_date_paid]
    ON [rd].[frequency_adjustments]([fd_paid_to_date] ASC);

