CREATE TABLE [rd].[rate_days] (
    [rg_code]                 INT      NOT NULL,
    [rr_rates_effective_date] DATETIME NOT NULL,
    [sf_key]                  INT      NOT NULL,
    [rtd_days_per_annum]      INT      NULL,
    CONSTRAINT [rate_days_cns] PRIMARY KEY CLUSTERED ([rg_code] ASC, [rr_rates_effective_date] ASC, [sf_key] ASC),
    CONSTRAINT [FK_standard_frequency] FOREIGN KEY ([sf_key]) REFERENCES [rd].[standard_frequency] ([sf_key])
);

