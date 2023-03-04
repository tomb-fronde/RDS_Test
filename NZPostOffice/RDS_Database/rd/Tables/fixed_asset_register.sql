CREATE TABLE [rd].[fixed_asset_register] (
    [fa_fixed_asset_no] VARCHAR (10)    NOT NULL,
    [fat_id]            INT             NULL,
    [fa_owner]          VARCHAR (40)    NULL,
    [fa_purchase_date]  DATETIME        NULL,
    [fa_purchase_price] NUMERIC (10, 2) NULL,
    CONSTRAINT [fixed_asset_register_cns] PRIMARY KEY CLUSTERED ([fa_fixed_asset_no] ASC),
    CONSTRAINT [FK_fixed_asset_type] FOREIGN KEY ([fat_id]) REFERENCES [rd].[fixed_asset_type] ([fat_id])
);

