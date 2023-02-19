CREATE TABLE [rd].[vehicle_override_rate] (
    [contract_no]                    INT             NOT NULL,
    [contract_seq_number]            INT             NOT NULL,
    [vor_nominal_vehicle_value]      NUMERIC (10, 2) NULL,
    [vor_repairs_maintenance_rate]   NUMERIC (6, 2)  NULL,
    [vor_tyre_tubes_rate]            NUMERIC (6, 2)  NULL,
    [vor_vehical_allowance_rate]     NUMERIC (6, 2)  NULL,
    [vor_licence_rate]               NUMERIC (6, 2)  NULL,
    [vor_vehicle_rate_of_return_pct] NUMERIC (6, 2)  NULL,
    [vor_salvage_ratio]              NUMERIC (6, 2)  NULL,
    [vor_ruc]                        NUMERIC (8, 2)  NULL,
    [vor_sundries_k]                 NUMERIC (12, 2) NULL,
    [vor_vehicle_insurance_premium]  NUMERIC (12, 2) NULL,
    [vor_fuel_rate]                  NUMERIC (6, 2)  NULL,
    [vor_consumption_rate]           NUMERIC (6, 2)  NULL,
    [vor_livery]                     NUMERIC (12, 2) NULL,
    [vor_effective_date]             DATETIME        NOT NULL,
    [vehicle_number]                 INT             NOT NULL,
    CONSTRAINT [vehicle_override_rate_cns] PRIMARY KEY CLUSTERED ([contract_no] ASC, [contract_seq_number] ASC, [vor_effective_date] ASC, [vehicle_number] ASC)
);

