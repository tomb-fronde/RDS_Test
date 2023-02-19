CREATE TABLE [odps].[t_payment_runs_2] (
    [pr_id]          INT          NOT NULL,
    [pr_date]        INT          NOT NULL,
    [gl_posted]      VARCHAR (1)  NULL,
    [pr_ap_posted]   VARCHAR (1)  NULL,
    [pr_contract_no] INT          NULL,
    [POTS]           VARCHAR (50) NULL
);

