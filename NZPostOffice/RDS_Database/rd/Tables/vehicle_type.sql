CREATE TABLE [rd].[vehicle_type] (
    [vt_key]         INT          IDENTITY (1, 1) NOT NULL,
    [vt_description] VARCHAR (30) NULL,
    CONSTRAINT [vehicle_type_cns] PRIMARY KEY CLUSTERED ([vt_key] ASC)
);

