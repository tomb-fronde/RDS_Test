CREATE TABLE [rd].[ca_load_results] (
    [rows_inserted]   INT             NULL,
    [rows_skipped]    INT             NULL,
    [row_errors]      INT             NULL,
    [amount_inserted] NUMERIC (10, 2) NULL,
    [load_name]       VARCHAR (20)    NULL,
    [load_date]       DATETIME        NULL
);

