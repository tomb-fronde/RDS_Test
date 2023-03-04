CREATE TABLE [rd].[vehicle_allowance_rates_history] (
    [var_id]             INT             NOT NULL,
    [var_description]    VARCHAR (100)   NULL,
    [var_carrier_pa]     NUMERIC (10, 2) NULL,
    [var_repairs_pk]     NUMERIC (10, 2) NULL,
    [var_licence_pa]     NUMERIC (10, 2) NULL,
    [var_tyres_pk]       NUMERIC (10, 2) NULL,
    [var_allowance_pk]   NUMERIC (10, 2) NULL,
    [var_insurance_pa]   NUMERIC (10, 2) NULL,
    [var_ror_pa]         NUMERIC (10, 2) NULL,
    [var_fuel_use_pk]    NUMERIC (10, 2) NULL,
    [var_fuel_rate]      NUMERIC (10, 2) NULL,
    [var_ruc_rate_pk]    NUMERIC (10, 2) NULL,
    [var_effective_date] DATETIME        NULL,
    [var_notes]          VARCHAR (200)   NULL
);

