CREATE TABLE [rd].[Road] (
    [road_id]           INT          NOT NULL,
    [rt_id]             INT          NULL,
    [road_name]         VARCHAR (50) NULL,
    [unique_road_id]    INT          NULL,
    [rs_id]             INT          NULL,
    [last_amended_date] DATETIME     NULL,
    [last_amended_user] VARCHAR (20) NULL,
    CONSTRAINT [Road_cns] PRIMARY KEY CLUSTERED ([road_id] ASC),
    CONSTRAINT [FK_ROAD_REF_ROAD_SUFFIX] FOREIGN KEY ([rs_id]) REFERENCES [rd].[road_suffix] ([rs_id]),
    CONSTRAINT [FK_ROAD_REFERENCE_ROAD_TYP] FOREIGN KEY ([rt_id]) REFERENCES [rd].[Road_Type] ([rt_id]),
    CONSTRAINT [FK_ROAD_REFERENCE_ROAD_TYP1] FOREIGN KEY ([rt_id]) REFERENCES [rd].[Road_Type] ([rt_id])
);

