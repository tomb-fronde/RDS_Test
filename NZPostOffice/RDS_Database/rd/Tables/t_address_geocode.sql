CREATE TABLE [rd].[t_address_geocode] (
    [adr_id]             INT            NOT NULL,
    [external_system_id] INT            NOT NULL,
    [geocode_x]          DECIMAL (8, 2) NOT NULL,
    [geocode_y]          DECIMAL (8, 2) NOT NULL
);

