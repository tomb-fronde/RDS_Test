CREATE TABLE [odps].[t_posttax_deductions_not_applied] (
    [ded_id]                 INT           NOT NULL,
    [contractor_supplier_no] INT           NOT NULL,
    [comments]               VARCHAR (400) NULL,
    [invoice_id]             INT           NULL,
    CONSTRAINT [t_posttax_deductions_not_applied_cns] PRIMARY KEY CLUSTERED ([ded_id] ASC, [contractor_supplier_no] ASC)
);

