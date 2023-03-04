CREATE TABLE [odps].[post_tax_deductions_applied] (
    [pcd_id]     INT             IDENTITY (1, 1) NOT NULL,
    [pcd_amount] NUMERIC (12, 2) NOT NULL,
    [ded_id]     INT             NOT NULL,
    [pcd_date]   DATETIME        NULL,
    [invoice_id] INT             NULL,
    CONSTRAINT [post_tax_deductions_applied_cns] PRIMARY KEY CLUSTERED ([pcd_id] ASC),
    CONSTRAINT [FK_Payment] FOREIGN KEY ([invoice_id]) REFERENCES [odps].[Payment] ([Invoice_ID])
);


GO



CREATE TRIGGER [odps].[t_ptad] ON [odps].[post_tax_deductions_applied]
WITH EXECUTE AS CALLER
FOR INSERT
AS
begin
  update post_tax_deductions set
    ded_end_balance = ded_start_balance-
    isnull((select sum(pcd_amount)*-1 
            from post_tax_deductions_applied 
            where post_tax_deductions_applied.ded_id = post_tax_deductions.ded_id),0) 
  where
    post_tax_deductions.ded_id in (select ded_id from inserted) and ded_start_balance <> 0
end