CREATE TABLE [rd].[rds_component1] (
    [rc_id]          INT           NOT NULL,
    [rc_name]        VARCHAR (50)  NULL,
    [rc_description] VARCHAR (255) NULL,
    [rc_allowcreate] VARCHAR (1)   NULL,
    [rc_allowread]   VARCHAR (1)   NULL,
    [rc_allowmodify] VARCHAR (1)   NULL,
    [rc_allowdelete] VARCHAR (1)   NULL,
    CONSTRAINT [rds_component_cns1] PRIMARY KEY CLUSTERED ([rc_id] ASC)
);

