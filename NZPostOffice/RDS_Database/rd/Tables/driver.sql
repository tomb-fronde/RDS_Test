CREATE TABLE [rd].[driver] (
    [driver_no]     INT           NOT NULL,
    [d_title]       VARCHAR (10)  NULL,
    [d_surname]     VARCHAR (50)  NULL,
    [d_first_names] VARCHAR (40)  NULL,
    [d_phone_day]   VARCHAR (15)  NULL,
    [d_phone_night] VARCHAR (15)  NULL,
    [d_mobile]      VARCHAR (15)  NULL,
    [d_mobile2]     VARCHAR (15)  NULL,
    [d_notes]       VARCHAR (200) NULL,
    CONSTRAINT [PK_driver] PRIMARY KEY CLUSTERED ([driver_no] ASC)
);

