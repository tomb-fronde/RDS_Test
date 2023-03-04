CREATE TABLE [odps].[payment_component_group] (
    [pcg_id]          INT           NOT NULL,
    [pcg_short_code]  VARCHAR (50)  NOT NULL,
    [pcg_description] VARCHAR (100) NULL,
    CONSTRAINT [payment_component_group_cns] PRIMARY KEY CLUSTERED ([pcg_id] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [pcg_pcgsd]
    ON [odps].[payment_component_group]([pcg_short_code] ASC);

