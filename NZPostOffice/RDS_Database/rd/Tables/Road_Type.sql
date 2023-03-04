CREATE TABLE [rd].[Road_Type] (
    [rt_id]     INT          IDENTITY (1, 1) NOT NULL,
    [rt_name]   VARCHAR (50) NULL,
    [rt_abbrev] VARCHAR (10) NULL,
    CONSTRAINT [Road_Type_cns] PRIMARY KEY CLUSTERED ([rt_id] ASC)
);

