CREATE TABLE [rd].[town_road] (
    [tc_id]   INT NOT NULL,
    [road_id] INT NOT NULL,
    CONSTRAINT [town_road_cns] PRIMARY KEY CLUSTERED ([tc_id] ASC, [road_id] ASC),
    CONSTRAINT [FK_TOWN_ROA_REFERENCE_ROAD] FOREIGN KEY ([road_id]) REFERENCES [rd].[Road] ([road_id]),
    CONSTRAINT [FK_TOWN_ROA_REFERENCE_TOWNCITY] FOREIGN KEY ([tc_id]) REFERENCES [rd].[TownCity] ([tc_id])
);

