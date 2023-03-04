CREATE TABLE [rd].[non_vehicle_override_rate_history] (
    [contract_no]                  INT             NOT NULL,
    [contract_seq_number]          INT             NOT NULL,
    [nvor_wage_hourly_rate]        NUMERIC (6, 2)  NULL,
    [nvor_public_liability_rate_2] NUMERIC (6, 2)  NULL,
    [nvor_carrier_risk_rate]       NUMERIC (6, 2)  NULL,
    [nvor_acc_rate]                NUMERIC (6, 2)  NULL,
    [nvor_item_proc_rate_per_hour] SMALLINT        NULL,
    [nvor_frozen]                  CHAR (1)        NULL,
    [nvor_accounting]              NUMERIC (8, 2)  NULL,
    [nvor_telephone]               NUMERIC (8, 2)  NULL,
    [nvor_sundries]                NUMERIC (8, 2)  NULL,
    [nvor_acc_rate_amount]         NUMERIC (12, 2) NULL,
    [nvor_uniform]                 NUMERIC (12, 2) NULL,
    [nvor_delivery_wage_rate]      NUMERIC (6, 2)  NULL,
    [nvor_processing_wage_rate]    NUMERIC (6, 2)  NULL,
    [nvor_effective_date]          DATETIME        NOT NULL,
    [nvor_relief_weeks]            NUMERIC (6, 2)  NULL,
    CONSTRAINT [non_vehicle_override_rate_history_cns] PRIMARY KEY CLUSTERED ([contract_no] ASC, [contract_seq_number] ASC, [nvor_effective_date] ASC)
);

