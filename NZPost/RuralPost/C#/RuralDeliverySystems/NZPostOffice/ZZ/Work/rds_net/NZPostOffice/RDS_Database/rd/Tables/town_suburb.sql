CREATE TABLE [rd].[town_suburb] (
    [tc_id] INT NOT NULL,
    [sl_id] INT NOT NULL,
    CONSTRAINT [town_suburb_cns] PRIMARY KEY CLUSTERED ([tc_id] ASC, [sl_id] ASC),
    CONSTRAINT [FK_TOWN_SUB_REFERENCE_SUBURBLO] FOREIGN KEY ([sl_id]) REFERENCES [rd].[SuburbLocality] ([sl_id]),
    CONSTRAINT [FK_TOWN_SUB_REFERENCE_TOWNCITY] FOREIGN KEY ([tc_id]) REFERENCES [rd].[TownCity] ([tc_id])
);

