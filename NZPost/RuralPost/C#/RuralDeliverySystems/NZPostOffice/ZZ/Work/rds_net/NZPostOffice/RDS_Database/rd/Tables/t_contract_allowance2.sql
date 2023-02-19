CREATE TABLE [rd].[t_contract_allowance2] (
    [alt_key]           INT             NOT NULL,
    [contract_no]       INT             NOT NULL,
    [ca_effective_date] DATETIME        NOT NULL,
    [ca_annual_amount]  NUMERIC (10, 2) NOT NULL,
    [ca_notes]          VARCHAR (200)   NULL,
    [ca_paid_to_date]   DATETIME        NULL,
    [pct_id]            INT             NULL,
    CONSTRAINT [t_contract_allowance2_cns] PRIMARY KEY CLUSTERED ([alt_key] ASC, [contract_no] ASC, [ca_effective_date] ASC, [ca_annual_amount] ASC)
);

