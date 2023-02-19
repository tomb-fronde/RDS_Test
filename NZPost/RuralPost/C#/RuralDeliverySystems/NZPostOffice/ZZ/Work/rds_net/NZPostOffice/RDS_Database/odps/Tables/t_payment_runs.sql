CREATE TABLE [odps].[t_payment_runs] (
    [pr_id]          INT          IDENTITY (1, 1) NOT NULL,
    [pr_date]        INT          NOT NULL,
    [gl_posted]      VARCHAR (1)  NULL,
    [pr_ap_posted]   VARCHAR (1)  NULL,
    [pr_contract_no] INT          NULL,
    [POTS]           VARCHAR (50) CONSTRAINT [DF__t_payment___POTS__405A880E] DEFAULT ('N') NULL,
    CONSTRAINT [t_payment_runs_cns] PRIMARY KEY CLUSTERED ([pr_id] ASC)
);

