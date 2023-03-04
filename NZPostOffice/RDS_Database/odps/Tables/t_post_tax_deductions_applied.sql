CREATE TABLE [odps].[t_post_tax_deductions_applied] (
    [pcd_id]     INT             IDENTITY (1, 1) NOT NULL,
    [pcd_amount] NUMERIC (12, 2) NOT NULL,
    [ded_id]     INT             NOT NULL,
    [pcd_date]   DATETIME        NULL,
    [invoice_id] INT             NULL,
    CONSTRAINT [t_post_tax_deductions_applied_cns] PRIMARY KEY CLUSTERED ([pcd_id] ASC)
);

