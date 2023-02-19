CREATE TABLE [rd].[TownCity] (
    [tc_id]     INT          IDENTITY (1, 1) NOT NULL,
    [region_id] INT          NOT NULL,
    [tc_name]   VARCHAR (50) NULL,
    CONSTRAINT [TownCity_cns] PRIMARY KEY CLUSTERED ([tc_id] ASC),
    CONSTRAINT [FK_TOWNCITY_REF_609_REGION] FOREIGN KEY ([region_id]) REFERENCES [rd].[region] ([region_id])
);

