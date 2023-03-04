CREATE TABLE [rd].[route_freq_verbs] (
    [rfv_id]          INT          IDENTITY (1, 1) NOT NULL,
    [rfv_description] VARCHAR (40) NULL,
    CONSTRAINT [route_freq_verbs_cns] PRIMARY KEY CLUSTERED ([rfv_id] ASC)
);

