CREATE TABLE [rd].[address_geocode] (
    [adr_id]             INT             NOT NULL,
    [external_system_id] INT             DEFAULT ((1)) NULL,
    [geocode_x]          NUMERIC (10, 2) NOT NULL,
    [geocode_y]          NUMERIC (10, 2) NOT NULL,
    CONSTRAINT [address_geocode_cns] PRIMARY KEY CLUSTERED ([adr_id] ASC),
    CONSTRAINT [FK_ADDRESS__REF_585_ADDRESS] FOREIGN KEY ([adr_id]) REFERENCES [rd].[address] ([adr_id]) ON DELETE CASCADE
);

