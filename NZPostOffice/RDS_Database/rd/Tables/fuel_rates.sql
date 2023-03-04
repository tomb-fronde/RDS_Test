CREATE TABLE [rd].[fuel_rates] (
    [ft_key]                  INT            NOT NULL,
    [rg_code]                 INT            NOT NULL,
    [rr_rates_effective_date] DATETIME       NOT NULL,
    [fr_fuel_rate]            NUMERIC (6, 2) NULL,
    [fr_fuel_consumtion_rate] NUMERIC (6, 2) NULL,
    CONSTRAINT [fuel_rates_cns] PRIMARY KEY CLUSTERED ([ft_key] ASC, [rg_code] ASC, [rr_rates_effective_date] ASC),
    CONSTRAINT [FK_fuel_type] FOREIGN KEY ([ft_key]) REFERENCES [rd].[fuel_type] ([ft_key])
);

