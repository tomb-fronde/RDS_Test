CREATE TABLE [odps].[post_tax_deductions] (
    [ded_id]                    INT             IDENTITY (1, 1) NOT NULL,
    [ded_description]           VARCHAR (200)   NULL,
    [ded_priority]              SMALLINT        NULL,
    [pct_id]                    INT             NULL,
    [ded_reference]             VARCHAR (200)   NULL,
    [ded_type_period]           VARCHAR (1)     NULL,
    [ded_percent_gross]         NUMERIC (5, 2)  NULL,
    [ded_percent_net]           NUMERIC (5, 2)  NULL,
    [ded_percent_start_balance] NUMERIC (5, 2)  NULL,
    [ded_fixed_amount]          NUMERIC (12, 2) NULL,
    [ded_min_threshold_gross]   NUMERIC (12, 2) NULL,
    [ded_max_threshold_net_pct] NUMERIC (5, 2)  NULL,
    [ded_default_minimum]       NUMERIC (12, 2) NULL,
    [ded_start_balance]         NUMERIC (12, 2) NULL,
    [ded_end_balance]           NUMERIC (12, 2) NULL,
    [contractor_supplier_no]    INT             NULL,
    [ded_pay_highest_value]     SMALLINT        NULL,
    CONSTRAINT [post_tax_deductions_cns] PRIMARY KEY CLUSTERED ([ded_id] ASC),
    CONSTRAINT [fk_balance_contractor] FOREIGN KEY ([contractor_supplier_no]) REFERENCES [rd].[contractor] ([contractor_supplier_no]),
    CONSTRAINT [FK_POST_TAX_REF_13920_PAYMENT_] FOREIGN KEY ([pct_id]) REFERENCES [odps].[Payment_Component_Type] ([pct_id])
);


GO
CREATE NONCLUSTERED INDEX [pt_contractor]
    ON [odps].[post_tax_deductions]([contractor_supplier_no] ASC);


GO


CREATE TRIGGER [odps].[t_pta_u] ON [odps].[post_tax_deductions]
WITH EXECUTE AS CALLER
FOR UPDATE
AS
begin
	declare @old_ded_end_balance decimal(12,2),@new_ded_id int,@new_ded_start_balance decimal(12,2)
	select @old_ded_end_balance = ded_end_balance from deleted
    select @new_ded_start_balance=ded_start_balance from inserted
    select @new_ded_id = ded_id from inserted

    if @new_ded_start_balance <> @old_ded_end_balance
    update post_tax_deductions set
      ded_end_balance = ded_start_balance+
      isnull((select sum(pcd_amount) from post_tax_deductions_applied where post_tax_deductions_applied.ded_id = post_tax_deductions.ded_id),0) 
    where
      post_tax_deductions.ded_id = @new_ded_id
end
GO







CREATE TRIGGER [odps].[t_pta_i] ON [odps].[post_tax_deductions]
WITH EXECUTE AS CALLER
FOR INSERT
AS
begin
  update post_tax_deductions set ded_end_balance= ded_start_balance --(select ded_start_balance from inserted) 
  where ded_id=(select max(ded_id) from odps.post_tax_deductions)
end