CREATE TABLE [rd].[budget] (
    [region_id]              INT      NOT NULL,
    [bud_year]               DATETIME NOT NULL,
    [bud_fixed_cost_vol]     INT      NULL,
    [bud_adpost_vol]         INT      NULL,
    [bud_courier_vol]        INT      NULL,
    [bud_medium_vol]         INT      NULL,
    [bud_small_parcel_vol]   INT      NULL,
    [bud_large_parcel_vol]   INT      NULL,
    [bud_fixed_cost_value]   INT      NULL,
    [bud_adpost_value]       INT      NULL,
    [bud_courier_value]      INT      NULL,
    [bud_medium_value]       INT      NULL,
    [bud_small_parcel_value] INT      NULL,
    [bud_large_parcel_value] INT      NULL,
    [bud_posting_qty]        INT      NULL,
    [bud_allowance_val]      INT      NULL,
    CONSTRAINT [budget_cns] PRIMARY KEY CLUSTERED ([region_id] ASC, [bud_year] ASC),
    CONSTRAINT [FK_region1] FOREIGN KEY ([region_id]) REFERENCES [rd].[region] ([region_id])
);

