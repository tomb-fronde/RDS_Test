CREATE TABLE [rd].[fixed_asset_type] (
    [fat_id]          INT          IDENTITY (1, 1) NOT NULL,
    [fat_description] VARCHAR (40) NULL,
    CONSTRAINT [fixed_asset_type_cns] PRIMARY KEY CLUSTERED ([fat_id] ASC)
);

