CREATE TABLE [rd].[vehicle_rate] (
    [vr_rates_effective_date]        DATETIME        NOT NULL,
    [vr_nominal_vehicle_value]       NUMERIC (10, 2) NULL,
    [vr_repairs_maintenance_rate]    NUMERIC (6, 2)  NULL,
    [vr_tyre_tubes_rate]             NUMERIC (6, 2)  NULL,
    [vr_vehicle_allowance_rate]      NUMERIC (6, 2)  NULL,
    [vr_licence_rate]                NUMERIC (6, 2)  NULL,
    [vr_vehicle_rate_of_return_pct]  NUMERIC (6, 2)  NULL,
    [vr_salvage_ratio]               NUMERIC (6, 2)  NULL,
    [vr_ruc]                         NUMERIC (8, 2)  NULL,
    [vr_sundries_k]                  NUMERIC (12, 2) NULL,
    [vr_vehicle_value_insurance_pct] NUMERIC (12, 2) NULL,
    [vt_key]                         INT             NOT NULL,
    [vr_livery]                      NUMERIC (12, 2) NULL,
    CONSTRAINT [vehicle_rate_cns] PRIMARY KEY CLUSTERED ([vr_rates_effective_date] ASC, [vt_key] ASC),
    CONSTRAINT [FK_VEHICLE__REF_1269_VEHICLE_] FOREIGN KEY ([vt_key]) REFERENCES [rd].[vehicle_type] ([vt_key]),
    CONSTRAINT [FK_VEHICLE__REF_1269_VEHICLE_1] FOREIGN KEY ([vt_key]) REFERENCES [rd].[vehicle_type] ([vt_key])
);

