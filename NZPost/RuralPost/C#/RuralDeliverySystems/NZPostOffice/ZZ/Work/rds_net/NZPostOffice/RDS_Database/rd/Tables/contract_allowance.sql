CREATE TABLE [rd].[contract_allowance] (
    [alt_key]            INT             NOT NULL,
    [contract_no]        INT             NOT NULL,
    [ca_effective_date]  DATETIME        NOT NULL,
    [ca_annual_amount]   NUMERIC (10, 2) NULL,
    [ca_notes]           VARCHAR (200)   NULL,
    [ca_paid_to_date]    DATETIME        NULL,
    [pct_id]             INT             NULL,
    [ca_approved]        CHAR (1)        NULL,
    [ca_doc_description] VARCHAR (500)   NULL,
    [ca_var1]            NUMERIC (10, 2) NULL,
    [ca_dist_day]        NUMERIC (10, 2) NULL,
    [ca_hrs_wk]          NUMERIC (10, 2) NULL,
    [var_id]             INT             NULL,
    [ca_costs_covered]   CHAR (1)        NULL,
    [ca_row_changed]     CHAR (1)        NULL,
    CONSTRAINT [contract_allowance_cns] PRIMARY KEY CLUSTERED ([alt_key] ASC, [contract_no] ASC, [ca_effective_date] ASC),
    CONSTRAINT [FK_allowance_type] FOREIGN KEY ([alt_key]) REFERENCES [rd].[allowance_type] ([alt_key]),
    CONSTRAINT [FK_contract] FOREIGN KEY ([contract_no]) REFERENCES [rd].[contract] ([contract_no]),
    CONSTRAINT [FK_payment_component_type] FOREIGN KEY ([pct_id]) REFERENCES [odps].[Payment_Component_Type] ([pct_id])
);


GO
CREATE NONCLUSTERED INDEX [ica_datepaid]
    ON [rd].[contract_allowance]([ca_paid_to_date] ASC);


GO
CREATE NONCLUSTERED INDEX [ica_contno]
    ON [rd].[contract_allowance]([contract_no] ASC, [ca_effective_date] ASC);


GO
CREATE NONCLUSTERED INDEX [ica_altkey]
    ON [rd].[contract_allowance]([alt_key] ASC);

