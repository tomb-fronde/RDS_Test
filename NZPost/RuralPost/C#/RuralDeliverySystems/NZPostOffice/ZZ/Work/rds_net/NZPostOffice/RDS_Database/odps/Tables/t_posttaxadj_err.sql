CREATE TABLE [odps].[t_posttaxadj_err] (
    [run_date]       DATETIME        NOT NULL,
    [contractor_no]  INT             NOT NULL,
    [invoice_id]     INT             NOT NULL,
    [pct_ded_id]     INT             NOT NULL,
    [pc_amount]      NUMERIC (12, 2) NULL,
    [instance_no]    INT             NOT NULL,
    [comment_length] INT             NOT NULL,
    [comment]        VARCHAR (400)   NOT NULL
);

