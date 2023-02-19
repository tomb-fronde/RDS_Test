CREATE TABLE [rd].[mail_carried] (
    [sf_key]               INT          NOT NULL,
    [contract_no]          INT          NOT NULL,
    [mc_sequence_no]       INT          NOT NULL,
    [rf_delivery_days]     VARCHAR (7)  NOT NULL,
    [mc_dispatch_carried]  VARCHAR (40) NULL,
    [mc_uplift_time]       DATETIME     NULL,
    [mc_uplift_outlet]     INT          NULL,
    [mc_set_down_time]     DATETIME     NULL,
    [mc_set_down_outlet]   INT          NULL,
    [mc_disbanded_date]    DATETIME     NULL,
    [mc_set_down_next_day] VARCHAR (1)  NULL,
    CONSTRAINT [mail_carried_cns] PRIMARY KEY CLUSTERED ([sf_key] ASC, [contract_no] ASC, [mc_sequence_no] ASC, [rf_delivery_days] ASC),
    CONSTRAINT [FK_outlet1] FOREIGN KEY ([mc_uplift_outlet]) REFERENCES [rd].[outlet] ([outlet_id]),
    CONSTRAINT [FK_route_frequency] FOREIGN KEY ([contract_no], [sf_key], [rf_delivery_days]) REFERENCES [rd].[route_frequency] ([contract_no], [sf_key], [rf_delivery_days]),
    CONSTRAINT [fk_set_down] FOREIGN KEY ([mc_set_down_outlet]) REFERENCES [rd].[outlet] ([outlet_id])
);

