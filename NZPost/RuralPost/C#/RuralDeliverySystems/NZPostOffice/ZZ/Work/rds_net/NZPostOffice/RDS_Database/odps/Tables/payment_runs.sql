CREATE TABLE [odps].[payment_runs] (
    [pr_id]          INT          NOT NULL,
    [pr_date]        INT          NOT NULL,
    [gl_posted]      VARCHAR (1)  NULL,
    [pr_ap_posted]   VARCHAR (1)  NULL,
    [pr_contract_no] INT          NULL,
    [POTS]           VARCHAR (50) CONSTRAINT [DF__payment_ru__POTS__1940BAED] DEFAULT ('N') NULL,
    CONSTRAINT [payment_runs_cns] PRIMARY KEY CLUSTERED ([pr_id] ASC)
);


GO
CREATE NONCLUSTERED INDEX [pr_prdate]
    ON [odps].[payment_runs]([pr_date] ASC);

