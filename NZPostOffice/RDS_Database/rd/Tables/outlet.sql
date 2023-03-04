CREATE TABLE [rd].[outlet] (
    [outlet_id]             INT           NOT NULL,
    [ot_code]               INT           NULL,
    [region_id]             INT           NULL,
    [o_name]                VARCHAR (40)  NULL,
    [o_address]             VARCHAR (200) NULL,
    [o_telephone]           VARCHAR (11)  NULL,
    [o_fax]                 VARCHAR (11)  NULL,
    [o_manager]             VARCHAR (40)  NULL,
    [o_responsibility_code] VARCHAR (10)  NULL,
    [o_phy_address]         VARCHAR (200) NULL,
    CONSTRAINT [outlet_cns] PRIMARY KEY CLUSTERED ([outlet_id] ASC),
    CONSTRAINT [FK_outlet_type] FOREIGN KEY ([ot_code]) REFERENCES [rd].[outlet_type] ([ot_code]),
    CONSTRAINT [FK_region2] FOREIGN KEY ([region_id]) REFERENCES [rd].[region] ([region_id])
);


GO
CREATE NONCLUSTERED INDEX [ou_region]
    ON [rd].[outlet]([region_id] ASC);

