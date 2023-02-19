CREATE TABLE [odps].[t_invoice_piecerates] (
    [invoice_id]   INT             NOT NULL,
    [atype]        VARCHAR (40)    NULL,
    [prd_date]     DATETIME        NOT NULL,
    [prt_code]     VARCHAR (4)     NULL,
    [prd_quantity] INT             NOT NULL,
    [rate]         NUMERIC (12, 5) NULL,
    [cost]         NUMERIC (12, 2) NULL,
    [rownum]       INT             NULL,
    [prs_key]      INT             NULL
);

