CREATE TABLE [odps].[t_telecom_import] (
    [bill_month]   VARCHAR (10)    NULL,
    [bill_cycle]   INT             NULL,
    [customer_no]  INT             NULL,
    [account_no]   INT             NULL,
    [account_name] VARCHAR (16)    NULL,
    [open_bal]     NUMERIC (10, 2) NULL,
    [payments]     NUMERIC (10, 2) NULL,
    [adj_tran]     NUMERIC (10, 2) NULL,
    [bal_bf]       NUMERIC (10, 2) NULL,
    [curr_chg]     NUMERIC (10, 2) NULL,
    [total_due]    NUMERIC (10, 2) NULL,
    [supplier_no]  INT             NULL,
    [contract_no]  INT             NULL
);

