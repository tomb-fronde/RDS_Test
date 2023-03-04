CREATE TABLE [rd].[allowance_type] (
    [alt_key]            INT             IDENTITY (1, 1) NOT NULL,
    [alt_description]    VARCHAR (35)    NULL,
    [alct_id]            INT             NULL,
    [alt_rate]           NUMERIC (10, 2) NULL,
    [alt_wks_yr]         NUMERIC (10, 2) NULL,
    [alt_acc]            NUMERIC (10, 2) NULL,
    [alt_effective_date] DATETIME        NULL,
    [alt_notes]          VARCHAR (200)   NULL,
    CONSTRAINT [allowance_type_cns] PRIMARY KEY CLUSTERED ([alt_key] ASC)
);

