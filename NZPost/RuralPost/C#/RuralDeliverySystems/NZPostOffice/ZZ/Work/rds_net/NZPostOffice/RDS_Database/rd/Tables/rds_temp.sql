CREATE TABLE [rd].[rds_temp] (
    [rds_id]   INT NOT NULL,
    [rds_code] INT NOT NULL,
    CONSTRAINT [rds_temp_cns] PRIMARY KEY CLUSTERED ([rds_id] ASC, [rds_code] ASC)
);

