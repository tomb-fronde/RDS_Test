CREATE TABLE [rd].[private_bags] (
    [pvt_date]      DATETIME DEFAULT (getdate()) NOT NULL,
    [pvt_bag_count] INT      NOT NULL,
    [pvt_frequency] INT      NOT NULL,
    [region_id]     INT      NULL,
    CONSTRAINT [private_bags_cns] PRIMARY KEY CLUSTERED ([pvt_date] ASC, [pvt_frequency] ASC)
);

