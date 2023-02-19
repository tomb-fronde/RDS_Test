CREATE TABLE [rd].[rds_user] (
    [u_id]       INT           NOT NULL,
    [u_name]     VARCHAR (50)  NULL,
    [u_location] VARCHAR (255) NULL,
    [u_email]    VARCHAR (50)  NULL,
    [u_mobile]   VARCHAR (25)  NULL,
    [region_id]  INT           NULL,
    CONSTRAINT [rds_user_cns] PRIMARY KEY CLUSTERED ([u_id] ASC)
);

