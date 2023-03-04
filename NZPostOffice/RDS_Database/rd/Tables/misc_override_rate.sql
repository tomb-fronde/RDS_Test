CREATE TABLE [rd].[misc_override_rate] (
    [contract_no]         INT            NOT NULL,
    [contract_seq_number] INT            NOT NULL,
    [mor_name]            VARCHAR (50)   NULL,
    [mor_value]           NUMERIC (9, 2) NULL,
    [mor_km_flag]         VARCHAR (1)    NULL,
    [mor_annual_flag]     VARCHAR (1)    NULL,
    [vehicle_number]      INT            NULL,
    CONSTRAINT [misc_override_rate_cns] PRIMARY KEY CLUSTERED ([contract_no] ASC, [contract_seq_number] ASC),
    CONSTRAINT [FK_MISC_OVE_REF_1026_CONTRACT] FOREIGN KEY ([contract_no], [contract_seq_number]) REFERENCES [rd].[contract_renewals] ([contract_no], [contract_seq_number])
);

