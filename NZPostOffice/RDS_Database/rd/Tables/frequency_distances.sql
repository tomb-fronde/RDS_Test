CREATE TABLE [rd].[frequency_distances] (
    [fd_effective_date]        DATETIME       NOT NULL,
    [contract_no]              INT            NOT NULL,
    [sf_key]                   INT            NOT NULL,
    [rf_delivery_days]         VARCHAR (7)    NOT NULL,
    [fd_distance]              NUMERIC (8, 2) NULL,
    [fd_no_of_boxes]           SMALLINT       NULL,
    [fd_no_rural_bags]         SMALLINT       NULL,
    [fd_no_other_bags]         SMALLINT       NULL,
    [fd_no_private_bags]       SMALLINT       NULL,
    [fd_no_post_offices]       SMALLINT       NULL,
    [fd_no_cmbs]               SMALLINT       NULL,
    [fd_no_cmb_customers]      SMALLINT       NULL,
    [fd_change_reason]         VARCHAR (250)  NULL,
    [fd_delivery_hrs_per_week] NUMERIC (6, 3) NULL,
    [fd_processing_hrs_week]   NUMERIC (6, 2) NULL,
    [fd_volume]                NUMERIC (8, 2) NULL,
    CONSTRAINT [frequency_distances_cns] PRIMARY KEY CLUSTERED ([fd_effective_date] ASC, [contract_no] ASC, [sf_key] ASC, [rf_delivery_days] ASC),
    CONSTRAINT [FK_route_frequency2] FOREIGN KEY ([contract_no], [sf_key], [rf_delivery_days]) REFERENCES [rd].[route_frequency] ([contract_no], [sf_key], [rf_delivery_days])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [xpkfrequency_distances]
    ON [rd].[frequency_distances]([sf_key] ASC, [contract_no] ASC, [rf_delivery_days] ASC, [fd_effective_date] ASC);

