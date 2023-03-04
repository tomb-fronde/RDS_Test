CREATE TABLE [rd].[route_freq_point_type] (
    [rfpt_id]          INT          IDENTITY (1, 1) NOT NULL,
    [rfpt_description] VARCHAR (40) NULL,
    CONSTRAINT [route_freq_point_type_cns] PRIMARY KEY CLUSTERED ([rfpt_id] ASC)
);

