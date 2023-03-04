CREATE TABLE [rd].[outlet_type] (
    [ot_code]        INT          IDENTITY (1, 1) NOT NULL,
    [ot_outlet_type] VARCHAR (30) NULL,
    CONSTRAINT [outlet_type(primary key)] PRIMARY KEY CLUSTERED ([ot_code] ASC)
);

