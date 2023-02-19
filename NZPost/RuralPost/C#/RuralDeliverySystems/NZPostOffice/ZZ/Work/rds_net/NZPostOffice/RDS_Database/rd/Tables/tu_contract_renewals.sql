CREATE TABLE [rd].[tu_contract_renewals] (
    [con_active_sequence]            SMALLINT        NOT NULL,
    [cct_key]                        INT             NULL,
    [contractno]                     INT             NULL,
    [rc_name]                        VARCHAR (100)   NULL,
    [title]                          VARCHAR (100)   NULL,
    [con_renewal_payment_value]      NUMERIC (12, 2) NULL,
    [ca_annual_amount]               NUMERIC (12, 2) NULL,
    [con_no_customers_at_renewal]    INT             NULL,
    [con_no_private_bags_at_renewal] INT             NULL,
    [con_start_date]                 DATETIME        NOT NULL,
    [con_rates_effective_date]       DATETIME        NOT NULL
);

