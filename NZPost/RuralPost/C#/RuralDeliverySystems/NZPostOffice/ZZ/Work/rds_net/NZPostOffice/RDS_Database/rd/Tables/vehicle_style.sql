CREATE TABLE [rd].[vehicle_style] (
    [vs_key]         INT          IDENTITY (1, 1) NOT NULL,
    [vs_description] VARCHAR (30) NULL,
    CONSTRAINT [vehicle_style_cns] PRIMARY KEY CLUSTERED ([vs_key] ASC)
);

