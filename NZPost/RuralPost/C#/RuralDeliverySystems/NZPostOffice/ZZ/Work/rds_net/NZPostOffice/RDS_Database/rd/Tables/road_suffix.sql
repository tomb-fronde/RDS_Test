CREATE TABLE [rd].[road_suffix] (
    [rs_id]     INT          NOT NULL,
    [rs_name]   VARCHAR (20) NULL,
    [rs_abbrev] VARCHAR (10) NULL,
    CONSTRAINT [road_suffix_cns] PRIMARY KEY CLUSTERED ([rs_id] ASC)
);

