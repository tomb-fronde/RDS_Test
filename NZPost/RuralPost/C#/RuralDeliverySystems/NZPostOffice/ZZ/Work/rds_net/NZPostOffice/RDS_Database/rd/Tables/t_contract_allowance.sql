CREATE TABLE [rd].[t_contract_allowance] (
    [alt_key]           INT             NOT NULL,
    [contract_no]       INT             NOT NULL,
    [ca_effective_date] DATETIME        NOT NULL,
    [ca_annual_amount]  NUMERIC (10, 2) NULL,
    [ca_notes]          VARCHAR (200)   NULL,
    [ca_paid_to_date]   DATETIME        NULL,
    [pct_id]            INT             NULL
);

