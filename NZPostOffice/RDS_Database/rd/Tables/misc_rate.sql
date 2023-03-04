CREATE TABLE [rd].[misc_rate] (
    [rg_code]           INT            NOT NULL,
    [mr_effective_date] DATETIME       NOT NULL,
    [mr_name]           VARCHAR (50)   NULL,
    [mr_value]          NUMERIC (9, 2) NULL,
    [mr_km_flag]        VARCHAR (1)    NULL,
    [mr_annual_flag]    VARCHAR (1)    NULL,
    CONSTRAINT [misc_rate_cns] PRIMARY KEY CLUSTERED ([rg_code] ASC, [mr_effective_date] ASC),
    CONSTRAINT [FK_MISC_RAT_REF_1010_RENEWAL_] FOREIGN KEY ([rg_code]) REFERENCES [rd].[renewal_group] ([rg_code])
);

