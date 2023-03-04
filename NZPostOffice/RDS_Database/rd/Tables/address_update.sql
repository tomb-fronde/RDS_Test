CREATE TABLE [rd].[address_update] (
    [npad_dp_id]       INT             NULL,
    [npad_road_id]     INT             NULL,
    [npad_mailtown_id] INT             NULL,
    [mail_town_name]   CHAR (50)       NULL,
    [rd_number]        CHAR (5)        NULL,
    [postcode]         CHAR (4)        NULL,
    [geocode_quality]  INT             NULL,
    [x_coord]          NUMERIC (10, 2) NULL,
    [y_coord]          NUMERIC (10, 2) NULL,
    [rds_adr_id]       INT             NULL
);

