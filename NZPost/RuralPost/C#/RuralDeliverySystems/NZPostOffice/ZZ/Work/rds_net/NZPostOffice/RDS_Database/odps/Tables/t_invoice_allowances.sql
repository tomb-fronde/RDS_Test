CREATE TABLE [odps].[t_invoice_allowances] (
    [contract_no]     INT             NOT NULL,
    [invoice_id]      INT             NOT NULL,
    [alt_key]         INT             NOT NULL,
    [alt_description] VARCHAR (40)    NULL,
    [amount]          NUMERIC (12, 2) NULL
);

