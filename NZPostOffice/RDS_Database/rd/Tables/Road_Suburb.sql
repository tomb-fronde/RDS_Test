CREATE TABLE [rd].[Road_Suburb] (
    [sl_id]   INT NOT NULL,
    [road_id] INT NOT NULL,
    CONSTRAINT [Road_Suburb_cns] PRIMARY KEY CLUSTERED ([sl_id] ASC, [road_id] ASC),
    CONSTRAINT [FK_ROAD_SUB_REF_600_SUBURBLO] FOREIGN KEY ([sl_id]) REFERENCES [rd].[SuburbLocality] ([sl_id]),
    CONSTRAINT [FK_ROAD_SUB_REF_606_ROAD] FOREIGN KEY ([road_id]) REFERENCES [rd].[Road] ([road_id])
);

