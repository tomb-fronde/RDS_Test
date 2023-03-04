CREATE TABLE [odps].[t_payment_component_2] (
    [pc_id]        INT              NOT NULL,
    [pct_id]       INT              NOT NULL,
    [invoice_id]   INT              NOT NULL,
    [pc_amount]    NUMERIC (12, 2)  NOT NULL,
    [comments]     VARCHAR (400)    NULL,
    [misc_date]    DATETIME         NULL,
    [misc_string]  VARCHAR (200)    NULL,
    [misc_decimal] NUMERIC (20, 12) NULL,
    [alt_key]      INT              NULL
);

