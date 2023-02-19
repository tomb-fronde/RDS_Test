CREATE TABLE [rd].[route_description] (
    [sf_key]                  INT             NOT NULL,
    [contract_no]             INT             NOT NULL,
    [rd_sequence]             SMALLINT        NOT NULL,
    [rf_delivery_days]        VARCHAR (7)     NOT NULL,
    [rd_description_of_point] VARCHAR (40)    NULL,
    [rd_time_at_point]        DATETIME        NULL,
    [rfv_id]                  INT             NULL,
    [rfpd_id]                 INT             NULL,
    [rf_distance_of_leg]      NUMERIC (10, 2) NULL,
    [rf_running_total]        NUMERIC (10, 2) NULL,
    [rfv_id_2]                INT             NULL,
    [cust_id]                 INT             NULL,
    [adr_id]                  INT             NULL,
    CONSTRAINT [route_description_cns] PRIMARY KEY CLUSTERED ([sf_key] ASC, [contract_no] ASC, [rd_sequence] ASC, [rf_delivery_days] ASC),
    CONSTRAINT [FK_RDESC_ADR] FOREIGN KEY ([adr_id]) REFERENCES [rd].[address] ([adr_id]) ON DELETE CASCADE,
    CONSTRAINT [FK_ROUTE_DE_REFERENCE_RDS_CUST] FOREIGN KEY ([cust_id]) REFERENCES [rd].[rds_customer] ([cust_id]) ON DELETE SET NULL,
    CONSTRAINT [FK_route_frequency1] FOREIGN KEY ([contract_no], [sf_key], [rf_delivery_days]) REFERENCES [rd].[route_frequency] ([contract_no], [sf_key], [rf_delivery_days]),
    CONSTRAINT [fky_route_freq_verb] FOREIGN KEY ([rfv_id]) REFERENCES [rd].[route_freq_verbs] ([rfv_id]),
    CONSTRAINT [fky_route_pt_type] FOREIGN KEY ([rfpd_id]) REFERENCES [rd].[route_freq_point_type] ([rfpt_id])
);


GO
CREATE NONCLUSTERED INDEX [c]
    ON [rd].[route_description]([contract_no] ASC, [sf_key] ASC, [rf_delivery_days] ASC, [rd_sequence] ASC);

