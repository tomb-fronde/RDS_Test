CREATE TABLE [rd].[contract_fixed_assets] (
    [contract_no]       INT          NOT NULL,
    [fa_fixed_asset_no] VARCHAR (10) NOT NULL,
    [sh_id]             INT          NULL,
    CONSTRAINT [contract_fixed_assets_cns] PRIMARY KEY CLUSTERED ([contract_no] ASC, [fa_fixed_asset_no] ASC),
    CONSTRAINT [FK_contract1] FOREIGN KEY ([contract_no]) REFERENCES [rd].[contract] ([contract_no]),
    CONSTRAINT [FK_fixed_asset_no] FOREIGN KEY ([fa_fixed_asset_no]) REFERENCES [rd].[fixed_asset_register] ([fa_fixed_asset_no])
);

